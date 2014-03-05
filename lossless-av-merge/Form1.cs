using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace lossless_av_merge
{
    public partial class Form1 : Form
    {

        public static AdvancedSettings advancedSettings = new AdvancedSettings();
        private long totalMediaDuration;
        SharpFFmpegEnc.VideoEncoder videoEncoder;

        public Form1()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\bin\\ffmpeg.exe") == false)
            {
                MessageBox.Show("Could not find the ffmpeg.exe binary in \\bin. Get ffmpeg.exe at http://ffmpeg.zeranoe.com/builds/ or compile it yourself." +
                    "\nThe program can not continue.", "ffmpeg.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            videoEncoder = new SharpFFmpegEnc.VideoEncoder(Environment.CurrentDirectory + "\\bin\\ffmpeg.exe");

            InitializeComponent();
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            FormAdvanced formAdvanced = new FormAdvanced();
            formAdvanced.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoEncoder.EventEncodingProgressChanged += videoEncoder_EventEncodingProgressChanged;
            videoEncoder.EventEncodingCompleted += videoEncoder_EventEncodingCompleted;
            //Drag and drop must be allowed
            listFiles.AllowDrop = true;
            cContainer.Text = cContainer.Items[1].ToString();
        }

        void videoEncoder_EventEncodingCompleted(int exitCode, string fullOutput)
        {
            MessageBox.Show("Done!");
            UpdateProgressBar(100);
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\log.txt", fullOutput);
        }

        void videoEncoder_EventEncodingProgressChanged(int frame, int frameRate, int size, TimeSpan time, int bitrate)
        {
            double percentagedec = time.TotalSeconds / totalMediaDuration;
            percentagedec *= 100;
            UpdateProgressBar(Convert.ToInt32(percentagedec));

            //You need to use cross thread calls since the events are called from a separate thread
            if (lblStatus.InvokeRequired == true)
            {
                lblStatus.Invoke(new Action<int, int, int, TimeSpan, int>(videoEncoder_EventEncodingProgressChanged), frame, frameRate, size, time, bitrate);
            }
            else
            {
                lblStatus.Text = "Merging files (" + (int)percentagedec + "%): " + " Frame: " + frame + " Fps:" + frameRate + " Size: " + size + "kB Bitrate:" + bitrate + "kb/s" + " Time:" + time.Hours + ":" + time.Minutes + ":" + time.Seconds;
            }


        }

        private void UpdateProgressBar(int percentage)
        {

            if (progressMain.InvokeRequired == true)
            {
                progressMain.Invoke(new Action<int>(UpdateProgressBar), percentage);
            }
            else
            {
                if (percentage > 100)
                {
                    progressMain.Value = 100;
                }
                else
                {
                    progressMain.Value = percentage;
                }
            }
        }


        private void UpdateOutputSize()
        {
            long totalSize = 0;

            foreach (ListViewItem item in listFiles.Items)
            {
                totalSize += new FileInfo(item.SubItems[2].Text + "\\" + item.Text).Length;
            }

            lblStatus.Text = "Expected output size: " + FormatDataLenght.FormatDataLenghtToString(totalSize);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            DialogResult result = fileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in fileDialog.FileNames)
                {
                    AddFileToList(file);
                }
            }
            UpdateOutputSize();
        }

        private void AddFileToList(string file)
        {
            ListViewItem listItem = new ListViewItem();
            FileInfo fileInfo = new FileInfo(file);

            listItem.Text = fileInfo.Name;
            listItem.SubItems.Add(FormatDataLenght.FormatDataLenghtToString(fileInfo.Length));
            listItem.SubItems.Add(fileInfo.DirectoryName);

            listFiles.Items.Add(listItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listFiles.SelectedItems)
            {
                item.Remove();
            }
            UpdateOutputSize();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in listFiles.SelectedItems)
            {
                ListViewItem tempItem = listItem;
                int tempIndex = listItem.Index;

                if (tempIndex != 0)
                {
                    listFiles.Items.Remove(listItem);
                    listFiles.Items.Insert(tempIndex - 1, tempItem);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in listFiles.SelectedItems)
            {
                ListViewItem tempItem = listItem;
                int tempIndex = listItem.Index;

                if (tempIndex + 1 != listFiles.Items.Count)
                {
                    listFiles.Items.Remove(listItem);
                    listFiles.Items.Insert(tempIndex + 1, tempItem);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtOutput.Text = saveDialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>();
            string extention = cContainer.Text.Remove(0, cContainer.Text.IndexOf("(") + 2).Replace(")", "");
            string output = txtOutput.Text;

            foreach (ListViewItem item in listFiles.Items)
            {
                fileList.Add(item.SubItems[2].Text + "\\" + item.Text);
            }

            lblStatus.Text = "Calculating total duration...";

            Thread mergeThread = new Thread(() => StartMergeThread(fileList, output, extention));
            mergeThread.Start();
        }

        private void StartMergeThread(List<string> fileList, string destination, string extention)
        {
            AVMerge merge = new AVMerge(videoEncoder);

            totalMediaDuration = GetMediaDuration(fileList);

            merge.Merge(fileList, destination, extention, ref advancedSettings);
        }

        private long GetMediaDuration(List<string> mediaFilePaths)
        {
            MediaInfoWrapper mw = new MediaInfoWrapper();
            long totalSeconds = 0;

            foreach (string file in mediaFilePaths)
            {
                totalSeconds += (long)mw.GetDuration(file).TotalSeconds;
            }

            return totalSeconds;
        }

        private void toolAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "lossless-av-merger\n" + 
                "PB1\n" +
                "\n" + 
                "Written in C# with .NET Framework 4.5.1\n" + 
                "by MightyNerd, licenced under GPL v2\n" + 
                "\n" + 
                "This program uses FFmpeg which is licenced under the LGPL licence. " + 
                "FFmpeg uses third party libriaries licenced under the GPL licence.\n" + 
                "\n" +
                "This program also uses MediaInfoLib. You can find the licence for it in licences\\MediaInfo - License.html\n" + 
                "\n" + 
                "This program's icons come from the Silk icon pack from http://www.famfamfam.com/"
                
                , "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.Show();
        }

        //Drag and drop into listFiles:
        private void listFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedFiles)
            {
                AddFileToList(file);
            }
        }

        private void listFiles_DragEnter(object sender, DragEventArgs e)
        {
            //Drag and drop mouse effect:
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
