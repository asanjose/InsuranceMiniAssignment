using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsurancePractice.Models;
using InsurancePractice.Core.Repository;

namespace InsurancePractice.Persistence
{
    /// <summary>
    /// The repository is showcasing how the program is going to operate.
    /// 
    /// GetAll() is a method that will be grabbing the data from the json file and turn it into an object.
    /// It is calling the deserializer from the InsuredData class located in the model folder.
    /// Once it is turned into an object, it will be then turned into a list so it can be processed through the api.
    /// 
    /// GetInsuranceId(id) is a method that will allow a user to input an id in a search box and it will find the matching
    /// id in the json file and send the data to the user requesting it.
    /// 
    /// SortHighestRate() is a method that will finding the highest rate and order them in descending format
    /// from highest to lowest.
    /// 
    /// PostNewRandom() is a method that will add hard coded entry to the json file.
    /// The convert variable is used to have the entry be saved and update the json file or in other therms
    /// It is reserialized to save the updated json entry onto the file itself.
    /// You deserialize the updated file and then call a overload of the GetAll() function
    /// so when that get method is called, it will dynamically change on the angular side.
    /// 
    /// DeleteNewRandom(int id) finds any id that matches the parameter or id in this case
    /// and deletes any it finds within the json file.
    /// 
    /// You will notice in the angular side I try to hard code the id but if you want to properly implement it,
    /// you would create an angular form and call a proper post method.
    /// </summary>
    public class InsuranceRepository: IInsuranceRepository
    {
        public InsuredData test = new InsuredData();
        

        public List<RootObject> GetAll()
        {
            InsuredData awesome = new InsuredData();
            var products = awesome.DeserializeInsurance();
            return products.ToList();
        }

        public List<RootObject> GetAll(string json)
        {
            InsuredData awesome = new InsuredData(json);
            var products = awesome.DeserializeInsurance(json);
            return products.ToList();
        }

        public RootObject GetInsuranceId(int id)
        {
            var products = GetAll();
            var insurance = products.FirstOrDefault((p) => p.Id == id);
            return insurance;
        }

        public List<RootObject> SortHighestRate()
        {
            var products = GetAll();
            var insurance = products.OrderByDescending(p => p.Rate).ToList();
            return insurance;
        }

        public List<RootObject> PostNewRandom()
        {
          
            var products = GetAll();
            products.Add(new RootObject(11, "AaronCo", "Security", "dummy@aaronco.com", 72.87));
            var convert = test.SerializeInsurance(products);
            var insurance = GetAll(convert);
            return insurance;
        }

        public void DeleteNewRandom(int id)
        {
            var products = GetAll();
            var insurance = products.RemoveAll(x => x.Id == id);
            var convert = test.SerializeInsurance(products);
        }
    }
}