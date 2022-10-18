using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonConverter.model
{
    public class Student
    {
        // przykładowe dane studenta
        // Paweł,Nowak1,Informatyka dzienne, Dzienne,459,2000-02-12,1@pjwstk.edu.pl,Alina,Adam

        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string Iname { get; set; }
        public DateTime birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   indexNumber == student.indexNumber &&
                   fname == student.fname &&
                   Iname == student.Iname &&
                   birthdate == student.birthdate &&
                   email == student.email &&
                   mothersName == student.mothersName &&
                   fathersName == student.fathersName &&
                   EqualityComparer<Studies>.Default.Equals(studies, student.studies);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(indexNumber, fname, Iname, birthdate, email, mothersName, fathersName, studies);
        }

        public void tostring()
        {
            Console.WriteLine(indexNumber + " " + fname + " " + Iname + " " + birthdate + " " + email + " " + mothersName + " " + fathersName + " {" + studies.name + " " + studies.mode + "}");
        }

    }
    public class Studies
    {
        public string name { get; set; }
        public string mode { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Studies studies &&
                   name == studies.name &&
                   mode == studies.mode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, mode);
        }

        public void tostring()
        {
            Console.WriteLine(name + " " + mode);
        }

    }
}
