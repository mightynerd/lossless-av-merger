using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lossless_av_merge
{
    public class AdvancedSettings
    {
        public bool AudioEncodingEnabled { get; set; }
        public string AudioEncoder { get; set; }
        public string AudioBitrate { get; set; }
        
        public static string AudioEncoderComboStringToEncoder(string comboString)
        {
            switch (comboString)
            {
                case "MP3 LAME (libmp3lame)":
                    return "libmp3lame";
                case "AAC (libvo_aacenc)":
                    return "libvo_aacenc";
                case "Vorbis (libvorbis)":
                    return "libvorbis";
                default:
                    return "libmp3lame";
            }
        }

    }
}
