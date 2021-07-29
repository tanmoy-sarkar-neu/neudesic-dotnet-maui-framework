using Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public class PolicyConfig : ICircuitBreakerPolicyConfig, IRetryPolicyConfig
    {
        public int RetryCount { get; }
        public int BreakDuration { get; }

        public PolicyConfig(int maxRetryCount, int breakDuration = 0)
        {
            RetryCount = maxRetryCount;
            BreakDuration = breakDuration;
        }
    }
}