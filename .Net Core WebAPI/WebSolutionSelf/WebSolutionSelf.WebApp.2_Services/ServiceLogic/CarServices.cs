using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Model;
using WebSolutionSelf.WebApp._2_Services.ServicesInterface;
using WebSolutionSelf.WebApp._3_BusinessLogic.ICarBusinessLogic;

namespace WebSolutionSelf.WebApp._2_Services.ServiceLogic
{
    public class CarServices : ICarServices
    {
        private ICarBusinessLogic1 iCarBusinessLogic;

        public CarServices(ICarBusinessLogic1 _iCarBusinessLogic)
        {
            this.iCarBusinessLogic = _iCarBusinessLogic;
        }

        public Task<List<Car>> searchcarAsync(CarSearchingParameters carsearchingparameters)
        {
            return iCarBusinessLogic.searchcarAsync(carsearchingparameters);
        }

        public async Task<bool> SavecarAsync(Car car)
        {
            return await  iCarBusinessLogic.SavecarAsync(car);
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            return await iCarBusinessLogic.UpdateCarAsync(id, car);
        }

        public async Task<bool> DeleteCarById(int CarId)
        {
             return await iCarBusinessLogic.DeleteCarById(CarId);
            
        }
    }
}
