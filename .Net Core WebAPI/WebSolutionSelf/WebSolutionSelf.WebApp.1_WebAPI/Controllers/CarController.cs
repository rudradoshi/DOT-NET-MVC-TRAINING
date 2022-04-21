using Microsoft.AspNetCore.Mvc;
using WebSolutionSelf.Common.Model;
using WebSolutionSelf.WebApp._2_Services.ServicesInterface;

namespace WebSolutionSelf.WebApp._1_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SearchCar")]
    public class CarController : Controller
    {
        private ICarServices iCarServices;

        public CarController(ICarServices _iCarServices)
        {
            iCarServices = _iCarServices;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public async Task<IActionResult>Get(CarSearchingParameters carsearchingparameters)
        {
            var cars = await iCarServices.searchcarAsync(carsearchingparameters);
            if(cars==null || !cars.Any())
            {
                return NotFound();
            }
            return Json(cars);
        }

        [HttpPost]
        [ProducesResponseType(200,Type=typeof(Car))]

        public async Task<IActionResult>Post([FromBody] Car car)
        {
            if(await iCarServices.SavecarAsync(car))
            {
                return Ok();
            }
            else
            {
                return BadRequest("unable to save movie");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        public async Task<IActionResult> UpdateCar([FromRoute] int id,[FromBody]Car car)
        {
             if (await iCarServices.UpdateCarAsync(id, car))
            {
                return Ok();
            }
             else
            { return BadRequest("unable to delete car"); 
            }
            
        }
        [HttpDelete("delete-car-by-id/{id}")]
         [ProducesResponseType(200, Type = typeof(Car))]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
           if(await iCarServices.DeleteCarById(id))
            { 
             return Ok(); 
            }
            else
            {
                return BadRequest("unable to delete car");
            }
            
        }

    }
}
