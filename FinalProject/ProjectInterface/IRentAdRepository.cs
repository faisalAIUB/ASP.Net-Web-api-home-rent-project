using ProjectEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInterface
{
    public interface IRentAdRepository:IRepository<RentAd>
    {
        List<RentAd> GetByUserId(int id);
    }
}
