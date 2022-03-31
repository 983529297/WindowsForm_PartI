using System.Collections.Generic;

namespace _homeWork
{
    class Course
    {
        const int SUNDAY = 0;
        const int MONDAY = 1;
        const int TUESDAY = 2;
        const int WEDNESDAY = 3;
        const int THURSDAY = 4;
        const int FRIDAY = 5;
        const int SATURDAY = 6;
        public Course(string number, string name, string stage, string credit, string hour, 
            string required, string teacher, List<string> classTime, string classroom, 
            string numberOfStudent, string numberOfDropStudent, string teacherA, string language, 
            string note, string outline, string other, string experiment)
        {
            this.Number = number;
            this.Name = name;
            this.Stage = stage;
            this.Credit = credit;
            this.Hour = hour;
            this.Required = required;
            this.Teacher = teacher;
            this.ClassTime = classTime;
            this.Classroom = classroom;
            this.NumberOfStudent = numberOfStudent;
            this.NumberOfDropStudent = numberOfDropStudent;
            this.TeacherA = teacherA;
            this.Language = language;
            this.Outline = outline;
            this.Note = note;
            this.Other = other;
            this.Experiment = experiment;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public List<string> ClassTime
        {
            get; set;
        }

        public string Classroom
        {
            get; set;
        }

        public string NumberOfStudent
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string NumberOfDropStudent
        {
            get; set;
        }

        public string TeacherA
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Outline
        {
            get; set;
        }

        public string Other
        {
            get; set;
        }

        public string Experiment
        {
            get; set;
        }

        public string Required
        {
            get; set;
        }

        //創造array
        public string[] GetArray()
        {
            string[] array = new string[] { Number, Name, Stage, Credit, Hour, Required, Teacher, ClassTime[SUNDAY], ClassTime[MONDAY], ClassTime[TUESDAY], ClassTime[WEDNESDAY], ClassTime[THURSDAY], ClassTime[FRIDAY], ClassTime[SATURDAY], Classroom, NumberOfStudent, NumberOfDropStudent, TeacherA, Language, Note, Outline, Other, Experiment };
            return array;
        }
    }
}
