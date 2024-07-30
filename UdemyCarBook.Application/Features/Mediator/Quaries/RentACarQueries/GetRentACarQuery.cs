﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;

namespace UdemyCarBook.Application.Features.Mediator.Quaries.RentACarQueries
{
    public class GetRentACarQuery:IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationID { get; set; }
        public bool Avaible { get; set; }
    }
}
