using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithCode.Models.context
{
    public class Ap1DbContext:IdentityDbContext
    {
        public Ap1DbContext(DbContextOptions option):base(option)
        {

        }
    }
}
