using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.WorkDtos
{
    public class WorkUpdateDto: IDto
    {
        [Range(1,int.MaxValue,ErrorMessage ="Id zorunlu")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Zorunlu")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
