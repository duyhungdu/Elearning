using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSchool.Library.Helpers
{
    public enum ReportFormatType
    {
        Mhtml,
        Pdf,
        Excel,
        Zip,
        Csv
    }

    public enum FileExtension
    {
        mhtml,
        pdf,
        xls,
        zip,
        csv
    }

    public class ReportFormatConverter
    {
        public static FileExtension ToFileExtension(ReportFormatType reportFormatType)
        {
            switch (reportFormatType)
            {
                case ReportFormatType.Pdf:
                    return FileExtension.pdf;
                case ReportFormatType.Mhtml:
                    return FileExtension.mhtml;
                case ReportFormatType.Excel:
                    return FileExtension.xls;
                case ReportFormatType.Csv:
                    return FileExtension.csv;

            }

            return FileExtension.pdf;
        }
    }
}
