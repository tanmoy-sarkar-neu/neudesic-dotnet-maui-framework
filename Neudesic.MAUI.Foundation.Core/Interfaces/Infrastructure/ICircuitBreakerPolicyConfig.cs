using System;
using System.Collections.Generic;
using System.Text;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure
{
    public interface ICircuitBreakerPolicyConfig
    {
        int RetryCount { get; }
        int BreakDuration { get; }
    }
}