using jsonConverter.model;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

// zapewnia unikalność elementów
HashSet<Student> students = new HashSet<Student>();
HashSet<Studies> studieCurses = new HashSet<Studies>();
string adres = args[0];
string path = args[1];
if (!File.Exists(path))
{
    throw new FileNotFoundException("Plik nazwa nie istnieje");
}
string format = args[2];
FileInfo fi = new FileInfo("dane.csv");
var reader = new StreamReader(fi.OpenRead());

string line = null;

while ((line = reader.ReadLine()) != null)
{
    {
        // create Student object and Studies Object
        Student student = new Student();
        Studies s = new Studies();
       

        List<string> studentsData = line.Split(",").ToList<string>();
        Console.WriteLine(studentsData.Count());
        if (studentsData.Count() != 9 )
        {
            Console.WriteLine("błąd");

            using (StreamWriter sw = File.AppendText(@"C:\\Users\\micha\\OneDrive\\Pulpit\\apbdpjatk\\apbd2\\jsonConverter\\jsonConverter\\log.txt"))
            {
                sw.WriteLine("ilość kolumn sie nie zgada log: " +line);
                sw.Close();
            }


        }

        if (checkifColumnisEmpty(studentsData))
        {
            Console.WriteLine("błąd");

            using (StreamWriter sw = File.AppendText(@"C:\\Users\\micha\\OneDrive\\Pulpit\\apbdpjatk\\apbd2\\jsonConverter\\jsonConverter\\log.txt"))
            {
                sw.WriteLine("jedna z kolum jest pusta log: " + line);
                sw.Close();
            }


        }


        student.fname = studentsData[0];
        student.Iname = studentsData[1];
        s.name = studentsData[2];
        s.mode = studentsData[3];
        student.indexNumber = studentsData[4];
        student.birthdate = DateTime.Parse(studentsData[5]);
        student.email = studentsData[6];
        student.fathersName = studentsData[7];
        student.mothersName = studentsData[8];
        student.studies = s;

        students.Add(student);
        studieCurses.Add(s);



    }
}
// utworzenie obiektu uczelnia

List<Student> listaStudentow = students.ToList();
List<Studies> coursesList = studieCurses.ToList();
//listaStudentow.ForEach(e => e.tostring());
Uczelnia uczelnia = new Uczelnia
{
    studenci = listaStudentow,
    kierunki = coursesList,
};



//coursesList.ForEach(e => e.tostring());
var jsonString = JsonSerializer.Serialize(uczelnia);
//var jsonStringKierunki = JsonSerializer.Serialize(coursesList);

Console.WriteLine(jsonString);

//Console.WriteLine(jsonStringKierunki);

 bool checkifColumnisEmpty(List<string> column)
{

    return column.Any(e => e.Count() == 0);
  //for (int i = 0; i < column.Count(); i++)
  //  {
  //      if (column[i].Length == 0)
  //      {
  //          return true;
  //      }
       
    //}
   
}