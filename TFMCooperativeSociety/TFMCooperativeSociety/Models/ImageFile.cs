using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class ImageFile
    {
        public int ImageFileId { get; set; }

        public string FileName { get; set; }

        public string FileExt { get; set; }

        public string FilePath { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreate { get; set; }=DateTime.Now;

        public virtual ApplicationUser AppUser { get; set; }
    }
}