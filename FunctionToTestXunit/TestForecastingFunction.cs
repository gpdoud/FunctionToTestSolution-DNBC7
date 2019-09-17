using FunctionToTestConsole;
using System;
using Xunit;

namespace FunctionToTestXunit {

    public class TestForecastingFunction {

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 1, 1, 2)]
        [InlineData(2, 2, 2, 24)]
        public void TestForecastingFormula(int m, int x, int y, int exp) {
            // Arrange
            var ff = new ForecastingFunction();
            // Act
            ff.Multiplier = m;
            var act = ff.Forecast(x, y);
            // Assert
            Assert.Equal(exp, act);
        }
        [Theory]
        [InlineData(1, -11, 11)]
        public void TestOutOfRangeValues(int m, int x, int y) {
            // Arrange
            var ff = new ForecastingFunction();
            // Act
            ff.Multiplier = m;
            var ex = Assert.Throws<Exception>(() => ff.Forecast(x, y));
            // Assert
            Assert.Equal("X or Y are outside the domain.", ex.Message);
        }
    }
}
