using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowCloneAPI.UITests
{
    public class DemoHelper
    {
        public static void Pause(int secondsToPause = 3000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
