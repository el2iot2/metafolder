using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaFolder.Repositories;

namespace MetaFolder.Representations.Amazon.S3
{
    class BucketRepository : Repository
    {
        public BucketRepository(Uri baseUri)
            : base(baseUri)
        {

        }



        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
