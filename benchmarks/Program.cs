using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;

namespace IsQualifiedName
{

    class Program
    {
        static void Main(string[] args)
        {
            // //////////////////////////////////

            // foreach (var test in TestData)
            // {
            //     for (int i = 0; i < 100; i++)
            //     {
            //         var result = Validator.IsQualifiedNameCustomScanner(test);
            //     }
            // }

            // //////////////////////////////////

            var summary = BenchmarkRunner.Run(typeof(Benchmarks).Assembly);
        }

        static string[] TestData = new[] { "aaaa.bbbb", "aaaa.", ".aaaa", "a. b1bbb", "a. .b", "a.b.c.d.e.f" };
    }
}