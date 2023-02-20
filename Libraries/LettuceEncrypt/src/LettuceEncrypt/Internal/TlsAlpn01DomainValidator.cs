// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Certes.Acme;
using Certes.Acme.Resource;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LettuceEncrypt.Internal;

internal class TlsAlpn01DomainValidator : DomainOwnershipValidator
{
    private readonly TlsAlpnChallengeResponder _tlsAlpnChallengeResponder;

    public TlsAlpn01DomainValidator(TlsAlpnChallengeResponder tlsAlpnChallengeResponder,
        IHostApplicationLifetime appLifetime,
        AcmeClient client, ILogger logger, string domainName) : base(appLifetime, client, logger, domainName)
    {
        logger.LogDebug("-> TlsAlpn01DomainValidator::TlsAlpn01DomainValidator");
        _tlsAlpnChallengeResponder = tlsAlpnChallengeResponder;
        logger.LogDebug("<- TlsAlpn01DomainValidator::TlsAlpn01DomainValidator");
    }

    public override async Task ValidateOwnershipAsync(IAuthorizationContext authzContext, CancellationToken cancellationToken)
    {
        _logger.LogDebug("-> TlsAlpn01DomainValidator::ValidateOwnershipAsync");
        try
        {
            await PrepareTlsAlpnChallengeResponseAsync(authzContext, _domainName, cancellationToken);
            await WaitForChallengeResultAsync(authzContext, cancellationToken);
        }
        finally
        {
            // cleanup after authorization is done to skip unnecessary cert lookup on all incoming SSL connections
            _tlsAlpnChallengeResponder.DiscardChallenge(_domainName);
        }
        _logger.LogDebug("<- TlsAlpn01DomainValidator::ValidateOwnershipAsync");
    }

    private async Task PrepareTlsAlpnChallengeResponseAsync(
        IAuthorizationContext authorizationContext,
        string domainName,
        CancellationToken cancellationToken)
    {
        _logger.LogDebug("-> TlsAlpn01DomainValidator::PrepareTlsAlpnChallengeResponseAsync");
        cancellationToken.ThrowIfCancellationRequested();

        var tlsAlpnChallenge = await _client.CreateChallengeAsync(authorizationContext, ChallengeTypes.TlsAlpn01);

        _tlsAlpnChallengeResponder.PrepareChallengeCert(domainName, tlsAlpnChallenge.KeyAuthz);

        _logger.LogTrace("Waiting for server to start accepting HTTP requests");
        await _appStarted.Task;

        _logger.LogTrace("Requesting server to validate TLS/ALPN challenge");
        await _client.ValidateChallengeAsync(tlsAlpnChallenge);
        _logger.LogDebug("<- TlsAlpn01DomainValidator::PrepareTlsAlpnChallengeResponseAsync");
    }
}
