﻿using AllModels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.DTO
{
    public class CountryMasterDto
    {
        public Guid CountryId { get; set; }
       
        [Required(ErrorMessage ="Enter valid Information")]
        [MaxLength(100)]
        public string CountryName { get; set; }
        public bool Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<StateMaster> StateMasters { get; set; } = new List<StateMaster>();
    }
}
