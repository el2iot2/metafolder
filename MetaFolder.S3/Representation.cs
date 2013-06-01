using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaFolder.S3
{
    public class Representation : IRepresentation
    {
        public string UriScheme
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsTag(Uri uri)
        {
            throw new NotImplementedException();
        }

        public bool IsMachineTag(Uri uri)
        {
            throw new NotImplementedException();
        }

        public bool IsResource(Uri uri)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IResource> GetResources(ITag tag)
        {
            throw new NotImplementedException();
        }

        public ISet<ITag> GetTags(IResource resource)
        {
            throw new NotImplementedException();
        }

        public void SetTags(IResource resource, ISet<ITag> tags)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IResource> Resources
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<ITag> Tags
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<IIndex> Indices
        {
            get { throw new NotImplementedException(); }
        }

        public System.IO.Stream Get(IResource resource)
        {
            throw new NotImplementedException();
        }

        public Uri Put(System.IO.Stream content, ISet<ITag> tags)
        {
            throw new NotImplementedException();
        }

        public void Delete(IResource resource)
        {
            throw new NotImplementedException();
        }

        public Uri Identify(System.IO.Stream content)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
