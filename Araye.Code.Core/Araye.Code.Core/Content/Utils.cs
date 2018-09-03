using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Araye.Code.Core.Extensions;

namespace Araye.Code.Core.Content
{
    public class Utils
    {
        public static string GetUniqueFilePath(string directoryName, string fileName)
        {
            var validatedName = Guid.NewGuid().ToStringSafe() + fileName;
            while (File.Exists(String.Format("{0}/{1}", directoryName, validatedName)))
            {
                validatedName = string.Format("{0}_{1}", Guid.NewGuid().ToStringSafe(), fileName);
            }
            return validatedName;
        }

        public static string GetSlug(string title, int length)
        {
            var end = title.Length > length ? length : title.Length;
            var slug = title.Substring(0, end);
            return slug = slug.Replace(" ", "-").Replace(":", "-").Replace(".", "-");
        }

        public static string GetSlug(string title)
        {
            return GetSlug(title, title.Length);
        }

        public static string UnSlug(string tilte)
        {
            return tilte.Replace("-", " ");
        }
    }
}
