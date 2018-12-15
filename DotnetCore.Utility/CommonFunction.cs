using System;

namespace DotnetCore.Utility
{
    public class CommonFunction
    {
        #region DATE TIME
        public static DateTime GetCurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        #endregion

        #region IS ACTIVE-TRUE
        public static bool GetStatusTrue
        {
            get
            {
                return true;
            }
        }
        #endregion
       
        #region IS ACTIVE-FALSE
        public static bool GetStatusFalse
        {
            get
            {
                return false;
            }
        }
        #endregion

    }
}
