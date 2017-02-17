namespace CGoogleDrive.SettingForms
{
    partial class GoogleSetup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKeyFileBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeyFile = new System.Windows.Forms.TextBox();
            this.txtServiceAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxParralel = new System.Windows.Forms.NumericUpDown();
            this.txtApplicationName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilterDocumentation = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParralel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnKeyFileBrowse);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtKeyFile);
            this.groupBox1.Controls.Add(this.txtServiceAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Size = new System.Drawing.Size(1318, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Account";
            // 
            // btnKeyFileBrowse
            // 
            this.btnKeyFileBrowse.Location = new System.Drawing.Point(28, 312);
            this.btnKeyFileBrowse.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnKeyFileBrowse.Name = "btnKeyFileBrowse";
            this.btnKeyFileBrowse.Size = new System.Drawing.Size(178, 58);
            this.btnKeyFileBrowse.TabIndex = 6;
            this.btnKeyFileBrowse.Text = "Browse";
            this.btnKeyFileBrowse.UseVisualStyleBackColor = true;
            this.btnKeyFileBrowse.Click += new System.EventHandler(this.btnKeyFileBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Service Accout Key File:";
            // 
            // txtKeyFile
            // 
            this.txtKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyFile.Location = new System.Drawing.Point(28, 245);
            this.txtKeyFile.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtKeyFile.Name = "txtKeyFile";
            this.txtKeyFile.Size = new System.Drawing.Size(698, 44);
            this.txtKeyFile.TabIndex = 4;
            // 
            // txtServiceAccount
            // 
            this.txtServiceAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceAccount.Location = new System.Drawing.Point(28, 97);
            this.txtServiceAccount.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtServiceAccount.Name = "txtServiceAccount";
            this.txtServiceAccount.Size = new System.Drawing.Size(698, 44);
            this.txtServiceAccount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Service Account E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 416);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1158, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "on Compute Engine VMs, App Engine apps, or systems running outside Google.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 377);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1201, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "A service account represents a Google Cloud service identity, such as code runnin" +
    "g";
            // 
            // numMaxParralel
            // 
            this.numMaxParralel.Location = new System.Drawing.Point(36, 863);
            this.numMaxParralel.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.numMaxParralel.Name = "numMaxParralel";
            this.numMaxParralel.Size = new System.Drawing.Size(133, 44);
            this.numMaxParralel.TabIndex = 1;
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationName.Location = new System.Drawing.Point(36, 798);
            this.txtApplicationName.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new System.Drawing.Size(698, 44);
            this.txtApplicationName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 752);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 37);
            this.label5.TabIndex = 6;
            this.label5.Text = "Application Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 870);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(587, 37);
            this.label6.TabIndex = 7;
            this.label6.Text = "Maximum Number of Parallel Processes";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(28, 950);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(178, 72);
            this.btnVerify.TabIndex = 8;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(221, 950);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(178, 72);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 550);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 37);
            this.label7.TabIndex = 11;
            this.label7.Text = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(36, 597);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(1306, 44);
            this.txtFilter.TabIndex = 10;
            // 
            // btnFilterDocumentation
            // 
            this.btnFilterDocumentation.Location = new System.Drawing.Point(36, 661);
            this.btnFilterDocumentation.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnFilterDocumentation.Name = "btnFilterDocumentation";
            this.btnFilterDocumentation.Size = new System.Drawing.Size(484, 72);
            this.btnFilterDocumentation.TabIndex = 12;
            this.btnFilterDocumentation.Text = "Google Filter Documentation";
            this.btnFilterDocumentation.UseVisualStyleBackColor = true;
            this.btnFilterDocumentation.Click += new System.EventHandler(this.btnFilterDocumentation_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(534, 678);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(549, 37);
            this.label8.TabIndex = 13;
            this.label8.Text = "Leave this filed blank to return all files";
            // 
            // GoogleSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 1052);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnFilterDocumentation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApplicationName);
            this.Controls.Add(this.numMaxParralel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "GoogleSetup";
            this.Text = "GoogleSetup";
            this.Load += new System.EventHandler(this.GoogleSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParralel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyFile;
        private System.Windows.Forms.TextBox txtServiceAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKeyFileBrowse;
        private System.Windows.Forms.NumericUpDown numMaxParralel;
        private System.Windows.Forms.TextBox txtApplicationName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilterDocumentation;
        private System.Windows.Forms.Label label8;
    }
}