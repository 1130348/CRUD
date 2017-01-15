using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Model;
using System.Data.Entity;
using ClassLibrary.DAL;

namespace CancelaTest.DbSet
{
    public class TestCancelaContext : DatumContext
    {
        public TestCancelaContext()
        {
            this.POIs = new TestPOIDbSet();
        }

        public DbSet<POI> POIs { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(POI item) { }
        public void Dispose() { }
    }
}
