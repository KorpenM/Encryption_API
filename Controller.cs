using Microsoft.AspNetCore.Mvc;
using EncryptionAPI;

namespace EncryptionAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly Encryptor _encryptor;

        public Controller(Encryptor encryptor)
        {
            _encryptor = encryptor;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] string plainText)
        {
            var encrypted = _encryptor.Encrypt(plainText);
            return Ok(encrypted);
        }

        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] string encryptedText)
        {
            var decrypted = _encryptor.Decrypt(encryptedText);
            return Ok(decrypted);
        }
    }
}
