using System;
using ReceptWebApi.Models.Domain;
using ReceptWebApi.Models.DTO;

namespace ReceptWebApi.Repository.Interfaces
{
    //defineras skalet för de metoder som skall 
    //finnas i ReceptRepo.skapar en lösare koppling
    //I detta fallet behövs ett interface för att kunna
    //sätta upp dependency injection

    public interface IReceptRepo
    {

        public List<ReceptResponseDto> GetAllRecepts();
        public Recept GetIndividualReceptById(int receptId);
        public ReceptResponseDto GetReceptByTitle(string title);
        public List<ReceptResponseDto> GetAvailableReceptsByPersonId(int personId);
        public ReceptStatusResponseDto InsertReceptByPersonId(ReceptInputInsertDto receptInputDto, int personId);
        public ReceptStatusResponseDto UpdateReceptById(ReceptUpdateDto updateinfo, int personId, int receptId);
        public string DeleteReceptById(int personId, int receptId);
        public string SetRatingValue(int personId, int receptId, int ratingValue);

    }
}

