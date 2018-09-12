using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsurancePractice.Models;


namespace InsurancePractice.Core.Repository
{
    public interface IInsuranceRepository
    {

        /// <summary>
        /// Here is an interface that is just showing what the repository is expected to be doing.
        /// It is allowing you to separate from what and how it is doing its operations.
        /// </summary>
        /// <returns></returns>
        List<RootObject> GetAll();
        List<RootObject> GetAll(string json);
        RootObject GetInsuranceId(int id);
        List<RootObject> SortHighestRate();

        List<RootObject> PostNewRandom();
    }
}