// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto.Tls;

namespace LettuceEncrypt.Internal;

internal class X509CertStore : ICertificateSource, ICertificateRepository, IDisposable
{
    private readonly X509Store _store;
    private readonly IOptions<LettuceEncryptOptions> _options;
    private readonly ILogger<X509CertStore> _logger;

    public bool AllowInvalidCerts { get; set; }

    public X509CertStore(IOptions<LettuceEncryptOptions> options, ILogger<X509CertStore> logger)
    {
        logger.LogDebug("-> X509CertStore::X509CertStore");
        _store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        _store.Open(OpenFlags.ReadWrite);
        _options = options;
        _logger = logger;
        logger.LogDebug("<- X509CertStore::X509CertStore");
    }

    public Task<IEnumerable<X509Certificate2>> GetCertificatesAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("-> X509CertStore::GetCertificatesAsync");
        var domainNames = new HashSet<string>(_options.Value.DomainNames);
        var result = new List<X509Certificate2>();
        var certs = _store.Certificates.Find(X509FindType.FindByTimeValid,
            DateTime.Now,
            validOnly: !AllowInvalidCerts);

        foreach (var cert in certs)
        {
            if (!cert.HasPrivateKey)
            {
                _logger.LogDebug("X509CertStore::cert: " + cert.FriendlyName + " does not have private key");
                continue;
            }

            foreach (var dnsName in X509CertificateHelpers.GetAllDnsNames(cert))
            {
                _logger.LogDebug("X509CertStore::dnsName: " + dnsName);
                if (domainNames.Contains(dnsName))
                {
                    _logger.LogDebug("X509CertStore::dnsName: " + dnsName + " is in domainNames");  
                    result.Add(cert);
                    break;
                }
            }
        }

        _logger.LogDebug("<- X509CertStore::GetCertificatesAsync");
        return Task.FromResult(result.AsEnumerable());
    }

    public Task SaveAsync(X509Certificate2 certificate, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"-> X509CertStore::SaveAsync {certificate.FriendlyName}");
        try
        {
            _store.Add(certificate);
        }
        catch (Exception ex)
        {
            _logger.LogError(0, ex, "Failed to save certificate to store");
            throw;
        }

        _logger.LogDebug($"<- X509CertStore::SaveAsync {certificate.FriendlyName}");
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _logger.LogDebug($"-> X509CertStore::Close");
        _store.Close();
        _logger.LogDebug($"<- X509CertStore::Close");
    }
}
