using System;
using System.Globalization;

namespace DateTime2String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! Heute ist der {DateTime.Now}");

            DateTime jetzt = DateTime.Now;

            //Verwenden der ToString-Methode. So frisst es auch MySql...
            //MySql-DB will "2022-05-23 12:34:56"
            //ToString von C# macht "23.05.2022 12:34:56", wenn man keinen FormatProvider angibt.
            string formatForMySql = jetzt.ToString("yyyy-MM-dd HH:mm:ss");

            //Unter Verwendung der CultureInfo-Klasse. --> Allerdings "using System.Globalization" nötig.
            // just to shorten the code
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
            var german = CultureInfo.CurrentCulture.DateTimeFormat; //Nach Format des Betriebsystems.
            // "1976-04-12T22:10:00"
            string jetztAlsString = jetzt.ToString(isoDateTimeFormat.SortableDateTimePattern);

            // "1976-04-12 22:10:00Z"    
            jetztAlsString = jetzt.ToString(isoDateTimeFormat.UniversalSortableDateTimePattern);


            //Und umgekehrt string -> DateTime
            string myDate = "12-Apr-1976 22:10";
            DateTime dateValue = DateTime.Parse(myDate);
            
            //Demos in verschiedenen Formaten
            string[] dateStrings = {"2008-05-01T07:34:42-5:00",
                              "2008-05-01 7:34:42Z",
                              "Thu, 01 May 2008 07:34:42 GMT",
                                "12.5.2022 13:55",
                                "asdf" //Aufpassen! Bei nicht konvertierbaren Angaben...(A)
            };
            
            foreach (string dateString in dateStrings)
            {
                DateTime convertedDate = DateTime.Now;
                try
                {
                    convertedDate = DateTime.Parse(dateString); // (A)...wirft Parse(...) eine Exception. Deswegen der try-catch-Block hier.
                }catch(Exception ex)
                {
                    Console.WriteLine($"Converting {dateString} not possible. {ex.Message}");
                }
                Console.WriteLine($"Converted {dateString} to {convertedDate.Kind} time {convertedDate}");
            }

            //Manuell zuammensetzen (keine gute Idee, aber möglich)
            int jahr = DateTime.Now.Year;
            // usw.

            //Damit die Konsole nicht gleich verschwindet.
            Console.ReadLine();

        }
    }
}
