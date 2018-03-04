namespace GUI
{
    using System.Windows.Forms;
    using System.Collections.Generic;

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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.Invert_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.Save_Start_btn = new System.Windows.Forms.Button();
            this.ComBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Select_Btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Baud_box = new System.Windows.Forms.ComboBox();
            this.first_gpu_temp_result = new System.Windows.Forms.Label();
            this.first_gpu_usage_result = new System.Windows.Forms.Label();
            this.first_gpu_memusage_result = new System.Windows.Forms.Label();
            this.first_gpu_memusage_mb_result = new System.Windows.Forms.Label();
            this.cpu_temp_result = new System.Windows.Forms.Label();
            this.cpu_usage_result = new System.Windows.Forms.Label();
            this.ram_usage_mb_result = new System.Windows.Forms.Label();
            this.ram_usage_result = new System.Windows.Forms.Label();
            this.disk_usage_result = new System.Windows.Forms.Label();
            this.disk_usage_mb_result = new System.Windows.Forms.Label();
            this.time_date_result = new System.Windows.Forms.Label();
            this.time_clock_result = new System.Windows.Forms.Label();
            this.disk_latency_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ext_btn
            // 
            this.Ext_btn.Location = new System.Drawing.Point(784, 475);
            this.Ext_btn.Name = "Ext_btn";
            this.Ext_btn.Size = new System.Drawing.Size(75, 23);
            this.Ext_btn.TabIndex = 0;
            this.Ext_btn.Text = "Exit";
            this.Ext_btn.UseVisualStyleBackColor = true;
            this.Ext_btn.Click += new System.EventHandler(this.Ext_btn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(40, 344);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "gpu_temp";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(40, 371);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(79, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "gpu_usage";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(40, 425);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(101, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "gpu_memusage";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(40, 398);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(121, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "gpu_memusage_mb";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(267, 341);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(73, 17);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "cpu_temp";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(267, 368);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(79, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "cpu_usage";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(267, 395);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(121, 17);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Text = "cpu_memusage_mb";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(267, 422);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(101, 17);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Text = "cpu_memusage";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // Invert_btn
            // 
            this.Invert_btn.Location = new System.Drawing.Point(124, 263);
            this.Invert_btn.Name = "Invert_btn";
            this.Invert_btn.Size = new System.Drawing.Size(94, 23);
            this.Invert_btn.TabIndex = 9;
            this.Invert_btn.Text = "Clear/Invert";
            this.Invert_btn.UseVisualStyleBackColor = true;
            this.Invert_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Graphics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "Processor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(684, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "Utilities";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(509, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 31);
            this.label4.TabIndex = 15;
            this.label4.Text = "Disks";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(498, 395);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(85, 17);
            this.checkBox9.TabIndex = 19;
            this.checkBox9.Text = "disk_latency";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(498, 368);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(80, 17);
            this.checkBox10.TabIndex = 18;
            this.checkBox10.Text = "disk_usage";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(498, 341);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(100, 17);
            this.checkBox11.TabIndex = 17;
            this.checkBox11.Text = "disk_usage_mb";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(691, 371);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(72, 17);
            this.checkBox15.TabIndex = 21;
            this.checkBox15.Text = "time_date";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(691, 344);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(77, 17);
            this.checkBox16.TabIndex = 20;
            this.checkBox16.Text = "time_clock";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // Save_Start_btn
            // 
            this.Save_Start_btn.Location = new System.Drawing.Point(661, 475);
            this.Save_Start_btn.Name = "Save_Start_btn";
            this.Save_Start_btn.Size = new System.Drawing.Size(117, 23);
            this.Save_Start_btn.TabIndex = 24;
            this.Save_Start_btn.Text = "Save/Start";
            this.Save_Start_btn.UseVisualStyleBackColor = true;
            this.Save_Start_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComBox
            // 
            this.ComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox.FormattingEnabled = true;
            this.ComBox.Location = new System.Drawing.Point(24, 77);
            this.ComBox.Name = "ComBox";
            this.ComBox.Size = new System.Drawing.Size(121, 21);
            this.ComBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Select correct COM-port";
            // 
            // Select_Btn
            // 
            this.Select_Btn.Location = new System.Drawing.Point(24, 263);
            this.Select_Btn.Name = "Select_Btn";
            this.Select_Btn.Size = new System.Drawing.Size(94, 23);
            this.Select_Btn.TabIndex = 27;
            this.Select_Btn.Text = "Select All";
            this.Select_Btn.UseVisualStyleBackColor = true;
            this.Select_Btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Select Baudrate";
            // 
            // Baud_box
            // 
            this.Baud_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Baud_box.FormattingEnabled = true;
            this.Baud_box.Location = new System.Drawing.Point(24, 131);
            this.Baud_box.Name = "Baud_box";
            this.Baud_box.Size = new System.Drawing.Size(121, 21);
            this.Baud_box.TabIndex = 28;
            // 
            // first_gpu_temp_result
            // 
            this.first_gpu_temp_result.AutoSize = true;
            this.first_gpu_temp_result.Location = new System.Drawing.Point(198, 345);
            this.first_gpu_temp_result.Name = "first_gpu_temp_result";
            this.first_gpu_temp_result.Size = new System.Drawing.Size(0, 13);
            this.first_gpu_temp_result.TabIndex = 30;
            // 
            // first_gpu_usage_result
            // 
            this.first_gpu_usage_result.AutoSize = true;
            this.first_gpu_usage_result.Location = new System.Drawing.Point(198, 373);
            this.first_gpu_usage_result.Name = "first_gpu_usage_result";
            this.first_gpu_usage_result.Size = new System.Drawing.Size(0, 13);
            this.first_gpu_usage_result.TabIndex = 31;
            // 
            // first_gpu_memusage_result
            // 
            this.first_gpu_memusage_result.AutoSize = true;
            this.first_gpu_memusage_result.Location = new System.Drawing.Point(198, 430);
            this.first_gpu_memusage_result.Name = "first_gpu_memusage_result";
            this.first_gpu_memusage_result.Size = new System.Drawing.Size(0, 13);
            this.first_gpu_memusage_result.TabIndex = 33;
            // 
            // first_gpu_memusage_mb_result
            // 
            this.first_gpu_memusage_mb_result.AutoSize = true;
            this.first_gpu_memusage_mb_result.Location = new System.Drawing.Point(198, 402);
            this.first_gpu_memusage_mb_result.Name = "first_gpu_memusage_mb_result";
            this.first_gpu_memusage_mb_result.Size = new System.Drawing.Size(0, 13);
            this.first_gpu_memusage_mb_result.TabIndex = 32;
            // 
            // cpu_temp_result
            // 
            this.cpu_temp_result.AutoSize = true;
            this.cpu_temp_result.Location = new System.Drawing.Point(427, 342);
            this.cpu_temp_result.Name = "cpu_temp_result";
            this.cpu_temp_result.Size = new System.Drawing.Size(0, 13);
            this.cpu_temp_result.TabIndex = 35;
            // 
            // cpu_usage_result
            // 
            this.cpu_usage_result.AutoSize = true;
            this.cpu_usage_result.Location = new System.Drawing.Point(427, 368);
            this.cpu_usage_result.Name = "cpu_usage_result";
            this.cpu_usage_result.Size = new System.Drawing.Size(0, 13);
            this.cpu_usage_result.TabIndex = 34;
            // 
            // ram_usage_mb_result
            // 
            this.ram_usage_mb_result.AutoSize = true;
            this.ram_usage_mb_result.Location = new System.Drawing.Point(427, 395);
            this.ram_usage_mb_result.Name = "ram_usage_mb_result";
            this.ram_usage_mb_result.Size = new System.Drawing.Size(0, 13);
            this.ram_usage_mb_result.TabIndex = 37;
            // 
            // ram_usage_result
            // 
            this.ram_usage_result.AutoSize = true;
            this.ram_usage_result.Location = new System.Drawing.Point(427, 422);
            this.ram_usage_result.Name = "ram_usage_result";
            this.ram_usage_result.Size = new System.Drawing.Size(0, 13);
            this.ram_usage_result.TabIndex = 36;
            // 
            // disk_usage_result
            // 
            this.disk_usage_result.AutoSize = true;
            this.disk_usage_result.Location = new System.Drawing.Point(633, 368);
            this.disk_usage_result.Name = "disk_usage_result";
            this.disk_usage_result.Size = new System.Drawing.Size(0, 13);
            this.disk_usage_result.TabIndex = 39;
            // 
            // disk_usage_mb_result
            // 
            this.disk_usage_mb_result.AutoSize = true;
            this.disk_usage_mb_result.Location = new System.Drawing.Point(633, 341);
            this.disk_usage_mb_result.Name = "disk_usage_mb_result";
            this.disk_usage_mb_result.Size = new System.Drawing.Size(0, 13);
            this.disk_usage_mb_result.TabIndex = 38;
            // 
            // time_date_result
            // 
            this.time_date_result.AutoSize = true;
            this.time_date_result.Location = new System.Drawing.Point(793, 373);
            this.time_date_result.Name = "time_date_result";
            this.time_date_result.Size = new System.Drawing.Size(0, 13);
            this.time_date_result.TabIndex = 41;
            // 
            // time_clock_result
            // 
            this.time_clock_result.AutoSize = true;
            this.time_clock_result.Location = new System.Drawing.Point(793, 345);
            this.time_clock_result.Name = "time_clock_result";
            this.time_clock_result.Size = new System.Drawing.Size(0, 13);
            this.time_clock_result.TabIndex = 40;
            // 
            // disk_latency_result
            // 
            this.disk_latency_result.AutoSize = true;
            this.disk_latency_result.Location = new System.Drawing.Point(633, 395);
            this.disk_latency_result.Name = "disk_latency_result";
            this.disk_latency_result.Size = new System.Drawing.Size(0, 13);
            this.disk_latency_result.TabIndex = 42;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(874, 510);
            this.Controls.Add(this.disk_latency_result);
            this.Controls.Add(this.time_date_result);
            this.Controls.Add(this.time_clock_result);
            this.Controls.Add(this.disk_usage_result);
            this.Controls.Add(this.disk_usage_mb_result);
            this.Controls.Add(this.ram_usage_mb_result);
            this.Controls.Add(this.ram_usage_result);
            this.Controls.Add(this.cpu_temp_result);
            this.Controls.Add(this.cpu_usage_result);
            this.Controls.Add(this.first_gpu_memusage_result);
            this.Controls.Add(this.first_gpu_memusage_mb_result);
            this.Controls.Add(this.first_gpu_usage_result);
            this.Controls.Add(this.first_gpu_temp_result);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Baud_box);
            this.Controls.Add(this.Select_Btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComBox);
            this.Controls.Add(this.Save_Start_btn);
            this.Controls.Add(this.checkBox15);
            this.Controls.Add(this.checkBox16);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Invert_btn);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Ext_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nixie Tube Configurator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ext_btn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Button Invert_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.Button Save_Start_btn;
        private System.Windows.Forms.ComboBox ComBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Select_Btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Baud_box;
        private System.Windows.Forms.Label first_gpu_temp_result;
        private System.Windows.Forms.Label first_gpu_usage_result;
        private System.Windows.Forms.Label first_gpu_memusage_result;
        private System.Windows.Forms.Label first_gpu_memusage_mb_result;
        private System.Windows.Forms.Label cpu_temp_result;
        private System.Windows.Forms.Label cpu_usage_result;
        private System.Windows.Forms.Label ram_usage_mb_result;
        private System.Windows.Forms.Label ram_usage_result;
        private System.Windows.Forms.Label disk_usage_result;
        private System.Windows.Forms.Label disk_usage_mb_result;
        private System.Windows.Forms.Label time_date_result;
        private System.Windows.Forms.Label time_clock_result;
        private System.Windows.Forms.Label disk_latency_result;
    }
}

