using BertoniExam.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BertoniExam.Services
{
    public class TypiCodeService
    {
        private HttpClient Client { get; set; }

        public TypiCodeService (HttpClient client)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            Client = client;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            var response = await Client.GetAsync("/albums");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(jsonResponse);
            return albums;
        }
        public async Task<List<Photo>> GetPhotosAsync(int albumId)
        {
            var response = await Client.GetAsync("/photos");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse).Where(photo =>photo.AlbumId==albumId).ToList();
            return photos;
        }
        public async Task<List<Comment>> GetCommentsAsync(int photoId)
        {
            var response = await Client.GetAsync("/comments");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(jsonResponse).Where(comment => comment.PostId == photoId).ToList();
            return comments;
        }
    }
}