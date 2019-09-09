using FunctionToTestConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FunctionToTestTestProject {

    [TestClass]
    public class UnitTest1 {

        ForecastingFunction ff = null;

        [TestInitialize]
        public void TestInit() {
            ff = new ForecastingFunction();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestParmsOutsideDomain() {
            ff.Multiplier = 0;
            Assert.AreEqual(0, ff.Forecast(100, 100));
        }

        [TestMethod]
        public void TestValidInputsWithMultiplierZero() {
            // Multiplier is zero
            ff.Multiplier = 0;
            Assert.AreEqual(0, ff.Forecast(0, 0), "Result should be zero");
            Assert.AreEqual(0, ff.Forecast(1, 1), "Result should be zero");
            Assert.AreEqual(0, ff.Forecast(-1, -1), "Result should be zero");
        }
        [TestMethod]
        public void TestValidInputsWithMultiplierOne() {
            // Multiplier is zero
            ff.Multiplier = 1;
            Assert.AreEqual(0, ff.Forecast(0, 0), "Result should be zero");
            Assert.AreEqual(2, ff.Forecast(1, 1), "Result should be 2");
            Assert.AreEqual(0, ff.Forecast(-1, -1), "Result should be zero");
        }

        [TestMethod]
        public void TestValidInputsWithMultiplierFive() {
            ff.Multiplier = 5;
            Assert.AreEqual(0, ff.Forecast(0, 0), "Result should be zero");
            Assert.AreEqual(10, ff.Forecast(1, 1), "Result should be 10");
            Assert.AreEqual(0, ff.Forecast(-1, -1), "Result should be zero");
            Assert.AreEqual(60, ff.Forecast(2, 2), "Result should be zero");
            Assert.AreEqual(-20, ff.Forecast(-2, -2), "Result should be zero");
            Assert.IsTrue(ff.Multiplier % 5 == 0);
        }

        public void Test() {
        }
    }
}
