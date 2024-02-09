using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class ErrorRes
    {
        public int StatusCode { get; set; }
        public string? Massage { get; set; }
        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize(this);
        //}
    }
}
