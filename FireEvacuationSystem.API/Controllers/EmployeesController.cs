using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace FireEvacuationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        #region  Employee Details

        /// <summary>
        /// Gets details of all employees
        /// </summary>        
        /// <returns>returns all employee records</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployee()
        {
            IEnumerable<Employee> result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                result = connection.Query<Employee>("GetAllEmployee", commandType: CommandType.StoredProcedure);
            }

            return result.ToList();
        }

        /// <summary>
        /// Gets Employee details by EmployeeId
        /// </summary>
        /// <param name="Id">The EmployeeId</param>
        /// <returns>returns employee record by EmployeeId</returns>
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Employee> GetEmployee(int Id)
        {
            Employee result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                result = connection.QuerySingle<Employee>("GetEmployeeById", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }


        /// <summary>
        /// Insert Employee details
        /// </summary>
        /// <param name="request">The Employee Request Body</param>
        /// <returns>returns inserted employee record</returns>
        [HttpPost]
        public ActionResult<Employee> InsertEmployee(EmployeeRequest request)
        {
            Employee result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
                result = connection.QuerySingle<Employee>("InsertEmployee", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Update Employee details
        /// </summary>        
        /// <param name="Id">The EmployeeId</param>
        /// <param name="request">The Employee Request Body</param>
        /// <returns>returns updated employee record</returns>
        [HttpPatch]
        [Route("{Id}")]
        public ActionResult<Employee> UpdateEmployee(int Id, EmployeeRequest request)
        {
            Employee result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                parameters.Add("@Name", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
                result = connection.QuerySingle<Employee>("UpdateEmployee", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        
        /// <summary>
        /// Delete Employee details by EmployeeId
        /// </summary>
        /// <param name="Id">The EmployeeId</param>
        /// <returns>returns empty result</returns>
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult<string> DeleteEmployee(int Id)
        {
            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                connection.Query("DeleteEmployeeById", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return "Record is deleted successfully";
        }

        #endregion

        #region Private Methods
        // private List<Employee> GetAllEmployeeFromJson()
        // {
        //     var jsonData = System.IO.File.ReadAllText(Startup.HostingEnvironment.ContentRootPath + "/data/employee.json");

        //     List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(jsonData).ToList();

        //     return list;
        // }
        #endregion
    }
}
