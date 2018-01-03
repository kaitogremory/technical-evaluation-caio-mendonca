using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum EnumGenre
    {
        [Display(Name = "Masculino")] Male = 0,
        [Display(Name = "Feminino")] Female = 1
    }
}
