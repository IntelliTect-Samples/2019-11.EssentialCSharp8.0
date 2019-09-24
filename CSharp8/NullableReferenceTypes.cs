using System;
using System.IO;
using Path = EssemtialCSharp8.NullReferenceTypes.Path;

namespace EssemtialCSharp8
{
    public partial class NullReferenceTypes
    {
        public static string GetTempPathInDirectory(string? directory = null)
        {
            if (directory is null) // Could use Null-coalescing assignment
            {
                directory = Path.GetTempPath();
            }
            string fullName;
            do
            {
                fullName = Path.Combine(directory, Path.GetRandomFileName());
            }
            while (Directory.Exists(fullName) || File.Exists(fullName));

            return fullName;
        }

        public static bool IsNotNull<T>(T thing) => thing is { };
        public static bool IsNull<T>(T thing) => thing is null;

        //public static bool IsNull<T>(T thing) where T : class => thing is null;
        //public static bool IsNull<T>(T? thing) where T : struct => thing is null;

        public static string GetTempPathInDirectory2(string? directory = null)
        {
            string fullName;
            do
            {
                if (IsNotNull(directory))
#pragma warning disable CS8604  // Leaving error in place for elucidation.
                    fullName = Path.Combine(directory, Path.GetRandomFileName());
#pragma warning restore CS8604
                else
                    fullName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }
            while (Directory.Exists(fullName) || File.Exists(fullName));

            return fullName;
        }
    }
}
