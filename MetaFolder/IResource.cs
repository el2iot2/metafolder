using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFolder
{
    public interface IResource
    {
        Uri Resource { get; }
        Stream Read();
        long? Length { get; }
    }

    public static class IResourceExtensions
    {
        public static bool EqualTo(this IResource first, IResource second)
        {
            if (first.Length.HasValue && //If the length is available
                second.Length.HasValue && //For both
                first.Length != second.Length) //and they differ
            {
                return false; //we know immediately
            }

            using (
                Stream
                    firstStream = first.Read(),
                    secondStream = second.Read())
            {
                return StreamCompare(firstStream, secondStream);
            }
        }

        const int BufferSize = 32768;
        static bool StreamCompare(Stream firstStream, Stream secondStream)
        {
            byte[] firstBuffer = new byte[BufferSize];
            byte[] secondBuffer = new byte[BufferSize];

            int firstRemaining = 0;
            int secondRemaining = 0;
            int firstIndex = 0;
            int secondIndex = 0;

            while (true)
            {
                if (firstRemaining == 0)
                {
                    firstIndex = 0;
                    firstRemaining = firstStream.Read(firstBuffer, 0, BufferSize);
                }
                if (secondRemaining == 0)
                {
                    secondIndex = 0;
                    secondRemaining = secondStream.Read(secondBuffer, 0, BufferSize);
                }

                // End of both streams simultaneously
                if (firstRemaining == 0 && secondRemaining == 0)
                {
                    return true;
                }
                // One stream ended before the other
                if (firstRemaining == 0 || secondRemaining == 0)
                {
                    return false;
                }

                int compareSize = Math.Min(firstRemaining, secondRemaining);
                for (int i = 0; i < compareSize; i++)
                {
                    if (firstBuffer[firstIndex] != secondBuffer[secondIndex])
                    {
                        return false;
                    }
                    firstIndex++;
                    secondIndex++;
                }

                firstRemaining -= compareSize;
                secondRemaining -= compareSize;
            }
        }
    }
}
