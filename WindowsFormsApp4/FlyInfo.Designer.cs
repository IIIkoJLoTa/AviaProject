namespace WindowsFormsApp4
{
    partial class FlyInfo
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.arrival = new System.Windows.Forms.Label();
            this.depatrure = new System.Windows.Forms.Label();
            this.departuretime = new System.Windows.Forms.Label();
            this.arrivaltime = new System.Windows.Forms.Label();
            this.departureDate = new System.Windows.Forms.Label();
            this.arrivalDate = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.price);
            this.panel1.Controls.Add(this.arrivalDate);
            this.panel1.Controls.Add(this.departureDate);
            this.panel1.Controls.Add(this.arrivaltime);
            this.panel1.Controls.Add(this.departuretime);
            this.panel1.Controls.Add(this.arrival);
            this.panel1.Controls.Add(this.depatrure);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 95);
            this.panel1.TabIndex = 0;
            // 
            // arrival
            // 
            this.arrival.AutoSize = true;
            this.arrival.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(151)))));
            this.arrival.Location = new System.Drawing.Point(415, 45);
            this.arrival.Name = "arrival";
            this.arrival.Size = new System.Drawing.Size(35, 13);
            this.arrival.TabIndex = 1;
            this.arrival.Text = "label2";
            // 
            // depatrure
            // 
            this.depatrure.AutoSize = true;
            this.depatrure.BackColor = System.Drawing.Color.White;
            this.depatrure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(151)))));
            this.depatrure.Location = new System.Drawing.Point(32, 45);
            this.depatrure.Name = "depatrure";
            this.depatrure.Size = new System.Drawing.Size(35, 13);
            this.depatrure.TabIndex = 0;
            this.depatrure.Text = "label1";
            // 
            // departuretime
            // 
            this.departuretime.AutoSize = true;
            this.departuretime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departuretime.Location = new System.Drawing.Point(31, 19);
            this.departuretime.Name = "departuretime";
            this.departuretime.Size = new System.Drawing.Size(51, 20);
            this.departuretime.TabIndex = 2;
            this.departuretime.Text = "label1";
            // 
            // arrivaltime
            // 
            this.arrivaltime.AutoSize = true;
            this.arrivaltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrivaltime.Location = new System.Drawing.Point(414, 19);
            this.arrivaltime.Name = "arrivaltime";
            this.arrivaltime.Size = new System.Drawing.Size(51, 20);
            this.arrivaltime.TabIndex = 3;
            this.arrivaltime.Text = "label1";
            // 
            // departureDate
            // 
            this.departureDate.AutoSize = true;
            this.departureDate.BackColor = System.Drawing.Color.White;
            this.departureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(151)))));
            this.departureDate.Location = new System.Drawing.Point(32, 65);
            this.departureDate.Name = "departureDate";
            this.departureDate.Size = new System.Drawing.Size(35, 13);
            this.departureDate.TabIndex = 4;
            this.departureDate.Text = "label1";
            // 
            // arrivalDate
            // 
            this.arrivalDate.AutoSize = true;
            this.arrivalDate.BackColor = System.Drawing.Color.White;
            this.arrivalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(151)))));
            this.arrivalDate.Location = new System.Drawing.Point(415, 65);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(35, 13);
            this.arrivalDate.TabIndex = 5;
            this.arrivalDate.Text = "label2";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price.Location = new System.Drawing.Point(229, 38);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(43, 20);
            this.price.TabIndex = 6;
            this.price.Text = "price";
            // 
            // FlyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FlyInfo";
            this.Size = new System.Drawing.Size(535, 93);
            this.Load += new System.EventHandler(this.FlyInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label arrival;
        private System.Windows.Forms.Label depatrure;
        private System.Windows.Forms.Label departuretime;
        private System.Windows.Forms.Label arrivaltime;
        private System.Windows.Forms.Label departureDate;
        private System.Windows.Forms.Label arrivalDate;
        private System.Windows.Forms.Label price;
    }
}
