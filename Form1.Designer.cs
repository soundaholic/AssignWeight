namespace AssignWeight
{
    partial class Form_AssignWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AssignWeight));
            this.button_Assign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Weight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Assign
            // 
            this.button_Assign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Assign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Assign.Location = new System.Drawing.Point(93, 79);
            this.button_Assign.Name = "button_Assign";
            this.button_Assign.Size = new System.Drawing.Size(113, 30);
            this.button_Assign.TabIndex = 0;
            this.button_Assign.Text = "Assign Weight";
            this.button_Assign.UseVisualStyleBackColor = true;
            this.button_Assign.Click += new System.EventHandler(this.Button_Assign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the desired weight:";
            // 
            // textBox_Weight
            // 
            this.textBox_Weight.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Weight.Location = new System.Drawing.Point(185, 27);
            this.textBox_Weight.Name = "textBox_Weight";
            this.textBox_Weight.Size = new System.Drawing.Size(68, 20);
            this.textBox_Weight.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(255, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "kg";
            // 
            // Form_AssignWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(157)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(314, 135);
            this.Controls.Add(this.textBox_Weight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Assign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AssignWeight";
            this.Text = "Assign Weight";
            this.Load += new System.EventHandler(this.Form_AssignWeight_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Assign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Weight;
        private System.Windows.Forms.Label label2;
    }
}

