using System;
using System.IO;
using Path = EssemtialCSharp8.NullReferenceTypes.Path;

namespace EssemtialCSharp8
{
    public partial class EnhancedPatternMatching
    {
        public struct Angle
        {
            public Angle(int degrees, int minutes, int seconds) =>
                (Degrees, Minutes, Seconds) = (degrees, minutes, seconds);

            // Using C# 6.0 read-only, automatically implemented properties
            public int Degrees { get; }
            public int Minutes { get; }
            public int Seconds { get; }

            public void Deconstruct(out int degrees, out int minutes, out int seconds) =>
                (degrees, minutes, seconds) = (Degrees, Minutes, Seconds);

            public static double ConvertToDecimalDegrees(Angle angle) =>
                angle is (int degrees, int minutes, int seconds) ?
                    degrees * 60 + minutes / 60 + seconds / 60 * 60 :
                        throw new InvalidOperationException();
        }
    }
}



