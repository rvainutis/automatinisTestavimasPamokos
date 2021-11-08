using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos
{
    public class Demo
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.IsTrue(CurrentTime.Hour.Equals(19), "Dabar ne 19 valanad.");
        }
        /*
        [Test]
        public static void TestWaitFor5sec()
        {
            Thread.sleep
        }
        */
        [Test]
        public static void Test995Dalyba3()
        {
            int leftover2 = 996 % 3;
            Assert.AreEqual(0, leftover2, "995 nesidalija is 3.");
        }
        /*
        [Test]
        public static void TestIfMonday()
        {
            DateTime CurrentDay = 
        }
        */
    }
}
