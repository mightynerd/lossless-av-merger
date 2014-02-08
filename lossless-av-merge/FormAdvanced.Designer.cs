namespace lossless_av_merge
{
    partial class FormAdvanced
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.cAudioCodec = new System.Windows.Forms.ComboBox();
            this.chkEncodeAudio = new System.Windows.Forms.CheckBox();
            this.lblCodec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cAudioBitrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(274, 207);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(118, 23);
            this.btnSaveSettings.TabIndex = 0;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // cAudioCodec
            // 
            this.cAudioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cAudioCodec.FormattingEnabled = true;
            this.cAudioCodec.Items.AddRange(new object[] {
            "MP3 LAME (libmp3lame)",
            "AAC (libvo_aacenc)",
            "Vorbis (libvorbis)"});
            this.cAudioCodec.Location = new System.Drawing.Point(64, 22);
            this.cAudioCodec.Name = "cAudioCodec";
            this.cAudioCodec.Size = new System.Drawing.Size(121, 21);
            this.cAudioCodec.TabIndex = 1;
            // 
            // chkEncodeAudio
            // 
            this.chkEncodeAudio.AutoSize = true;
            this.chkEncodeAudio.Location = new System.Drawing.Point(12, 12);
            this.chkEncodeAudio.Name = "chkEncodeAudio";
            this.chkEncodeAudio.Size = new System.Drawing.Size(168, 17);
            this.chkEncodeAudio.TabIndex = 2;
            this.chkEncodeAudio.Text = "Encode audio (for compability)";
            this.chkEncodeAudio.UseVisualStyleBackColor = true;
            // 
            // lblCodec
            // 
            this.lblCodec.AutoSize = true;
            this.lblCodec.Location = new System.Drawing.Point(17, 25);
            this.lblCodec.Name = "lblCodec";
            this.lblCodec.Size = new System.Drawing.Size(41, 13);
            this.lblCodec.TabIndex = 3;
            this.lblCodec.Text = "Codec:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cAudioBitrate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cAudioCodec);
            this.groupBox1.Controls.Add(this.lblCodec);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Channel count, sample rate, etc. will be automatically \r\nchosen by ffmpeg.";
            // 
            // cAudioBitrate
            // 
            this.cAudioBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cAudioBitrate.FormattingEnabled = true;
            this.cAudioBitrate.Items.AddRange(new object[] {
            "96k",
            "128k",
            "192k",
            "256k",
            "320k"});
            this.cAudioBitrate.Location = new System.Drawing.Point(64, 49);
            this.cAudioBitrate.Name = "cAudioBitrate";
            this.cAudioBitrate.Size = new System.Drawing.Size(121, 21);
            this.cAudioBitrate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bitrate:";
            // 
            // FormAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 242);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkEncodeAudio);
            this.Controls.Add(this.btnSaveSettings);
            this.Name = "FormAdvanced";
            this.Text = "FormAdvanced";
            this.Load += new System.EventHandler(this.FormAdvanced_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.ComboBox cAudioCodec;
        private System.Windows.Forms.CheckBox chkEncodeAudio;
        private System.Windows.Forms.Label lblCodec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cAudioBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}