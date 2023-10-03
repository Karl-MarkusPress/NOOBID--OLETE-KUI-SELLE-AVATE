using ContsoUniversityPressTARpe22.Models;

namespace ContsoUniversityPressTARpe22.Data
{
    public static class Dbinitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            //OTSIB ÕPILASI
            if (context.Students.Any())
            {
                return; //väljub meetodist kui andmebaas sisaldab juba andmeid ning meetodis kirjeldatud
                        //näidisõpilasi/kursuseid/aineosalejaid  
            }

            var students = new Student[]
            {
                new Student {FirstMidName="Karl-Markus",LastName="Press",EnrollmentDate=DateTime.Parse("2022-09-01")},
                new Student {FirstMidName="Karl",LastName="Jobu",EnrollmentDate=DateTime.Parse("2022-09-01")},
                new Student {FirstMidName="Karl-Markus",LastName="Tobu",EnrollmentDate=DateTime.Parse("2022-09-01")},
                new Student {FirstMidName="Markus",LastName="Poolakas",EnrollmentDate=DateTime.Parse("2022-09-01")},
                new Student {FirstMidName="Markus",LastName="Leedukas",EnrollmentDate=DateTime.Parse("2022-09-01")},
                new Student {FirstMidName="Karl",LastName="Sibul",EnrollmentDate=DateTime.Now}
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor {FirstMidName="Kim", LastName="Kardashian",HireDate=DateTime.Parse("2005-09-01")},
                new Instructor {FirstMidName="Meister", LastName="Jaan",HireDate=DateTime.Parse("2005-09-01")},
                new Instructor {FirstMidName="Parmu", LastName="Jaak",HireDate=DateTime.Parse("2005-09-01")},
                new Instructor {FirstMidName="Olev", LastName="Ait",HireDate=DateTime.Parse("2005-09-01")},
                new Instructor {FirstMidName="Sinu", LastName="Ema",HireDate=DateTime.Parse("2005-09-01")}
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department {Name = "Infotechnology",Budget = 100,StartDate = DateTime.Parse("2022-09-01"),InstructorID=instructors.Single(i => i.LastName == "Kardashian").ID},
                new Department {Name = "Home Economics",Budget = 35000,StartDate = DateTime.Parse("2002-09-01"),InstructorID=instructors.Single(i => i.LastName == "Reynolds").ID},
                new Department {Name = "Internet Trolling",Budget = 0,StartDate = DateTime.Parse("2010-09-01"),InstructorID=instructors.Single(i => i.LastName == "Bean").ID},
                new Department {Name = "Joomarlus",Budget = 23765471,StartDate = DateTime.Parse("1991-09-01"),InstructorID=instructors.Single(i => i.LastName == "Oss").ID}
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();
            var courses = new Course[]
            {
                new Course {CourseID = 1001, Title="Programming", Credits = 3,DepartmentID=departments.Single(s => s.Name == "InfoTechnology").DepartmentID},
                new Course { CourseID = 2221, Title="DataBases 101", Credits = 4, DepartmentID=departments.Single(s => s.Name == "InfoTechnology").DepartmentID },
                new Course {CourseID = 3001, Title="HTML", Credits = 3,DepartmentID=departments.Single(s => s.Name == "InfoTechnology").DepartmentID },
                new Course {CourseID = 5001, Title="Cloud applications", Credits = 5,DepartmentID=departments.Single(s => s.Name == "InfoTechnology").DepartmentID },
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment
                {
                    InstructorID = instructors.Single(i=>i.LastName == "Kardashian").ID,
                      Location= "A128"
                },
                new OfficeAssignment
                {
                    InstructorID = instructors.Single(i=>i.LastName == "Jaan").ID,
                      Location= "A127"
                },
                new OfficeAssignment
                {
                    InstructorID = instructors.Single(i=>i.LastName == "Jaak").ID,
                      Location= "A126"
                },
                new OfficeAssignment
                {
                    InstructorID = instructors.Single(i=>i.LastName == "Ait").ID,
                      Location= "A125"
                },
                new OfficeAssignment
                {
                    InstructorID = instructors.Single(i=>i.LastName == "Ema").ID,
                      Location= "A124"
                }
            };
            context.OfficeAssignments.AddRange(officeAssignments);
            context.SaveChanges();

            var courseAssignments = new CourseAssignment[]
            {
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="Programming").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kardashian").ID
                },
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="Databases 101").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jaan").ID
                },
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="HTML ").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jaak").ID
                },
                new CourseAssignment
                {
                    CourseID = courses.Single(c => c.Title =="Cloud applications ").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Ait").ID
                },
            };
            context.CourseAssignments.AddRange(courseAssignments);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    StudentID = students.Single(s => s.LastName =="Press").ID,
                    CourseID = courses.Single(c => c.Title == "Cloud applications").CourseID,
                    Grade = Grade.F
                },
                new Enrollment
                {
                    StudentID = students.Single(s => s.LastName =="Jobu").ID,
                    CourseID = courses.Single(c => c.Title == "HTML").CourseID,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentID = students.Single(s => s.LastName =="Tobu").ID,
                    CourseID = courses.Single(c => c.Title == "Databases 101").CourseID,
                    Grade = Grade.F
                },
                new Enrollment
                {
                    StudentID = students.Single(s => s.LastName =="Poolakas").ID,
                    CourseID = courses.Single(c => c.Title == "HTML").CourseID,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    StudentID = students.Single(s => s.LastName =="Sibul").ID,
                    CourseID = courses.Single(c => c.Title == "Cloud applications").CourseID,
                    Grade = Grade.F
                },
            };
            foreach(Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where
                    (
                    s =>
                    s.StudentID == e.StudentID && 
                    s.CourseID == e.CourseID)
                    .SingleOrDefault(); 
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            };
            context.SaveChanges();
         } 
    } 
}
  
