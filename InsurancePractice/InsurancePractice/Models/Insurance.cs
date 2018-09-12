using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsurancePractice.Models
{
    public class RootObject
    {
        /// <summary>
        /// RootObject contains all of the properties from the Json file that will be deserialized into an object.
        /// In theory, we are using getters and setters for each property because if a SQL server is going to be utlizied,
        /// we will be able to use other http requests such as POST, DELETE, and UPDATE.
        /// Id will be the primary key if this was created into the table and will be the link for other tables
        /// if a realtion is required.
        /// </summary>
        public int Id { get; set; }
        public string Company_Name { get; set; }
        public string Product_Type { get; set; }
        public string Email { get; set; }
        public double Rate { get; set; }

        public RootObject(int id, string company, string product, string email, double rate)
        {
            Id = id;
            Company_Name = company;
            Product_Type = product;
            Email = email;
            Rate = rate;
        }
    }

 
    
}
