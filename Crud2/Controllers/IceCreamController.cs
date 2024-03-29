using Crud2.Models;
using Crud2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crud2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamController : ControllerBase
    {
        private readonly IIceCreamRepository repo;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_repo"></param>
        public IceCreamController(IIceCreamRepository _repo)
        {
            repo = _repo;
        }
        /// <summary>
        /// Get all ice creams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<IceCream>> GetIceCreams()
        {
            return Ok(repo.GetIceCreams());
            //return BadRequest("Some Message");
        }
        /// <summary>
        /// Get ice cream by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IceCream> GetIceCreamById(int id)
        {
            IceCream iceCream = repo.GetIceCreamById(id);
            if( iceCream == null )
            {
                return NotFound();
            }
            return Ok(iceCream);
        }
        /// <summary>
        /// Inserts an Ice cream
        /// </summary>
        /// <param name="iceCream"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IceCream> InsertIceCream(IceCream iceCream)
        {
            repo.InsertIceCream(iceCream);
            return CreatedAtAction("GetIceCreamById", new IceCream() { Id = iceCream.Id }, iceCream);
        }
        /// <summary>
        /// Updates an existing ice cream
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iceCream"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateIceCream(int id, IceCream iceCream)
        {
            if(repo.UpdateIceCream(id, iceCream))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Deletes an ice cream if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteIceCream(int id)
        {
            if (repo.DeleteIceCream(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Get all ice creams that matches filter value
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/search")]
        public ActionResult<IEnumerable<IceCream>> GetFilteredIceCreams(string filter)
        {
            IEnumerable<IceCream> filteredIceCreams = repo.GetFilteredIceCreams(filter);
            if (filteredIceCreams.Any())
            {
                return Ok(filteredIceCreams);
            }
            else
            {
                return NotFound();
            }
        }
        // ---------------------------------------------------------------------------------------------------------------------------- //
        [HttpPost("ImageUpload")]
        public ActionResult DocumentUpload(IceCreamImages iceCreamImages)
        {
            try
            {
                repo.UploadiceCreamImage(iceCreamImages);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
