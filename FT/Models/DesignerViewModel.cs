using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FT.Models
{
    public class DesignerViewModel
    {
        public string Name { get; set; }

        public string HeadShot { get; set; }

        public List<string> Designs { get; set; }

        public List<string> Bio { get; set; }

        public string MainDesign { get; set; }

        public string Description { get; set; }

        public string ImageFolderName { get; set; }

        public DesignerViewModel()
        {
            Bio = new List<string>();
            Designs = new List<string>();
        }
    }
}