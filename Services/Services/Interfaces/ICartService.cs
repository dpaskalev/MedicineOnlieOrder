using Services.VewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartViewModel>> GetIndexAsync(string userId);

        public Task AddAsync(int medicineId, string userId);

        public Task RemoveAsync(int medicineId, string userId);
    }
}
