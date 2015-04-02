namespace CodeChallenge.Api.Client
{
    public interface ICodeChallengeClientFactory
    {
        ICodeChallengeClient Create(string apiUri);
    }
}