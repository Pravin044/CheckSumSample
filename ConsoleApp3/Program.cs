using System;
using System.IO;
using System.Security.Cryptography;
namespace CheckSumSample
{
    class CheckSumExample
    {
        static void Main(string[] args)
        {

            byte[] checkSum1;
            byte[] checkSum2;
            using (Stream fs = File.OpenRead("myfile.txt"))
            {
                checkSum1 = MD5.Create().ComputeHash(fs);
                foreach (var item in checkSum1)
                {
                    Console.WriteLine(string.Format("Check sum 1 values:{0}", item));
                }
            }
            using (Stream fd = File.OpenRead("newfile\\myfile.txt"))
            {
                checkSum2 = MD5.Create().ComputeHash(fd);

                foreach (var item in checkSum2)
                {
                    Console.WriteLine(string.Format("Check sum 2 values:{0}", item));
                }

            }
            
            if (Equals(checkSum1, checkSum2))
            {
                Console.WriteLine("Both are same");


            }
            else
            {
                Console.WriteLine("both are not same");
            }

            Console.ReadKey();


        }

        private static bool Equals(byte[] checkSum1, byte[] checkSum2)
        {
            for (int index = 0; index < checkSum1.Length; index++)
            {
                if (checkSum1[index] != checkSum2[index])
                    return false;
            }
            return true;
        }
    }
}
