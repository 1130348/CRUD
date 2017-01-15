using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelaTest.DbSet
{
    public class TestPOIDbSet : TestDbSet<POI>
    {
        public override POI Find(params object[] keyValues)
        {
            return this.SingleOrDefault(poi => poi.PoiID == (int)keyValues.Single());
        }
    }
}
