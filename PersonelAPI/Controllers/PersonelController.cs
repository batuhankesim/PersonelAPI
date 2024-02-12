using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelAPI.DAL;
using PersonelAPI.Model;
using System.Diagnostics;

namespace PersonelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly PersonelDbContext _context;

        public PersonelController(PersonelDbContext context)
        {
            _context = context;
        }

        [HttpGet("{sicilnumarasi}")]
        public async Task<IActionResult> Getir(int sicilnumarasi)
        {
            try
            {
                Personel personel = await _context.OkuPersonel(new Personel() { SicilNumarasi = sicilnumarasi });

                if (personel == null)
                {
                    return NotFound("Belirtilen sicil numarasına sahip personel bulunamadı.");
                }

                return Ok(personel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Personel getirme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Personel personel)
        {
            try
            {
              Personel eklenenPersonel = await _context.EklePersonel(personel);
              return Ok(eklenenPersonel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Guncelle(Personel personel)
        {
            try
            {
                await _context.GuncellePersonel(personel);
                return Ok("Çalışan başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Personel güncelleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Sil(Personel personel)
        {
            try
            {
                await _context.SilPersonel(personel);
                return Ok("Çalışan başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Personel silme sırasında bir hata oluştu: {ex.Message}");
            }
        }
    }
}
