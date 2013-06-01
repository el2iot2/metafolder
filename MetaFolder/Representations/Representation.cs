using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaFolder.Representations.Hashes;

namespace MetaFolder.Representations
{
    public abstract class Representation : IRepresentation
    {
        readonly string _UriScheme;
        public Representation(string uriScheme)
        {
            if (string.IsNullOrEmpty(uriScheme))
            {
                throw new ArgumentNullException("uriScheme");
            }
            _UriScheme = uriScheme;
        }

        public string UriScheme
        {
            get { return _UriScheme; }
        }

        public Uri Identify(IRepository repository, Stream stream, int pass)
        {
            int hash;
            hash = MurMurHash3.Hash(stream, pass);
            byte[] bytes = BitConverter.GetBytes(hash);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return new Uri(repository.BaseUri, Convert.ToBase64String(bytes));
        }


        public abstract IRepository Open(Uri repositoryUri);
    }
}
