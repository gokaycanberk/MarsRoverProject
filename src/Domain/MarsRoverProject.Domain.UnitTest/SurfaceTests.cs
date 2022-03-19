using MarsRoverProject.Core.Exceptions;
using Xunit;

namespace MarsRoverProject.Domain.UnitTest
{
    public class SurfaceTests
    {
        [Fact]
        public void Surface_Should_Be_Created_Successfully_When_Height_And_Width_Valid()
        {
            var surface = new Surface(int.MaxValue, int.MaxValue);

            Assert.Equal(int.MaxValue, surface.Height);
            Assert.Equal(int.MaxValue, surface.Width);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MinValue, 100)]
        [InlineData(100, int.MinValue)]
        public void Surface_Should_Throw_Exception_When_Height_Or_Width_Not_Valid(int height, int width)
        {
            Assert.Throws<DomainException>(() => new Surface(height, width));
        }
    }
}