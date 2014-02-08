using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lossless_av_merge
{ 

    class MediaInfoWrapper
    {
        MediaInfoLib.MediaInfo mediaInfo = new MediaInfoLib.MediaInfo(); 

        public MediaInfoWrapper()
        {

        }

        public TimeSpan GetDuration(string filePath)
        {
            mediaInfo.Open(filePath);
            TimeSpan duration = TimeSpan.Parse(mediaInfo.Get(MediaInfoLib.StreamKind.General, 0, "Duration/String3"));
            return duration;
        }

    }
}
