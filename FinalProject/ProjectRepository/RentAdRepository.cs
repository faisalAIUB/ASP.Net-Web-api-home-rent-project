using ProjectEntity;
using ProjectInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public class RentAdRepository:Repository<RentAd>,IRentAdRepository
    {
        ProjectDBContext context = new ProjectDBContext();
        public List<RentAd> GetByUserId(int id)
        {
            return context.RentAds.Where(r => r.UserId == id).ToList();
        }
    }
}
