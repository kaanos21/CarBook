﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Command.PricingCommands
{
    public class UpdatePricingCommand:IRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
