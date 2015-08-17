using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace DevooTesting
{
    
    public class DateExtensionMethods
    {

        [Test]
        public void SqlDate()
        {
            new DateTime(2009, 08, 09).SqlDate()
                .AssertEqualTo("'20090809'");

            new DateTime(2000, 08, 09).SqlDate()
                .AssertEqualTo("'20000809'");

            DateTime.MinValue.SqlDate().AssertEqualTo("NULL");
            new DateTime().SqlDate().AssertEqualTo("NULL");
        }

        [Test]
        public void SqlDateEmpty()
        {
            DateTime.MinValue.SqlDate()
                .AssertEqualTo("NULL");

            var date = new DateTime?();

            date.SqlDate()
                .AssertEqualTo("NULL");
        }


        [Test]
        public void SqlDateTime()
        {
            new DateTime(2009, 08, 09).SqlDateTime()
                .AssertEqualTo("'20090809'");

            new DateTime(2009, 08, 09, 2, 3, 4).SqlDateTime()
                .AssertEqualTo("'20090809 02:03:04.000'");

            new DateTime(2009, 08, 09, 2, 3, 4, 5).SqlDateTime()
                .AssertEqualTo("'20090809 02:03:04.005'");

            new DateTime(2009, 08, 09, 2, 3, 4, 15).SqlDateTime()
                .AssertEqualTo("'20090809 02:03:04.015'");

            new DateTime(2009, 08, 09, 2, 3, 4, 123).SqlDateTime()
                .AssertEqualTo("'20090809 02:03:04.123'");            
        }

        [Test]
        public void SqlDateTimeEmpty()
        {
            DateTime.MinValue.SqlDateTime()
                .AssertEqualTo("NULL");

            var date = new DateTime?();

            date.SqlDateTime()
                .AssertEqualTo("NULL");
        }


        [Test]
        public void AbbreviatedDayName()
        {
            new DateTime(2009, 12, 21).AbbreviatedDayName()
                .AssertEqualTo("LUN");

            new DateTime(2009, 12, 22).AbbreviatedDayName()
                .AssertEqualTo("MAR");

            new DateTime(2009, 12, 23).AbbreviatedDayName()
                .AssertEqualTo("MIE");

            new DateTime(2009, 12, 24).AbbreviatedDayName()
                .AssertEqualTo("JUE");

            new DateTime(2009, 12, 25).AbbreviatedDayName()
                .AssertEqualTo("VIE");

            new DateTime(2009, 12, 26).AbbreviatedDayName()
                .AssertEqualTo("SAB");

            new DateTime(2009, 12, 27).AbbreviatedDayName()
                .AssertEqualTo("DOM");
        }

        [Test]
        public void SetDate()
        {
            new DateTime(2010, 01, 11).SetDate(2011, 05, 01).AssertEqualTo(new DateTime(2011, 05, 01));
            new DateTime(2010, 01, 11).SetDate(1999, 12, 30).AssertEqualTo(new DateTime(1999, 12, 30));
            new DateTime(2010, 01, 11).SetDate(3000, 12, 30).AssertEqualTo(new DateTime(3000, 12, 30));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetDate(1999, 12, 40));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetDate(1999, 20, 01));
        }

        [Test]
        public void SetYear()
        {
            new DateTime(2010, 01, 11).SetYear(2011).AssertEqualTo(new DateTime(2011, 01, 11));
            new DateTime(2010, 01, 11).SetYear(1999).AssertEqualTo(new DateTime(1999, 01, 11));
            new DateTime(2010, 01, 11).SetYear(3000).AssertEqualTo(new DateTime(3000, 01, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetYear(0));
        }

        [Test]
        public void SetMonth()
        {
            new DateTime(2010, 01, 11).SetMonth(5).AssertEqualTo(new DateTime(2010, 05, 11));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetMonth(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetMonth(13));
        }

        [Test]
        public void SetDay()
        {
            new DateTime(2010, 01, 11).SetDay(1).AssertEqualTo(new DateTime(2010, 01, 01));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetDay(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11).SetDay(32));
        }

        [Test]
        public void SetHour()
        {
            new DateTime(2010, 01, 11, 10, 10, 10).SetHour(22).AssertEqualTo(new DateTime(2010, 01, 11, 22, 10, 10));
            new DateTime(2010, 01, 11, 10, 10, 10).SetHour(0).AssertEqualTo(new DateTime(2010, 01, 11, 00, 10, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetHour(24));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetHour(50));
        }

        [Test]
        public void SetMinute()
        {
            new DateTime(2010, 01, 11, 10, 10, 10).SetMinute(50).AssertEqualTo(new DateTime(2010, 01, 11, 10, 50, 10));
            new DateTime(2010, 01, 11, 10, 10, 10).SetMinute(0).AssertEqualTo(new DateTime(2010, 01, 11, 10, 00, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetMinute(60));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetMinute(100));
        }

        [Test]
        public void SetSecond()
        {
            new DateTime(2010, 01, 11, 10, 10, 10).SetSecond(50).AssertEqualTo(new DateTime(2010, 01, 11, 10, 10, 50));
            new DateTime(2010, 01, 11, 10, 10, 10).SetSecond(0).AssertEqualTo(new DateTime(2010, 01, 11, 10, 10, 00));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetSecond(60));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetSecond(100));
        }

        [Test]
        public void SetTime()
        {
            new DateTime(2010, 01, 11, 10, 10, 10).SetTime(22, 50, 50).AssertEqualTo(new DateTime(2010, 01, 11, 22, 50, 50));
            new DateTime(2010, 01, 11, 10, 10, 10).SetTime(00, 00, 00).AssertEqualTo(new DateTime(2010, 01, 11, 00, 00, 00));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetTime(25, 00, 00));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetTime(00, 60, 00));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(2010, 01, 11, 10, 10, 10).SetTime(00, 00, 60));
        }

      
        
    }
}
