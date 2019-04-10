using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704___1_N_db__Students_And_Clases_
{
    class SchoolDAO : ISchoolDAO
    {
        SQLiteConnection connection;
        string dbName = @"Data Source = C:\meir\StudentsAndClass_1_N.db;";

        public SchoolDAO()
        {
            connection = new SQLiteConnection(dbName + "Version=3;");
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }



        public Dictionary<Class, List<Student>> GetMapClassToStudentsDictionary()
        {
            List<Class> listClases = new List<Class>();
            List<Student> listStudents = new List<Student>();
            Dictionary<Class, List<Student>> dict = new Dictionary<Class, List<Student>>();
            using (SQLiteCommand cmd = new SQLiteCommand($"select c.id AS ClassId, c.name as ClassName, c.code, c.Number_Of_Students, c.Number_Of_Vip, c.Age_Average,"
                + "c.Most_Popular_City, c.Oldest_Vip, c.Youngest_Vip from class c", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Class c = new Class();
                        c.Id = (Int64)reader["classId"];
                        c.Name = (string)reader["className"];
                        c.Code = (int)reader["code"];
                        c.NumberOfStudents = (int)reader["Number_Of_Students"];
                        c.NumberOfVip = (int)reader["Number_Of_Vip"];
                        c.MostPopularCity = (string)reader["Most_Popular_City"];
                        c.OldestVip = (int)reader["Oldest_Vip"];
                        c.YoungestVip = (int)reader["Youngest_Vip"];
                        //{
                        //    Id = (Int64)reader["classId"],
                        //    Name = (string)reader["className"],
                        //    Code = (int)reader["code"],
                        //    NumberOfStudents = (int)reader["Number_Of_Students"],
                        //    NumberOfVip = (int)reader["Number_Of_Vip"],
                        //    AgeAvarege = (float)reader["age_Avarege"],
                        //    MostPopularCity = (string)reader["Most_Popular_City"],
                        //    OldestVip = (int)reader["Oldest_Vip"],
                        //    YoungestVip = (int)reader["Youngest_Vip"],
                        //};
                        listClases.Add(c);
                    }
                }
            }
            using (SQLiteCommand cmd = new SQLiteCommand($"Select s.id as StudentId, s.Name as StudentName, s.Age, s.addressCity, s.Vip, s.Class_Id from students s", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Student s = new Student
                        {
                            Id = (Int64)reader["StudentId"],
                            Name = (string)reader["StudentName"],
                            Age = (int)reader["Age"],
                            AddressCity = (string)reader["addressCity"],
                            Vip = (string)reader["VIP"],
                            Class_Id = (int)reader["Class_Id"],
                        };
                        //s.Id = (Int64)reader["StudentId"];
                        //s.Name = (string)reader["StudentName"];
                        //s.Age = (int)reader["Age"];
                        //s.AddressCity = (string)reader["addressCity"];
                        //s.Vip = (string)reader["VIP"];
                        //s.Class_Id = (int)reader["Class_Id"];
                        listStudents.Add(s);
                    }
                }
            }
            for (int i = 0; i < listClases.Count; i++)
            {
                for (int j = 0; j < listStudents.Count; j++)
                {
                    if (listStudents[j].Class_Id == listClases[i].Id)
                    {
                        if (dict.TryGetValue(listClases[i], out List<Student> students))
                            students.Add(listStudents[j]);
                        else
                        {
                            List<Student> newStudentsList = new List<Student>();
                            newStudentsList.Add(listStudents[j]);
                            dict.Add(listClases[i], newStudentsList);
                        }
                    }
                }
            }
            //foreach (KeyValuePair<Class, List<Student>> cs in dict)
            //{
            //    Console.WriteLine(cs.Key);
            //    for (int i = 0; i < cs.Value.Count; i++)
            //    {
            //        if (cs.Key.Id == cs.Value[i].Class_Id)
            //            Console.WriteLine(cs.Value[i]);
            //    }
            //}
            return dict;
        }
    
        public List<Student> GetStudentsFromClass(int IdOrCode)
        {
            Dictionary<Class, List<Student>> dict = GetMapClassToStudentsDictionary();
            List<Student> list = new List<Student>();

            foreach (KeyValuePair<Class, List<Student>> cs in dict)
            {
                for (int i = 0; i < cs.Value.Count; i++)
                {
                    if (cs.Value[i].Class_Id == IdOrCode)
                    {
                        list.Add(cs.Value[i]);
                        Console.WriteLine(list[i]);
                    }
                }
            }
            return list;
        }
    }
}