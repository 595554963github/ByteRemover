using System.Text;

namespace UniversalByteRemover
{
    public partial class ByteRemover : Form
    {
        public ByteRemover()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            EnableDragDropSupport();
        }

        private void EnableDragDropSupport()
        {
            textBoxPath.AllowDrop = true;
            textBoxPath.DragEnter += TextBoxPath_DragEnter;
            textBoxPath.DragDrop += TextBoxPath_DragDrop;
            textBoxPath.DragLeave += TextBoxPath_DragLeave;

            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;
        }

        private void TextBoxPath_DragEnter(object? sender, DragEventArgs e)
        {
            if (textBoxPath == null) return;

            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length == 1 && (Directory.Exists(files[0]) || File.Exists(files[0])))
                {
                    e.Effect = DragDropEffects.Copy;
                    textBoxPath.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBoxPath_DragDrop(object? sender, DragEventArgs e)
        {
            if (textBoxPath == null) return;

            textBoxPath.BackColor = System.Drawing.SystemColors.Window;

            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length == 1 && (Directory.Exists(files[0]) || File.Exists(files[0])))
                {
                    textBoxPath.Text = files[0];
                    AppendToOutput($"已通过拖放选择路径:{files[0]}");
                    TriggerPathChanged();
                }
                else
                {
                    AppendToOutput("错误:请拖放单个文件或文件夹");
                }
            }
        }

        private void TextBoxPath_DragLeave(object? sender, EventArgs e)
        {
            if (textBoxPath == null) return;

            textBoxPath.BackColor = System.Drawing.SystemColors.Window;
        }

        private void Form_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length == 1 && (Directory.Exists(files[0]) || File.Exists(files[0])))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length == 1 && (Directory.Exists(files[0]) || File.Exists(files[0])))
                {
                    textBoxPath.Text = files[0];
                    AppendToOutput($"已通过窗体拖放选择路径:{files[0]}");
                    TriggerPathChanged();
                }
                else
                {
                    AppendToOutput("错误:请拖放单个文件或文件夹到路径文本框或窗体");
                }
            }
        }

        private void AppendToOutput(string message)
        {
            if (richTextBoxOutput.InvokeRequired)
            {
                richTextBoxOutput.Invoke(new Action<string>(AppendToOutput), message);
                return;
            }

            richTextBoxOutput.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n");
            richTextBoxOutput.ScrollToCaret();
        }

        private void TriggerPathChanged()
        {
            if (!string.IsNullOrEmpty(textBoxPath.Text) && (File.Exists(textBoxPath.Text) || Directory.Exists(textBoxPath.Text)))
            {
                buttonProcess.Enabled = true;
                foreach (RadioButton rb in new RadioButton[] {
                    radioButtonMode1, radioButtonMode2, radioButtonMode3, radioButtonMode4,
                    radioButtonMode5, radioButtonMode6, radioButtonMode7, radioButtonMode8,
                    radioButtonMode9
                })
                {
                    rb.Enabled = true;
                }
            }
            else
            {
                buttonProcess.Enabled = false;
                foreach (RadioButton rb in new RadioButton[] {
                    radioButtonMode1, radioButtonMode2, radioButtonMode3, radioButtonMode4,
                    radioButtonMode5, radioButtonMode6, radioButtonMode7, radioButtonMode8,
                    radioButtonMode9
                })
                {
                    rb.Enabled = false;
                }
            }
        }

        private void RadioButtonMode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxByteSequence.Enabled = false;
            textBoxHexAddress.Enabled = false;
            textBoxStartAddress.Enabled = false;
            textBoxEndAddress.Enabled = false;
            textBoxByteValue.Enabled = false;
            textBoxNumber.Enabled = false;
            textBoxString.Enabled = false;
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
            else if (radioButtonMode9.Checked)
            {
                textBoxString.Enabled = true;
                textBoxFileFormat.Enabled = true;
            }
        }

        private void textBoxFileFormat_TextChanged(object sender, EventArgs e)
        {
            buttonProcess.Enabled = !string.IsNullOrEmpty(textBoxFileFormat.Text);
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            TriggerPathChanged();
        }

        private async void buttonProcess_Click(object sender, EventArgs e)
        {
            string inputPath = textBoxPath.Text;
            if (!string.IsNullOrEmpty(inputPath))
            {
                buttonProcess.Enabled = false;
                buttonBrowse.Enabled = false;
                buttonClear.Enabled = false;

                try
                {
                    if (File.Exists(inputPath))
                    {
                        await ProcessSingleFileAsync(inputPath, 1);
                    }
                    else if (Directory.Exists(inputPath))
                    {
                        string[] files = Directory.GetFiles(inputPath, "*", SearchOption.AllDirectories);
                        int fileCount = 1;
                        foreach (string file in files)
                        {
                            await ProcessSingleFileAsync(file, fileCount);
                            fileCount++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("指定的文件路径不存在，请检查输入。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"处理过程中发生错误:{ex.Message}");
                }
                finally
                {
                    buttonProcess.Enabled = true;
                    buttonBrowse.Enabled = true;
                    buttonClear.Enabled = true;
                }
            }
        }

        private async Task ProcessSingleFileAsync(string filePath, int fileNumber)
        {
            string? parentDirectory = Path.GetDirectoryName(filePath);

            if (parentDirectory != null)
            {
                string extractedDirectory = Path.Combine(parentDirectory, "Extracted");

                if (!Directory.Exists(extractedDirectory))
                {
                    Directory.CreateDirectory(extractedDirectory);
                }

                byte[] fileBytes = await Task.Run(() => File.ReadAllBytes(filePath));

                byte[] resultBytes = await Task.Run(() => ProcessBytes(fileBytes));

                string originalFileName = Path.GetFileNameWithoutExtension(filePath);
                string userExtension = textBoxFileFormat.Text.Trim().TrimStart('.');
                string outputFileName = $"{originalFileName}_{fileNumber}.{userExtension}";

                string outputFilePath = Path.Combine(extractedDirectory, outputFileName);

                await Task.Run(() => File.WriteAllBytes(outputFilePath, resultBytes));

                if (richTextBoxOutput.InvokeRequired)
                {
                    richTextBoxOutput.Invoke(new Action(() =>
                    {
                        richTextBoxOutput.Text += $"[{fileNumber}]处理完成，结果已保存到{outputFilePath}\n";
                        richTextBoxOutput.ScrollToCaret();
                    }));
                }
                else
                {
                    richTextBoxOutput.Text += $"[{fileNumber}]处理完成，结果已保存到{outputFilePath}\n";
                    richTextBoxOutput.ScrollToCaret();
                }
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
            else if (radioButtonMode9.Checked)
            {
                string targetString = textBoxString.Text.Trim();
                if (!string.IsNullOrEmpty(targetString))
                {
                    byte[] stringBytes = Encoding.UTF8.GetBytes(targetString);
                    int index = FindByteSequenceIndex(fileBytes, stringBytes);
                    if (index != -1)
                    {
                        return new ArraySegment<byte>(fileBytes, index, fileBytes.Length - index).ToArray();
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

                if (!string.IsNullOrEmpty(textBoxPath.Text) && Directory.Exists(textBoxPath.Text))
                {
                    folderDialog.SelectedPath = textBoxPath.Text;
                }
                else if (!string.IsNullOrEmpty(textBoxPath.Text) && File.Exists(textBoxPath.Text))
                {
                    string? directoryPath = Path.GetDirectoryName(textBoxPath.Text);
                    if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
                    {
                        folderDialog.SelectedPath = directoryPath;
                    }
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
