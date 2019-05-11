using Acme;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AcmeUnitTest
{
    [TestClass]
    public class SerialGeneratorTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Generate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var Movie = new Movie();
            Movie.Number = 1;
            Movie.ReleaseDate = System.DateTime.Now;

            // Act
            var result = SerialGenerator.Generate(
                Movie);
            System.Console.WriteLine(result);

            // Assert
            Assert.AreEqual(result[1], "ACME#01-"+System.String.Format("{0:MMyy}", System.DateTime.Now) +"-R");
            Assert.AreEqual(result[0], "ACME#01-"+System.String.Format("{0:MMyy}", System.DateTime.Now) +"-W");
            
        }
    }
}
