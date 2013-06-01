using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace MetaFolder.Repositories
{
    public abstract class Repository : IRepository
    {
        readonly Uri _BaseUri;
        public Repository(Uri baseUri)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (!baseUri.IsAbsoluteUri)
            {
                throw new ArgumentException("URI should be absolute", "baseUri");
            }
            _BaseUri = baseUri;
        }

        public Uri BaseUri
        {
            get { return _BaseUri; }
        }

        

        //public Uri Put(IContent content, ISet<ITag> tags)
        //{
        //    int pass = 0;
        //    Uri destinationUri;
        //    IEnumerable<Uri> 
        //        uriSelections = Enumerable.Empty<Uri>(), 
        //        uriCollisions;
            
        //    do
        //    {
        //        destinationUri = CalculateUri(content, pass++);
        //        uriCollisions = uriSelections; //preserve last selections
        //        uriSelections = SelectIdentifiers(destinationUri).ToList();
        //    }
        //    while (uriSelections.Any());

        //    //Check collisions byte by byte
        //    Uri existingContentUri = uriCollisions
        //        .FirstOrDefault(uriCollision => Get(uriCollision).ContentIsIdentical(content));

        //    //if this content is already represented
        //    if (existingContentUri != null)
        //    {
        //        //just return the uri and don't upload
        //        return existingContentUri;    
        //    }
        //    PutContent(content);
        //    return destinationUri;
        //}


        public abstract void Dispose();



        public IQbservable<Uri> Resources
        {
            get { throw new NotImplementedException(); }
        }

        public IQbservable<string> Tags
        {
            get { throw new NotImplementedException(); }
        }

        public IQbservable<IIndex> Indices
        {
            get { throw new NotImplementedException(); }
        }

        public IObservable<IResource> Get(IEnumerable<Uri> resources)
        {
            throw new NotImplementedException();
        }

        public IObservable<Uri> Post(IEnumerable<Uri> resources)
        {
            throw new NotImplementedException();
        }

        public IObservable<Uri> Post(IEnumerable<IResource> resources)
        {
            throw new NotImplementedException();
        }

        public IObservable<Uri> Delete(IEnumerable<Uri> resources)
        {
            throw new NotImplementedException();
        }
    }
}
