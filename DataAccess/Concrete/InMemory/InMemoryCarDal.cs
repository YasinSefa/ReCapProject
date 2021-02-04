using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId="Mercedes", ColorId=20, ModelYear=2019, DailyPrice=400000, Description="Yeni", CategoryId=1 },
                new Car{Id=2, BrandId="BMW", ColorId=50, ModelYear=2000, DailyPrice=150000, Description="Yeni", CategoryId=1 },
                new Car{Id=3, BrandId="Audi", ColorId=43, ModelYear=2015, DailyPrice=350000, Description="Yeni", CategoryId=1 },
                new Car{Id=4, BrandId="Tofaş", ColorId=89, ModelYear=2006, DailyPrice=60000, Description="Yeni", CategoryId=2 },
                new Car{Id=5, BrandId="Toyota", ColorId=16, ModelYear=2021, DailyPrice=600000, Description="Yeni" , CategoryId=2 },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            
            Car carToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByCategory(int categoryId)
        {
            return _cars.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(p => p.Id == car.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
