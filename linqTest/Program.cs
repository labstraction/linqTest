namespace linqTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temperatures = new List<double> { 30.5, 32.0, 31.5, 29.0, 28.5, 30.0, 31.0, 32.5, 33.0, 34.0 };
            var cities = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" };
            var students = new List<Student>
            {
                new Student("Grace", 20, true),
                new Student("Bob", 22, false),
                new Student("Charlie", 21, true),
                new Student("Grace", 23, false),
                new Student("Eve", 19, true),
                new Student("Frank", 24, false),
                new Student("Grace", 20, true),
                new Student("Heidi", 22, false),
                new Student("Ivan", 21, true),
                new Student("Judy", 23, false)
            };


            var cityTemperature = new Dictionary<string, double>()
            {
                { "New York", 30.5 },
                { "Los Angeles", 32.0 },
                { "Chicago", 31.5 },
                { "Houston", 29.0 },
                { "Phoenix", 28.5 },
                { "Philadelphia", 30.0 },
                { "San Antonio", 31.0 },
                { "San Diego", 32.5 },
                { "Dallas", 33.0 },
                { "San Jose", 34.0 }
            };

            var nicknameStudent = new Dictionary<string, Student>()
            {
                { "pippo", new Student("Grace", 20, true)},
                { "pluto", new Student("Bob", 22, false)},
                { "paperino", new Student("Charlie", 21, true)},
                { "topolino", new Student("Grace", 23, false)},
                { "minnie", new Student("Eve", 19, true)},
                { "topastro", new Student("Frank", 24, false)},
                { "paperina", new Student("Grace", 20, true)},
                { "pippo2", new Student("Heidi", 22, false)},
                { "pluto2", new Student("Ivan", 21, true)},
                { "paperino2", new Student("Judy", 23, false)}
            }; 


            var temperatureAbove30 = temperatures.Where(t => t > 30).ToList();

            var temperatureAbove30sql = (from t in temperatures
                                        where t > 30
                                        select t).ToList();

            var temperatureAbove30Ordered = temperatures
                                            .Where(t => t > 30)
                                            .OrderByDescending(t => t)
                                            .ToList();

            var temperatureAbove30Ordered2 = temperatures
                                            .OrderByDescending(t => t)
                                            .Where(t => t > 30)
                                            .ToList();

            var firstTwoCitiesStartingWithS = cities
                                            .Where(c => c.ToLower().StartsWith("s"))
                                            .Take(2)
                                            .ToList();

            var firstCityStartingWithS = cities
                                            .Where(c => c.ToLower().StartsWith("a"))
                                            .FirstOrDefault();

            var studentsOrdersByNameAndAge = students
                                            .OrderBy(s => s.Name)
                                            .ThenByDescending(s => s.Age)
                                            .ToList();

            var citiesWithTemperatureAbove30 = cityTemperature
                                            .Where(kv => kv.Value > 30)
                                            .Select(kv => kv.Key)
                                            .ToList();


            //Console.WriteLine($"city: {firstCityStartingWithS}");
            for (int i = 0; i < citiesWithTemperatureAbove30.Count; i++)
            {
                Console.WriteLine($"{citiesWithTemperatureAbove30[i]}");
            }
        }
    }
}
