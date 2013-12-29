using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFolder
{
    public interface IContentType
    {
        string Name { get; }
        IEnumerable<string> SupportedExtensions { get; }
    }

    public class ContentType : IContentType
    {
        public static readonly IContentType Any;
        public static readonly IContentType ImageJpeg;
        static ContentType()
        {
            Any = new ContentType("*/*");
            ImageJpeg = new ContentType("image/jpeg", "jpeg", "jpg");
        }

        readonly string _Name;
        readonly string[] _SupportedExtensions;
        internal ContentType(string name, params string[] supportedExtensions)
        {
            _Name = name;
            _SupportedExtensions = supportedExtensions;
        }

        public string Name
        {
            get { return _Name; }
        }

        public IEnumerable<string> SupportedExtensions
        {
            get { return _SupportedExtensions; }
        }

        public override string ToString()
        {
            return _Name;
        }
    }

    public interface ITypedContent
    {
        IContentType ContentType { get; }
        string FileExtension { get; }
    }

    public class TypedContent : ITypedContent
    {
        readonly IContentType _ContentType;
        readonly string _FileExtension;
        internal TypedContent(IContentType contentType, string fileExtension)
        {
            _ContentType = contentType;
            _FileExtension = fileExtension;
        }

        public IContentType ContentType
        {
            get { return _ContentType; }
        }

        public override string ToString()
        {
            return _ContentType.ToString();
        }

        public string FileExtension
        {
            get { return _FileExtension; }
        }
    }
}
