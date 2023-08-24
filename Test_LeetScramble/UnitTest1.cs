using NUnit.Framework;

namespace Scramble.nUnitTests
{
    public class Tests
    {
        private LeetScramble _ls { get; set; }

        [SetUp]
        public void Setup()
        {
            _ls = new LeetScramble();
        }

        [Test]
        public void Encode_EqualTest()
        {
            string[] line = { "It", "was", "many", "and", "many", "a", "year", "ago" };
            string expected = "I0t w1s m2y a1d m2y a y2r a1o";

            string encodedLine = _ls.Encode(line);

            Assert.That(encodedLine, Is.EqualTo(expected));
        }
    }
}