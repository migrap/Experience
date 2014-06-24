using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Experience.Models {
    //Inverse Functional Identifier
    public class InverseFunctionalIdentifier {
        public Mailto Mbox { get; set; }
        public string Shasum {
            get { return Mbox.GetHash(); }
        }
        public string Openid { get; set; }
        public IPrincipal Account { get; set; }
    }

    public static partial class Extensions {
        private static SHA512CryptoServiceProvider _provider = new SHA512CryptoServiceProvider();

        public static string GetHash(this Mailto self) {
            if(null == self) {
                return string.Empty;
            }

            var mailto = self.ToString();
            var buffer = Encoding.UTF8.GetBytes(mailto);
            var hash = _provider.ComputeHash(buffer);
            hash = _provider.ComputeHash(hash);
            return Convert.ToBase64String(hash);
        }
    }
}