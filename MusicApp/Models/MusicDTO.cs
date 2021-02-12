using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class MusicDTO
    {
        static HttpClient client = new HttpClient();
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public static async Task<List<MusicDTO>> GetMusicsAsync()
        {
            List<MusicDTO> musics = new List<MusicDTO>();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44369/api/Musics");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                musics = JsonConvert.DeserializeObject<List<MusicDTO>>(data);
            }
            return musics;
        }

        public static async Task<bool> CreateProductAsync(MusicDTO music)
        {
            string musicJs = JsonConvert.SerializeObject(music);
            StringContent data = new StringContent(musicJs, Encoding.UTF8, "application/json");

            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44369/api/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await Client.PostAsync("Musics", data);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
