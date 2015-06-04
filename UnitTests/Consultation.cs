using System;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Consultation
    {
        private int exam, tempAcademK, amountHours, tempStudCountK;
        public double GetConsultationForDaily()
        {
            return 2 * exam * tempAcademK + 0.06 * amountHours * (tempStudCountK) / 25;
        }

        public double GetConsultationForAbsentee()
        {
            return 2 * exam * tempAcademK + 0.12 * amountHours * (tempStudCountK) / 25;
        }

        [SetUp]
        public void SetUp()
        {
            exam = 30;
            tempAcademK = 80;
            amountHours = 67;
            tempStudCountK = 34;
        }

        [Test]
        public void CheckDailyConsultationTest()
        {
            Assert.That(4805.47, Is.EqualTo(Math.Round(GetConsultationForDaily(), 2)));
        }

        [Test]
        public void CheckAbsenteeConsultationTest()
        {
            Assert.That(4810.93, Is.EqualTo(Math.Round(GetConsultationForAbsentee(), 2)));
        }
    }
}
