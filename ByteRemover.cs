using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UniversalByteRemover
{
    public partial class ByteRemover : Form
    {
        public ByteRemover()
        {
            InitializeComponent();
        }

        private void RadioButtonMode_CheckedChanged(object sender, EventArgs e)
        {
            // 禁用所有输入框
            textBoxByteSequence.Enabled = false;
            textBoxHexAddress.Enabled = false;
            textBoxStartAddress.Enabled = false;
            textBoxEndAddress.Enabled = false;
            textBoxByteValue.Enabled = false;
            textBoxNumber.Enabled = false;
            textBoxFileFormat.Enabled = false;
            textBoxFileFormat.Text = "";
            buttonProcess.Enabled = false;

            if (radioButtonMode1.Checked || radioButtonMode2.Checked)
            {
                textBoxByteSequence.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
            else if (radioButtonMode3.Checked || radioButtonMode4.Checked)
            {
                textBoxHexAddress.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
            else if (radioButtonMode5.Checked)
            {
                textBoxStartAddress.Enabled = true;
                textBoxEndAddress.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
            else if (radioButtonMode6.Checked)
            {
                textBoxByteValue.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
            else if (radioButtonMode7.Checked || radioButtonMode8.Checked)
            {
                textBoxNumber.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
        }

        private void textBoxFileFormat_TextChanged(object sender, EventArgs e)
        {
            buttonProcess.Enabled = !string.IsNullOrEmpty(textBoxFileFormat.Text);
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPath.Text) && (File.Exists(textBoxPath.Text) || Directory.Exists(textBoxPath.Text)))
            {
                // 启用相关操作按钮和选项
                buttonProcess.Enabled = true;
                foreach (RadioButton rb in new RadioButton[] { radioButtonMode1, radioButtonMode2, radioButtonMode3, radioButtonMode4, radioButtonMode5, radioButtonMode6, radioButtonMode7, radioButtonMode8 })
                {
                    rb.Enabled = true;
                }
            }
            else
            {
                // 禁用相关操作按钮和选项
                buttonProcess.Enabled = false;
                foreach (RadioButton rb in new RadioButton[] { radioButtonMode1, radioButtonMode2, radioButtonMode3, radioButtonMode4, radioButtonMode5, radioButtonMode6, radioButtonMode7, radioButtonMode8 })
                {
                    rb.Enabled = false;
                }
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            string inputPath = textBoxPath.Text;
            if (!string.IsNullOrEmpty(inputPath))
            {
                if (File.Exists(inputPath))
                {
                    ProcessSingleFile(inputPath);
                }
                else if (Directory.Exists(inputPath))
                {
                    string[] files = Directory.GetFiles(inputPath, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        ProcessSingleFile(file);
                    }
                }
                else
                {
                    MessageBox.Show("指定的文件路径不存在，请检查输入。");
                }
            }
        }

        private void ProcessSingleFile(string filePath)
        {
            string? parentDirectory = Path.GetDirectoryName(filePath);

            if (parentDirectory != null)
            {
                string extractedDirectory = Path.Combine(parentDirectory, "Extracted");

                if (!Directory.Exists(extractedDirectory))
                {
                    Directory.CreateDirectory(extractedDirectory);
                }

                byte[] fileBytes = File.ReadAllBytes(filePath);

                byte[] resultBytes = ProcessBytes(fileBytes);

                string outputFileName = Path.ChangeExtension(Path.GetFileName(filePath), textBoxFileFormat.Text);

                string outputFilePath = Path.Combine(extractedDirectory, outputFileName);

                File.WriteAllBytes(outputFilePath, resultBytes);

                richTextBoxOutput.Text += $"处理完成，结果已保存到 {outputFilePath}\n";
            }
            else
            {
                MessageBox.Show("无法获取父目录路径，操作终止。");
            }
        }

        private byte[] ProcessBytes(byte[] fileBytes)
        {
            if (radioButtonMode1.Checked)
            {
                byte[] sequence = ParseByteSequence(textBoxByteSequence.Text);
                int index = FindByteSequenceIndex(fileBytes, sequence);
                if (index != -1)
                {
                    return new ArraySegment<byte>(fileBytes, index, fileBytes.Length - index).ToArray();
                }
            }
            else if (radioButtonMode2.Checked)
            {
                byte[] sequence = ParseByteSequence(textBoxByteSequence.Text);
                int index = FindByteSequenceIndex(fileBytes, sequence);
                if (index != -1)
                {
                    return new ArraySegment<byte>(fileBytes, 0, index).ToArray();
                }
            }
            else if (radioButtonMode3.Checked)
            {
                string hexAddressText = textBoxHexAddress.Text.Trim();
                if (hexAddressText.StartsWith("0x") || hexAddressText.StartsWith("0X"))
                {
                    hexAddressText = hexAddressText.Substring(2);
                }
                int address;
                if (int.TryParse(hexAddressText, System.Globalization.NumberStyles.HexNumber, null, out address))
                {
                    if (address < fileBytes.Length)
                    {
                        return new ArraySegment<byte>(fileBytes, address, fileBytes.Length - address).ToArray();
                    }
                }
            }
            else if (radioButtonMode4.Checked)
            {
                string hexAddressText = textBoxHexAddress.Text.Trim();
                if (hexAddressText.StartsWith("0x") || hexAddressText.StartsWith("0X"))
                {
                    hexAddressText = hexAddressText.Substring(2);
                }
                int address;
                if (int.TryParse(hexAddressText, System.Globalization.NumberStyles.HexNumber, null, out address))
                {
                    if (address < fileBytes.Length)
                    {
                        return new ArraySegment<byte>(fileBytes, 0, address).ToArray();
                    }
                }
            }
            else if (radioButtonMode5.Checked)
            {
                string startAddressText = textBoxStartAddress.Text.Trim();
                if (startAddressText.StartsWith("0x") || startAddressText.StartsWith("0X"))
                {
                    startAddressText = startAddressText.Substring(2);
                }
                string endAddressText = textBoxEndAddress.Text.Trim();
                if (endAddressText.StartsWith("0x") || endAddressText.StartsWith("0X"))
                {
                    endAddressText = endAddressText.Substring(2);
                }
                int startAddress, endAddress;
                if (!int.TryParse(startAddressText, System.Globalization.NumberStyles.HexNumber, null, out startAddress) ||
                    !int.TryParse(endAddressText, System.Globalization.NumberStyles.HexNumber, null, out endAddress))
                {
                    MessageBox.Show("起始地址或结束地址输入无效，请输入有效的十六进制地址。");
                    return fileBytes;
                }

                if (startAddress >= endAddress)
                {
                    MessageBox.Show("起始地址必须小于结束地址，请重新输入。");
                    return fileBytes;
                }

                if (startAddress < fileBytes.Length && endAddress < fileBytes.Length)
                {
                    return new ArraySegment<byte>(fileBytes, startAddress, endAddress - startAddress).ToArray();
                }
            }
            else if (radioButtonMode6.Checked)
            {
                string input = textBoxByteValue.Text.Trim();
                if (input.Length == 2)
                {
                    if (byte.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out byte byteValue))
                    {
                        int lastIndex = fileBytes.Length - 1;
                        while (lastIndex >= 0 && fileBytes[lastIndex] == byteValue)
                        {
                            lastIndex--;
                        }
                        if (lastIndex != -1)
                        {
                            return new ArraySegment<byte>(fileBytes, 0, lastIndex + 1).ToArray();
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入的不是有效的十六进制字节，请输入一个有效的十六进制字节，如 00、5B 等。");
                    }
                }
                else
                {
                    MessageBox.Show("输入的十六进制字节长度必须为 2，请输入一个有效的十六进制字节，如 00、5B 等。");
                }
            }
            else if (radioButtonMode7.Checked)
            {
                if (int.TryParse(textBoxNumber.Text, out int count))
                {
                    if (count < fileBytes.Length)
                    {
                        return new ArraySegment<byte>(fileBytes, 0, fileBytes.Length - count).ToArray();
                    }
                }
            }
            else if (radioButtonMode8.Checked)
            {
                if (int.TryParse(textBoxNumber.Text, out int count))
                {
                    if (count < fileBytes.Length)
                    {
                        return new ArraySegment<byte>(fileBytes, count, fileBytes.Length - count).ToArray();
                    }
                }
            }

            return fileBytes;
        }

        private byte[] ParseByteSequence(string input)
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<byte> bytes = new List<byte>();
            foreach (string part in parts)
            {
                if (byte.TryParse(part, System.Globalization.NumberStyles.HexNumber, null, out byte b))
                {
                    bytes.Add(b);
                }
            }
            return bytes.ToArray();
        }

        private int FindByteSequenceIndex(byte[] source, byte[] sequence)
        {
            for (int i = 0; i <= source.Length - sequence.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (source[i + j] != sequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Clear();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "请选择一个文件夹";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}