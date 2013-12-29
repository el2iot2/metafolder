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
        static readonly IDictionary<IContentType, Func<Stream, Stream>> _StreamIdentifierPreprocessorFuncs;
        static DirectoryRepresentation()
        {
            _StreamIdentifierPreprocessorFuncs = new Dictionary<IContentType, Func<Stream, Stream>>()
            {
                {ContentType.ImageJpeg, SkipExifData}
            };
        }

        //Based On: http://techmikael.blogspot.com/2009/07/removing-exif-data-continued.html
        static Stream SkipExifData(Stream stream)
        {
            byte[] jpegHeader = new byte[2];
            jpegHeader[0] = (byte)stream.ReadByte();
            jpegHeader[1] = (byte)stream.ReadByte();
            if (jpegHeader[0] == 0xff && jpegHeader[1] == 0xd8) //check if it's a jpeg file
            {
                byte[] header = new byte[2];
                header[0] = (byte)stream.ReadByte();
                header[1] = (byte)stream.ReadByte();

                while (header[0] == 0xff && (header[1] >= 0xe0 && header[1] <= 0xef))
                {
                    int exifLength = stream.ReadByte();
                    exifLength = exifLength << 8;
                    exifLength |= stream.ReadByte();

                    for (int i = 0; i < exifLength - 2; i++)
                    {
                        stream.ReadByte();
                    }
                    header[0] = (byte)stream.ReadByte();
                    header[1] = (byte)stream.ReadByte();
                }
                stream.Position -= 2; //skip back two bytes
            }
            return stream;
        }
    }
}
