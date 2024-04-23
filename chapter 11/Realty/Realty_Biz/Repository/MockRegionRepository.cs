using Realty_Biz.Repository.IRepository;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository
{
    public class MockRegionRepository : IRegionRepository
    {
        private List<Region> data;

        public MockRegionRepository()
        {
            data = new List<Region>()
            {
                new Region() { Id = 1, Nm = "Москва", GIBDD = "77" },
                new Region() { Id = 2, Nm = "Московская область", GIBDD = "50" },
                new Region() { Id = 3, Nm = "Санкт-Петербург", GIBDD = "78" }
            };
        }

        public async Task<Region> Create(Region obj)
        {
            await Task.Delay(500);
            if (data.Where(x => x.Nm?.ToUpper() == obj.Nm?.ToUpper()).Count() > 0) throw new Exception("Элемент уже существует в списке.");
            obj.Id = data.Max(p => p.Id) + 1;
            data.Add(obj);
            return obj;
        }

        public async Task<int> Delete(int id)
        {
            await Task.Delay(500);
            var obj = data.FirstOrDefault(p => p.Id == id);
            if (obj == null) return 0;
            return data.RemoveAll(x => x.Id == id);
        }

        public async Task<Region> Get(int id)
        {
            await Task.Delay(500);
            var obj = data.FirstOrDefault(p => p.Id == id);
            Region region = new Region();
            if (obj != null)
            {
                region.Id = obj.Id;
                region.Nm = obj.Nm;
                region.GIBDD = obj.GIBDD;
            }
            return region;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            await Task.Delay(500);
            return data;
        }

        public async Task<Region> Update(Region obj)
        {
            await Task.Delay(500);
            var objFromData = data.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromData != null)
            {
                objFromData.Nm = obj.Nm;
                objFromData.GIBDD = obj.GIBDD;
                data.Where(p => p.Id == obj.Id).ToList().ForEach(x => { x.Nm = obj.Nm; x.GIBDD = obj.GIBDD; });
                return objFromData;
            }
            return obj;
        }
    }
}
