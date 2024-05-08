namespace Student_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int S_id { get; set; }
        public string S_Address { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
