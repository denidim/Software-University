using WebShopDemo.Core.ValidationAttributes;

namespace WebShopDemo.Tests
{
    
    public class CurrentYearRangeAttributeTest
    {
        [Fact]
        public void IsValidReturnsFalseForDateTimeAfterCurrentYear()
        {
            //Arange
            var attribute = new CurrentYearRange(199);

            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));

            //Assert

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsFalseForYearAfterCurrentYear()
        {
            //Arange
            var attribute = new CurrentYearRange(199);

            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1).Year);

            //Assert

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueForYearBeforeCurrentYear()
        {
            //Arange
            var attribute = new CurrentYearRange(199);

            //Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(-1).Year);

            //Assert

            Assert.True(isValid);
        }



    }
}
