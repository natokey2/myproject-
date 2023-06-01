using System;
using ReceptWebApi.Models.DTO;

namespace ReceptWebApi.Repository.Interfaces
{

    //defineras skalet för de metoder som skall 
    //finnas i personRepo.skapar en lösare koppling
    //I detta fallet behövs ett interface för att kunna
    //sätta upp dependency injection
	public interface IPersonRepo
	{

        public PersonResponseDto LoginPerson(PersonLoginInputDTO loginInputDTO);

        public string InsertPerson(PersonInsertInputDTO personInputDto);

        public string UpdatePerson(PersonInsertInputDTO updateinfo, int id);

        public string DeletePerson(int id);






    }
}

