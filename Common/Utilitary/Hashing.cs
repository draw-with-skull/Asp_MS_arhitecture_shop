using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilitary
{
    public static class Hashing
    {
        public static string GetHash(string inputString)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            byte[] encoded= algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            return BitConverter.ToString(encoded).Replace("-","");
        }
    }
}
