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
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;
        public AuthorsController(IMapper mapper, IAuthor author)
        {
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var author = await _author.GetAll();
            var dtos = _mapper.Map<IEnumerable<AuthorDto>>(author);
            return Ok(dtos);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>>  Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(result));
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorForCreateDto AuthorForCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(AuthorForCreateDto);
                var result = await _author.Insert(author);
                var authorReturn = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authorReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorForCreateDto AuthorForCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(AuthorForCreateDto);
                var result = await _author.Update(id.ToString(), author);
                var authordto = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authordto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id.ToString());
                return Ok($"Data auhtor {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byfirstname")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetByName(string FirstName)
        {
            var results = await _author.GetByName(FirstName);
            var dto = _mapper.Map<IEnumerable<AuthorDto>>(results);
            return Ok(dto);
        }
    }
}
