using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        // Endpoint för att kryptera en text
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            string encrypted = EncryptText(text);
            return Ok(new { EncryptedText = encrypted });
        }

        // Endpoint för att avkryptera en text
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            string decrypted = DecryptText(text);
            return Ok(new { DecryptedText = decrypted });
        }

        // Enkelt exempel på Caesar-chiffer
        private string EncryptText(string input)
        {
            int shift = 3; // Flyttar bokstäver tre steg framåt i alfabetet
            return new string(input.Select(c => (char)(c + shift)).ToArray());
        }

        private string DecryptText(string input)
        {
            int shift = 3; // Flyttar bokstäver tre steg bakåt i alfabetet
            return new string(input.Select(c => (char)(c - shift)).ToArray());
        }
    }
}
