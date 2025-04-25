namespace task1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer c = null;

        protected override void Dispose(bool d)
        {
            if (d && (c != null))
            {
                c.Dispose();
            }
            base.Dispose(d);
        }

        private void InitializeComponent()
        {
            this.pB = new System.Windows.Forms.PictureBox();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            this.SuspendLayout();
            // 
            // pB
            // 
            this.pB.Location = new System.Drawing.Point(12, 12);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(776, 426);
            this.pB.TabIndex = 0;
            this.pB.TabStop = false;
            this.pB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_MD);
            this.pB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_MM);
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(12, 444);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 23);
            this.b1.TabIndex = 1;
            this.b1.Text = "Открыть";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_C);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(93, 444);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 23);
            this.b2.TabIndex = 2;
            this.b2.Text = "Сохранить";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.b2_C);
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(174, 444);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(120, 23);
            this.b3.TabIndex = 3;
            this.b3.Text = "Градации серого";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.b3_C);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.pB);
            this.Name = "Form1";
            this.Text = "Простой графический редактор";
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pB;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
    }
}