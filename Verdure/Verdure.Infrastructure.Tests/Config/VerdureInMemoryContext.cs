using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.EFCore;

namespace Verdure.Infrastructure.Tests.Config
{
    public class VerdureInMemoryContext : VerdureEfcContext
    {
        public VerdureInMemoryContext(DbContextOptions options): base(options)
        {  }

        public static VerdureInMemoryContext Context => new VerdureInMemoryContext(new DbContextOptionsBuilder<VerdureInMemoryContext>()
                .UseInMemoryDatabase(databaseName: "VerdureTestDb")
                .Options);
    }

}
