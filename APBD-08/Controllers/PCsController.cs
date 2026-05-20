using APBD_08.DTOs.PCDTOs;
using APBD_08.Exceptions;
using APBD_08.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly IDBService _dbService;

        public PCsController(IDBService dbService)
        {
            _dbService = dbService;
        }
        
        //• GET api/pcs
        [HttpGet]
        public async Task<IActionResult> getAllPCsAsync()
        {
            try
            {
                var PCs = await _dbService.getAllPCsAsync();
                return Ok(PCs);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        //• GET api/pcs/{id}/components
        [Route("{id}/components")]
        [HttpGet]
        public async Task<IActionResult> getPCsComponentsAsync([FromRoute]int id)
        {
            if (await _dbService.getPCAsync(id) == null)
            {
                return NotFound(id);
            }

            try
            {
                var PCs = await _dbService.getPCsComponentsAsync(id);
                return Ok(PCs);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        //• POST api/pcs
        [HttpPost]
        public async Task<IActionResult> addPCAsync([FromBody] AddPCDTO addPC)
        {
            await _dbService.addPCAsync(addPC);
            return Created();   
        }
        
        //• PUT api/pcs/{id}
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> updatePCAsync([FromRoute]int id, [FromBody] UpdatePCDTO updatePC)
        {
            try
            {
                await _dbService.updatePCAsync(id, updatePC);
                return Ok(); 
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            } 
        }
        
        //• DELETE api/pcs/{id}
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> removePC([FromRoute]int id)
        {
            try
            {
                await _dbService.removePCByIdAsync(id);
                return NoContent();   
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
