using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Service
{
    public static class OrderCodeGenerator
    {
        private static readonly object lockObject = new();
        private static int counter = 0;

        public static string GenerateOrderCode()
        {
            lock (lockObject)
            {
                // Reset counter nếu đạt tới 9999
                if (counter > 9999) counter = 0;

                string dateString = DateTime.Now.ToString("yyyyMMdd");
                string counterString = (++counter).ToString("D4");
                return $"ORD{dateString}{counterString}";
            }
        }
    }
}