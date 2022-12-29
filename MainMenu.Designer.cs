namespace MiniGames
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn3x32P = new System.Windows.Forms.Button();
            this.btn3x3CPU = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mini Game Selection";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn3x32P
            // 
            this.btn3x32P.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3x32P.Location = new System.Drawing.Point(37, 81);
            this.btn3x32P.Name = "btn3x32P";
            this.btn3x32P.Size = new System.Drawing.Size(328, 55);
            this.btn3x32P.TabIndex = 1;
            this.btn3x32P.Text = "Tic Tac Toe [2P]";
            this.btn3x32P.UseVisualStyleBackColor = true;
            this.btn3x32P.Click += new System.EventHandler(this.btn3x32P_Click);
            // 
            // btn3x3CPU
            // 
            this.btn3x3CPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3x3CPU.Location = new System.Drawing.Point(37, 142);
            this.btn3x3CPU.Name = "btn3x3CPU";
            this.btn3x3CPU.Size = new System.Drawing.Size(328, 55);
            this.btn3x3CPU.TabIndex = 2;
            this.btn3x3CPU.Text = "Matching Game";
            this.btn3x3CPU.UseVisualStyleBackColor = true;
            this.btn3x3CPU.Click += new System.EventHandler(this.btn3x3CPU_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "by Kim Chimy";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn3x3CPU);
            this.Controls.Add(this.btn3x32P);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn3x32P;
        private System.Windows.Forms.Button btn3x3CPU;
        private System.Windows.Forms.Label label2;
    }
}