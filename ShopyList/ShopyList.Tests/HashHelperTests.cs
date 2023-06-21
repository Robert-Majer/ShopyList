using ShopyList.DataAccess.HelperFeatures;

namespace ShopyList.Tests
{
    [TestClass]
    public class HashHelperTests
    {
        [TestMethod]
        public void GenereteSaltMethodReturnByteArray()
        {
            // Arrange

            // Act
            byte[] fromCall = HashHelper.GenerateSalt();

            // Assert
            Assert.IsNotNull(fromCall);
            Assert.IsInstanceOfType(fromCall, typeof(byte[]));
        }

        [TestMethod]
        public void GenereteSaltMethodDoesNotReturnSameByteArray()
        {
            // Arrange
            byte[] byte1;
            byte[] byte2;
            byte[] byte3;

            // Act
            byte1 = HashHelper.GenerateSalt();
            byte2 = HashHelper.GenerateSalt();
            byte3 = HashHelper.GenerateSalt();

            // Assert
            CollectionAssert.AreNotEqual(byte1, byte2);
            CollectionAssert.AreNotEqual(byte1, byte3);
            CollectionAssert.AreNotEqual(byte2, byte3);
        }

        [TestMethod]
        public void HashPasswordMethodReturnString()
        {
            // Arrange
            byte[] salt = HashHelper.GenerateSalt();
            string password = "password";
            string hashedPassword;

            // Act
            hashedPassword = HashHelper.HashPassword(password, salt);

            // Assert
            Assert.IsNotNull(hashedPassword);
            Assert.IsInstanceOfType(hashedPassword, typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashPasswordMethodPasswordDoesNull()
        {
            // Arrange
            byte[] salt = HashHelper.GenerateSalt();
            string password = null;
            string hashedPassword;

            // Act
            hashedPassword = HashHelper.HashPassword(password, salt);
        }

        [TestMethod]
        public void VerifyPasswordMethodPasswordDoesCorrect()
        {
            // Arrange
            byte[] salt = HashHelper.GenerateSalt();
            string password = "password";
            string hashedPassword;

            // Act
            hashedPassword = HashHelper.HashPassword(password, salt);

            // Assert
            Assert.IsTrue(HashHelper.VerifyPassword("password",hashedPassword, salt));
        }

        [TestMethod]
        public void VerifyPasswordMethodPasswordDoesNotCorrect()
        {
            // Arrange
            byte[] salt = HashHelper.GenerateSalt();
            string password = "password";
            string hashedPassword;

            // Act
            hashedPassword = HashHelper.HashPassword(password, salt);

            // Assert
            Assert.IsFalse(HashHelper.VerifyPassword("incorrect", hashedPassword, salt));
        }
    }
}