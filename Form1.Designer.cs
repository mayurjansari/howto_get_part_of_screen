namespace howto_get_part_of_screen
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxCommands = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuWholeScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaptureArea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdScreenImage = new System.Windows.Forms.SaveFileDialog();
            this.ctxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctxCommands;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScreenGrabber";
            this.notifyIcon1.Visible = true;
            // 
            // ctxCommands
            // 
            this.ctxCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWholeScreen,
            this.mnuCaptureArea,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.ctxCommands.Name = "ctxCommands";
            this.ctxCommands.Size = new System.Drawing.Size(176, 76);
            // 
            // mnuWholeScreen
            // 
            this.mnuWholeScreen.Name = "mnuWholeScreen";
            this.mnuWholeScreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuWholeScreen.Size = new System.Drawing.Size(175, 22);
            this.mnuWholeScreen.Text = "Capture &All";
            this.mnuWholeScreen.Click += new System.EventHandler(this.mnuWholeScreen_Click);
            // 
            // mnuCaptureArea
            // 
            this.mnuCaptureArea.Name = "mnuCaptureArea";
            this.mnuCaptureArea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuCaptureArea.Size = new System.Drawing.Size(175, 22);
            this.mnuCaptureArea.Text = "&Select Area";
            this.mnuCaptureArea.Click += new System.EventHandler(this.mnuCaptureArea_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(175, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // sfdScreenImage
            // 
            this.sfdScreenImage.Filter = "Graphic Files|*.bmp;*.gif;*.jpg;*.png|All Files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 145);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ctxCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctxCommands;
        private System.Windows.Forms.ToolStripMenuItem mnuWholeScreen;
        private System.Windows.Forms.ToolStripMenuItem mnuCaptureArea;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.SaveFileDialog sfdScreenImage;
    }
}

