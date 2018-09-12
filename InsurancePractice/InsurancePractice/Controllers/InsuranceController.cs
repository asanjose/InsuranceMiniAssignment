using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsurancePractice.Models;
using InsurancePractice.Core;
using System.Web.Http.Cors;
using InsurancePractice.Persistence;

namespace InsurancePractice.Controllers
{
    /// <summary>
    /// Cors is an added security measurement with http requests.
    /// The origins is saying that only this url will be able to access any of the api calls within
    /// this controllers.
    /// If you want to provide access to any url, methods (HttpPut, HttpPost, HttpDelete), or headers
    /// you would just use the "*" key.
    /// 
    /// The repo is instantiating the repository so the api controller can utilize all the methods provided within it.
    /// This allows the "how" to be separated from what is being sent to the user making a request from the api.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "Content-Type", methods: "*")]

    public class InsuranceController : ApiController
    {
        
        InsuranceRepository repo = new InsuranceRepository();
        public IHttpActionResult GetAllInsurance()
        {
            var insurance = repo.GetAll();
            return Ok(insurance);
        }

        public IHttpActionResult GetInsuranceBy(int id)
        {

            var insurance = repo.GetInsuranceId(id);

            if (insurance == null)
            {
                return NotFound();
            }

            else
                return Ok(insurance);

        }

        [Route("api/AddRandom")]
        
        public IHttpActionResult PostHardCodedObject()
        {
            var insurance = repo.PostNewRandom();
            if (insurance == null)
            {
                return NotFound();
            }

            else
                return Ok(insurance);

        }

        [HttpDelete, Route("api/DeleteRandom/{id}")]
        public IHttpActionResult DeleteHardCodedObject(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Needs to be a valid ID");
            }

            else
            {
                repo.DeleteNewRandom(id);
                var insurance = GetAllInsurance();
                return Ok(insurance);
            }
        }

        [Route("api/SortedRate")]
        public IHttpActionResult GetSortedHighestRate()
        {
            var insurance = repo.SortHighestRate();
            return Ok(insurance);
        }


    }

}
