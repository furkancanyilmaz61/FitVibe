using FitVibe.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitVibe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataProtectionService _dataProtectionService;

        public TestController(DataProtectionService dataProtectionService)
        {
            _dataProtectionService = dataProtectionService;
        }

        [HttpPost("protect")]
        public ActionResult ProtectData([FromBody] string input)
        {
            var protectedData = _dataProtectionService.Protect(input);
            return Ok(new { ProtectedData = protectedData });
        }

        [HttpPost("unprotect")]
        public ActionResult UnprotectData([FromBody] string encryptedData)
        {
            try
            {
                var unprotectedData = _dataProtectionService.Unprotect(encryptedData);
                return Ok(new { UnprotectedData = unprotectedData });
            }
            catch (Exception)
            {
                // Burada hata GlobalExceptionMiddleware'e fırlatılır
                throw;
            }
        }
    }
}