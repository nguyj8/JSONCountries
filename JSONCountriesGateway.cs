using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace JSONCountries
{
    public class JSONCountriesGateway // Information is entering through
    {
        private HttpClient http = null;
        private Country[] countries;

        public JSONCountriesGateway()
        {
            http = new HttpClient(); // Only want 1 http thus all class variables are private 
        }

        public async Task<Country[]> GetAsianCountries() 
        {
            List<Country> asianCountries = new List<Country>();

            if (countries != null) // If countries are not null, goes through foreach loop 
            {
                foreach (var c in this.countries)
                {
                    if (c.Region == "Asia")
                    {
                        asianCountries.Add(c);
                    }
                }
                return asianCountries.ToArray();
            }
            else
            {
                await GetAllCountries(); // If not run, wait to run and once run, run GetAsianCountries
                return await GetAsianCountries();
            }

        }

        public async Task<Country[]> GetAfricanCountries()
        {
            List<Country> africanCountries = new List<Country>();

            if (countries != null) 
            {
                foreach (var c in this.countries)
                {
                    if (c.Region == "Africa")
                    {
                        africanCountries.Add(c);
                    }
                }
                return africanCountries.ToArray();
            }
            else
            {
                await GetAllCountries(); 
                return await GetAfricanCountries();
            }

        }

        public async Task<Country[]> GetEuropeanCountries()
        {
            List<Country> europeanCountries = new List<Country>();

            if (countries != null) 
            {
                foreach (var c in this.countries)
                {
                    if (c.Region == "Europe")
                    {
                        europeanCountries.Add(c);
                    }
                }
                return europeanCountries.ToArray();
            }
            else
            {
                await GetAllCountries(); 
                return await GetEuropeanCountries();
            }

        }

        public async Task<Country[]> GetAmericanCountries()
        {
            List<Country> americanCountries = new List<Country>();

            if (countries != null) 
            {
                var somecountries = from c in countries // using System.Linq is alike SQL that Microsoft VS included with C# 
                                    where c.Region == "Americas"
                                    select c;
                var someothercountries = from c in somecountries 
                                    where c.Name != "Mexico"
                                    select c;


                americanCountries = somecountries.ToList();

                return americanCountries.ToArray();
            }
            else
            {
                await GetAllCountries(); 
                return await GetAmericanCountries();
            }

        }


        public async Task<Country[]> GetAllCountries()
        {
            HttpResponseMessage response = await http.GetAsync("https://restcountries.com/v2/all");
            // await is running it asynchronously and awaits til it finishes
            // response is the response from the website or an error messagae

            if (response.StatusCode == HttpStatusCode.OK) // OK is 200 status which is a 'success' 
            {
                var content = await response.Content.ReadAsStringAsync();
                countries = JsonConvert.DeserializeObject<Country[]>(content);
            }
            return countries;
        }

    }
}
