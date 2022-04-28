using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuscleWorld.Models;

namespace MuscleWorld.Data
{
    public class MuscleWorldContext : DbContext
    {
        public MuscleWorldContext (DbContextOptions<MuscleWorldContext> options)
            : base(options)
        {
        }

        public DbSet<MuscleWorld.Models.Member> Member { get; set; }
    }
}
