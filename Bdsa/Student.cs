using System;

namespace Bdsa
{
    public class Student
    {
        public int Id { get; private set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status Status { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GraduationDate { get; set; }

        public Student(int Id, string GivenName, string Surname, DateTime StartDate, DateTime EndDate, DateTime GraduationDate){
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;

            if(EndDate < GraduationDate){
                this.Status = Status.Dropout;
            }else if(DateTime.Now < StartDate){
                this.Status = Status.New;
            }else if(DateTime.Now < GraduationDate){
                this.Status = Status.Active;
            }else if(DateTime.Now > GraduationDate){
                this.Status = Status.Graduate;
            }
        }

        public string toString() {
            return $"{this.GivenName} {this.Surname} with id {this.Id} has the status: {this.Status}. He/she started on {this.StartDate.ToString()} and stopped at {this.EndDate.ToString()}. He/she is supposed to have graduated at {this.GraduationDate.ToString()}.";
        }

    }

    public enum Status
    {
        New,
        Active,
        Dropout,
        Graduate
    }

    public record ImmutableStudent{
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }
        public Status Status { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime GraduationDate { get; init; }
    }
}