using Phieu_khai_thai.Data;

namespace Phieu_khai_thai.Services
{
    public interface IApiService
    {
        Task<ResponseApi<ResponLogin<Function>>> Login(string userName, string passWord);
        Task<ResponseApi<List<DataLocation>>> GetLocation(string token);

        Task<ResponseApi<List<Eninlocation>>> GetEninlocations(string token,string value,string fromdate, string todate);

        Task<ResponseApi<EncounterInfo>> GetInforEncounter(string token,string encounter);

    }
}
