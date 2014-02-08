using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lossless_av_merge
{
    class FormatDataLenght
    {

        public static string FormatDataLenghtToString(long fileLenght)
        {
            string ret = fileLenght + " B";

            if (fileLenght > 1024)
            {
                ret = Math.Round((decimal)fileLenght / 1024, 0).ToString() + " kiB";
            }
            if (fileLenght > Math.Pow(1024, 2))
            {
                ret = Math.Round((decimal)fileLenght / (decimal)Math.Pow(1024, 2), 0).ToString() + " MiB";
            }
            if (fileLenght > Math.Pow(1024, 3))
            {
                ret = Math.Round((decimal)fileLenght / (decimal)Math.Pow(1024, 3), 1).ToString() + " GiB";
            }
            if (fileLenght > Math.Pow(1024, 4))
            {
                ret = Math.Round((decimal)fileLenght / (decimal)Math.Pow(1024, 4), 2).ToString() + " TiB";
            }

            return ret;
        }

    }
}
