using Common.DateTime;
using Common.DateTime.Interface;
using NUnit.Framework;

namespace CommonUnitTest.DateTime
{
    public class ElapsedTimeServiceTest
    {
        [Test]
        public void UnixEpoch_given_valid_data_should_return_valid_TotalSeconds()
        {
            // Arrange
            var year1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var dateTimeNow = System.DateTime.Now;
            var expected = (dateTimeNow.ToLocalTime() - year1970).TotalSeconds;
            IElapsedTimeService classUnderTest = new ElapsedTimeService();

            // Act
            var actual = classUnderTest.UnixEpoch(dateTimeNow);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YearOneEpoch_given_valid_data_should_return_valid_TotalSeconds()
        {
            // Arrange
            var yearOne = new System.DateTime(1, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var dateTimeNow = System.DateTime.Now;
            var expected = (dateTimeNow.ToLocalTime() - yearOne).TotalSeconds;
            IElapsedTimeService classUnderTest = new ElapsedTimeService();

            // Act
            var actual = classUnderTest.YearOneEpoch(dateTimeNow);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
