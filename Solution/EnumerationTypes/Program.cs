using System;

namespace EnumerationTypes
{
    class Program
    {
        //By default the underlying type of each element in the enum is int.
        enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        //You can specify another integral numeric type by using a colon.
        //The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
        enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
        //The use and effect of the System.FlagsAttribute attribute indicates that an enumeration can be treated as a bit field; that is, a set of flags
        [Flags]
        public enum CarOptions
        {
            // The flag for SunRoof is 0001.
            SunRoof = 0x01,
            // The flag for Spoiler is 0010.
            Spoiler = 0x02,
            // The flag for FogLights is 0100.
            FogLights = 0x04,
            // The flag for TintedWindows is 1000.
            TintedWindows = 0x08,
        }
        // Define an Enum with FlagsAttribute.
        [FlagsAttribute]
        enum MultiHue : short
        {
            Black = 0,
            Red = 1,
            Green = 2,
            Blue = 4
        };

        static void Main(string[] args)
        {
            Days today = Days.Monday;
            int dayNumber = (int)today;
            Console.WriteLine("{0} is day number #{1}.", today, dayNumber);

            Months thisMonth = Months.Dec;
            byte monthNumber = (byte)thisMonth;
            Console.WriteLine("{0} is month number #{1}.", thisMonth, monthNumber);


            // The bitwise OR of 0001 and 0100 is 0101.
            CarOptions options = CarOptions.SunRoof | CarOptions.FogLights;
            // Because the Flags attribute is specified, Console.WriteLine displays 
            // the name of each enum element that corresponds to a flag that has 
            // the value 1 in variable options.
            Console.WriteLine(options);
            // The integer value of 0101 is 5.
            Console.WriteLine((int)options);
            // Display all possible combinations of values. 
            // Also display an invalid value. 
            for (int val = 0; val <= 8; val++)
                Console.WriteLine("{0,3} - {1}",
                    val, ((MultiHue)val).ToString());

            Console.ReadKey();
        }
    }
}
