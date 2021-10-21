using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1 {
    class Program {
        static int loops = 1;
        static void Main(string[] args) {
            loops = 10000;
            var data = System.IO.Directory.EnumerateFileSystemEntries("C:\\temp", "*.*", System.IO.SearchOption.AllDirectories).ToList();
            System.Console.WriteLine($"#{data.Count} items; loops:{loops }");

            Test1(data);
            Test1a(data);
            Test1b(data);
            Test1c(data);
            Test2(data);
            Test3(data);
            System.Console.WriteLine("");
            System.Console.WriteLine("");

            loops = 1000000;
            data = data.Take(4).ToList();
            System.Console.WriteLine($"#{data.Count} items; loops:{loops }");

            Test1(data);
            Test1a(data);
            Test1b(data);
            Test1c(data);
            Test2(data);
            Test3(data);
        }

        private static void Test1(List<string> data) {

            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            var dtStart = System.DateTime.UtcNow;
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

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test1 {tms}ms {d}ticks/1");
        }

        private static void Test1a(List<string> data) {
            var i0 = 1;

            var d0 = data[i0];

            var dtStart = System.DateTime.UtcNow;
            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d0));
                    if (act != i0) { throw new Exception("0"); }
                }
            }

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test1a {tms}ms {d}ticks/1");
        }

        private static void Test1b(List<string> data) {
            var i1 = data.Count / 2;

            var d1 = data[i1];

            var dtStart = System.DateTime.UtcNow;
            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d1));
                    if (act != i1) { throw new Exception("1"); }
                }
            }

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test1b {tms}ms {d}ticks/1");
        }

        private static void Test1c(List<string> data) {

            var i2 = data.Count - 1;

            var d2 = data[i2];

            var dtStart = System.DateTime.UtcNow;
            for (int loop = 0; loop < loops; loop++) {
                {
                    var act = data.FindIndex((v) => (v == d2));
                    if (act != i2) { throw new Exception("2"); }
                }
            }

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test1c {tms}ms {d}ticks/1");
        }

        private static void Test2(List<string> data) {

            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            var dtStart = System.DateTime.UtcNow;
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

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test2 {tms}ms {d}ticks/1");
        }


        private static void Test3(List<string> data) {

            var i0 = 1;
            var i1 = data.Count / 2;
            var i2 = data.Count - 1;

            var d0 = data[i0];
            var d1 = data[i1];
            var d2 = data[i2];

            var dtStart = System.DateTime.UtcNow;

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

            var dtStop = System.DateTime.UtcNow;
            var d = ((double)(dtStop - dtStart).Ticks) / ((double)loops);
            var tms = (dtStop - dtStart).TotalMilliseconds;
            System.Console.WriteLine($"Test3 {tms}ms {d}ticks/1");
        }
    }
}
