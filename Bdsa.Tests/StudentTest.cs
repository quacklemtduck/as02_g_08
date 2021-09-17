using System;
using Xunit;

namespace Bdsa.Tests
{
    public class StudentTest
    {
        [Fact]
        public void StudentToString()
        {
            var student = new Student(0, "Jens", "Andersen", new DateTime(2008, 10, 10), new DateTime(2010, 10, 10), new DateTime(2009, 10, 9));
            
            var output = student.toString();
            var expected = "Jens Andersen with id 0 has the status: Graduate. He/she started on 10.10.2008 and stopped at 10.10.2010. He/she is supposed to have graduated at 10.09.2009.";
            
            Assert.Equal(expected, output);
        }

        [Fact]
        public void StudentStatus()
        {
            var dropoutStudent = new Student(5, "Lars", "Larsen", new DateTime(2016, 9, 1), new DateTime(2016, 9, 2), new DateTime(2019, 6, 1));
            var newStudent = new Student(6, "Hans", "Hansen", new DateTime(2022, 9, 1), new DateTime(2025, 6, 1), new DateTime(2025, 6, 1));
            var activeStudent = new Student(7, "Jens", "Jensen", new DateTime(2019, 9, 1), new DateTime(2023, 6, 1), new DateTime(2023, 6, 1));
            var graduatedStudent = new Student(8, "Mads", "Madsen", new DateTime(2015, 9, 1), new DateTime(2019, 6, 1), new DateTime(2019, 6, 1));

            Assert.Equal(Status.Dropout, dropoutStudent.Status);
            Assert.Equal(Status.New, newStudent.Status);
            Assert.Equal(Status.Active, activeStudent.Status);
            Assert.Equal(Status.Graduate, graduatedStudent.Status);
        }

        [Fact]
        public void ImmutableStudentEquals()
        {
            var s1 = new ImmutableStudent{
                Id=1,
                GivenName = "Lars",
                Surname = "Larsen",
                Status = Status.Active,
                StartDate = new DateTime(2019, 9, 1),
                EndDate = new DateTime(2023, 6, 1),
                GraduationDate = new DateTime(2023,6,1)
            };
            var s2 = new ImmutableStudent{
                Id=1,
                GivenName = "Lars",
                Surname = "Larsen",
                Status = Status.Active,
                StartDate = new DateTime(2019, 9, 1),
                EndDate = new DateTime(2023, 6, 1),
                GraduationDate = new DateTime(2023,6,1)
            };
            
            Assert.True(s1 == s2);
        }


        [Fact]
        public void RecordToString () {

            var immutableStudent = new ImmutableStudent{
                Id=1,
                GivenName = "Lars",
                Surname = "Larsen",
                Status = Status.Active,
                StartDate = new DateTime(2019, 9, 1),
                EndDate = new DateTime(2023, 6, 1),
                GraduationDate = new DateTime(2023,6,1)
            };


            var output = immutableStudent.ToString();
            var expected = "ImmutableStudent { Id = 1, GivenName = Lars, Surname = Larsen, Status = Active, StartDate = 01/09/2019 00.00.00, EndDate = 01/06/2023 00.00.00, GraduationDate = 01/06/2023 00.00.00 }";

            Assert.Equal(expected, output);
            
        }
    }
}



// return $"{this.GivenName} {this.Surname} with id {this.Id} has the status: {this.Status}. He/she started on {this.StartDate.DateToString("MM/dd/yyyy")} and stopped at {this.EndDate.DateToString("MM/dd/yyyy")}. He/she is supposed to have graduated at {this.Graduation.DateToString("MM/dd/yyyy")} ";