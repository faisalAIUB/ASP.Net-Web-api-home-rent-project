using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectEntity
{
    public class RentAd:Entity
    {
        
        
        public string FlatNo { get; set; }
        public string HouseNo { get; set; }
        
        public string RoadNo { get; set; }
        
        public string Area { get; set; }
        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        
        public string Description { get; set; }
        
        public double RentAmount { get; set; }
        public string Date { get; set; }
        public int HidePost { get; set; }
        public int UserId { get; set; }

    }
}
