namespace PlannabelleClassLibrary.Models
{
    public class Enrollment
    {
        // Properties
        public int Id { get; set; }
        public User User { get; set; }
        public Module Module { get; set; }
        public Semester Semester { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int SelfStudyHoursPerWeek { get; set; }
        public double SelfStudyHoursRemainingForWeek { get; set; }


        // Constructors
        public Enrollment()
        {

        }

        public Enrollment(int id, User user, Module module, Semester semester, int classHoursPerWeek, int selfStudyHoursPerWeek, double selfStudyHoursRemainingForWeek)
        {
            Id = id;
            User = user;
            Module = module;
            Semester = semester;
            ClassHoursPerWeek = classHoursPerWeek;
            SelfStudyHoursPerWeek = selfStudyHoursPerWeek;
            SelfStudyHoursRemainingForWeek = selfStudyHoursRemainingForWeek;
        }

        public Enrollment(User user, Module module, Semester semester, int classHoursPerWeek, int selfStudyHoursPerWeek, double selfStudyHoursRemainingForWeek)
        {
            User = user;
            Module = module;
            Semester = semester;
            ClassHoursPerWeek = classHoursPerWeek;
            SelfStudyHoursPerWeek = selfStudyHoursPerWeek;
            SelfStudyHoursRemainingForWeek = selfStudyHoursRemainingForWeek;
        }
    }
}