namespace Sidera.Utilities.Clock
{
    partial class SegmentedDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fpnlDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // fpnlDisplay
            // 
            this.fpnlDisplay.AutoSize = true;
            this.fpnlDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fpnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.fpnlDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.fpnlDisplay.MinimumSize = new System.Drawing.Size(16, 16);
            this.fpnlDisplay.Name = "fpnlDisplay";
            this.fpnlDisplay.Padding = new System.Windows.Forms.Padding(12);
            this.fpnlDisplay.Size = new System.Drawing.Size(24, 24);
            this.fpnlDisplay.TabIndex = 0;
            this.fpnlDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.fpnlDisplay_Paint);
            // 
            // SegmentedDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.fpnlDisplay);
            this.Name = "SegmentedDisplay";
            this.Size = new System.Drawing.Size(24, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnlDisplay;
    }
}
