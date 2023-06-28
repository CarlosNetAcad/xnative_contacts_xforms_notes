using System;
using NUnit.Framework;

namespace NUnitTest
{
	public class SampleTests
	{
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp.....");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown.....");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1.....");

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Test2.....");

            Assert.Pass();
        }
    }
}

