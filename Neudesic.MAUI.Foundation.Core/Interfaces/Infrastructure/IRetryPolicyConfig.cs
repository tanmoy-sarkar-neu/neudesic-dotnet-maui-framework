using System;
using System.Collections.Generic;
using System.Text;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure
{
    public interface IRetryPolicyConfig
    {
        int RetryCount { get; }
    }
}