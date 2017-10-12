namespace MSMQDemo
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.Send = new System.Windows.Forms.Button();
            this.Receive = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Queue = new System.Windows.Forms.TextBox();
            this.Peek = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Queue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(92, 82);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(113, 45);
            this.trackBar.TabIndex = 3;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(157, 133);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(58, 23);
            this.Send.TabIndex = 4;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Receive
            // 
            this.Receive.Location = new System.Drawing.Point(92, 171);
            this.Receive.Name = "Receive";
            this.Receive.Size = new System.Drawing.Size(59, 23);
            this.Receive.TabIndex = 5;
            this.Receive.Text = "Receive";
            this.Receive.UseVisualStyleBackColor = true;
            this.Receive.Click += new System.EventHandler(this.Receive_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 6;
            // 
            // Queue
            // 
            this.Queue.Location = new System.Drawing.Point(92, 33);
            this.Queue.Name = "Queue";
            this.Queue.Size = new System.Drawing.Size(119, 21);
            this.Queue.TabIndex = 7;
            // 
            // Peek
            // 
            this.Peek.Location = new System.Drawing.Point(92, 133);
            this.Peek.Name = "Peek";
            this.Peek.Size = new System.Drawing.Size(59, 23);
            this.Peek.TabIndex = 8;
            this.Peek.Text = "Peek";
            this.Peek.UseVisualStyleBackColor = true;
            this.Peek.Click += new System.EventHandler(this.Peek_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(157, 171);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(58, 23);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 225);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Peek);
            this.Controls.Add(this.Queue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Receive);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "main";
            this.Text = "MSMQDemo";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Receive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Queue;
        private System.Windows.Forms.Button Peek;
        private System.Windows.Forms.Button Delete;
    }
}

