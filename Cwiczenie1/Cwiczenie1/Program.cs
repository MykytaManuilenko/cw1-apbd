using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace Cwiczenie1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");

                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error!!!");
                    return;
                }

                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);
                //==============kolekcje
                //var set = new HashSet<string>();
                //var list = new List<string>();
                //var slownik = new Dictionary<string, string>();

                //=============LINQ
                var list = new List<string>();
                var el = from e in list
                         where e.StartsWith("A")
                         select e;

                var el2 = list.Where(s => s.StartsWith("A"));


                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }

            }catch(Exception ex)
            {
                //string.Format("Wystapil blad {0}", ex.ToString());
                Console.WriteLine($"Wystapil blad {ex.ToString()}");
            }
            Console.WriteLine("Koniec!");
        }
    }
}
