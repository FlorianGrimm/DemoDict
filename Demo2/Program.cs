using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Demo2 {
    public class Program {
        private static List<string>? _Data;
        public static void Main(string[] args) {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }

        public static List<string> getData() {
            return _Data ??= System.IO.Directory.EnumerateFileSystemEntries("C:\\temp", "*.*", System.IO.SearchOption.AllDirectories).ToList();
        }
    }

    public class Benchmarks{
        private readonly List<string> data;

        const int loops = 100;

        public Benchmarks() {
            this.data = Program.getData();
        }

        [Benchmark]
        public void Test1() {
            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d0));
                    if (act != i0) { throw new Exception("0"); }
                }
                {
                    var act = data.FindIndex((v) => (v == d1));
                    if (act != i1) { throw new Exception("1"); }
                }
                {
                    var act = data.FindIndex((v) => (v == d2));
                    if (act != i2) { throw new Exception("2"); }
                }
            }
        }

        [Benchmark]
        public void Test1a() {
            var i0 = 1;

            var d0 = data[i0];

            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d0));
                    if (act != i0) { throw new Exception("0"); }
                }
            }
        }


        [Benchmark]
        public void Test1b() {
            var i1 = data.Count / 2;

            var d1 = data[i1];

            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d1));
                    if (act != i1) { throw new Exception("1"); }
                }
            }
        }


        [Benchmark]
        public void Test1c() {
            var i2 = data.Count - 1;

            var d2 = data[i2];

            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d2));
                    if (act != i2) { throw new Exception("2"); }
                }
            }
        }


        [Benchmark]
        public void Test2() {

            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            for (int loop = 0; loop < loops; loop++) {
                {
                    var dict = new Dictionary<string, string>();
                    foreach (var item in data) {
                        dict.Add(item, item);
                    }
                    if (!dict.TryGetValue(d0, out var _)) {
                        throw new Exception("0");
                    }
                    if (!dict.TryGetValue(d1, out var _)) {
                        throw new Exception("1");
                    }
                    if (!dict.TryGetValue(d2, out var _)) {
                        throw new Exception("2");
                    }
                }
            }
        }

        [Benchmark]
        public void Test3() {

            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            var dict = new Dictionary<string, string>();
            foreach (var item in data) {
                dict.Add(item, item);
            }
            for (int loop = 0; loop < loops; loop++) {
                {
                    if (!dict.TryGetValue(d0, out var _)) {
                        throw new Exception("0");
                    }
                    if (!dict.TryGetValue(d1, out var _)) {
                        throw new Exception("1");
                    }
                    if (!dict.TryGetValue(d2, out var _)) {
                        throw new Exception("2");
                    }
                }
            }
        }
    }
}
