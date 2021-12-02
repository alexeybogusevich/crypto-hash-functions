using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KNU.Crypto.HashFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            using var sha256 = new SHA256C.SHA256C();
            RunPOW(sha256);
        }

        private static int ProofOfWork(HashAlgorithm hashAlgorithm, int substringSize = 1)
        {
            int i = 0;
            var random = new Random();
            var previuosAttempts = new HashSet<string>();
            var b = new byte[256];

            while (true)
            {
                random.NextBytes(b);

                var hash = hashAlgorithm.ComputeHash(b);
                var hexHash = GetHexString(hash);

                var sub = hexHash[..substringSize];

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

        private static void RunPOW(HashAlgorithm hashAlgorithm, int maxIter = 6)
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

                Console.WriteLine($"Substring size:\t{i}");
                Console.WriteLine($"Average time:\t{runTimes.Average()} ms.");
                Console.WriteLine($"Average iterations:\t{iterations.Average()}\n");
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
    }
}
