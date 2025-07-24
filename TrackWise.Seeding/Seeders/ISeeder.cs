using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Seeding.Seeders
{
    public interface ISeeder
    {
        public Task<bool> ShouldRunAsync();
        public Task SeedAsync();
    }
}
