
using System;
using Xunit;
using QuadraticEquationSolver;

namespace QuadraticEquationSolver.Tests
{
    public class QuadraticSolverTests
    {
        [Theory]
        [InlineData(1, 0, 1)] // brak pierwiastków
        [InlineData(2, 2, 5)]
        public void Solve_ShouldReturnNoRealRoots(double a, double b, double c)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(0, result.NumberOfRoots);
            Assert.Null(result.Root1);
            Assert.Null(result.Root2);
        }

        [Theory]
        [InlineData(1, 2, 1, -1)]
        [InlineData(4, 4, 1, -0.5)]
        public void Solve_ShouldReturnOneRealRoot_WhenDiscriminantIsZero(double a, double b, double c, double expectedRoot)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(1, result.NumberOfRoots);
            Assert.NotNull(result.Root1);
            Assert.Equal(expectedRoot, result.Root1.Value, precision: 5);
            Assert.Null(result.Root2);
        }

        [Theory]
        [InlineData(1, -3, 2, 2, 1)]
        [InlineData(1, 0, -4, 2, -2)]
        public void Solve_ShouldReturnTwoRealRoots_WhenDiscriminantIsPositive(double a, double b, double c, double expectedRoot1, double expectedRoot2)
        {
            var result = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(2, result.NumberOfRoots);
            Assert.NotNull(result.Root1);
            Assert.NotNull(result.Root2);
            Assert.Contains(result.Root1.Value, new[] { expectedRoot1, expectedRoot2 });
            Assert.Contains(result.Root2.Value, new[] { expectedRoot1, expectedRoot2 });
        }

        [Fact]
        public void Solve_ShouldThrowArgumentException_WhenAIsZero()
        {
            Assert.Throws<ArgumentException>(() => QuadraticSolver.Solve(0, 2, 3));
        }
    }
}
