using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Biz.Repository.IRepository
{
public interface IRegionRepository
{
    public Task<Region> Create(Region obj);
    public Task<Region> Update(Region obj);
    public Task<int> Delete(int id);
    public Task<Region> Get(int id);
    public Task<IEnumerable<Region>> GetAll();
}
}
