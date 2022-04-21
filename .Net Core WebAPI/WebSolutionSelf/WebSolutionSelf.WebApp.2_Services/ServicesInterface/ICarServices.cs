using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Model;

namespace WebSolutionSelf.WebApp._2_Services.ServicesInterface
{
    public interface ICarServices
    {
        Task<List<Car>> searchcarAsync(CarSearchingParameters carsearchingparameters);
        Task<bool> SavecarAsync(Car car);
        Task<bool> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarById(int CarId);
    }
}
