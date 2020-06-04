namespace RNutzenbergerICA11
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
            this._DGV = new System.Windows.Forms.DataGridView();
            this._btnLoad = new System.Windows.Forms.Button();
            this._btnAvg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // _DGV
            // 
            this._DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DGV.Location = new System.Drawing.Point(6, 59);
            this._DGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._DGV.Name = "_DGV";
            this._DGV.RowHeadersVisible = false;
            this._DGV.RowHeadersWidth = 82;
            this._DGV.RowTemplate.Height = 33;
            this._DGV.Size = new System.Drawing.Size(217, 466);
            this._DGV.TabIndex = 0;
            // 
            // _btnLoad
            // 
            this._btnLoad.Location = new System.Drawing.Point(6, 6);
            this._btnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnLoad.Name = "_btnLoad";
            this._btnLoad.Size = new System.Drawing.Size(217, 23);
            this._btnLoad.TabIndex = 2;
            this._btnLoad.Text = "Load File";
            this._btnLoad.UseVisualStyleBackColor = true;
            // 
            // _btnAvg
            // 
            this._btnAvg.Location = new System.Drawing.Point(6, 33);
            this._btnAvg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnAvg.Name = "_btnAvg";
            this._btnAvg.Size = new System.Drawing.Size(217, 23);
            this._btnAvg.TabIndex = 3;
            this._btnAvg.Text = "Average : 0";
            this._btnAvg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 531);
            this.Controls.Add(this._btnAvg);
            this.Controls.Add(this._btnLoad);
            this.Controls.Add(this._DGV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _DGV;
        private System.Windows.Forms.Button _btnLoad;
        private System.Windows.Forms.Button _btnAvg;
    }
}

