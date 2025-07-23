using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Seeding.Seeders
{
    public interface ISeeder
    {
        Task<bool> ShouldRunAsync();
        Task SeedAsync();
    }
}
