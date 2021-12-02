using CryptoHash.Kupyna;
using CryptoHash.SHA256C;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoHash
{
    class Program
    {
        private static int ProofOfWork(HashAlgorithm hashAlgorithm, int substringSize = 1)
        {
            int i = 0;
            Random rnd = new Random();
            ISet<string> previuosAttempts = new HashSet<string>();
            byte[] b = new byte[256];

            while (true)
            {
                rnd.NextBytes(b);
                var hash = GetHexString(hashAlgorithm.ComputeHash(b));
                var sub = hash.Substring(0, substringSize);

                if (previuosAttempts.Contains(sub))
                {
                    return i;
                }
                else
                {
                    previuosAttempts.Add(sub);
                }

                i++;
            }
        }

        private static string GetHexString(byte[] data)
        {
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static void RunPOF(HashAlgorithm hashAlgorithm, int maxIter = 6)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine($"\n**{hashAlgorithm.GetType()} -- {hashAlgorithm.HashSize}**\n");
            Console.WriteLine("");

            var runTimes = new LinkedList<long>();
            var iterations = new LinkedList<int>();
            Console.WriteLine("Substring size | Average time | Average iterations");
            Console.WriteLine("---|---|---");

            for (int i = 1; i <= maxIter; i++)
            {
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    sw.Restart();
                    iterations.AddLast(ProofOfWork(hashAlgorithm, i));
                    sw.Stop();
                    runTimes.AddLast(sw.ElapsedMilliseconds);
                }

                /*Console.WriteLine($"Substring size:\t{i}");
                Console.WriteLine($"Average time:\t{runTimes.Average()} ms.");
                Console.WriteLine($"Average iterations:\t{iterations.Average()}");*/
                Console.WriteLine($"{i}  |  {Math.Round(runTimes.Average(),3)} ms.  |  {Math.Round(iterations.Average(),1)}  ");
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
    }
}
