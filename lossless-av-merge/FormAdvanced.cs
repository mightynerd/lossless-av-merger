using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lossless_av_merge
{
    public partial class FormAdvanced : Form
    {
      
        public FormAdvanced()
        {
            InitializeComponent();
        }

        private void FormAdvanced_Load(object sender, EventArgs e)
        {
            cAudioCodec.Text = cAudioCodec.Items[0].ToString();
            cAudioBitrate.Text = cAudioBitrate.Items[2].ToString();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Form1.advancedSettings.AudioBitrate = cAudioBitrate.Text;
            Form1.advancedSettings.AudioEncoder = AdvancedSettings.AudioEncoderComboStringToEncoder(cAudioCodec.Text);
            Form1.advancedSettings.AudioEncodingEnabled = chkEncodeAudio.Checked;
            this.Close();
        }
    }
}
