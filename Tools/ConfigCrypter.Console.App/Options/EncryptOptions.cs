using CommandLine;

namespace ThePlaceToMeet.ConfigCrypter.Console.Options
{
    [Verb("encrypt", HelpText = "Encrypts a key in the config file.")]
    public class EncryptOptions : CommandlineOptions { }
}
