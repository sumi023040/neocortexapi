﻿// Copyright (c) Damir Dobric. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using AkkaSb.Net;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoCortexApi;
using NeoCortexApi.DistributedComputeLib;
using NeoCortexApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestsProject
{
    [TestClass]
    public class ThreadSafeRandomTests
    {
        [TestMethod]
        [TestCategory("Invariant Learning")]
        public void RandomTestRun()
        {
            Random a = new ThreadSafeRandom(42);
            Random b = new ThreadSafeRandom(42);
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine($"a is {a.NextDouble()}");
                Debug.WriteLine($"b is {a.NextDouble()}");
                Debug.WriteLine($"are equal: {((a == b) ? "yes" : "no")}");
                Debug.WriteLine("");
            }
        }
    }
}