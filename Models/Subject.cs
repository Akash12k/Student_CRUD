namespace Student_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Subject
    {
        public int S_id { get; set; }

        [Required]
        public string Subject_opted { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
