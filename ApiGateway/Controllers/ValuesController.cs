using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseData courseData;

        public CoursesController(ICourseData courseData)
        {
            this.courseData = courseData;
        }

        // GET: api/Course
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return courseData.GetAll();
        }

        // GET: api/Course/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public ActionResult<Course> Get(string id)
        {
            var course = courseData.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        // POST: api/Course
        [HttpPost]
        [ProducesResponseType(201), ProducesResponseType(400)]
        public ActionResult<Course> Post([FromBody] Course newCourse)
        {
            if (ModelState.IsValid)
            {
                newCourse = courseData.Add(newCourse);
                return CreatedAtRoute("Get", new { id = newCourse.Id }, newCourse);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        [ProducesResponseType(200), ProducesResponseType(400)]
        public ActionResult<Course> Put(string id, [FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                course.Id = id;
                course = courseData.Update(course);
                if (course == null)
                {
                    return NotFound();
                }
                return course;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200), ProducesResponseType(400)]
        public ActionResult<Course> Delete(string id)
        {
            var course = courseData.Delete(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }
    }
}
