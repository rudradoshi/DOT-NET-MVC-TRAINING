using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Enum;
using WebSolutionSelf.Common.Model;
using WebSolutionSelf.WebApp._4_DataAccess.Entities;
using WebSolutionSelf.WebApp._4_DataAccess.ICarRepository;


namespace WebSolutionSelf.WebApp._4_DataAccess.CarRepository
{
    public class CarRepositor1 : BaseRepository, ICarRepositor
    {
        public CarRepositor1(Context context) : base(context)
        {
        }

        public async Task<bool> SavecarAsync(Car car)
        {
            var CarObj = context.CarDbSet.Find(car.Id);
            if (CarObj == null)
            {
                CarObj = new CarEntities();
                context.Add(CarObj);
            }
                CarObj.CarName = car.CarName;
                CarObj.CarManufacturer = car.CarManufacturer;
                CarObj.CarModel = car.CarModel;
                CarObj.CarColor = (short)car.CarColor;
                CarObj.CarReleaseDate = car.CarReleaseDate;
            return await context.SaveChangesAsync() > 0;
        }

        public  async Task<List<Car>> searchcarAsync(CarSearchingParameters carsearchingparameters)
        {
            IQueryable<CarEntities> CarQuery = context.CarDbSet.AsQueryable(); 
            //var CarQuery = context.CarDbSet.AsQueryable();
            return await  CarQuery.Select(m => new Car
            {
                Id = m.Id,
                CarName=m.CarName,
                CarManufacturer=m.CarManufacturer,
                CarModel=m.CarModel,
                CarColor = (ColorType)m.CarColor,
                CarReleaseDate=m.CarReleaseDate,
            }).ToListAsync();
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var c= await context.CarDbSet.FindAsync(id);
            if (c != null)
            {
                c.CarName = car.CarName;
                c.CarManufacturer = car.CarManufacturer;
                c.CarModel = car.CarModel;
                c.CarColor = (short)car.CarColor;
                c.CarReleaseDate = car.CarReleaseDate;
               
            }
            return await context.SaveChangesAsync()>0;
        }
        public async Task<bool> DeleteCarById(int id)
        {
            //var _car=context.CarDbSet.FirstOrDefault(c => c.Id == CarId);
            var _car = context.CarDbSet.Find(id);
            if (_car != null)
            {
                context.CarDbSet.Remove(_car);

            }
            return await context.SaveChangesAsync() > 0;

            //CarEntities c = new CarEntities() { Id=CarId};
            //context.Remove(c);
            //return await context.SaveChangesAsync()>0;



        }

        
    }
}
