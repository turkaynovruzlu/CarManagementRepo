using CarManagementAPİ.Data;
using CarManagementAPİ.Data.Entity;
using CarManagementAPİ.DTO.RequestDTO.CreateDTO;
using CarManagementAPİ.DTO.RequestDTO.ReadDTO;
using CarManagementAPİ.DTO.RequestDTO.UpdateDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarManagementAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        public readonly AppDbContext _context;
        public MarkaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMarka(CreateMarkaDTO CreateMarkaDTO)
        {
            Marka MarkaEntity= new Marka();
            MarkaEntity.Name = CreateMarkaDTO.Name;
            await _context.Markas.AddAsync(MarkaEntity);
            await _context.SaveChangesAsync();
            return Ok(MarkaEntity);
        }
        [HttpGet]
        public async Task<IActionResult> ReadAll(int id)
        {
            var result = await _context.Markas.Include(m=>m.SpeacialModels).Select(p=>new ReadMarkaDTO
            {
                Id = p.Id,
                Name = p.Name,
            }).ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMarkaTable(UpdateMarkaDTO updateMarkaDTO,int id)
        {
            var marka = await _context.Markas.FindAsync(id);
            if(marka== null)
            {
                return NotFound();
            }
            marka.Name = updateMarkaDTO.Name;
            await _context.SaveChangesAsync();
            return Ok(marka);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMarka(int id)
        {
            var marka = await _context.Markas.FindAsync(id);
            if(marka== null)
            {
                return NotFound();
            }
            _context.Markas.Remove(marka);
            await _context.SaveChangesAsync();
            return Ok(marka);
        }
    }
}
