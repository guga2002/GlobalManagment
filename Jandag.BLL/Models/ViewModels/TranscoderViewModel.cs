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

        [Display(Name = "არხის სახელი")]
        public string CHanellName { get; set; }

        [Display(Name = "ტრანსკოდირების ფორმატი")]
        public TransocdingFormat TransocdingFormat { get; set; }

        [Display(Name = "იემერის მისამართი")]
        public int EmrNumber { get; set; }

        [Display(Name = "ქარდი")]
        public string Card { get; set; }

        [Display(Name = "პორტი")]
        public string Port { get; set; }
    }

    public enum TransocdingFormat
    {
        [Display(Name = "MPEG-2")]
        Mpeg2,
        [Display(Name = "MPEG-4")]
        mpeg4,
        [Display(Name = "HD")]
        HD,
        [Display(Name = "SD")]
        Sd

    }
}
