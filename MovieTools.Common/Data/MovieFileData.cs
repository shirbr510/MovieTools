using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MovieTools.Common.Data
{
    public struct MovieFileData
    {

        public string Name { get; set; }

        public int Year { get; set; }

        public string Extension { get; set; }

        public string Resolution { get; set; }

        public string ToFilePath()
        {
            var str = Name;
            if (Year != -1)
            {
                str = string.Join(".", str, Year);
            }
            if (!string.IsNullOrWhiteSpace(Resolution))
            {
                str = string.Join(".", str, Resolution);
            }
            return string.Join(".", str, Extension);
        }

        public string ToDirectoryPath()
        {
            return Year == -1 ? Name : string.Format("{0} ({1})", Name, Year);
        }
    }
}
