using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ReceptWebApi.Repository.Interfaces;
using ReceptWebApi.Models.DTO;


namespace ReceptWebApi.Repository.Repositories
{
	public class PersonRepo:IPersonRepo
	{
		private readonly string _connString;
		public PersonRepo(IConfiguration config)
		{
			_connString = config.GetConnectionString("MatReceptDB");
		}

        public string InsertPerson(PersonInsertInputDTO personInputDto)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonName", personInputDto.PersonName);
                parameters.Add("@Email", personInputDto.Email);
                parameters.Add("@Password", personInputDto.Password);

                var success = conn.Execute("sp_insert_person", parameters, commandType: CommandType.StoredProcedure);

                if (success > 0)
                {
                    return "New User is Inserted";
                }

                return "something went wrong";

            }
        }

        public PersonResponseDto LoginPerson(PersonLoginInputDTO loginInputDTO)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email", loginInputDTO.Email);
                parameters.Add("@Password", loginInputDTO.Password);

                var person = conn.QueryFirst<PersonResponseDto>("sp_getperson_email_password"
                    , parameters, commandType: CommandType.StoredProcedure);
                return person;

            }
        }
        public string UpdatePerson(PersonInsertInputDTO updateinfo, int id)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonId", id);
                parameters.Add("@PersonName", updateinfo.PersonName);
                parameters.Add("@Email", updateinfo.Email);
                parameters.Add("@Password", updateinfo.Password);

                var success = conn.Execute("sp_person_update", parameters, commandType: CommandType.StoredProcedure);

                if (success > 0)
                {
                    return "User information is updated";
                }

                return "something went wrong";
            }
        }

        public string DeletePerson(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PersonId", id);

                var success = conn.Execute("sp_person_available_status", parameters, commandType: CommandType.StoredProcedure);

                if (success > 0)
                {
                    return "person is deleted from the database";
                }

                return "something went wrong";
            }
        }


    }
}

