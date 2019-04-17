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
    public class BlockRoutesController : ControllerBase
    {
        #region Route Details
        /// <summary>
        /// Gets details of all routes
        /// </summary>        
        /// <returns>returns all route records</returns>
        [HttpGet]
        public ActionResult<IEnumerable<BlockRoutes>> GetAllBlockRoutes()
        {
            IEnumerable<BlockRoutes> result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                result = connection.Query<BlockRoutes>("GetAllBlockRoutes", commandType: CommandType.StoredProcedure);
            }

            return result.ToList();
        }

        /// <summary>
        /// Gets Route details by RouteId
        /// </summary>
        /// <param name="Id">The RouteId</param>
        /// <returns>returns route record by RouteId</returns>
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<BlockRoutes> GetBlockRoutesById(int Id)
        {
            BlockRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                result = connection.QuerySingle<BlockRoutes>("GetBlockRoutesById", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Insert Route details
        /// </summary>
        /// <param name="request">The Route Request Body</param>
        /// <returns>returns inserted route record</returns>
        [HttpPost]
        public ActionResult<BlockRoutes> InsertBlockRoute(BlockRoutesRequest request)
        {
            BlockRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
                parameters.Add("@StartX", dbType: DbType.Decimal, value: request.StartX, direction: ParameterDirection.Input);
                parameters.Add("@EndX", dbType: DbType.Decimal, value: request.EndX, direction: ParameterDirection.Input);
                parameters.Add("@StartY", dbType: DbType.Decimal, value: request.StartY, direction: ParameterDirection.Input);
                parameters.Add("@EndY", dbType: DbType.Decimal, value: request.EndY, direction: ParameterDirection.Input);
                result = connection.QuerySingle<BlockRoutes>("InsertBlockRoute", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        /// <summary>
        /// Update BlockRoutes details
        /// </summary>        
        /// <param name="Id">The BlockRouteId</param>
        /// <param name="request">The BlockRoutes Request Body</param>
        /// <returns>returns updated blockroute record</returns>
        [HttpPatch]
        [Route("{Id}")]
        public ActionResult<BlockRoutes> UpdateBlockRoutes(int Id, BlockRoutesRequest request)
        {
            BlockRoutes result;

            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                parameters.Add("@Name", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
                parameters.Add("@StartX", dbType: DbType.Decimal, value: request.StartX, direction: ParameterDirection.Input);
                parameters.Add("@EndX", dbType: DbType.Decimal, value: request.EndX, direction: ParameterDirection.Input);
                parameters.Add("@StartY", dbType: DbType.Decimal, value: request.StartY, direction: ParameterDirection.Input);
                parameters.Add("@EndY", dbType: DbType.Decimal, value: request.EndY, direction: ParameterDirection.Input);
                result = connection.QuerySingle<BlockRoutes>("UpdateBlockRoutes", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        
        /// <summary>
        /// Delete BlockRoutes details by BlockRoutesId
        /// </summary>
        /// <param name="Id">The BlockRoutesId</param>
        /// <returns>returns empty result</returns>
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult<string> DeleteBlockRoutes(int Id)
        {
            using (var connection = new SqlConnection(AppSettings.DbConnectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", dbType: DbType.Int32, value: Id, direction: ParameterDirection.Input);
                connection.Query("DeleteBlockRoutesById", param: parameters, commandType: CommandType.StoredProcedure);
            }

            return "Record is deleted successfully";
        }
        #endregion
    }
}