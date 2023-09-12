﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppcationDbContext
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserLocation> UserLocations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
