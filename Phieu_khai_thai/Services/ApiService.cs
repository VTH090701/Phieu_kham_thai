using Blazored.SessionStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Phieu_khai_thai.Data;
using System;
using System.Text;

namespace Phieu_khai_thai.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

       
        private readonly ISessionStorageService _sessionStorageService;
        public ApiService(HttpClient http

     
            , ISessionStorageService sessionStorageService
            )
        {
            _httpClient = http;
            _sessionStorageService = sessionStorageService;
            
        }

        public async Task<ResponseApi<List<Eninlocation>>> GetEninlocations(string token, string value, string fromdate, string todate)
        {
            string kind = null;

            try
            {
                var para = new
                {
                    location = value,
                    status = "active",
                    from = fromdate,
                    to = todate,
                    active_new_ip = false,
                    kind = kind
                };
                var jsonContent = JsonConvert.SerializeObject(para);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
                string base64EncodedString = Convert.ToBase64String(jsonBytes);




                var request = new HttpRequestMessage(HttpMethod.Get, $"http://14.241.182.251:59325/api/patient/list/{base64EncodedString}");
                request.Headers.Add("token", token);
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadFromJsonAsync<ResponseApi<List<Eninlocation>>>();
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ResponseApi<EncounterInfo>> GetInforEncounter(string token, string encounter)
        {

            try
            {
                var para = new
                {
                    type = "all",
                    encounter = encounter,

                };
                var jsonContent = JsonConvert.SerializeObject(para);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
                string base64EncodedString = Convert.ToBase64String(jsonBytes);


                var request = new HttpRequestMessage(HttpMethod.Get, $"http://14.241.182.251:59325/api/patient/medical/{base64EncodedString}");
                request.Headers.Add("token", token);
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadFromJsonAsync<ResponseApi<EncounterInfo>>();

             

                return result;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<ResponseApi<List<DataLocation>>> GetLocation(string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://14.241.182.251:59325/api/location/list/eyJ0eXBlIjoiYWxsIiwia2luZCI6InRyZWF0bWVudF9yb2xlIn0=");
                request.Headers.Add("token", token);
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadFromJsonAsync< ResponseApi<List<DataLocation>>>();
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
        }

        public async Task<ResponseApi<ResponLogin<Function>>> Login(string userName, string passWord)
        {
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, "http://14.241.182.251:59325/api/user/login");
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "rd_key" ,"i3uJU1ms+3Sj+2sUtQN2GyqT8gvpHwTLcpnCRDAybQclD8XVQiowmglOtz+PKuY1/Bj6yBgnJzozFhcOLgM6DoKd3rmcZXfJN1QQ+/AoA0/BcElT++FDpmoK1UyirKooNUb33+u1NjhpOIY/o1XXHfU12MK8SW5Y+wR8xbLMvksjgx35bqkDBSeHc1aC2uWDvyu8S7NoGXOOhvrqzdl1XAbWBppXCToPfg/54Lff2XLovSxvOKHzwWjDu4Z9KP4W5VbdDl9WZi7g7Df+5jw7zmnkHqB5oyWlBxTF0HK0nilRn5FN5k1s0LfMIJstuS8Lk5s64ORyLD10hqfD0M6POQ==" },
                    { "user" ,    userName },
                    { "password" , passWord }
                };

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadFromJsonAsync<ResponseApi<ResponLogin<Function>>>();

                if (result.Code == "200")
                {
                    var data = new
                    {
                        Display = result.Value.Display,
                        Code = result.Value.Code,
                        Token = result.Value.Token

                    };
                    _sessionStorageService.SetItemAsync("us", data);
  
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Ném lại ngoại lệ để xử lý ở tầng gọi phương thức
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Ném lại ngoại lệ để xử lý ở tầng gọi phương thức
            }

        }
    }
}
