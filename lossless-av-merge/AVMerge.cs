using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lossless_av_merge
{
    class AVMerge
    {

        private SharpFFmpegEnc.VideoEncoder encoder;
        private string listPath = Environment.CurrentDirectory + "\\temporary-file-list.txt";

        public AVMerge(SharpFFmpegEnc.VideoEncoder videoEncoder)
        {
            encoder = videoEncoder;
        }

        public void Merge(List<string> fileList, string outputFile, string extention, ref AdvancedSettings advancedSettings)
        {
            WriteFileList(fileList);
            string arguments = "";

            if (advancedSettings.AudioEncodingEnabled == true)
            {
                arguments = String.Format("-f concat -i \"{0}\" -c:v copy -c:a {1} -b:a {2} \"{3}\"", listPath, advancedSettings.AudioEncoder, advancedSettings.AudioBitrate, outputFile + extention);
            }
            else
            {
                arguments = String.Format("-f concat -i \"{0}\" -c copy \"{1}\"", listPath, outputFile + extention);
            }

            encoder.Encode(arguments);
        }

        private void WriteFileList(List<string> fileList)
        {
            if (File.Exists(listPath))
            {
                File.Delete(listPath);
            }

            StreamWriter writer = new StreamWriter(listPath);
            writer.WriteLine("#Temporary file list by lossless-av-merge");

            foreach (string file in fileList)
            {
                writer.WriteLine(String.Format("file '{0}'", file));
            }

            writer.Close();
        }
    }
}
