﻿using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorService :EntityBaseRepository<Actor>, IActorsService
    {
        public ActorService(AppDBContext context) : base (context) { }
    }
}
