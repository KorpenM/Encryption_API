using System.Text;

namespace EncryptionAPI.Services
{
    public class Encryptor
    {
        public string Encrypt(string plainText)
        {
            return CaesarCipher(plainText, 3);
        }

        public string Decrypt(string encryptedText)
        {
            return CaesarCipher(encryptedText, -3);
        }

        private string CaesarCipher(string input, int shift)
        {
            var result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    var start = char.IsUpper(c) ? 'A' : 'a';
                    result.Append((char)((((c + shift) - start + 26) % 26) + start));
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
