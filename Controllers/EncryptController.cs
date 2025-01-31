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
    }
}
