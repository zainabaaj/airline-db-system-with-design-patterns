namespace Airlines2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.classcb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(44, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class List";
            // 
            // classcb
            // 
            this.classcb.FormattingEnabled = true;
            this.classcb.Items.AddRange(new object[] {
            "Airline",
            "Airplane",
            "Airport",
            "Airline Employee",
            "Booking Agent",
            "Customer",
            "Flight",
            "Ticket"});
            this.classcb.Location = new System.Drawing.Point(134, 28);
            this.classcb.Name = "classcb";
            this.classcb.Size = new System.Drawing.Size(121, 21);
            this.classcb.TabIndex = 1;
            this.classcb.SelectedIndexChanged += new System.EventHandler(this.classcb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose A Class";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(287, 28);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(400, 28);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(520, 28);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 517);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classcb);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox classcb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}

