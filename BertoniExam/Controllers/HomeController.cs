using BertoniExam.Models;
using BertoniExam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BertoniExam.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient Client { get; }
        private TypiCodeService _typiCodeService;

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            _typiCodeService = new TypiCodeService(Client);
            var albums = await _typiCodeService.GetAlbumsAsync();
            var albumsViewModel = new AlbumsViewModel
            {
                Albums = albums
            };
            return View(albumsViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> ViewAlbum(int id)
        {
            _typiCodeService = new TypiCodeService(Client);
            var photos = await _typiCodeService.GetPhotosAsync(id);
            var photosViewModel = new PhotosViewModel
            {
                Photos = photos
            };
            return View("AlbumPhotos",photosViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> ViewComments(int id)
        {
            _typiCodeService = new TypiCodeService(Client);
            var comments = await _typiCodeService.GetCommentsAsync(id);
            var commentsViewModel = new CommentsViewModel
            {
                Comments = comments
            };
            return PartialView("_Comments", commentsViewModel);
        }

    }
}