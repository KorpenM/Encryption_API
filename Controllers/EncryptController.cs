using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EncryptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        // Endpoint f�r att kryptera text
        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] string plainText)
        {
            var encrypted = CaesarCipher(plainText, 3); // Skiftar med 3
            return Ok(encrypted);
        }

        // Endpoint f�r att avkryptera text
        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] string encryptedText)
        {
            var decrypted = CaesarCipher(encryptedText, -3); // Skiftar med -3
            return Ok(decrypted);
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
                    result.Append(c); // Beh�ller andra tecken of�r�ndrade
                }
            }
            return result.ToString();
        }
    }
}
