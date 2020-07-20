using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BertoniSolutionTest.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BertoniSolutionTest.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
            _ = new List<Album>();
            List<Album> listaAbum = JsonConvert.DeserializeObject<List<Album>>(json);

            ViewBag.Datos = listaAbum;
            return View(listaAbum);
        }
        [HttpGet]
        public async Task<JsonResult> Lista2(int Id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/photos");
            var photoList = new List<Foto>();
            photoList = JsonConvert.DeserializeObject<List<Foto>>(json);
            var listaFiltrada = photoList.Where(p => p.AlbumId == Id).ToList();

            return Json(listaFiltrada);
        }
        [HttpGet]
        public async Task<JsonResult> CommentsPhoto(int Id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/comments");
            var commentList = new List<Comentario>();
            commentList = JsonConvert.DeserializeObject<List<Comentario>>(json);
            var listaFiltrada = commentList.Where(c => c.PostId == Id).ToList();
            return Json(listaFiltrada);
        }
    }
}