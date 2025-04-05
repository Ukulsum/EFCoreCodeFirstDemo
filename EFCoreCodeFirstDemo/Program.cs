using EFCoreCodeFirstDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the DbContext class
            using var context = new EFCoreDbContext();

            // Adding two new Branches
            AddBranches(context);

            // Adding two new Students
            AddStudents(context);

            // Retrieve and display all students
            GetAllStudents(context);

            // Retrieve and display a single student by ID
            GetStudentById(context, 1); // Assuming 1 is the StudentId

            // Update a student's information
            UpdateStudent(context, 1);

            // Delete a student by ID 
            DeleteStudent(context, 2);   // Assuming 2 is the StudentId

            // Final retrieval to confirm operations
            GetAllStudents(context);

            Console.WriteLine("All operations completed successfully!");


        }

        private static void AddBranches(EFCoreDbContext context)
        {
            //Create two new Branch Objects
            var branch1 = new Branch()
            {
                BranchName = "Computer Science",
                Description = "Focuses on software development and computing technologies.",
                PhoneNumber = "123-456-7890",
                Email = "csumme23@gmail.com"
            };
            var branch2 = new Branch()
            {
                BranchName = "Electrical Engineering",
                Description = "Focuses on electrical systems and circuit design.",
                PhoneNumber = "987-654-3210",
                Email = "kulsum23@gmail.com"
            };

            // Add the branches to the context
            context.Branches.Add(branch1);
            context.Branches.Add(branch2);

            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Branches added successfully.");
            Console.ReadLine();
        }

        private static void AddStudents(EFCoreDbContext context)
        {
            // Retrieve the branches from the context
            var csBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Computer Science");
            var eeBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Electrical Engineering");

            // Create two new Student objects
            var student1 = new Student
            {
                FirstName = "Umme",
                LastName = "Kulsum",
                DateOfBirth = new DateTime(1999, 10, 23),
                Gender = "Female",
                Email = "ukds@gmail.com",
                PhoneNumber = "21453-25565",
                EnrollmentDate = DateTime.Now,
                Branch = csBranch // Assign the Computer Science branch
            };

            var student2 = new Student
            {
                FirstName = "Faria",
                LastName = "Akter",
                DateOfBirth = new DateTime(2000, 1, 22),
                Gender = "Female",
                Email = "fariaakter@gmail.com",
                PhoneNumber = "4562-55411",
                EnrollmentDate = DateTime.Now,
                Branch = eeBranch   // Assign the Electrical Engineering branch
            };


            // Add the students to the context
            context.Students.Add(student1);
            context.Students.Add(student2);

            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Students add successfully!");
        }


        private static void GetAllStudents(EFCoreDbContext context)
        {
            // Retrieve all students from the context
            var students = context.Students.Include(s => s.Branch).ToList();

            // Display the students in the console
            Console.WriteLine("All Students");
            foreach (var student in students)
            {
                Console.WriteLine($"\t{student.Id}: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
        }


        private static void GetStudentById(EFCoreDbContext context, int id)
        {
            // Retrieve a single student by ID
            var student = context.Students.Include(s => s.Branch).FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Student found: {student.Id} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        private static void UpdateStudent(EFCoreDbContext context, int id)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                // Update the student's information
                student.LastName = "UpdatedLastName";
                student.Email = "updated.email@dotnettutorials.net";

                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {id} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        private static void DeleteStudent(EFCoreDbContext context, int id)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.Id == id);

            if(student != null)
            {
                // Remove the student from the context
                context.Students.Remove(student);

                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }
    }
}
