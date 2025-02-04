using Xunit;

namespace EncryptionAPI.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void Encrypt_ValidInput_ReturnsEncryptedString()
        {
            // Arrange
            var encryptor = new Encryptor(); // Din krypteringslogik här
            string input = "Test";

            // Act
            var result = encryptor.Encrypt(input);

            // Assert
            Assert.NotEqual(input, result); // Eller ett annat sätt att verifiera resultatet
        }

        [Fact]
        public void Decrypt_EncryptedString_ReturnsOriginal()
        {
            // Arrange
            var encryptor = new Encryptor();
            string input = "Test";
            var encrypted = encryptor.Encrypt(input);

            // Act
            var result = encryptor.Decrypt(encrypted);

            // Assert
            Assert.Equal(input, result);
        }
    }
}
