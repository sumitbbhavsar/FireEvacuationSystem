using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FireEvacuationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoutesController : ControllerBase
    {
        #region Employee Routes

        /// <summary>
        /// Gets locations of all employees
        /// </summary>        
        /// <returns>returns location of all employees</returns>        
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeLocation>> GetAllEmployeeLocation()
        {
            return GetAllEmployeeLocationsFromJson();

    

        }

        /// <summary>
        /// Get locations of employee by Id
        /// </summary>
        /// <param name="Id">The EmployeeId.</param>
        /// <returns>retuns location of employee by Id</returns>

        [Route("{Id}")]
        [HttpGet]
        public ActionResult<EmployeeLocation> GetEmployeeLocation(int Id)
        {
            List<EmployeeLocation> list = GetAllEmployeeLocationsFromJson();
            EmployeeLocation result = list.Where(x => x.Id == Id).Single();

            return result;

        }
        #endregion

        #region Private Methods
        private List<EmployeeLocation> GetAllEmployeeLocationsFromJson()
        {
            var jsonData = System.IO.File.ReadAllText(Startup.HostingEnvironment.ContentRootPath + "/data/employee-location.json");

            List<EmployeeLocation> list = JsonConvert.DeserializeObject<List<EmployeeLocation>>(jsonData).ToList();

            return list;
        }
        #endregion
    }
}