using Microsoft.VisualStudio.TestTools.UnitTesting;
using Angle = EssemtialCSharp8.EnhancedPatternMatching.Angle;

namespace EssemtialCSharp8.Tests
{
    public partial class EnhancedPatternMatchingTests
    {
        [TestClass]
       public partial class AngleTests
        {
            [TestMethod]
            public void Deconstruct_UsingAssignmentSyntax_Success()
            {
                Angle angle = new Angle(15, 15, 15);
                (int degrees, int minutes, int seconds) = angle;
                Assert.AreEqual<(int degrees, int minutes, int seconds)>(
                    (15, 15, 15), (degrees, minutes, seconds));
            }

            [TestMethod]
            public void ConvertToDecimalDegrees_GivenBasicAngle_Success()
            {
                Angle angle = new Angle(15, 15, 15);
                Assert.AreEqual<double>(900, Angle.ConvertToDecimalDegrees(angle));
                angle = new Angle(1, 1, 1);
                Assert.AreEqual<double>(60, Angle.ConvertToDecimalDegrees(angle));
            }

        }

    }
}