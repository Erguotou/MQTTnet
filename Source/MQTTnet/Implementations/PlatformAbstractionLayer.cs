﻿using System;
using System.Threading.Tasks;

namespace MQTTnet.Implementations
{
    public static class PlatformAbstractionLayer
    {
#if NET452
        public static Task CompletedTask => Task.FromResult(0);
#else
        public static Task CompletedTask => Task.CompletedTask;
#endif

        public static void Sleep(TimeSpan timeout)
        {
#if NET452 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1
            System.Threading.Thread.Sleep(timeout);
#else
            Task.Delay(timeout).Wait();
#endif
        }
    }
}
