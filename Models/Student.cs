namespace Student_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public int S_id { get; set; }

        [Required]
        public string S_Name { get; set; }
        public Nullable<int> S_Age { get; set; }
    
        public virtual Address Address { get; set; }


        public virtual Subject Subject { get; set; }
    }
}
