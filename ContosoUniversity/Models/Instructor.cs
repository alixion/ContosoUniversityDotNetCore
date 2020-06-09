using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ContosoUniversity.Features.Instructors;

namespace ContosoUniversity.Models
{
    // Removed Person parent class because
    // System.InvalidOperationException : The entity type 'Instructor' cannot be mapped to a table because it is derived from 'Person'. Only base entity types can be mapped to a table.
    public class Instructor:IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstMidName;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; private set; } = new List<CourseAssignment>();
        public OfficeAssignment OfficeAssignment { get; private set; }

        public void Handle(CreateEdit.Command message,
            IEnumerable<Course> courses)
        {
            UpdateDetails(message);

            UpdateInstructorCourses(message.SelectedCourses, courses);
        }

        public void Handle(Delete.Command message) => OfficeAssignment = null;

        private void UpdateDetails(CreateEdit.Command message)
        {
            FirstMidName = message.FirstMidName;
            LastName = message.LastName;
            HireDate = message.HireDate.GetValueOrDefault();

            if (string.IsNullOrWhiteSpace(message.OfficeAssignmentLocation))
            {
                OfficeAssignment = null;
            }
            else if (OfficeAssignment == null)
            {
                OfficeAssignment = new OfficeAssignment
                {
                    Location = message.OfficeAssignmentLocation
                };
            }
            else
            {
                OfficeAssignment.Location = message.OfficeAssignmentLocation;
            }
        }

        private void UpdateInstructorCourses(string[] selectedCourses, IEnumerable<Course> courses)
        {
            if (selectedCourses == null)
            {
                CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (CourseAssignments.Select(c => c.CourseID));

            foreach (var course in courses)
            {
                if (selectedCoursesHS.Contains(course.Id.ToString()))
                {
                    if (!instructorCourses.Contains(course.Id))
                    {
                        CourseAssignments.Add(new CourseAssignment { Course = course, Instructor = this });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.Id))
                    {
                        var toRemove = CourseAssignments.Single(ci => ci.CourseID == course.Id);
                        CourseAssignments.Remove(toRemove);
                    }
                }
            }
        }
    }
}