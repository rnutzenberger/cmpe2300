namespace RNutzenbergerICA9
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
            this.components = new System.ComponentModel.Container();
            this.UI_Timer = new System.Windows.Forms.Timer(this.components);
            this._nudQueues = new System.Windows.Forms.NumericUpDown();
            this._btnSim = new System.Windows.Forms.Button();
            this._lblNext = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._nudQueues)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_Timer
            // 
            this.UI_Timer.Enabled = true;
            // 
            // _nudQueues
            // 
            this._nudQueues.Location = new System.Drawing.Point(272, 6);
            this._nudQueues.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._nudQueues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudQueues.Name = "_nudQueues";
            this._nudQueues.Size = new System.Drawing.Size(40, 20);
            this._nudQueues.TabIndex = 0;
            this._nudQueues.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _btnSim
            // 
            this._btnSim.Location = new System.Drawing.Point(6, 6);
            this._btnSim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnSim.Name = "_btnSim";
            this._btnSim.Size = new System.Drawing.Size(262, 24);
            this._btnSim.TabIndex = 1;
            this._btnSim.Text = "Simulate";
            this._btnSim.UseVisualStyleBackColor = true;
            // 
            // _lblNext
            // 
            this._lblNext.BackColor = System.Drawing.SystemColors.ControlDark;
            this._lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblNext.ForeColor = System.Drawing.Color.Black;
            this._lblNext.Location = new System.Drawing.Point(12, 37);
            this._lblNext.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblNext.Name = "_lblNext";
            this._lblNext.Size = new System.Drawing.Size(300, 38);
            this._lblNext.TabIndex = 2;
            this._lblNext.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 84);
            this.Controls.Add(this._lblNext);
            this.Controls.Add(this._btnSim);
            this.Controls.Add(this._nudQueues);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "o";
            ((System.ComponentModel.ISupportInitialize)(this._nudQueues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_Timer;
        private System.Windows.Forms.NumericUpDown _nudQueues;
        private System.Windows.Forms.Button _btnSim;
        private System.Windows.Forms.Label _lblNext;
    }
}

