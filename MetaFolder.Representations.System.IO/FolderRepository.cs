using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaFolder.Repositories;

namespace MetaFolder.Representations.System.IO
{
    class FolderRepository : Repository
    {
        public FolderRepository(Uri baseUri) : base(baseUri)
        {

        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
