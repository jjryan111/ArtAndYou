using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using Newtonsoft.Json;



namespace ArtAndYou.Models
{
    public class Queries
    {
        public Queries() { } //constructor; created by default if we don't put it here.

        public string ImageSearch(string classification, string culture, string century)
        {
            string ancientSearch = "5th%20century|4th%20century%20|3rd%20century%20CE|2nd%20century%20CE|1st%20century%20CE|1st%20century%20BCE|2nd%20century%20BCE|3rd%20century%20BCE|4th%20century%20BCE|5th%20century%20BCE|6th%20century%20BCE|7th%20century%20BCE|8th%20century%20BCE|9th%20century%20BCE|10th%20century%20BCE|11th%20century%20BCE|12th%20century%20BCE|13th%20century%20BCE|14th%20century%20BCE|15th%20century%20BCE|16th%20century%20BCE|17th%20century%20BCE|18th%20century%20BCE|19th%20century%20BCE|20th%20century%20BCE";
            string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";
            string portfolio = "";
            string photoSize = "?height=500"; //API holds links to photos of difference sizes. This is one option:

            //change 'Ancient' from survey/database to proper search string
            if (century == "Ancient")
            {
                century = ancientSearch;
            }

            //BLOCK FOR HARD CODING SEARCH CRITERIA (for testing purposes):
            //string classSpec = "Paintings";
            //string cultureSpec = "French";
            //string centurySpec = "19th%20century";
            //HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org/object?classification=" + classSpec + "&culture=" + cultureSpec + "&century=" + centurySpec + "&sort=random&hasimage=1&size=100" + APIkey);

            //BLOCK FOR PASSING SEARCH CRITERIA THROUGH METHOD PARAMETERS
            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org/object?classification=" + classification + "&culture=" + culture + "&century=" + century + "&sort=random&hasimage=1&size=100" + APIkey);

            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            /*set   index[0] = totalrecords
                    index[1] = classification
                    index[2] = culture
                    index[3] = century
            */

            //modify classification search string for display
            classification = classification.Replace("%20", " ");

            //modify culture search string for display
            culture = culture.Replace("%20", " ");

            if (culture == "German|French|Italian|British")
            {
                culture = "European";
            }
            else if (culture == "Japanese|Chinese")
            {
                culture = "Asian";
            }

            //switch century from search string to display string
            if (century == ancientSearch)
            {
                century = "Ancient";
            }

            //modify century search string for display
            century = century.Replace("%20", " ");
            century = century.Replace("cent", "Cent");
            century = century.Replace("mill", "Mill");

            portfolio += o["info"]["totalrecords"] + "," + classification + "," + culture + "," + century + ",";

            for (int i = 0; i <= 99; i++)
            {
                try
                {
                    portfolio += o["records"][i]["images"][0]["baseimageurl"] + photoSize + ",";
                }
                catch (Exception)
                {
                    portfolio += "";
                }
            }
            return portfolio;
        }
    }

    public class Input
    {
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Culture { get; set; }
        [Required]
        public string Century { get; set; }
    }

    public class GetName
    {
        [Required]
        public string Name { get; set; }
    }
}
