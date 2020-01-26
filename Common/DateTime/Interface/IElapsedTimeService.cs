namespace Common.DateTime.Interface
{
    public interface IElapsedTimeService
    {
        /// <summary>
        /// The "epoch" serves as a reference point from which time is measured.
        /// 
        /// The Unix epoch (or Unix time or POSIX time or Unix timestamp) is the number of seconds that have elapsed since January 1, 1970 (midnight UTC/GMT) Not counting leap seconds (in ISO 8601: 1970-01-01T00:00:00Z).
        /// </summary>
        /// <param name="dateTimeNow"></param>
        /// <returns></returns>
        double UnixEpoch(System.DateTime dateTimeNow);

        /// <summary>
        /// The "epoch" serves as a reference point from which time is measured.
        /// 
        /// Seconds since 1/1/1
        /// 
        /// I've seen some older systems use this as a starting point so support was needed.
        /// </summary>
        /// <param name="dateTimeNow"></param>
        /// <returns></returns>
        double YearOneEpoch(System.DateTime dateTimeNow);
    }
}
