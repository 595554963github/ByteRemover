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
        private System.Windows.Forms.Label labelByteSequencePrompt;
        private System.Windows.Forms.TextBox textBoxByteSequence;
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
        private System.Windows.Forms.Button buttonBrowse;
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
            labelByteSequencePrompt = new Label();
            textBoxByteSequence = new TextBox();
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
            buttonBrowse = new Button();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // labelPathPrompt
            // 
            labelPathPrompt.AutoSize = true;
            labelPathPrompt.Location = new Point(13, 15);
            labelPathPrompt.Name = "labelPathPrompt";
            labelPathPrompt.Size = new Size(131, 17);
            labelPathPrompt.TabIndex = 0;
            labelPathPrompt.Text = "请输入一个有效的路径:";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(144, 11);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(250, 23);
            textBoxPath.TabIndex = 1;
            textBoxPath.TextChanged += textBoxPath_TextChanged;
            // 
            // labelBackupPrompt
            // 
            labelBackupPrompt.AutoSize = true;
            labelBackupPrompt.ForeColor = Color.Lime;
            labelBackupPrompt.Location = new Point(13, 45);
            labelBackupPrompt.Name = "labelBackupPrompt";
            labelBackupPrompt.Size = new Size(228, 17);
            labelBackupPrompt.TabIndex = 3;
            labelBackupPrompt.Text = "请放心操作 该操作不会破坏您的游戏数据";
            // 
            // labelModePrompt
            // 
            labelModePrompt.AutoSize = true;
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
            // labelByteSequencePrompt
            // 
            labelByteSequencePrompt.AutoSize = true;
            labelByteSequencePrompt.Location = new Point(13, 330);
            labelByteSequencePrompt.Name = "labelByteSequencePrompt";
            labelByteSequencePrompt.Size = new Size(164, 17);
            labelByteSequencePrompt.TabIndex = 15;
            labelByteSequencePrompt.Text = "请输入字节序列，以空格间隔";
            // 
            // textBoxByteSequence
            // 
            textBoxByteSequence.Enabled = false;
            textBoxByteSequence.Location = new Point(183, 326);
            textBoxByteSequence.Name = "textBoxByteSequence";
            textBoxByteSequence.Size = new Size(281, 23);
            textBoxByteSequence.TabIndex = 16;
            // 
            // labelHexAddressPrompt
            // 
            labelHexAddressPrompt.AutoSize = true;
            labelHexAddressPrompt.Location = new Point(13, 369);
            labelHexAddressPrompt.Name = "labelHexAddressPrompt";
            labelHexAddressPrompt.Size = new Size(227, 17);
            labelHexAddressPrompt.TabIndex = 17;
            labelHexAddressPrompt.Text = "请输入一个16进制地址，0x写不写都可以";
            // 
            // textBoxHexAddress
            // 
            textBoxHexAddress.Enabled = false;
            textBoxHexAddress.Location = new Point(246, 365);
            textBoxHexAddress.Name = "textBoxHexAddress";
            textBoxHexAddress.Size = new Size(218, 23);
            textBoxHexAddress.TabIndex = 18;
            // 
            // labelStartAddressPrompt
            // 
            labelStartAddressPrompt.AutoSize = true;
            labelStartAddressPrompt.Location = new Point(13, 405);
            labelStartAddressPrompt.Name = "labelStartAddressPrompt";
            labelStartAddressPrompt.Size = new Size(56, 17);
            labelStartAddressPrompt.TabIndex = 19;
            labelStartAddressPrompt.Text = "起始地址";
            // 
            // textBoxStartAddress
            // 
            textBoxStartAddress.Enabled = false;
            textBoxStartAddress.Location = new Point(75, 401);
            textBoxStartAddress.Name = "textBoxStartAddress";
            textBoxStartAddress.Size = new Size(112, 23);
            textBoxStartAddress.TabIndex = 20;
            // 
            // labelEndAddressPrompt
            // 
            labelEndAddressPrompt.AutoSize = true;
            labelEndAddressPrompt.Location = new Point(200, 405);
            labelEndAddressPrompt.Name = "labelEndAddressPrompt";
            labelEndAddressPrompt.Size = new Size(56, 17);
            labelEndAddressPrompt.TabIndex = 21;
            labelEndAddressPrompt.Text = "结束地址";
            // 
            // textBoxEndAddress
            // 
            textBoxEndAddress.Enabled = false;
            textBoxEndAddress.Location = new Point(263, 401);
            textBoxEndAddress.Name = "textBoxEndAddress";
            textBoxEndAddress.Size = new Size(100, 23);
            textBoxEndAddress.TabIndex = 22;
            // 
            // labelByteValuePrompt
            // 
            labelByteValuePrompt.AutoSize = true;
            labelByteValuePrompt.Location = new Point(13, 441);
            labelByteValuePrompt.Name = "labelByteValuePrompt";
            labelByteValuePrompt.Size = new Size(128, 17);
            labelByteValuePrompt.TabIndex = 23;
            labelByteValuePrompt.Text = "请输入要删除的字节值";
            // 
            // textBoxByteValue
            // 
            textBoxByteValue.Enabled = false;
            textBoxByteValue.Location = new Point(144, 437);
            textBoxByteValue.Name = "textBoxByteValue";
            textBoxByteValue.Size = new Size(320, 23);
            textBoxByteValue.TabIndex = 24;
            // 
            // labelNumberPrompt
            // 
            labelNumberPrompt.AutoSize = true;
            labelNumberPrompt.Location = new Point(13, 477);
            labelNumberPrompt.Name = "labelNumberPrompt";
            labelNumberPrompt.Size = new Size(92, 17);
            labelNumberPrompt.TabIndex = 25;
            labelNumberPrompt.Text = "请输入一个数字";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Enabled = false;
            textBoxNumber.Location = new Point(144, 473);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(320, 23);
            textBoxNumber.TabIndex = 26;
            // 
            // buttonProcess
            // 
            buttonProcess.Enabled = false;
            buttonProcess.ForeColor = Color.Red;
            buttonProcess.Location = new Point(314, 541);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(72, 57);
            buttonProcess.TabIndex = 27;
            buttonProcess.Text = "开始处理";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // labelFileFormatPrompt
            // 
            labelFileFormatPrompt.AutoSize = true;
            labelFileFormatPrompt.Location = new Point(12, 515);
            labelFileFormatPrompt.Name = "labelFileFormatPrompt";
            labelFileFormatPrompt.Size = new Size(152, 17);
            labelFileFormatPrompt.TabIndex = 28;
            labelFileFormatPrompt.Text = "请输入要保存的文件扩展名";
            // 
            // textBoxFileFormat
            // 
            textBoxFileFormat.Enabled = false;
            textBoxFileFormat.Location = new Point(183, 512);
            textBoxFileFormat.Name = "textBoxFileFormat";
            textBoxFileFormat.Size = new Size(281, 23);
            textBoxFileFormat.TabIndex = 29;
            textBoxFileFormat.TextChanged += textBoxFileFormat_TextChanged;
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(481, 11);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(349, 524);
            richTextBoxOutput.TabIndex = 30;
            richTextBoxOutput.Text = "";
            // 
            // buttonBrowse
            // 
            buttonBrowse.ForeColor = Color.Red;
            buttonBrowse.Location = new Point(400, 12);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 31;
            buttonBrowse.Text = "浏览";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonClear
            // 
            buttonClear.ForeColor = Color.Red;
            buttonClear.Location = new Point(392, 541);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(72, 57);
            buttonClear.TabIndex = 32;
            buttonClear.Text = "清除信息";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 622);
            Controls.Add(buttonClear);
            Controls.Add(buttonBrowse);
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
            Controls.Add(textBoxByteSequence);
            Controls.Add(labelByteSequencePrompt);
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
            Name = "Form1";
            Text = "万能字节移除器";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}