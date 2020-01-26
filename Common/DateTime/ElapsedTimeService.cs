using Common.DateTime.Interface;

namespace Common.DateTime
{
    public class ElapsedTimeService : IElapsedTimeService
    {
        private readonly System.DateTime Year1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
        private readonly System.DateTime YearOne = new System.DateTime(1, 1, 1, 0, 0, 0, 0).ToLocalTime();

        public double UnixEpoch(System.DateTime dateTimeNow)
        {
            var span = (dateTimeNow.ToLocalTime() - Year1970);
            return span.TotalSeconds;
        }

        public double YearOneEpoch(System.DateTime dateTimeNow)
        {
            var span = (dateTimeNow.ToLocalTime() - YearOne);
            return span.TotalSeconds;
        }
    }
}
