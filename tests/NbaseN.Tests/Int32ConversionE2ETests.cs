using Xunit;

namespace NbaseN.Tests
{
    public class Int32ConversionE2ETests
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "10")]
        [InlineData(100500, "11000100010010100")]
        [InlineData(2147483647, "1111111111111111111111111111111")]
        public void ConvertToString_WhenCalledWithBase2_CovertsCorrect(int decInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base2>.ConvertToString(decInput);
            
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
        public void ConvertToString_WhenCalledWithBase16_CovertsCorrect(int decInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base16>.ConvertToString(decInput);
            
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
        public void ConvertToString_WhenCalledWithBase36_CovertsCorrect(int decInput, string binExpected)
        {
            // act
            var actualResult = NbaseN<Base36>.ConvertToString(decInput);
            
            //assert
            Assert.Equal(binExpected, actualResult);
        }
    }
}