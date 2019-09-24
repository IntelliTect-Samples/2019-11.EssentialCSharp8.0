using System;
using System.IO;
using Path = EssemtialCSharp8.NullReferenceTypes.Path;

namespace EssemtialCSharp8
{
    public partial class EnhancedPatternMatching
    {
        // Is Not Null 
        public static bool TryConvertToNotNullable(ref object? value)
        {
            if(value is { } result)
            {
                value = result;
                return true;
            }
            return false;
        }


        // Switch Expression
        static public bool TryFormatDate(object input, string? format, out string? result)
        {
            result = input switch
            {
                DateTime date => date.ToString(format),
                DateTimeOffset date => date.ToString(format),
                string dateText => DateTime.TryParse(
                    dateText, out DateTime dateTime) ?
                        dateTime.ToString(format) : default,
                _ => null,
            };
            return !(result is null);  // Could be result is { }
        }


        void Puzzle()
        {
            string? test=null; 
            // Question: Why is this allowed: 
            test ??= null;
            Console.WriteLine(test);
        }
#if CompileError
        // Question: Why the requirement to specify class or struct constraint?
        // Question: Why is nonNullableValue not set?
        public static bool TryConvertToNotNullable<T>(T? value, T result)
        {
            bool @return;
            if (@return = value is { } nonNullableValue)
            {
                // Error: Use of unassigned local variable.
                // result = nonNullableValue;
            }
            return @return;
        }
#endif // CompileError


        // Property Patterns
        static public bool IsWeekend(DateTime dateTime) =>
            dateTime switch
            {
                { DayOfWeek: DayOfWeek.Saturday } => true,
                { DayOfWeek: DayOfWeek.Sunday } => true,
                // Assume the weekend starts at 5 PM on Friday
                { DayOfWeek: DayOfWeek.Friday, Hour: int hour } when hour >= 5 => true,
                // Same as default for value types
                // { } => false,  // Not null
                _ => false
            };

        // Another Property Pattern Example
        static public string FormatName(string first, string last, string? middle = null) =>
            (First: first, Last: last, Middle: middle) switch
            {
                { First: string f, Last: string l, Middle: null } => $"{l}, {f} ",
                { First: string f, Last: string l, Middle: string m } => $"{l}, {f} {m}",
                { First: null } => throw new ArgumentNullException(nameof(first)),
                { Last: null } => throw new ArgumentNullException(nameof(last)),
            };


        // Recursive Patterns
        public static bool TryCompositeFormatDate(
            object input, string compositFormatString, out string? result)
        {
            result = null;
            if(input switch
            {
                DateTime {Year: int Year, Month: int Month, Day: int Day } 
                    => (Year, Month, Day),
                DateTimeOffset { Year: int Year, Month: int Month, Day: int Day } 
                    => (Year, Month, Day),
                string dateText => DateTime.TryParse(
                    dateText, out DateTime dateTime) ?
                            (dateTime.Year, dateTime.Month, dateTime.Day) : 
                            default((int Year, int Month, int Day)?),
                _ => default((int Year, int Month, int Day)?)  // Bug: IDE shows this as optional but it is requried.
            } is { } date)
            {
                result = string.Format(
                    compositFormatString, date.Year, date.Month, date.Day);
                return true;
            }

            return false;
        }

        // Tuple Patterns
        public static string GetNextSate(int door, int motionSensor, string currentState) =>
            (door, motionSensor, currentState) switch
            {
                (0, 0, "armed") => "disarm",
                (0, 0, "disarmed") => "arm",
                (0, 1, "armed") => "disarm",
                (0, 1, "disarmed") => "disarm",
                (1, 0, "armed") => "arm",
                (1, 0, "disarmed") => "arm",
                (1, 1, "armed") => "arm",
                (1, 1, "disarmed") => "disarm",
                _ => throw new InvalidOperationException()
            };


        // Positional Patterns
        static public double ConvertToDecimalDegrees(Angle angle) => 
            angle is var (degrees, minutes, seconds) ?
                degrees * 60 + minutes / 60 + seconds / 60 * 60 : 
                    throw new InvalidOperationException();

        DayOfWeek[] WeekendDays = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Monday };
        static public bool Weekday(DateTime dateTime) =>
            !(dateTime is {DayOfWeek: DayOfWeek.Sunday } || dateTime is { DayOfWeek: DayOfWeek.Monday });

    }    
}



