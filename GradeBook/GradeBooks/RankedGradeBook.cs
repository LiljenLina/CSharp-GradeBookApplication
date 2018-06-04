using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading is only available when > 5 students");
            }
            var threshold = (int)Math.Ceiling(Students.Count * 0.2); //20% of the students
            List<double> grades = new List<double>();
            foreach (var Student in Students)
            {
                grades.Add(Student.AverageGrade);
            }
            var sortedGrades = grades.OrderByDescending(x => x).ToList();
            

            if (sortedGrades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if (sortedGrades[(threshold*2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (sortedGrades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }

            else if (sortedGrades[(threshold * 4) - 1] <= averageGrade)
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
