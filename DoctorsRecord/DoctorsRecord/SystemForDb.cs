using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsRecord
{
    public class SystemForDb
    {
        public void InsertPatient(Patient patient)
        {
            using (HospitalContext context = new HospitalContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
        }

        public void InsertDoctor(Doctor doctor)
        {
            using (HospitalContext context = new HospitalContext())
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
            }
        }

        public void InsertApplications(Application application)
        {
            using (HospitalContext context = new HospitalContext())
            {
                context.Applications.Add(application);
                context.SaveChanges();
            }
        }

        public List<Application> SelectApplication()
        {
            List<Application> result = new List<Application>();

            using (HospitalContext context = new HospitalContext())
            {
                result = context.Applications.ToList();
            }
            return result;
        }

        public List<Doctor> SelectDoctors()
        {
            List<Doctor> result = new List<Doctor>();

            using (HospitalContext context = new HospitalContext())
            {
                result = context.Doctors.ToList();
            }
            return result;
        }

        public List<Patient> SelectPatients()
        {
            List<Patient> result = new List<Patient>();

            using (HospitalContext context = new HospitalContext())
            {
                result = context.Patients.ToList();
            }
            return result;
        }

        public Patient ChoisePatient(int id)
        {
            List<Patient> patients = new List<Patient>();

            using (HospitalContext context = new HospitalContext())
            {                
                patients = context.Patients.ToList();
            }

            Patient patient = new Patient();

            foreach (var i in patients)
            {
                if (i.Id == id)
                    patient = i;
            }

            return patient;
        }

        public Doctor ChoiseDoctor(int id)
        {
            List<Doctor> boctors = new List<Doctor>();

            using (HospitalContext context = new HospitalContext())
            {
                boctors = context.Doctors.ToList();
            }

            Doctor doctor = new Doctor();

            foreach (var i in boctors)
            {
                if (i.Id == id)
                    doctor = i;
            }

            return doctor;
        }

        public Application ChoiseApplication(int id)
        {
            List<Application> applications = new List<Application>();

            using (HospitalContext context = new HospitalContext())
            {
                applications = context.Applications.ToList();
            }

            Application application = new Application();

            foreach (var i in applications)
            {
                if (i.Id == id)
                    application = i;
            }

            return application;
        }
    }
}
