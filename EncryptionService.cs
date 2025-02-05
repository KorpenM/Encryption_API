using System.Text;

namespace EncryptionAPI
{
    public class EncryptionService
    {
        private int _key;

        public EncryptionService(int key)
        {
            _key = key;
        }

        // Krypterar texten genom att använda Caesar Cipher
        public string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    var start = char.IsUpper(c) ? 'A' : 'a';
                    result.Append((char)((((c - start + _key) + 26) % 26) + start));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        // Avkrypterar texten genom att använda Caesar Cipher (använder negativ nyckel)
        public string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    var start = char.IsUpper(c) ? 'A' : 'a';
                    result.Append((char)((((c - start - _key) + 26) % 26) + start));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
