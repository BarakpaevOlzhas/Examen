namespace DoctorsRecord
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalContext : DbContext
    {       
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Doctor> Doctors { set; get; }
        public DbSet<Application> Applications { set; get; }
    }   
}