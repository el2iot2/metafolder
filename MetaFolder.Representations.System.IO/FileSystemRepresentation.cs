using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaFolder.Representations.System.IO
{
    public class FileSystemRepresentation : Representation
    {
        public FileSystemRepresentation()
            : base(Ruri.Scheme)
        {

        }

        public override IRepository Open(Uri repositoryUri)
        {
            throw new NotImplementedException();
        }
    }
}
