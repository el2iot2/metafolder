using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFolder.Representations.Amazon.S3
{
    public class S3Representation : Representation
    {
        public S3Representation()
            : base(Ruri.Scheme)
        {

        }

        public override IRepository Open(Uri repositoryUri)
        {
            return new BucketRepository(repositoryUri);
        }
    }
}
