using CarManagementAPİ.Data;
using CarManagementAPİ.Data.Entity;
using CarManagementAPİ.DTO.RequestDTO.CreateDTO;
using CarManagementAPİ.DTO.RequestDTO.ReadDTO;
using CarManagementAPİ.DTO.RequestDTO.UpdateDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarManagementAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly AppDbContext _context;
        public PersonController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create_Person(CreatePersonDTO CreatePersonDTO)
        {
            Person PersonEntity = new Person();
            PersonEntity.Name = CreatePersonDTO.Name;
            PersonEntity.Email = CreatePersonDTO.Email;

            PersonEntity.Gender = CreatePersonDTO.Gender;
            PersonEntity.BirthDate = CreatePersonDTO.BirthDate;
            PersonEntity.SpecialModelId = CreatePersonDTO.SpecialModelId;
            await _context.Persons.AddAsync(PersonEntity);
            await _context.SaveChangesAsync();
            return Ok(PersonEntity);
        }
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await _context.Persons.Include(p => p.SpeacialModel)
                .Select(p => new ReadPersonDTO 
                { Id = p.Id, 
                    Email = p.Email, 
                    Gender = p.Gender, 
                    Name = p.Name, 
                    BirthDate = p.BirthDate, 
                    SpecialModelId = p.SpecialModelId 
                }).ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePersonTable(UpdatePersonDTO updatePersonDTO,int id)
        {
            var Person = await _context.Persons.FindAsync(id);
            if(Person == null)
            {
                return NotFound();
            }
            Person.Name = updatePersonDTO.Name;
            Person.Gender = updatePersonDTO.Gender;
            Person.BirthDate = updatePersonDTO.BirthDate;
            Person.SpecialModelId = updatePersonDTO.SpecialModelId;
            Person.Email = updatePersonDTO.Email;
            await _context.SaveChangesAsync();
            return Ok(Person);

        }
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
    }
}
