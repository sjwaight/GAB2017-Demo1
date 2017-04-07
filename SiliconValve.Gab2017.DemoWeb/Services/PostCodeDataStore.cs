using SiliconValve.Gab2017.DemoWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace SiliconValve.Gab2017.DemoWeb.Services
{
    public class PostCodeDataStore
    {
        private static List<PostcodeEntry> dataSource;

        public static List<PostcodeEntry> Instance
        {
            get
            {
                if(dataSource == null || dataSource.Count == 0)
                {
                    dataSource = File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/data.csv"))
                                           .Skip(1)
                                           .Select(v => PostcodeEntry.FromCsv(v))
                                           .ToList();
                }

                return dataSource;
            }
        }
    }
}