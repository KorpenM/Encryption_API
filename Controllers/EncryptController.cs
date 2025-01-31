using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EncryptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        // Endpoint för att kryptera text
        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] string plainText)
        {
            var encrypted = CaesarCipher(plainText, 3); // Skiftar med 3
            return Ok(encrypted);
        }

        // Endpoint för att avkryptera text
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
                    char d = (char)(c + shift);
                    if (char.IsLower(c) && d > 'z' || char.IsUpper(c) && d > 'Z')
                    {
                        d = (char)(c - (26 - shift));
                    }
                    else if (char.IsLower(c) && d < 'a' || char.IsUpper(c) && d < 'A')
                    {
                        d = (char)(c + (26 - shift));
                    }
                    result.Append(d);
                }
                else
                {
                    result.Append(c);  // Behandlar icke-bokstäver
                }
            }
            return result.ToString();
        }
    }
}
