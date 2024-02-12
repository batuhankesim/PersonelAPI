using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelAPI.DAL;
using PersonelAPI.Model;

namespace PersonelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelDataController : ControllerBase
    {
        private readonly PersonelDbContext _context;

        public PersonelDataController(PersonelDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> GetirDepartmanVeTarihIle(Personel personel)
        {
            try
            {
                List<Personel> eklenenPersonel = await _context.GetirPersonel(personel);
                return Ok(eklenenPersonel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
