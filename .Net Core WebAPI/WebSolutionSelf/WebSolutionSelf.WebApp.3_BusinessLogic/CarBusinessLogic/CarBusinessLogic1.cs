using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Model;
using WebSolutionSelf.WebApp._3_BusinessLogic.ICarBusinessLogic;
using WebSolutionSelf.WebApp._4_DataAccess.ICarRepository;

namespace WebSolutionSelf.WebApp._3_BusinessLogic.CarBusinessLogic
{
    public class CarBusinessLogic1 : ICarBusinessLogic1
    {
        private ICarRepositor iCarRepository;

        public CarBusinessLogic1(ICarRepositor _iCarRepository)
        {
            this.iCarRepository = _iCarRepository;
        }

        public async Task<List<Car>> searchcarAsync(CarSearchingParameters carsearchingparameters)
        {
            return await iCarRepository.searchcarAsync(carsearchingparameters);
        }
        public async Task<bool> SavecarAsync(Car car)
        {
            return await iCarRepository.SavecarAsync(car);
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            return await iCarRepository.UpdateCarAsync(id, car);
        }
        public async Task<bool> DeleteCarById(int CarId)
        {
            return await iCarRepository.DeleteCarById(CarId);

        }
    }
}
