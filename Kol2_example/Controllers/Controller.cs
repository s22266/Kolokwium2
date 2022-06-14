using System.Threading.Tasks;
using Kol2_example.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2_example.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly IDbService _dbService;
        public Controller(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idMusician}")]
        public async Task<object> GetMusician(int idMusician)
        {
            return await _dbService.GetMusician(idMusician);
        }

        [HttpDelete]
        [Route("{idMusician}")]
        public async Task<IActionResult> RemoveMusician(int idMusician)
        {
            
        }
    }
}
