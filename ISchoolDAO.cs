using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704___1_N_db__Students_And_Clases_
{
    interface ISchoolDAO
    {
        Dictionary<Class, List<Student>> GetMapClassToStudentsDictionary();
        List<Student> GetStudentsFromClass(int IdOrCode);

    }
}
