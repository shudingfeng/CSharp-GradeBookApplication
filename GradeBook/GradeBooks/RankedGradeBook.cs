using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int bar = (int)Math.Ceiling(this.Students.Count * 0.2);
            var grades = this.Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (averageGrade >= grades[bar - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[bar * 2 - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[bar * 3 - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[bar * 4 - 1])
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
