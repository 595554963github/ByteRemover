using System;
using System.Windows.Forms;

namespace UniversalByteRemover
{
    public partial class ByteRemover : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPathPrompt;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelBackupPrompt;
        private System.Windows.Forms.Label labelModePrompt;
        private System.Windows.Forms.RadioButton radioButtonMode1;
        private System.Windows.Forms.RadioButton radioButtonMode2;
        private System.Windows.Forms.RadioButton radioButtonMode3;
        private System.Windows.Forms.RadioButton radioButtonMode4;
        private System.Windows.Forms.RadioButton radioButtonMode5;
        private System.Windows.Forms.RadioButton radioButtonMode6;
        private System.Windows.Forms.RadioButton radioButtonMode7;
        private System.Windows.Forms.RadioButton radioButtonMode8;
        private System.Windows.Forms.RadioButton radioButtonMode9;
        private System.Windows.Forms.Label labelByteSequencePrompt;
        private System.Windows.Forms.TextBox textBoxByteSequence;
        private System.Windows.Forms.Label labelStringPrompt;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Label labelHexAddressPrompt;
        private System.Windows.Forms.TextBox textBoxHexAddress;
        private System.Windows.Forms.Label labelStartAddressPrompt;
        private System.Windows.Forms.TextBox textBoxStartAddress;
        private System.Windows.Forms.Label labelEndAddressPrompt;
        private System.Windows.Forms.TextBox textBoxEndAddress;
        private System.Windows.Forms.Label labelByteValuePrompt;
        private System.Windows.Forms.TextBox textBoxByteValue;
        private System.Windows.Forms.Label labelNumberPrompt;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Label labelFileFormatPrompt;
        private System.Windows.Forms.TextBox textBoxFileFormat;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelPathPrompt = new Label();
            textBoxPath = new TextBox();
            labelBackupPrompt = new Label();
            labelModePrompt = new Label();
            radioButtonMode1 = new RadioButton();
            radioButtonMode2 = new RadioButton();
            radioButtonMode3 = new RadioButton();
            radioButtonMode4 = new RadioButton();
            radioButtonMode5 = new RadioButton();
            radioButtonMode6 = new RadioButton();
            radioButtonMode7 = new RadioButton();
            radioButtonMode8 = new RadioButton();
            radioButtonMode9 = new RadioButton();
            labelByteSequencePrompt = new Label();
            textBoxByteSequence = new TextBox();
            labelStringPrompt = new Label();
            textBoxString = new TextBox();
            labelHexAddressPrompt = new Label();
            textBoxHexAddress = new TextBox();
            labelStartAddressPrompt = new Label();
            textBoxStartAddress = new TextBox();
            labelEndAddressPrompt = new Label();
            textBoxEndAddress = new TextBox();
            labelByteValuePrompt = new Label();
            textBoxByteValue = new TextBox();
            labelNumberPrompt = new Label();
            textBoxNumber = new TextBox();
            buttonProcess = new Button();
            labelFileFormatPrompt = new Label();
            textBoxFileFormat = new TextBox();
            richTextBoxOutput = new RichTextBox();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // labelPathPrompt
            // 
            labelPathPrompt.AutoSize = true;
            labelPathPrompt.ForeColor = Color.Red;
            labelPathPrompt.Location = new Point(13, 15);
            labelPathPrompt.Name = "labelPathPrompt";
            labelPathPrompt.Size = new Size(128, 17);
            labelPathPrompt.TabIndex = 0;
            labelPathPrompt.Text = "请拖放一个文件夹到此";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(144, 11);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(320, 23);
            textBoxPath.TabIndex = 1;
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            // 
            // labelBackupPrompt
            // 
            labelBackupPrompt.AutoSize = true;
            labelBackupPrompt.ForeColor = Color.Lime;
            labelBackupPrompt.Location = new Point(13, 45);
            labelBackupPrompt.Name = "labelBackupPrompt";
            labelBackupPrompt.Size = new Size(236, 17);
            labelBackupPrompt.TabIndex = 3;
            labelBackupPrompt.Text = "请放心操作，该工具不会破坏您的游戏数据";
            // 
            // labelModePrompt
            // 
            labelModePrompt.AutoSize = true;
            labelModePrompt.ForeColor = Color.DeepSkyBlue;
            labelModePrompt.Location = new Point(13, 76);
            labelModePrompt.Name = "labelModePrompt";
            labelModePrompt.Size = new Size(155, 17);
            labelModePrompt.TabIndex = 6;
            labelModePrompt.Text = "请选择模式，点击对应选项:";
            // 
            // radioButtonMode1
            // 
            radioButtonMode1.AutoSize = true;
            radioButtonMode1.Location = new Point(13, 105);
            radioButtonMode1.Name = "radioButtonMode1";
            radioButtonMode1.Size = new Size(216, 21);
            radioButtonMode1.TabIndex = 7;
            radioButtonMode1.Text = "1:删除指定字节序列前面的所有字节";
            radioButtonMode1.UseVisualStyleBackColor = true;
            radioButtonMode1.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode2
            // 
            radioButtonMode2.AutoSize = true;
            radioButtonMode2.Location = new Point(13, 132);
            radioButtonMode2.Name = "radioButtonMode2";
            radioButtonMode2.Size = new Size(240, 21);
            radioButtonMode2.TabIndex = 8;
            radioButtonMode2.Text = "2:删除指定字节序列及其后面的所有字节";
            radioButtonMode2.UseVisualStyleBackColor = true;
            radioButtonMode2.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode3
            // 
            radioButtonMode3.AutoSize = true;
            radioButtonMode3.Location = new Point(13, 159);
            radioButtonMode3.Name = "radioButtonMode3";
            radioButtonMode3.Size = new Size(192, 21);
            radioButtonMode3.TabIndex = 9;
            radioButtonMode3.Text = "3:删除指定地址前面的所有字节";
            radioButtonMode3.UseVisualStyleBackColor = true;
            radioButtonMode3.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode4
            // 
            radioButtonMode4.AutoSize = true;
            radioButtonMode4.Location = new Point(13, 186);
            radioButtonMode4.Name = "radioButtonMode4";
            radioButtonMode4.Size = new Size(180, 21);
            radioButtonMode4.TabIndex = 10;
            radioButtonMode4.Text = "4:删除指定地址后的所有字节";
            radioButtonMode4.UseVisualStyleBackColor = true;
            radioButtonMode4.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode5
            // 
            radioButtonMode5.AutoSize = true;
            radioButtonMode5.Location = new Point(13, 213);
            radioButtonMode5.Name = "radioButtonMode5";
            radioButtonMode5.Size = new Size(276, 21);
            radioButtonMode5.TabIndex = 11;
            radioButtonMode5.Text = "5:删除起始地址前面和结束地址后面的所有字节";
            radioButtonMode5.UseVisualStyleBackColor = true;
            radioButtonMode5.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode6
            // 
            radioButtonMode6.AutoSize = true;
            radioButtonMode6.Location = new Point(13, 240);
            radioButtonMode6.Name = "radioButtonMode6";
            radioButtonMode6.Size = new Size(168, 21);
            radioButtonMode6.TabIndex = 12;
            radioButtonMode6.Text = "6:删除文件尾部的重复字节";
            radioButtonMode6.UseVisualStyleBackColor = true;
            radioButtonMode6.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode7
            // 
            radioButtonMode7.AutoSize = true;
            radioButtonMode7.Location = new Point(13, 267);
            radioButtonMode7.Name = "radioButtonMode7";
            radioButtonMode7.Size = new Size(180, 21);
            radioButtonMode7.TabIndex = 13;
            radioButtonMode7.Text = "7:删除文件尾部指定数量字节";
            radioButtonMode7.UseVisualStyleBackColor = true;
            radioButtonMode7.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode8
            // 
            radioButtonMode8.AutoSize = true;
            radioButtonMode8.Location = new Point(13, 294);
            radioButtonMode8.Name = "radioButtonMode8";
            radioButtonMode8.Size = new Size(180, 21);
            radioButtonMode8.TabIndex = 14;
            radioButtonMode8.Text = "8:删除文件开头指定数量字节";
            radioButtonMode8.UseVisualStyleBackColor = true;
            radioButtonMode8.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // radioButtonMode9
            // 
            radioButtonMode9.AutoSize = true;
            radioButtonMode9.Location = new Point(13, 321);
            radioButtonMode9.Name = "radioButtonMode9";
            radioButtonMode9.Size = new Size(204, 21);
            radioButtonMode9.TabIndex = 15;
            radioButtonMode9.Text = "9:删除指定字符串前面的所有字节";
            radioButtonMode9.UseVisualStyleBackColor = true;
            radioButtonMode9.CheckedChanged += RadioButtonMode_CheckedChanged;
            // 
            // labelByteSequencePrompt
            // 
            labelByteSequencePrompt.AutoSize = true;
            labelByteSequencePrompt.ForeColor = Color.Black;
            labelByteSequencePrompt.Location = new Point(13, 357);
            labelByteSequencePrompt.Name = "labelByteSequencePrompt";
            labelByteSequencePrompt.Size = new Size(164, 17);
            labelByteSequencePrompt.TabIndex = 16;
            labelByteSequencePrompt.Text = "请输入字节序列，以空格间隔";
            // 
            // textBoxByteSequence
            // 
            textBoxByteSequence.Enabled = false;
            textBoxByteSequence.Location = new Point(183, 353);
            textBoxByteSequence.Name = "textBoxByteSequence";
            textBoxByteSequence.Size = new Size(281, 23);
            textBoxByteSequence.TabIndex = 17;
            // 
            // labelStringPrompt
            // 
            labelStringPrompt.AutoSize = true;
            labelStringPrompt.ForeColor = Color.Black;
            labelStringPrompt.Location = new Point(13, 390);
            labelStringPrompt.Name = "labelStringPrompt";
            labelStringPrompt.Size = new Size(104, 17);
            labelStringPrompt.TabIndex = 18;
            labelStringPrompt.Text = "请输入目标字符串";
            // 
            // textBoxString
            // 
            textBoxString.Enabled = false;
            textBoxString.Location = new Point(123, 386);
            textBoxString.Name = "textBoxString";
            textBoxString.Size = new Size(341, 23);
            textBoxString.TabIndex = 19;
            // 
            // labelHexAddressPrompt
            // 
            labelHexAddressPrompt.AutoSize = true;
            labelHexAddressPrompt.ForeColor = Color.Black;
            labelHexAddressPrompt.Location = new Point(13, 429);
            labelHexAddressPrompt.Name = "labelHexAddressPrompt";
            labelHexAddressPrompt.Size = new Size(227, 17);
            labelHexAddressPrompt.TabIndex = 20;
            labelHexAddressPrompt.Text = "请输入一个16进制地址，0x写不写都可以";
            // 
            // textBoxHexAddress
            // 
            textBoxHexAddress.Enabled = false;
            textBoxHexAddress.Location = new Point(246, 425);
            textBoxHexAddress.Name = "textBoxHexAddress";
            textBoxHexAddress.Size = new Size(218, 23);
            textBoxHexAddress.TabIndex = 21;
            // 
            // labelStartAddressPrompt
            // 
            labelStartAddressPrompt.AutoSize = true;
            labelStartAddressPrompt.ForeColor = Color.Black;
            labelStartAddressPrompt.Location = new Point(13, 465);
            labelStartAddressPrompt.Name = "labelStartAddressPrompt";
            labelStartAddressPrompt.Size = new Size(56, 17);
            labelStartAddressPrompt.TabIndex = 22;
            labelStartAddressPrompt.Text = "起始地址";
            // 
            // textBoxStartAddress
            // 
            textBoxStartAddress.Enabled = false;
            textBoxStartAddress.Location = new Point(69, 461);
            textBoxStartAddress.Name = "textBoxStartAddress";
            textBoxStartAddress.Size = new Size(160, 23);
            textBoxStartAddress.TabIndex = 23;
            // 
            // labelEndAddressPrompt
            // 
            labelEndAddressPrompt.AutoSize = true;
            labelEndAddressPrompt.ForeColor = Color.Black;
            labelEndAddressPrompt.Location = new Point(242, 465);
            labelEndAddressPrompt.Name = "labelEndAddressPrompt";
            labelEndAddressPrompt.Size = new Size(56, 17);
            labelEndAddressPrompt.TabIndex = 24;
            labelEndAddressPrompt.Text = "结束地址";
            // 
            // textBoxEndAddress
            // 
            textBoxEndAddress.Enabled = false;
            textBoxEndAddress.Location = new Point(304, 462);
            textBoxEndAddress.Name = "textBoxEndAddress";
            textBoxEndAddress.Size = new Size(160, 23);
            textBoxEndAddress.TabIndex = 25;
            // 
            // labelByteValuePrompt
            // 
            labelByteValuePrompt.AutoSize = true;
            labelByteValuePrompt.ForeColor = Color.Black;
            labelByteValuePrompt.Location = new Point(13, 501);
            labelByteValuePrompt.Name = "labelByteValuePrompt";
            labelByteValuePrompt.Size = new Size(140, 17);
            labelByteValuePrompt.TabIndex = 26;
            labelByteValuePrompt.Text = "请输入一个要删除的字节";
            // 
            // textBoxByteValue
            // 
            textBoxByteValue.Enabled = false;
            textBoxByteValue.Location = new Point(159, 497);
            textBoxByteValue.Name = "textBoxByteValue";
            textBoxByteValue.Size = new Size(305, 23);
            textBoxByteValue.TabIndex = 27;
            // 
            // labelNumberPrompt
            // 
            labelNumberPrompt.AutoSize = true;
            labelNumberPrompt.ForeColor = Color.Black;
            labelNumberPrompt.Location = new Point(13, 537);
            labelNumberPrompt.Name = "labelNumberPrompt";
            labelNumberPrompt.Size = new Size(140, 17);
            labelNumberPrompt.TabIndex = 28;
            labelNumberPrompt.Text = "请输入要删除的字节数量";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Enabled = false;
            textBoxNumber.Location = new Point(159, 533);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(305, 23);
            textBoxNumber.TabIndex = 29;
            // 
            // buttonProcess
            // 
            buttonProcess.Enabled = false;
            buttonProcess.ForeColor = Color.Red;
            buttonProcess.Location = new Point(290, 601);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(72, 31);
            buttonProcess.TabIndex = 30;
            buttonProcess.Text = "开始处理";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // labelFileFormatPrompt
            // 
            labelFileFormatPrompt.AutoSize = true;
            labelFileFormatPrompt.ForeColor = Color.Black;
            labelFileFormatPrompt.Location = new Point(12, 575);
            labelFileFormatPrompt.Name = "labelFileFormatPrompt";
            labelFileFormatPrompt.Size = new Size(152, 17);
            labelFileFormatPrompt.TabIndex = 31;
            labelFileFormatPrompt.Text = "请输入要保存的文件扩展名";
            // 
            // textBoxFileFormat
            // 
            textBoxFileFormat.Enabled = false;
            textBoxFileFormat.Location = new Point(170, 572);
            textBoxFileFormat.Name = "textBoxFileFormat";
            textBoxFileFormat.Size = new Size(294, 23);
            textBoxFileFormat.TabIndex = 32;
            textBoxFileFormat.TextChanged += textBoxFileFormat_TextChanged;
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(481, 11);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(349, 581);
            richTextBoxOutput.TabIndex = 33;
            richTextBoxOutput.Text = "";
            // 
            // buttonClear
            // 
            buttonClear.ForeColor = Color.Red;
            buttonClear.Location = new Point(392, 601);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(72, 31);
            buttonClear.TabIndex = 35;
            buttonClear.Text = "清除信息";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // ByteRemover
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 644);
            Controls.Add(buttonClear);
            Controls.Add(richTextBoxOutput);
            Controls.Add(textBoxFileFormat);
            Controls.Add(labelFileFormatPrompt);
            Controls.Add(buttonProcess);
            Controls.Add(textBoxNumber);
            Controls.Add(labelNumberPrompt);
            Controls.Add(textBoxByteValue);
            Controls.Add(labelByteValuePrompt);
            Controls.Add(textBoxEndAddress);
            Controls.Add(labelEndAddressPrompt);
            Controls.Add(textBoxStartAddress);
            Controls.Add(labelStartAddressPrompt);
            Controls.Add(textBoxHexAddress);
            Controls.Add(labelHexAddressPrompt);
            Controls.Add(textBoxString);
            Controls.Add(labelStringPrompt);
            Controls.Add(textBoxByteSequence);
            Controls.Add(labelByteSequencePrompt);
            Controls.Add(radioButtonMode9);
            Controls.Add(radioButtonMode8);
            Controls.Add(radioButtonMode7);
            Controls.Add(radioButtonMode6);
            Controls.Add(radioButtonMode5);
            Controls.Add(radioButtonMode4);
            Controls.Add(radioButtonMode3);
            Controls.Add(radioButtonMode2);
            Controls.Add(radioButtonMode1);
            Controls.Add(labelModePrompt);
            Controls.Add(labelBackupPrompt);
            Controls.Add(textBoxPath);
            Controls.Add(labelPathPrompt);
            ForeColor = Color.BlueViolet;
            Name = "ByteRemover";
            Text = "万能字节移除器";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
