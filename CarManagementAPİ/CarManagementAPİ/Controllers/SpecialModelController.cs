using CarManagementAPİ.Data.Entity;
using CarManagementAPİ.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarManagementAPİ.DTO.RequestDTO.CreateDTO;
using CarManagementAPİ.DTO.RequestDTO.UpdateDTO;
using CarManagementAPİ.DTO.RequestDTO.ReadDTO;

namespace CarManagementAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialModelController : ControllerBase
    {
        public readonly AppDbContext _context;
        public SpecialModelController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateModel(CreateModelDTO CreateModelDTO)
        {
            SpeacialModel ModelEntity = new SpeacialModel();
            ModelEntity.Name = CreateModelDTO.Name;
            ModelEntity.Price = CreateModelDTO.Price;
            ModelEntity.MarkaId = CreateModelDTO.MarkaId;
            await _context.SpeacialModels.AddAsync(ModelEntity);
            await _context.SaveChangesAsync();
            return Ok(ModelEntity);
        }
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result=await _context.SpeacialModels.Include(m=>m.Marka).Select(p=>new ReadSpecialModelDTO
            {
                Id = p.Id, 
                MarkaId = p.MarkaId, 
                Name=p.Name, 
                Price=p.Price
            }).ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateModelTable(UpdateModelDTO updateModelDTO,int id)
        {
            var model=await _context.SpeacialModels.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            model.Name= updateModelDTO.Name;    
            model.Price= updateModelDTO.Price;
            model.MarkaId= updateModelDTO.MarkaId;
            await _context.SaveChangesAsync();
            return Ok(model);   
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _context.SpeacialModels.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            _context.SpeacialModels.Remove(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

    }
}
