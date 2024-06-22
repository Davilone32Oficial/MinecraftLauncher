namespace MinecraLaunherCra
{
    partial class Form2
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
            label2 = new Label();
            hScrollBar1 = new HScrollBar();
            button1 = new Button();
            ServerBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(233, 11);
            label2.Name = "label2";
            label2.Size = new Size(45, 14);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(9, 11);
            hScrollBar1.Maximum = 16000;
            hScrollBar1.Minimum = 1024;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(221, 23);
            hScrollBar1.TabIndex = 8;
            hScrollBar1.Value = 1024;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // button1
            // 
            button1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 94);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Accept";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServerBox
            // 
            ServerBox.Location = new Point(9, 53);
            ServerBox.Name = "ServerBox";
            ServerBox.Size = new Size(101, 23);
            ServerBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(116, 56);
            label1.Name = "label1";
            label1.Size = new Size(272, 14);
            label1.TabIndex = 12;
            label1.Text = "IP of the server you want to enter directly";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(492, 176);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(ServerBox);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(hScrollBar1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Settings";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private HScrollBar hScrollBar1;
        private Button button1;
        private TextBox ServerBox;
        private Label label1;
    }
}