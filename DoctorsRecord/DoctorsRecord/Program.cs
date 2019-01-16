using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (HospitalContext context = new HospitalContext())
            //{
            //    var patientOne = new Patient
            //    {
            //        Id = 1,
            //        FullName = "Chelovek",
            //        Phone = "87076910915"
            //    };

            //    var doctorOne = new Doctor
            //    {
            //        Id = 1,
            //        FullName = "DoctorP",
            //        Specialty = "Stam"
            //    };

            //    var rec = new Application
            //    {
            //        Id = 1,
            //        Doctor = doctorOne,
            //        Patient = patientOne,
            //        RecordingDate = DateTime.Now
            //    };

            //    context.Patients.Add(patientOne);
            //    context.Doctors.Add(doctorOne);
            //    context.Applications.Add(rec);

            //    context.SaveChanges();
            //}

            int choise;
            SystemForDb systemForDb = new SystemForDb();

            bool IsTrue = true;

            while (IsTrue)
            {
                Console.WriteLine("1)Добавить пациента");
                Console.WriteLine("2)Добавить доктора");
                Console.WriteLine("3)Добавить заявку на лечения");
                Console.WriteLine("4)Показать всех пациентов");
                Console.WriteLine("5)Показать всех врачей");
                Console.WriteLine("6)Показать все заявки");
                Console.WriteLine("0)Выход");

                int.TryParse(Console.ReadLine(), out choise);

                switch (choise)
                {
                    case 1:
                        Patient patient = new Patient();

                        Console.WriteLine("Введите полное имя");
                        Console.Write(">> ");
                        patient.FullName = Console.ReadLine(); 

                        Console.WriteLine("Введите телефон");
                        Console.Write(">> ");
                        patient.Phone = Console.ReadLine();

                        systemForDb.InsertPatient(patient);
                        break;

                    case 2:
                        Doctor doctor = new Doctor();

                        Console.WriteLine("Введите полное имя");
                        Console.Write(">>");
                        doctor.FullName = Console.ReadLine();

                        Console.WriteLine("Введите специализацию");
                        Console.Write(">>");
                        doctor.Specialty = Console.ReadLine();

                        systemForDb.InsertDoctor(doctor);
                        break;

                    case 3:
                        Application application = new Application();

                        Console.WriteLine("Выберите пациента по Id");
                        var resultOne = systemForDb.SelectPatients();

                        int count = 0;                        

                        foreach (var i in resultOne)
                        {                         
                            Console.WriteLine("Id: " + i.Id);
                            Console.WriteLine("FullName: " + i.FullName);
                            Console.WriteLine("Phone: " + i.Phone);                            
                            Console.WriteLine();
                        }

                        int.TryParse(Console.ReadLine(),out count);

                        application.Patient = systemForDb.ChoisePatient(count);
                        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Console.WriteLine("Выберите Доктора по Id");

                        var resultTwo = systemForDb.SelectDoctors();

                        count = 0;

                        foreach (var i in resultTwo)
                        {                            
                            Console.WriteLine("Id: " + i.Id);
                            Console.WriteLine("FullName: " + i.FullName);
                            Console.WriteLine("Specialty: " + i.Specialty);                            
                            Console.WriteLine();
                        }

                        int.TryParse(Console.ReadLine(), out count);

                        application.Doctor = systemForDb.ChoiseDoctor(count);

                        application.RecordingDate = DateTime.Now;

                        systemForDb.InsertApplications(application);
                        break;

                    case 4:
                        foreach (var i in systemForDb.SelectPatients())
                        {
                            Console.WriteLine("Id: " + i.Id);
                            Console.WriteLine("FullName: " + i.FullName);
                            Console.WriteLine("Phone: " + i.Phone);
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        foreach (var i in systemForDb.SelectDoctors())
                        {
                            Console.WriteLine("Id: " + i.Id);
                            Console.WriteLine("FullName: " + i.FullName);
                            Console.WriteLine("Specialty: " + i.Specialty);
                            Console.WriteLine();
                        }
                        break;

                    case 6:
                        foreach (var i in systemForDb.SelectApplication())
                        {
                            Console.WriteLine("Id: " + i.Id);
                            Console.WriteLine("Patient: " + i.PatientId);
                            Console.WriteLine("Doctor: " + i.DoctorId);
                            Console.WriteLine("DateTime: " + i.RecordingDate);
                            Console.WriteLine();
                        }
                        break;

                    case 0:
                        IsTrue = false;
                        break;
                }
            }

        }        


    }
}
