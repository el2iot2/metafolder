using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFolder.Resources
{
    public class FileResource : IResource
    {
        readonly string _Path;
        readonly Uri _Resource;
        public FileResource(Uri resource, string path)
        {
            _Path = path;
        }

        public Stream Read()
        {
            return File.OpenRead(_Path);
        }


        public long? Length
        {
            get { return new FileInfo(_Path).Length; }
        }

        public Uri Resource
        {
            get { return _Resource; }
        }
    }
}
