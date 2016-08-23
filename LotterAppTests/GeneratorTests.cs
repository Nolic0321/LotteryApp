using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RNG;
using System.Collections;
using System.Collections.Generic;

namespace LotterAppTests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void TestBaseConstructor()
        {
            Generator rng = new Generator();

            Assert.AreEqual(rng.max, 10);
            Assert.AreEqual(rng.min, 0);
            for(int i = 0; i < 10; i++)
                Assert.IsTrue(rng.Generate() < 10);

            Generator rngMax = new Generator(100);

            for (int i = 0; i < 100; i++)
                Assert.IsTrue(rng.Generate() < 100);
        }

        [TestMethod]
        public void TestMaxConstructor()
        {
            Generator rngMax = new Generator(100);
            Assert.AreEqual(rngMax.max, 100);
            Assert.AreEqual(rngMax.min, 0);
            

            for (int i = 0; i < 100; i++)
                Assert.IsTrue(rngMax.Generate() < 100);
        }

        [TestMethod]
        public void TestMinMaxConstructor()
        {
            Generator rngMax = new Generator(-100,100);
            Assert.AreEqual(rngMax.max, 100);
            Assert.AreEqual(rngMax.min, -100);


            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(rngMax.Generate() < 100);
                Assert.IsTrue(rngMax.Generate() > -100);
            }
        }

        [TestMethod]
        public void TrulyRandomTest()
        {
            Generator rng = new Generator(100);

            SortedList<int,int> numbers = new SortedList<int,int>();

            for(int i = 0; i < 101; i++)
            {
                numbers.Add(i, 0);
            }
            

            for(int i = 0; i < 10000; i++)
            {
                int index = rng.Generate();
                numbers[index]++;
            }

            foreach(KeyValuePair<int,int> kvp in numbers)
            {
                Console.WriteLine(String.Format("{0} : {1} picks", kvp.Key, kvp.Value));
            }
        }
    }
}
