using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dapper;
using System.Data.SqlClient;
using System.Data;

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
        public ActionResult<IEnumerable<EmployeeRoutes>> GetAllEmployeeRoutes()
        {
            IEnumerable<EmployeeRoutes> result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                result = connection.Query<EmployeeRoutes>("GetAllEmployeeRoutes", commandType: CommandType.StoredProcedure);
            }

            return result.ToList();
        }

        /// <summary>
        /// Gets location of employee by Id
        /// </summary>
        /// <param name="EmployeeId">The EmployeeId.</param>
        /// <returns>retuns location of employee by EmployeeId</returns>

        [Route("{EmployeeId}")]
        [HttpGet]
        public ActionResult<EmployeeRoutes> GetEmployeeRoutesByEmployeeId(int EmployeeId)
        {
            EmployeeRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", dbType: DbType.Int32, value: EmployeeId, direction: ParameterDirection.Input);
                result = connection.QuerySingle<EmployeeRoutes>("GetEmployeeRoutesByEmployeeId", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Insert location of employee
        /// </summary>
        /// <param name="request">The employee route request Body</param>
        /// <returns>returns inserted employee route record</returns>
        [HttpPost]
        public ActionResult<EmployeeRoutes> InsertEmployeeRoutes(EmployeeRoutesRequest request)
        {
            EmployeeRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                
                parameters.Add("@EmployeeId", dbType: DbType.Int32, value: request.EmployeeId, direction: ParameterDirection.Input);
                parameters.Add("@X", dbType: DbType.Decimal, value: request.X, direction: ParameterDirection.Input);
                parameters.Add("@Y", dbType: DbType.Decimal, value: request.Y, direction: ParameterDirection.Input);
                parameters.Add("@NearByRouteId", dbType: DbType.Int32, value: request.NearByRouteId, direction: ParameterDirection.Input);
                
                result = connection.QuerySingle<EmployeeRoutes>("InsertEmployeeRoutes", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Updates location of employee
        /// </summary>        
        /// <param name="Id">The Id</param>
        /// <param name="request">The EmployeeRoutes Request Body</param>
        /// <returns>returns updated EmployeeRoutes record</returns>
        [HttpPatch]
        [Route("{Id}")]
        public ActionResult<EmployeeRoutes> UpdateEmployeeRoutes(int Id, EmployeeRoutesRequest request)
        {
            EmployeeRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                parameters.Add("@EmployeeId", dbType: DbType.Int32, value: request.EmployeeId, direction: ParameterDirection.Input);
                parameters.Add("@X", dbType: DbType.Decimal, value: request.X, direction: ParameterDirection.Input);
                parameters.Add("@Y", dbType: DbType.Decimal, value: request.Y, direction: ParameterDirection.Input);
                parameters.Add("@NearByRouteId", dbType: DbType.Int32, value: request.NearByRouteId, direction: ParameterDirection.Input);
                result = connection.QuerySingle<EmployeeRoutes>("UpdateEmployeeRoutes", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        
        /// <summary>
        /// Delete location of employee by employeeId
        /// </summary>
        /// <param name="Id">The EmployeeRoutesId</param>
        /// <returns>returns empty result</returns>
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult<string> DeleteEmployeeRoutes(int Id)
        {
            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                connection.Query("DeleteEmployeeRoutesById", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return "Record is deleted successfully";
        }
        #endregion

        #region Private Methods
        // private List<EmployeeLocation> GetAllEmployeeLocationsFromJson()
        // {
        //     var jsonData = System.IO.File.ReadAllText(Startup.HostingEnvironment.ContentRootPath + "/data/employee-location.json");

        //     List<EmployeeLocation> list = JsonConvert.DeserializeObject<List<EmployeeLocation>>(jsonData).ToList();

        //     return list;
        // }
        #endregion
    }
}