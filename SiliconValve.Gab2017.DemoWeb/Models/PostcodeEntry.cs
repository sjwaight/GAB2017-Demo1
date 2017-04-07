using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace SiliconValve.Gab2017.DemoWeb.Models
{
    public class PostcodeEntry
    {       
        public string PostCode { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }

        public string DC { get; set; }

        public string EntryType { get; set; }

        public GeoCoordinate Location { get; set; }

        // based on: http://stackoverflow.com/questions/26790477/read-csv-to-list-of-objects
        public static PostcodeEntry FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');

            return new PostcodeEntry
            {
                PostCode = values[0],
                Suburb = values[1],
                State = values[2],
                DC = values[3],
                EntryType = values[4].Trim(),
                Location = new GeoCoordinate(double.Parse(values[5]), double.Parse(values[6]))
            };
        }
    }
}