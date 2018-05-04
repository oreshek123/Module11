using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10
{
    public enum Vacancies
    {
        Manager, Boss, Clerk, Salesman
    }
    public struct Employees
    {
      
        private string fullName_;

        public string FullName
        {
            get { return fullName_;}
            set
            {
                fullName_ = value.Replace("<center><b><font size=7>", "").Replace("</font></b></center>","").Replace("\n","");
            }
        }
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }
        public Vacancies Position { get; set; }

    }
}
