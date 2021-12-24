using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimulasiRESTAPI.Data;
using SimulasiRESTAPI.Dtos;
using SimulasiRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimulasiRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(IMapper mapper, ICourse course)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _course = course ?? throw new ArgumentNullException(nameof(course));
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var course = await _course.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(course);
            return Ok(dtos);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseForCreateDto);
                var result = await _course.Insert(course);
                var coursedto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseToCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseToCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var coursedto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bytitle")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            var dto = _mapper.Map<IEnumerable<CourseDto>>(results);
            return Ok(dto);
        }

        [HttpGet("byauthor")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByAuthor(int id)
        {
            var result = await _course.GetTitleByAuthor(id.ToString());
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(result));
            //return Ok(result);
        }
    }
}
