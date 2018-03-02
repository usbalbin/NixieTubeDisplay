namespace GUI
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
            this.Ext_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ext_btn
            // 
            this.Ext_btn.Location = new System.Drawing.Point(1090, 627);
            this.Ext_btn.Name = "Ext_btn";
            this.Ext_btn.Size = new System.Drawing.Size(75, 23);
            this.Ext_btn.TabIndex = 0;
            this.Ext_btn.Text = "Exit";
            this.Ext_btn.UseVisualStyleBackColor = true;
            this.Ext_btn.Click += new System.EventHandler(this.Ext_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 662);
            this.Controls.Add(this.Ext_btn);
            this.Name = "Form1";
            this.Text = "Nixie Tube Configurator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ext_btn;
    }
}

