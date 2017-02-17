namespace CGoogleDrive.SettingForms
{
    partial class ApplicationSetup
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Google Setup");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Flat File");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("SQL Server");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MySQL Server");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MongoDB Server");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Input Configuration", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Flat File");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("SQL Server");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("MySQL Server");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("MongoDB Server");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Global");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Output Configuration", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("CGoogleDrive Setup", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode12});
            this.tree_SettingsArea = new System.Windows.Forms.TreeView();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tree_SettingsArea
            // 
            this.tree_SettingsArea.Location = new System.Drawing.Point(12, 12);
            this.tree_SettingsArea.Name = "tree_SettingsArea";
            treeNode1.Name = "Node1";
            treeNode1.Tag = "Google";
            treeNode1.Text = "Google Setup";
            treeNode2.Name = "Node0";
            treeNode2.Tag = "input_FlatFile";
            treeNode2.Text = "Flat File";
            treeNode3.Name = "Node1";
            treeNode3.Tag = "input_SQL";
            treeNode3.Text = "SQL Server";
            treeNode4.Name = "Node2";
            treeNode4.Tag = "input_MySQL";
            treeNode4.Text = "MySQL Server";
            treeNode5.Name = "Node3";
            treeNode5.Tag = "input_MongoDB";
            treeNode5.Text = "MongoDB Server";
            treeNode6.Name = "Node2";
            treeNode6.Tag = "Input";
            treeNode6.Text = "Input Configuration";
            treeNode7.Name = "Node4";
            treeNode7.Tag = "output_FlatFile";
            treeNode7.Text = "Flat File";
            treeNode8.Name = "Node5";
            treeNode8.Tag = "output_SQL";
            treeNode8.Text = "SQL Server";
            treeNode9.Name = "Node6";
            treeNode9.Tag = "output_MySQL";
            treeNode9.Text = "MySQL Server";
            treeNode10.Name = "Node7";
            treeNode10.Tag = "output_MongoDB";
            treeNode10.Text = "MongoDB Server";
            treeNode11.Name = "Node0";
            treeNode11.Tag = "output_Global";
            treeNode11.Text = "Global";
            treeNode12.Name = "Node3";
            treeNode12.Tag = "Output";
            treeNode12.Text = "Output Configuration";
            treeNode13.Name = "Node0";
            treeNode13.Tag = "root";
            treeNode13.Text = "CGoogleDrive Setup";
            this.tree_SettingsArea.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.tree_SettingsArea.Size = new System.Drawing.Size(268, 482);
            this.tree_SettingsArea.TabIndex = 1;
            this.tree_SettingsArea.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_SettingsArea_AfterSelect);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Location = new System.Drawing.Point(286, 12);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(825, 482);
            this.pnlSettings.TabIndex = 3;
            // 
            // ApplicationSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 537);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.tree_SettingsArea);
            this.Name = "ApplicationSetup";
            this.Text = "ApplicationSetup";
            this.Load += new System.EventHandler(this.ApplicationSetup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree_SettingsArea;
        private System.Windows.Forms.Panel pnlSettings;


    }
}