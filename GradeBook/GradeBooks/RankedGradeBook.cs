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
            
            var grades = new List<double>();
            foreach (var student in Students) 
            {
                grades.Add(student.AverageGrade);
            }
            grades= grades.OrderDescending().ToList();
            for(int i=0; i < grades.Count; i++)
            {
                if (grades[i] <= averageGrade)
                {
                   switch (i)
                    {
                        case 0:
                            return 'A';
                        case 1:
                            return 'B';
                        case 2:
                            return 'C';
                        case 3:
                            return 'D';
                        case 4:
                            return 'F';
                    }
                }
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else if(Students.Count >= 5)
            {
                Console.WriteLine();
            }
        }
    }
}

