using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Authors;
using TaskAPI.Services.Models;

namespace TaskAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _service;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<ICollection<AuthorDto>> GetAuthors()
        {
            var authors    = _service.GetAllAuthors();
            var authorsDto = _mapper.Map<ICollection<AuthorDto>>(authors);

            //var authorsDto = new List<AuthorDto>();

            //foreach(var author in authors)
            //{
            //    var authorDto = new AuthorDto
            //    {
            //        Id = author.Id,
            //        Name = author.Name,
            //        Address = $"{author.AddressNo} {author.Street}, {author.City}"
            //    };
            //    authorsDto.Add(authorDto);
            //}
            return Ok(authorsDto);
        }

        [HttpGet("{id}")] 
        public ActionResult<AuthorDto> GetAuthor(int id)
        {
            var author = _service.GetAuthor(id);
            if(author is null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<AuthorDto>(author);

            return Ok(authorDto);
        }
    }
}
