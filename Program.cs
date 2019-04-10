using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704___1_N_db__Students_And_Clases_
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolDAO school = new SchoolDAO();
            //school.GetMapClassToStudentsDictionary();
            school.GetStudentsFromClass(3);
         }
    }
}