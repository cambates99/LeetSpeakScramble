using NUnit.Framework;
using System.Diagnostics;

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
        public void Example_EqualTest()
        {
            string line = "It was many and many a year ago";
            string expected = "I0t w1s m2y a1d m2y a y2r a1o";

            string encodedLine = _ls.Encode(line);

            Assert.That(encodedLine, Is.EqualTo(expected));
        }
        [Test]
        public void Example2_EqualTest()
        {
            string line = "Copyright,Microsoft:Corporation";
            string expected = "C7t,M6t:C6n";

            string encodedLine = _ls.Encode(line);

            Assert.That(encodedLine, Is.EqualTo(expected));
        }
        [Test]
        public void AllLetters_EqualTest()
        {
            string line = "The quick brown fox jumps over the lazy dog";
            string expected = "T1e q3k b3n f1x j3s o2r t1e l2y d1g";

            string encodedLine = _ls.Encode(line);

            Assert.That(encodedLine, Is.EqualTo(expected));
        }
        [Test]
        public void AllPunctuation_EqualTest()
        {
            string line = @" ,./;'[]\`1234567890-=<>?:{}~!@#$%^&*()_+";
            string expected = @" ,./;'[]\`1234567890-=<>?:{}~!@#$%^&*()_+";

            string encodedLine = _ls.Encode(line);

            Assert.That(encodedLine, Is.EqualTo(expected));
        }
        [Test]
        public void StressTest()
        {
            StreamReader sr = new StreamReader("Lorem1000.txt");
            string line = sr.ReadToEnd();

            Stopwatch sw = Stopwatch.StartNew();
            string encodedLine = _ls.Encode(line);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 20);
        }
    }
}