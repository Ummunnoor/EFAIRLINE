using EFAIRLINE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.DTOs
{
    public class CreateAirCraftDto
    {
       public string Number { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
   
    public class GetAirCraftDto
    {
         public int Capacity { get; set; } 
    }


}