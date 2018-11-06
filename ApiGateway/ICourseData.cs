using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiGateway
{
    public interface ICourseData
    {
        List<Course> GetAll();
        Course Get(string id);
        Course Add(Course newCourse);
        Course Update(Course updatedCourse);
        Course Delete(string id);
    }

    // Do not use for real work!
    public class InMemoryCourseData : ICourseData
    {
        public InMemoryCourseData()
        {
            courses = new List<Course>()
            {
                new Course { Id = NewGuid(), Title="Azure Getting Started", Length=360  },
                new Course { Id = NewGuid(), Title="Azure Patterns", Length=300},
                new Course { Id = NewGuid(), Title="Azure Services", Length = 400 }
            };
        }

        public Course Add(Course newCourse)
        {
            newCourse.Id = NewGuid();
            courses.Add(newCourse);
            return newCourse;
        }

        public Course Delete(string id)
        {
            var course = courses.SingleOrDefault(c => c.Id == id);
            if (course != null)
            {
                courses.Remove(course);
            }
            return course;
        }

        public Course Get(string id)
        {
            return courses.SingleOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course Update(Course updatedCourse)
        {
            var course = Get(updatedCourse.Id);
            if (course != null)
            {
                course.Title = updatedCourse.Title;
                course.Length = updatedCourse.Length;
            }
            return course;
        }

        readonly Func<string> NewGuid = () => Guid.NewGuid().ToString();

        List<Course> courses;
    }
}