using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Assessment requires 5 students");
            }

            int rank = 1;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    rank++;
            }

            var percent = (double)rank / Students.Count;

            if (percent >= 0.8)
            {
                return 'A';
            }
            else if (percent >= 0.6)
            {
                return 'B';
            }
            else if (percent >= 0.4)
            {
                return 'C';
            }
            else if (percent >= 0.2)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}

