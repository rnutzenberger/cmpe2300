namespace RNutzenbergerICA10
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
            this._btnLLFilterOrder = new System.Windows.Forms.Button();
            this._btnShuffle = new System.Windows.Forms.Button();
            this._btnMakeList = new System.Windows.Forms.Button();
            this._btnLLPop = new System.Windows.Forms.Button();
            this._nudDivisor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._nudDivisor)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnLLFilterOrder
            // 
            this._btnLLFilterOrder.Location = new System.Drawing.Point(12, 438);
            this._btnLLFilterOrder.Name = "_btnLLFilterOrder";
            this._btnLLFilterOrder.Size = new System.Drawing.Size(446, 75);
            this._btnLLFilterOrder.TabIndex = 0;
            this._btnLLFilterOrder.Text = "Filter/Order Linked List";
            this._btnLLFilterOrder.UseVisualStyleBackColor = true;
            // 
            // _btnShuffle
            // 
            this._btnShuffle.Location = new System.Drawing.Point(12, 196);
            this._btnShuffle.Name = "_btnShuffle";
            this._btnShuffle.Size = new System.Drawing.Size(446, 75);
            this._btnShuffle.TabIndex = 5;
            this._btnShuffle.Text = "Shuffle";
            this._btnShuffle.UseVisualStyleBackColor = true;
            // 
            // _btnMakeList
            // 
            this._btnMakeList.Location = new System.Drawing.Point(12, 77);
            this._btnMakeList.Name = "_btnMakeList";
            this._btnMakeList.Size = new System.Drawing.Size(446, 75);
            this._btnMakeList.TabIndex = 6;
            this._btnMakeList.Text = "Make List";
            this._btnMakeList.UseVisualStyleBackColor = true;
            // 
            // _btnLLPop
            // 
            this._btnLLPop.Location = new System.Drawing.Point(12, 317);
            this._btnLLPop.Name = "_btnLLPop";
            this._btnLLPop.Size = new System.Drawing.Size(446, 75);
            this._btnLLPop.TabIndex = 7;
            this._btnLLPop.Text = "Populate Linked List";
            this._btnLLPop.UseVisualStyleBackColor = true;
            // 
            // _nudDivisor
            // 
            this._nudDivisor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._nudDivisor.Location = new System.Drawing.Point(12, 12);
            this._nudDivisor.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._nudDivisor.Name = "_nudDivisor";
            this._nudDivisor.Size = new System.Drawing.Size(446, 31);
            this._nudDivisor.TabIndex = 8;
            this._nudDivisor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 535);
            this.Controls.Add(this._nudDivisor);
            this.Controls.Add(this._btnLLPop);
            this.Controls.Add(this._btnMakeList);
            this.Controls.Add(this._btnShuffle);
            this.Controls.Add(this._btnLLFilterOrder);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._nudDivisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnLLFilterOrder;
        private System.Windows.Forms.Button _btnShuffle;
        private System.Windows.Forms.Button _btnMakeList;
        private System.Windows.Forms.Button _btnLLPop;
        private System.Windows.Forms.NumericUpDown _nudDivisor;
    }
}

