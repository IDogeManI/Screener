
namespace Screener
{
    partial class Screener
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.secondPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.clearSecondPanelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(501, 517);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.WrapContents = false;
            // 
            // secondPanel
            // 
            this.secondPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondPanel.AutoScroll = true;
            this.secondPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.secondPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.secondPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondPanel.Location = new System.Drawing.Point(551, 12);
            this.secondPanel.Name = "secondPanel";
            this.secondPanel.Size = new System.Drawing.Size(501, 517);
            this.secondPanel.TabIndex = 1;
            this.secondPanel.WrapContents = false;
            // 
            // clearSecondPanelButton
            // 
            this.clearSecondPanelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearSecondPanelButton.BackColor = System.Drawing.SystemColors.Control;
            this.clearSecondPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearSecondPanelButton.Location = new System.Drawing.Point(763, 535);
            this.clearSecondPanelButton.Name = "clearSecondPanelButton";
            this.clearSecondPanelButton.Size = new System.Drawing.Size(75, 23);
            this.clearSecondPanelButton.TabIndex = 2;
            this.clearSecondPanelButton.Text = "Clear";
            this.clearSecondPanelButton.UseVisualStyleBackColor = false;
            this.clearSecondPanelButton.Click += new System.EventHandler(this.clearSecondPanelButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Location = new System.Drawing.Point(510, 540);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 14);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "500000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1064, 565);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clearSecondPanelButton);
            this.Controls.Add(this.secondPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel secondPanel;
        private System.Windows.Forms.Button clearSecondPanelButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

