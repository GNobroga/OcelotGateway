
using Service2.ObjectValues;
using Service2.Utils;

namespace Service2.Services.Impl
{
    public class PeopleService : IPeopleService
    {
        private readonly string _baseAddress;

        public PeopleService(IConfiguration configuration)
        {
            _baseAddress = configuration["ServiceUrls:PeopleAPI"]!;
        }


        public IEnumerable<PeopleVO> FindAll()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseAddress)
            };

            var result = httpClient.GetAsync("people").Result;

            if (!result.IsSuccessStatusCode)
                Console.WriteLine("Unable to make get request");

            var people = result.Content.ReadFromJsonAsync<IEnumerable<PeopleVO>>().Result!;

            return people.Select(p => 
            {
                var modified = p with { Number = InputProcess.ApplyMask(p.Number) };
                return modified;
            });
        }
    }
}