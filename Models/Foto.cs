using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniSolutionTest.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
