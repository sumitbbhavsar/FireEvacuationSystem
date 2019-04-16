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
    public class EmployeesController : ControllerBase
    {

        #region  Employee Details

        /// <summary>
        /// Gets Employee details by EmployeeId
        /// </summary>
        /// <param name="Id">The EmployeeId</param>
        /// <returns>returns employee record by EmployeeId</returns>
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Employee> GetEmployee(int Id)
        {
            IEnumerable<Employee> list = GetAllEmployeeFromJson();
            Employee result = list.Where(x => x.Id == Id).Single();

            return result;
        }

        /// <summary>
        /// Gets details of all employees
        /// </summary>        
        /// <returns>returns all employee records</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployee()
        {
            return GetAllEmployeeFromJson();
        }

        #endregion

        #region Employee Locations

        /// <summary>
        /// Gets locations of all employees
        /// </summary>        
        /// <returns>returns location of all employees</returns>
        [Route("location")]
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

        [Route("{Id}/location")]
        [HttpGet]
        public ActionResult<EmployeeLocation> GetEmployeeLocation(int Id)
        {
            List<EmployeeLocation> list = GetAllEmployeeLocationsFromJson();
            EmployeeLocation result = list.Where(x => x.Id == Id).Single();

            return result;

        }
        #endregion

        #region Private Methods
        private List<Employee> GetAllEmployeeFromJson()
        {
            var jsonData = System.IO.File.ReadAllText(Startup.HostingEnvironment.ContentRootPath + "/data/employee.json");

            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(jsonData).ToList();

            return list;
        }
        private List<EmployeeLocation> GetAllEmployeeLocationsFromJson()
        {
            var jsonData = System.IO.File.ReadAllText(Startup.HostingEnvironment.ContentRootPath + "/data/employee-location.json");

            List<EmployeeLocation> list = JsonConvert.DeserializeObject<List<EmployeeLocation>>(jsonData).ToList();

            return list;
        }
        #endregion
    }
}
