using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsRecord
{
    public class Application
    {
        public int Id { set; get; }
        public int DoctorId { set; get; }
        public virtual Doctor Doctor { set; get; }
        public int PatientId { set; get; }
        public virtual Patient Patient { set; get; }
        public DateTime RecordingDate { set; get; }
    }
}
