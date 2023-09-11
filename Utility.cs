using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace Brayns.BCT
{
    public static class Utility
    {
        public const string ENCRYPT_KEY = "bc-toolkit";

        public static string EncryptString(string value)
        {
            var sha = SHA256.Create();
            var shaKey = sha.ComputeHash(Encoding.UTF8.GetBytes(ENCRYPT_KEY));

            var aes = Aes.Create();
            aes.Key = shaKey;
            aes.IV = new byte[16];

            var aesVal = aes.EncryptEcb(Encoding.UTF8.GetBytes(value), PaddingMode.PKCS7);
            return Convert.ToBase64String(aesVal);
        }

        public static string DecryptString(string value)
        {
            if (value == "")
                return "";

            var sha = SHA256.Create();
            var shaKey = sha.ComputeHash(Encoding.UTF8.GetBytes(ENCRYPT_KEY));

            var aes = Aes.Create();
            aes.Key = shaKey;
            aes.IV = new byte[16];

            var aesVal = aes.DecryptEcb(Convert.FromBase64String(value), PaddingMode.PKCS7);
            return Encoding.UTF8.GetString(aesVal);
        }
    }

    public class ListViewColumnSorter : IComparer
    {
        CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();
        ListView? _list = null;

        public int Column { get; set; }
        public bool Descending { get; set; }

        public ListViewColumnSorter(ListView newList)
        {
            _list = newList;
            Column = -1;
        }

        public int Compare(object? x, object? y)
        {
            if (Column > 0)
            {
                x = ((ListViewItem)x!).SubItems[Column].Tag;
                y = ((ListViewItem)y!).SubItems[Column].Tag;
            }
            else
            {
                x = ((ListViewItem)x!).Text;
                y = ((ListViewItem)y!).Text;
            }

            if ((x == null) && (y == null)) return 0;
            if ((x != null) && (y == null)) return 1;
            if ((y != null) && (x == null)) return -1;

            if (Descending)
                return _comparer.Compare(y, x);
            else
                return _comparer.Compare(x, y);
        }
    }
}
