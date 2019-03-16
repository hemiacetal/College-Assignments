namespace Question3
{
    partial class MainForm
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
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.titleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.queryTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // queryComboBox
            // 
            this.queryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Items.AddRange(new object[] {
            "All Titles, Sorted by Title",
            "All Titles, Sorted by Title, with Authors Sorted Alphabetically by Last Name then" +
                " First Name",
            "All Authors, Grouped and Sorted by Title, with Authors Sorted Alphabetically by L" +
                "ast Name then First Name"});
            this.queryComboBox.Location = new System.Drawing.Point(12, 328);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(560, 21);
            this.queryComboBox.TabIndex = 2;
            this.queryComboBox.SelectedIndexChanged += new System.EventHandler(this.queryComboBox_SelectedIndexChanged);
            // 
            // titleBindingSource
            // 
            this.titleBindingSource.DataSource = typeof(BooksModel.Title);
            // 
            // queryTextBox
            // 
            this.queryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTextBox.Location = new System.Drawing.Point(13, 13);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.ReadOnly = true;
            this.queryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryTextBox.Size = new System.Drawing.Size(559, 300);
            this.queryTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.queryComboBox);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "MainForm";
            this.Text = "Title and Author DB by Vivian Ren";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource titleBindingSource;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.TextBox queryTextBox;
    }
}