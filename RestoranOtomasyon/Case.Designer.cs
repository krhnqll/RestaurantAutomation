namespace RestoranOtomasyon
{
    partial class Case
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnbutton = new System.Windows.Forms.Button();
            this.btndesks = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnPayment);
            this.panel1.Controls.Add(this.btndesks);
            this.panel1.Controls.Add(this.btnbutton);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 108);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Location = new System.Drawing.Point(0, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 517);
            this.panel2.TabIndex = 1;
            // 
            // btnbutton
            // 
            this.btnbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnbutton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbutton.Location = new System.Drawing.Point(13, 27);
            this.btnbutton.Name = "btnbutton";
            this.btnbutton.Size = new System.Drawing.Size(117, 42);
            this.btnbutton.TabIndex = 0;
            this.btnbutton.Text = "Menu";
            this.btnbutton.UseVisualStyleBackColor = false;
            this.btnbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // btndesks
            // 
            this.btndesks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndesks.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btndesks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndesks.Location = new System.Drawing.Point(136, 27);
            this.btndesks.Name = "btndesks";
            this.btndesks.Size = new System.Drawing.Size(117, 42);
            this.btndesks.TabIndex = 1;
            this.btndesks.Text = "Desks";
            this.btndesks.UseVisualStyleBackColor = false;
            this.btndesks.Click += new System.EventHandler(this.btndesks_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPayment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(259, 27);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(117, 42);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.button3_Click);
            // 
            // Case
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 618);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Case";
            this.Text = "Case";
            this.Load += new System.EventHandler(this.Case_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndesks;
        private System.Windows.Forms.Button btnbutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPayment;
    }
}