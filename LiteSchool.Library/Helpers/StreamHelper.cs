using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LiteSchool.Library.Helpers
{
    public class StreamHelper
    {
        public static byte[] CreateByteArrayFromStream(Stream input)
        {            
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }            
        }

        public static Stream CreateStreamFromByteArray(byte[] byteInfo)
        {            
            MemoryStream ms = new MemoryStream();
            
            ms.Write(byteInfo, 0, byteInfo.Length);
            ms.Position = 0;

            return ms;
        }
    }
}

