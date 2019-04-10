using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704___1_N_db__Students_And_Clases_
{
    class Class
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfVip { get; set; }
        public double AgeAvarege { get; set; }
        public string MostPopularCity { get; set; }
        public int OldestVip { get; set; }
        public int YoungestVip { get; set; }


        static public bool operator ==(Class c1, Class c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            if (ReferenceEquals(c1.Id, c2.Id))
                return true;
            else
                return false;
        }
        static public bool operator !=(Class c1, Class c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Class OtherClass = obj as Class;
            return this.Id == OtherClass.Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public override string ToString()
        {
            return $"Class ID: {Id}. Name: {Name}. Code: {Code}. Number Of Students: {NumberOfStudents}. Number Of Vip {NumberOfVip}."
                + $"Age Avarege {AgeAvarege}. Most Popular City {MostPopularCity}. OldestVip {OldestVip}. YoungestVip {YoungestVip}.";
        }
    }
}
