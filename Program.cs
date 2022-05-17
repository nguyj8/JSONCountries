using System;
using System.Threading.Tasks;
// By default, Microsoft does not implement a JSON file in the machine
// Must be inserted with a plugin


namespace JSONCountries
{
    public class Program
    {
        public static void Main(string[] args) // Main does not support asynchronous, thus having another method within a class 
        {
            testCountries().Wait(); // Call method then wait 
            Console.ReadLine(); 
        }

        private async static Task testCountries()
        {
            JSONCountriesGateway aGateway = new JSONCountriesGateway();
            //var countries = await aGateway.GetAllCountries();
            //var countries = await aGateway.GetAsianCountries();
            //var countries = await aGateway.GetAfricanCountries();
            //var countries = await aGateway.GetEuropeanCountries();
            var countries = await aGateway.GetAmericanCountries();


            foreach (var c in countries)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
