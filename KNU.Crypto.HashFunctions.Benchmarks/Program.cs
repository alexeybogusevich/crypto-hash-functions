using KNU.Crypto.HashFunctions.Kupyna;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace KNU.Crypto.HashFunctions.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var sha256 = new SHA256C.SHA256C())
            {
                RunBenchmark(sha256);
            }

            using (var sha256 = SHA256.Create())
            {
                RunBenchmark(sha256);
            }

            using (var kupyna = new KupynaHash(256))
            {
                RunBenchmark(kupyna);
            }

            using (var kupyna = new KupynaHash(304))
            {
                RunBenchmark(kupyna);
            }

            using (var kupyna = new KupynaHash(384))
            {
                RunBenchmark(kupyna);
            }

            using (var kupyna = new KupynaHash(512))
            {
                RunBenchmark(kupyna);
            }
        }
        private static void RunBenchmark(HashAlgorithm hashAlgorithm)
        {
            Stopwatch sw = new Stopwatch();

            Random rnd = new Random();
            var b = new byte[12048];

            rnd.NextBytes(b);
            sw.Start();
            var hash = hashAlgorithm.ComputeHash(b);
            sw.Stop();

            Console.WriteLine($"{hashAlgorithm.GetType()}({hashAlgorithm.HashSize}) | {sw.ElapsedMilliseconds} ms.");
        }
    }
}
