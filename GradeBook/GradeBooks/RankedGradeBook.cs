using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        
            public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var grades = new List<double>();
            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades = grades.OrderByDescending(g => g).ToList();
            int x = (int)Math.Ceiling(Students.Count * 0.2);

            if (averageGrade >= grades[x - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(x * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(x * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(x * 4) - 1])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }


        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}

