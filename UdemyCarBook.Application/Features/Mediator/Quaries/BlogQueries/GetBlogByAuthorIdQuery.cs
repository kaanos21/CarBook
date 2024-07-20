﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Quaries.BlogQueries
{
    public class GetBlogByAuthorIdQuery : IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public GetBlogByAuthorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
