using Models;

namespace DataAccess.Data
{
    public interface ICitiesPopData
    {
        Task DeleteCity(int id);
        Task<IEnumerable<CitiesPopulationModel>> GetCities();
        Task<CitiesPopulationModel?> GetCity(int id);
        Task InsertCity(CitiesPopulationModel city);
        Task UpdateCity(CitiesPopulationModel city);
    }
}