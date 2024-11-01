namespace MsgViewerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.WebBrowser bodyWebBrowser;
        private System.Windows.Forms.ListBox attachmentsListBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button saveSelectedButton;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.Button printButton; // Add print button here

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            subjectTextBox = new TextBox();
            bodyWebBrowser = new WebBrowser();
            attachmentsListBox = new ListBox();
            browseButton = new Button();
            saveSelectedButton = new Button();
            saveAllButton = new Button();
            printButton = new Button(); // Initialize print button

            SuspendLayout();
            // 
            // subjectTextBox
            // 
            subjectTextBox.Dock = DockStyle.Top;
            subjectTextBox.Font = new Font("Segoe UI", 10F);
            subjectTextBox.Location = new Point(0, 0);
            subjectTextBox.Name = "subjectTextBox";
            subjectTextBox.ReadOnly = true;
            subjectTextBox.Size = new Size(800, 34);
            subjectTextBox.TabIndex = 0;
            // 
            // bodyWebBrowser
            // 
            bodyWebBrowser.Dock = DockStyle.Fill;
            bodyWebBrowser.Location = new Point(0, 64);
            bodyWebBrowser.MinimumSize = new Size(20, 20);
            bodyWebBrowser.Name = "bodyWebBrowser";
            bodyWebBrowser.Size = new Size(600, 376);
            bodyWebBrowser.TabIndex = 1;
            // 
            // attachmentsListBox
            // 
            attachmentsListBox.Dock = DockStyle.Right;
            attachmentsListBox.FormattingEnabled = true;
            attachmentsListBox.ItemHeight = 25;
            attachmentsListBox.Location = new Point(600, 64);
            attachmentsListBox.Name = "attachmentsListBox";
            attachmentsListBox.Size = new Size(200, 376);
            attachmentsListBox.TabIndex = 2;
            // 
            // browseButton
            // 
            browseButton.Dock = DockStyle.Top;
            browseButton.Font = new Font("Segoe UI", 9F);
            browseButton.Location = new Point(0, 34);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(800, 30);
            browseButton.TabIndex = 3;
            browseButton.Text = "Browse .msg File";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // saveSelectedButton
            // 
            saveSelectedButton.Dock = DockStyle.Bottom;
            saveSelectedButton.Enabled = false;
            saveSelectedButton.Font = new Font("Segoe UI", 9F);
            saveSelectedButton.Location = new Point(0, 440);
            saveSelectedButton.Name = "saveSelectedButton";
            saveSelectedButton.Size = new Size(800, 30);
            saveSelectedButton.TabIndex = 4;
            saveSelectedButton.Text = "Save Selected Attachments";
            saveSelectedButton.Click += saveSelectedButton_Click;
            // 
            // saveAllButton
            // 
            saveAllButton.Dock = DockStyle.Bottom;
            saveAllButton.Font = new Font("Segoe UI", 9F);
            saveAllButton.Location = new Point(0, 470);
            saveAllButton.Name = "saveAllButton";
            saveAllButton.Size = new Size(800, 30);
            saveAllButton.TabIndex = 5;
            saveAllButton.Text = "Save All Attachments";
            saveAllButton.Click += saveAllButton_Click;
            // 
            // printButton
            // 
            printButton.Dock = DockStyle.Bottom; // Position it above the save buttons
            printButton.Font = new Font("Segoe UI", 9F);
            printButton.Location = new Point(0, 410); // Adjust position
            printButton.Name = "printButton";
            printButton.Size = new Size(800, 30);
            printButton.TabIndex = 6;
            printButton.Text = "Print Email";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click; // Attach the click event
            // 
            // Form1
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(bodyWebBrowser);
            Controls.Add(attachmentsListBox);
            Controls.Add(saveSelectedButton);
            Controls.Add(saveAllButton);
            Controls.Add(printButton); // Add the print button to controls
            Controls.Add(browseButton);
            Controls.Add(subjectTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Msg Viewer - Laboratory 404";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
