namespace MgChitDotNetCore.WindowForm
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 62);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 129);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 1;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 189);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 2;
            label3.Text = "Content";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(192, 62);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(463, 31);
            txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(192, 123);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(463, 31);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(192, 183);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(463, 31);
            txtContent.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(192, 231);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "&Cancle";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(310, 231);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(310, 231);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmBlog";
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnCancel;
        private Button btnSave;
        private Button btnUpdate;
    }
}
