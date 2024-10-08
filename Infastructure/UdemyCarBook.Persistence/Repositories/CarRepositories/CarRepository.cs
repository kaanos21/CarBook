﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            int x = _context.Cars.Count();
            return x;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var vv=_context.Cars.Include(x=>x.Brand).ToList();
            return vv;
        }

       

        public List<Car> GetLast5CarsWithBrands()
        {
            var values=_context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }
    }
}
