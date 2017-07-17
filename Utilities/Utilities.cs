using System;

namespace Utilities
{
    public static class Utilities
    {
        public static void Guard(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
