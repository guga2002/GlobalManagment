using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models.ViewModels
{
    public class TranscoderViewModel
    {
        [Key]
        public int Id { get; set; }
        public string CHanellName { get; set; }
        public TransocdingFormat TransocdingFormat { get; set; }
        public int EmrNumber { get; set; }
        public string Card { get; set; }
        public string Port { get; set; }
    }

    public enum TransocdingFormat
    {
        Mpeg2,
        mpeg4,
        HD,
        Sd

    }
}
