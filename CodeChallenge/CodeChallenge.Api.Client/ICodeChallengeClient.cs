using System;
using CodeChallenge.Api.Client.Resource;

namespace CodeChallenge.Api.Client
{
    public interface ICodeChallengeClient :IDisposable
    {
        IBeaconResource BeaconResource { get; }
    }
}