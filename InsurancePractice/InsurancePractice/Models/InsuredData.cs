using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InsurancePractice.Models
{
    public class InsuredData
    {
        /// <summary>
        /// This class is used to separate some functionality from the RootObject class.
        /// The code below will show you how to use Newtonsoft.Json to deserialize the json file given in the path.
        /// string json variable is used so the json file can be converted into a string.
        /// var result variable is used to convert the json into a list of objects since the json file contains
        /// an array of the RootObject.
        /// The reason it is a list because the get method is expecting an Ienumerable or collection to receive.
        /// </summary>
        public List<RootObject> InsuranceDetails { get; set; }
        public string NewJson { get; set; }
        
        public InsuredData()
        {

        }
        public InsuredData(string json)
        {
            NewJson = json;
        }

        public List<RootObject> DeserializeInsurance()
        {
            using (StreamReader file = new StreamReader(@"c:\Users\aaron.jose\Downloads\MOCK_DATA.json"))
            {
                string json = file.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<RootObject>>(json);
                return result;
            }

            /*
            using (StreamReader file = File.OpenText(@"c:\Users\aaron.jose\Downloads\MOCK_DATA.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                InsuredData movie2 = (InsuredData)serializer.Deserialize(file, typeof(InsuredData));
                return movie2;
            }*/

        }

        //This method is called for the overloaded GetAll() so you can deserialize it
        public List<RootObject> DeserializeInsurance(string json)
        {
            var result = JsonConvert.DeserializeObject<List<RootObject>>(json);
            return result;

        }
        //This method receives a collection and turns it into a jsonfile
        public string SerializeInsurance(List<RootObject> json)
        {
            var converted = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText(@"c:\Users\aaron.jose\Downloads\MOCK_DATA.json",converted);
            return converted;
        }
    }
}