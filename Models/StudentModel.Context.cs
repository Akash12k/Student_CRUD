namespace Student_CRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StudentEntities4 : DbContext
    {
        public StudentEntities4()
            : base("name=StudentEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CreateStudent(string s_Name, Nullable<int> s_Age, string s_Address, string subject_opted)
        {
            var s_NameParameter = s_Name != null ?
                new ObjectParameter("S_Name", s_Name) :
                new ObjectParameter("S_Name", typeof(string));
    
            var s_AgeParameter = s_Age.HasValue ?
                new ObjectParameter("S_Age", s_Age) :
                new ObjectParameter("S_Age", typeof(int));
    
            var s_AddressParameter = s_Address != null ?
                new ObjectParameter("S_Address", s_Address) :
                new ObjectParameter("S_Address", typeof(string));
    
            var subject_optedParameter = subject_opted != null ?
                new ObjectParameter("Subject_opted", subject_opted) :
                new ObjectParameter("Subject_opted", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateStudent", s_NameParameter, s_AgeParameter, s_AddressParameter, subject_optedParameter);
        }
    
        public virtual int DeleteStudent(Nullable<int> s_id)
        {
            var s_idParameter = s_id.HasValue ?
                new ObjectParameter("S_id", s_id) :
                new ObjectParameter("S_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudent", s_idParameter);
        }
    
        public virtual int UpdateStudent(Nullable<int> s_id, string s_Name, Nullable<int> s_Age, string s_Address, string subject_opted)
        {
            var s_idParameter = s_id.HasValue ?
                new ObjectParameter("S_id", s_id) :
                new ObjectParameter("S_id", typeof(int));
    
            var s_NameParameter = s_Name != null ?
                new ObjectParameter("S_Name", s_Name) :
                new ObjectParameter("S_Name", typeof(string));
    
            var s_AgeParameter = s_Age.HasValue ?
                new ObjectParameter("S_Age", s_Age) :
                new ObjectParameter("S_Age", typeof(int));
    
            var s_AddressParameter = s_Address != null ?
                new ObjectParameter("S_Address", s_Address) :
                new ObjectParameter("S_Address", typeof(string));
    
            var subject_optedParameter = subject_opted != null ?
                new ObjectParameter("Subject_opted", subject_opted) :
                new ObjectParameter("Subject_opted", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateStudent", s_idParameter, s_NameParameter, s_AgeParameter, s_AddressParameter, subject_optedParameter);
        }
    }
}
