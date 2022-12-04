﻿using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.WorkDtos
{
   public class WorkCreateDto:IDto
    {

      
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}
