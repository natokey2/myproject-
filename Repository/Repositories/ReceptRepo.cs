using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ReceptWebApi.Models.Domain;
using ReceptWebApi.Models.DTO;
using ReceptWebApi.Repository.Interfaces;

namespace ReceptWebApi.Repository.Repositories
{
    //Genom att implementeras inetrfacet måste Repositories
    //ha alla metoder som finns specade i interfacet
	public class ReceptRepo:IReceptRepo
	{
		private readonly string _connString;
        // configration läggs automatiskt i DI containern.för att
        // använda det måste det injectas på detta sätt

		public ReceptRepo(IConfiguration configuration)
		{
			_connString = configuration.GetConnectionString("MatReceptDB");
		}

        public List<ReceptResponseDto> GetAllRecepts()
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {

                var  recepts = (List<ReceptResponseDto>)conn.Query<ReceptResponseDto>("SP_GetAll_Recepts", commandType: CommandType.StoredProcedure);

                if (recepts.Count > 0)
                {
                    return recepts;
                }

                return null;

            }
        }
        public Recept GetIndividualReceptById(int receptId)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ReceptId", receptId);
                var recept = conn.QuerySingle<Recept>("sp_getrecept_byReceptId", parameters, commandType: CommandType.StoredProcedure);
                if (recept != null)
                {
                    return recept;
                }

                return null;

            }
        }
        public ReceptResponseDto GetReceptByTitle(string title)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Title", title);
                var recept = (ReceptResponseDto)conn.QuerySingle<ReceptResponseDto>("sp_serach_recept_bytitle", parameters, commandType: CommandType.StoredProcedure);
                if (recept != null)
                {
                    return recept;
                }

                return null;

            }
        }
        public List<ReceptResponseDto> GetAvailableReceptsByPersonId(int personId)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonId", personId);
                var recepts = (List<ReceptResponseDto>)conn.Query<ReceptResponseDto>("sp_getrecepts_byPersonId", parameters, commandType: CommandType.StoredProcedure);
                if (recepts != null)
                {
                    return recepts;
                }

                return null;

            }
        }
        public ReceptStatusResponseDto InsertReceptByPersonId(ReceptInputInsertDto receptInputDto, int personId)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Title", receptInputDto.Title);
                parameters.Add("@Description", receptInputDto.Description);
                parameters.Add("@Ingredients", receptInputDto.Ingredients);
                parameters.Add("@CategoryId", receptInputDto.CategoryId);
                parameters.Add("@PersonId", personId);

                ReceptStatusResponseDto response = (ReceptStatusResponseDto)conn.QuerySingle<ReceptStatusResponseDto>("sp_insertrecept_byPersonId", parameters, commandType: CommandType.StoredProcedure);

                if (response != null)
                {
                    return response;
                }

                return null;

            }
        }
        public ReceptStatusResponseDto UpdateReceptById(ReceptUpdateDto updateinfo, int personId, int receptId)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Title", updateinfo.Title);
                parameters.Add("@Description", updateinfo.Description);
                parameters.Add("@Ingredients", updateinfo.Ingredients);
                parameters.Add("@ReceptId", receptId);
                parameters.Add("@PersonId", personId);

                ReceptStatusResponseDto response = (ReceptStatusResponseDto)conn.QuerySingle<ReceptStatusResponseDto>("sp_update_recept_byid", parameters, commandType: CommandType.StoredProcedure);

                if (response != null)
                {
                    return response;
                }

                return null;

            }
        }
        public string DeleteReceptById(int personId, int receptId)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonId", personId);
                parameters.Add("@ReceptId", receptId);

                var success = conn.Execute("sp_delete_recept_byid", parameters, commandType: CommandType.StoredProcedure);
                if (success > 0)
                {
                    return "Recept is deleted";
                }

                return "Some thing went wrong";

            }
        }
        public string SetRatingValue(int personId, int receptId, int ratingValue)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonId", personId);
                parameters.Add("@ReceptId", receptId);
                parameters.Add("@Rating", ratingValue);

                var response = conn.Execute("sp_insert_update_rating_byId", parameters, commandType: CommandType.StoredProcedure);

                if (response > 0)
                {
                    return "Rating value is updated";
                }

                return "Something went wrong!!";

            }
        }

    }
}

