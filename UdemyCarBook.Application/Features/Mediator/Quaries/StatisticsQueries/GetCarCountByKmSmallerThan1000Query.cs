﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;

namespace UdemyCarBook.Application.Features.Mediator.Quaries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThan1000Query:IRequest<GetCarCountByKmSmallerThen1000QueryResult>
    {
    }
}
