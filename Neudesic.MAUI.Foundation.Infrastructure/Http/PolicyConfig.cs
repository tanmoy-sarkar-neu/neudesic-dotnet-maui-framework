namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public interface ICircuitBreakerPolicyConfig
    {
        int RetryCount { get; }
        int BreakDuration { get; }
    }

    public interface IRetryPolicyConfig
    {
        int RetryCount { get; }
    }

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
