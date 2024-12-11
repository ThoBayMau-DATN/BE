using BACK_END.DTOs.Count;

namespace BACK_END.Services.Interfaces
{
    public interface IHome
    {
        public Task<List<CountDtos>> CountHomePage();

    }
}


