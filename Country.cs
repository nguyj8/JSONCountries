using System;
using System.Collections.Generic;

namespace JSONCountries
{
    public class Country
    {
        private string name = "n/a";
        private string capital = "n/a";
        private string region = "n/a";
        private int population = 0;
        private List<string> borders = new List<string>();

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Capital
        {
            get { return this.capital; }
            set { this.capital = value; }
        }
        public string Region
        {
            get { return this.region; }
            set { this.region = value; }
        }
        public int Population
        {
            get { return this.population; }
            set { this.population = value; }
        }
        public List<string> Borders
        {
            get { return this.borders; }
            set { this.borders = value; }
        }

        public override string ToString()
        {
            string msg = "";
            msg += "\tName: " + this.Name + "\n";
            msg += "\tCapital: " + this.Capital + "\n";
            msg += "\tRegion: " + this.Region + "\n";
            msg += "\tPopulation: " + this.Population + "\n";
            msg += "\tBorders:\n";

            foreach (var s in this.Borders)
            {
                msg = msg + "\t\t" + s + "\n"; 
            }
            msg += "\n\n";
            return msg;
        }
    }
}
