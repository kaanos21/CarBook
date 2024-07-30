﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var vv = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();
            return vv;
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from (Select  Model,CoverImageUrl ,PricingID,Amount from CarPricings Inner join Cars On Cars.CarID=CarPricings.CarID Inner join Brands on Brands.BrandID=Cars.BrandID ) as SourceTable Pivot( sum(amount) for PricingID In([2],[4],[5],[7]) ) AS PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts=new List<decimal>
                            {
                                reader.IsDBNull(2) ? 0 : Convert.ToDecimal(reader[2]),
                        reader.IsDBNull(3) ? 0 : Convert.ToDecimal(reader[3]),
                        reader.IsDBNull(4) ? 0 : Convert.ToDecimal(reader[4])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }































            //var vv = from x in _context.CarPricings
            //         group x by x.PricingID into g
            //         select new
            //         {
            //             CarId = g.Key,
            //             DailyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
            //             WeeklyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
            //             MonthlyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
            //         };
            //return vv.ToList();
            /*sdfsd
             * 
             * List<CarPricing> values=new List<CarPricing>();
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "select * from (Select Model,PricingID,Amount from CarPricings Inner join Cars On Cars.CarID=CarPricings.CarID Inner join Brands on Brands.BrandID=Cars.BrandID ) as SourceTable Pivot( sum(amount) for PricingID In([2],[4],[5],[7]) ) AS PivotTable;";
                    command.CommandType=System.Data.CommandType.Text;
                    _context.Database.OpenConnection();
                    using (var reader= command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarPricing carPricing = new CarPricing();
                            Enumerable.Range(1, 3).ToList().ForEach(x =>
                            {
                                if (DBNull.Value.Equals(reader[x]))
                                {
                                    carPricing
                                }
                                else
                                {
                                    carPricing.Amount
                                }
                            });
                            values.Add(carPricing);
                        }
                    }
                    _context.Database.CloseConnection();
                    return values;
                }
             */
        }
    }
}
