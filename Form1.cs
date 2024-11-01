using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using MsgReader.Outlook;
using DinkToPdf;
using System.Diagnostics;

namespace MsgViewerApp
{
    public partial class Form1 : Form
    {
        private string? currentFilePath; // Nullable type
        private Storage.Message? msg; // Declare msg at the class level

        // Update constructor to accept an optional file path
        public Form1(string msgFilePath = null)
        {
            InitializeComponent();

            // If a file path is provided, open the message file
            if (!string.IsNullOrEmpty(msgFilePath))
            {
                OpenMsgFile(msgFilePath);
            }
        }

        private void OpenMsgFile(string filePath)
        {
            currentFilePath = filePath; // Assign the file path
            msg = null; // Reset msg before loading

            try
            {
                // Load the message
                msg = new Storage.Message(filePath);
                subjectTextBox.Text = msg.Subject;

                // Load HTML body into the WebBrowser
                if (msg.BodyHtml != null)
                {
                    string htmlBody = msg.BodyHtml;

                    // Create a mapping of attachment file names to base64 data for images
                    foreach (Storage.Attachment attachment in msg.Attachments)
                    {
                        if (attachment.MimeType.StartsWith("image/"))
                        {
                            string imageBase64 = Convert.ToBase64String(attachment.Data);
                            string imageSrc = $"data:{attachment.MimeType};base64,{imageBase64}";
                            // Replace the src in HTML with the base64 string
                            htmlBody = htmlBody.Replace(attachment.FileName, imageSrc);
                        }
                    }

                    // Update the bodyWebBrowser with the modified HTML
                    bodyWebBrowser.DocumentText = htmlBody;
                }
                else
                {
                    // Fallback to plain text if HTML is not available
                    string plainTextBody = msg.BodyText;

                    // Format line breaks for HTML display
                    if (!string.IsNullOrEmpty(plainTextBody))
                    {
                        plainTextBody = plainTextBody.Replace("\r\n", "<br>").Replace("\n", "<br>");
                    }
                    else
                    {
                        plainTextBody = "No content available."; // Handle empty body case
                    }

                    bodyWebBrowser.DocumentText = plainTextBody; // Display formatted plain text
                }

                attachmentsListBox.Items.Clear();
                saveSelectedButton.Enabled = msg.Attachments.Count > 0; // Enable button if there are attachments

                foreach (Storage.Attachment attachment in msg.Attachments)
                {
                    attachmentsListBox.Items.Add(attachment.FileName); // Add the file name directly to the ListBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Outlook Message Files (*.msg)|*.msg",
                Title = "Open Message File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenMsgFile(openFileDialog.FileName);
            }
        }

        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            if (attachmentsListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("No attachments selected to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string selectedFileName in attachmentsListBox.SelectedItems)
                    {
                        // Find the corresponding attachment by file name
                        if (msg != null) // Ensure msg is not null
                        {
                            foreach (Storage.Attachment attachment in msg.Attachments)
                            {
                                if (attachment.FileName == selectedFileName)
                                {
                                    string savePath = Path.Combine(folderDialog.SelectedPath, selectedFileName);
                                    File.WriteAllBytes(savePath, attachment.Data);
                                    break; // Break the inner loop once the attachment is found
                                }
                            }
                        }
                    }

                    MessageBox.Show("Selected attachments saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            if (attachmentsListBox.Items.Count == 0)
            {
                MessageBox.Show("No attachments to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    if (msg != null) // Ensure msg is not null
                    {
                        foreach (string fileName in attachmentsListBox.Items)
                        {
                            // Find the corresponding attachment by file name
                            foreach (Storage.Attachment attachment in msg.Attachments)
                            {
                                if (attachment.FileName == fileName)
                                {
                                    string savePath = Path.Combine(folderDialog.SelectedPath, fileName);
                                    File.WriteAllBytes(savePath, attachment.Data);
                                    break; // Break the inner loop once the attachment is found
                                }
                            }
                        }

                        MessageBox.Show("All attachments saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // Show the print dialog
            using (PrintDialog printDialog = new PrintDialog())
            {
                // Set the print dialog settings if needed
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Print the content of the WebBrowser
                    bodyWebBrowser.Print();
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
