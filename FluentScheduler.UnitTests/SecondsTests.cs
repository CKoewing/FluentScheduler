namespace FluentScheduler.UnitTests
{
    using System;
    using Xunit;
    using static Xunit.Assert;

    public class SecondsTests
    {
        [Fact]
        public void Should_Add_Specified_Seconds_To_Next_Run_Date()
        {
            // Assert
            var input = new DateTime(2000, 1, 1);
            var expected = new DateTime(2000, 1, 1, 0, 0, 30);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(30).Seconds();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
        }

        [Fact]
        public void Should_Add_Specified_Seconds_To_Same_Date_Within_Bounds()
        {
            // Assert
            var input = new DateTime(2000, 1, 1, 10, 15, 0);
            var expected = new DateTime(2000, 1, 1, 10, 15, 30);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(30).Seconds().Between(10, 0, 11, 0);
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
        }

        [Fact]
        public void Should_Roll_To_Next_Run_Date_Bound_Start_As_After_Bounds()
        {
            // Arrange
            var input = new DateTime(2000, 1, 1, 12, 0, 0);
            var expected = new DateTime(2000, 1, 2, 10, 0, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(30).Seconds().Between(10, 0, 11, 0);
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
        }
    }
}
