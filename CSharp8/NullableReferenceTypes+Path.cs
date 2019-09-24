namespace EssemtialCSharp8
{
    partial class NullReferenceTypes
    {
        public class Path
        {
            //
            // Summary:
            //     Combines two strings into a path.
            //
            // Parameters:
            //   path1:
            //     The first path to combine.
            //
            //   path2:
            //     The second path to combine.
            //
            // Returns:
            //     The combined paths. If one of the specified paths is a zero-length string, this
            //     method returns the other path. If path2 contains an absolute path, this method
            //     returns path2.
            //
            // Exceptions:
            //   T:System.ArgumentException:
            //     path1 or path2 contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.
            //
            //   T:System.ArgumentNullException:
            //     path1 or path2 is null.
            public static string Combine(string path1, string path2)
            {
                return System.IO.Path.Combine(path1, path2);
            }

            //
            // Summary:
            //     Returns a random folder name or file name.
            //
            // Returns:
            //     A random folder name or file name.
            public static string GetRandomFileName()
            {

                return RandomFileName;
            }

            static public string RandomFileName { get; set;} = System.IO.Path.GetRandomFileName();

            //
            // Summary:
            //     Returns the path of the current user's temporary folder.
            //
            // Returns:
            //     The path to the temporary folder, ending with a backslash.
            //
            // Exceptions:
            //   T:System.Security.SecurityException:
            //     The caller does not have the required permissions.
            public static string GetTempPath()
            {
                return System.IO.Path.GetTempPath();
            }
        }
    }
}
