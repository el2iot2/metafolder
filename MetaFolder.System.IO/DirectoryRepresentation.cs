using CrockfordBase32;
using Murmur;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetaFolder.System.IO
{
    public partial class DirectoryRepresentation : Representation
    {
        readonly HashAlgorithm _HashAlgorithm;
        readonly CrockfordBase32Encoding _Encoding;
        readonly int _FolderDepth;
        public DirectoryRepresentation() : this(seed: 3475832, folderDepth: 2)
	    {

	    }

        public DirectoryRepresentation(uint seed, int folderDepth) : base(new Uri("MetaFolder.System.IO.FolderRepresentation"))
	    {
            _HashAlgorithm = MurmurHash.Create128(seed);
            _Encoding = new CrockfordBase32Encoding();
            _FolderDepth = folderDepth;
	    }

        public override Uri Identify(IRepository repository, Stream originalContentStream, ITypedContent typedContent)
        {
            Stream contentStream = originalContentStream;
            string fileExtension = null;

            if (typedContent != null)
            {
                fileExtension = typedContent.FileExtension;
                Func<Stream, Stream> streamPreprocessorFunc;
                if (_StreamIdentifierPreprocessorFuncs.TryGetValue(typedContent.ContentType, out streamPreprocessorFunc))
                {
                    contentStream = streamPreprocessorFunc(originalContentStream);
                }
            }
            
            byte[] hash = _HashAlgorithm.ComputeHash(contentStream);
            string relativeUri = string.Concat(
                    _Encoding
                        .Encode(
                            BitConverter.ToUInt64(hash, 0),
                            false)
                        .ToLower(),
                    "-",
                    _Encoding
                        .Encode(
                            BitConverter.ToUInt64(hash, 8),
                            false)
                        .ToLower());

            for (int i = _FolderDepth; i > 0; i--)
            {
                relativeUri = relativeUri.Insert(i, Path.DirectorySeparatorChar.ToString());
            }
            
            if (fileExtension != null)
            {
                relativeUri = Path.ChangeExtension(relativeUri, fileExtension);
            }

            return new Uri(repository.Uri, relativeUri);
        }

        public override IRepository Open(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            if (!uri.IsAbsoluteUri || !uri.IsFile || !Directory.Exists(uri.LocalPath))
            {
                throw new ArgumentException("Expected a local directory path", "uri");
            }
            return new DirectoryRepository(uri);
        }
    }
}
