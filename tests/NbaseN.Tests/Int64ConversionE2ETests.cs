using Xunit;

namespace NbaseN.Tests
{
    public class Int64ConversionE2ETests
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "10")]
        [InlineData(100500, "11000100010010100")]
        [InlineData(2147483647, "1111111111111111111111111111111")]
        [InlineData(9223372036854775807, "111111111111111111111111111111111111111111111111111111111111111")]
        public void ConvertToString_WhenCalledWithBase2_CovertsCorrect(long longDecInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base2>.ConvertToString(longDecInput);
            
            //assert
            Assert.Equal(binExpected, actualResult);
        }
        
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(10, "A")]
        [InlineData(16, "10")]
        [InlineData(100500, "18894")]
        [InlineData(2147483647, "7FFFFFFF")]
        [InlineData(9223372036854775807, "7FFFFFFFFFFFFFFF")]
        public void ConvertToString_WhenCalledWithBase16_CovertsCorrect(long longDecInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base16>.ConvertToString(longDecInput);
            
            //assert
            Assert.Equal(binExpected, actualResult);
        }
        
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(10, "A")]
        [InlineData(16, "G")]
        [InlineData(17325410, "ABCDE")]
        public void ConvertToString_WhenCalledWithBase36_CovertsCorrect(long longDecInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base36>.ConvertToString(longDecInput);
            
            //assert
            Assert.Equal(binExpected, actualResult);
        }
    }
}