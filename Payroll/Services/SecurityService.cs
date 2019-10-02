using System;
using System.Security.Cryptography;
using System.Text;

namespace Payroll.Services {
    public class SecurityService {
        public String HashString(String stringToHash) {
            using (var md5Algorithm = MD5.Create()) {
                Byte[] hashedBytes = md5Algorithm.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}