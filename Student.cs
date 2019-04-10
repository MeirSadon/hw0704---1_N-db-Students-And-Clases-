using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704___1_N_db__Students_And_Clases_
{
    //Poco Class
    class Student
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string AddressCity { get; set; }
        public string Vip { get; set; }
        public int Class_Id { get; set; }


        static public bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, null) && ReferenceEquals(s2, null))
                return true;
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
                return false;
            if (ReferenceEquals(s1.Id, s2.Id))
                return true;
            else
                return false;
        }
        static public bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Student OtherClass = obj as Student;
            return this.Id == OtherClass.Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public override string ToString()
        {
            return $"Student ID: {Id}. Name: {Name}. Age: {Age}. Address City: {AddressCity}. Vip? {Vip}. Class Id: {Class_Id}";
        }
    }
}
