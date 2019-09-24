using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssemtialCSharp8;
using System;
using System.Collections.Generic;
using System.Text;

namespace EssemtialCSharp8.Tests
{
    [TestClass()]
    public partial class EnhancedPatternMatchingTests
    {
        [TestMethod()]
        public void TryConvertToNotNull_GivenNull_ReturnFalse()
        {
            string? test;
            test = Guid.NewGuid().ToString();
            test ??= null;
            Console.WriteLine(test);
            object? text = null;
            Assert.IsFalse(EnhancedPatternMatching.TryConvertToNotNullable(ref text));
            text = "Inigo Montoya";
            Assert.IsTrue(EnhancedPatternMatching.TryConvertToNotNullable(ref text));
        }

        [TestMethod()]
        public void TryFormatDateTest_GivenDateTime_FormatSuccessfully()
        {
            const string format = "MMMM dd, yyyy";
            DateTime now = DateTime.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryFormatDate(now, format, out string? result));

            Assert.AreEqual<string>(now.ToString(format), result!);
        }

        [TestMethod()]
        public void TryFormatDateTest_GivenDateTimeOffset_FormatSuccessfully()
        {
            const string format = "MMMM dd, yyyy";
            DateTimeOffset now = DateTimeOffset.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryFormatDate(now, format, out string? result));

            Assert.AreEqual<string>(now.ToString(format), result!);
        }

        [TestMethod()]
        public void TryFormatDateTest_GivenString_FormatSuccessfully()
        {
            const string format = "MMMM dd, yyyy";
            DateTimeOffset now = DateTimeOffset.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryFormatDate(now.ToString(), format, out string? result));

            Assert.AreEqual<string>(now.ToString(format), result!);
        }

        [TestMethod()]
        public void TryCompositeFormatDate_GivenDateTime_FormatSuccessfully()
        {
            const string compositeFormat = "{0}-{1}-{2}";
            DateTime now = DateTime.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryCompositeFormatDate(now, compositeFormat, out string? result));

            Assert.AreEqual<string>(now.ToString("yyyy-M-dd"), result!);
        }

        [TestMethod()]
        public void TryCompositeFormatDate_GivenDateTimeOffset_FormatSuccessfully()
        {
            const string compositeFormat = "{0}-{1}-{2}";
            DateTimeOffset now = DateTimeOffset.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryCompositeFormatDate(now, compositeFormat, out string? result));

            Assert.AreEqual<string>(now.ToString("yyyy-M-dd"), result!);
        }

        [TestMethod()]
        public void TryCompositeFormatDate_GivenString_FormatSuccessfully()
        {
            const string compositeFormat = "{0}-{1}-{2}";
            DateTimeOffset now = DateTimeOffset.Now;
            Assert.IsTrue(
                EnhancedPatternMatching.TryCompositeFormatDate(now.ToString(), compositeFormat, out string? result));

            Assert.AreEqual<string>(now.ToString("yyyy-M-dd"), result!);
        }

        [TestMethod()]
        public void TryCompositeFormatDate_GivenUnconvertableDateText_FormatFails()
        {
            Assert.IsFalse(
                EnhancedPatternMatching.TryCompositeFormatDate("Inigo Montoya", "", out string? result));
        }
        [TestMethod()]
        public void TryCompositeFormatDate_GivenObject_FormatFails()
        {
            Assert.IsFalse(
                EnhancedPatternMatching.TryCompositeFormatDate(new object(), "", out string? result));
        }

        [TestMethod]
        public void IsWeekend_GivenWeekendDate_ReturnTrue()
        {
            DateTime dateTime = new DateTime(2019, 9, 22);
            Assert.IsTrue(EnhancedPatternMatching.IsWeekend(dateTime));
        }
        [TestMethod]
        public void IsWeekend_GivenWeekdayDate_ReturnTrue()
        {
            DateTime dateTime = new DateTime(2019, 9, 23);
            Assert.IsFalse(EnhancedPatternMatching.IsWeekend(dateTime));
        }
    }
}