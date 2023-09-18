namespace Brayns.BCT
{
    partial class GenericApiInvoke
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
            label4 = new Label();
            tbSubsys = new TextBox();
            splitContainer1 = new SplitContainer();
            tbRequest = new TextBox();
            tbResponse = new TextBox();
            label1 = new Label();
            tbProcedure = new TextBox();
            btInvoke = new Button();
            label2 = new Label();
            tbCompID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 27);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 19);
            label4.TabIndex = 11;
            label4.Text = "Subsystem ID:";
            // 
            // tbSubsys
            // 
            tbSubsys.Location = new Point(165, 23);
            tbSubsys.Margin = new Padding(4);
            tbSubsys.Name = "tbSubsys";
            tbSubsys.Size = new Size(200, 26);
            tbSubsys.TabIndex = 10;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 107);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tbRequest);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbResponse);
            splitContainer1.Size = new Size(1039, 461);
            splitContainer1.SplitterDistance = 500;
            splitContainer1.TabIndex = 12;
            // 
            // tbRequest
            // 
            tbRequest.AcceptsTab = true;
            tbRequest.Dock = DockStyle.Fill;
            tbRequest.Font = new Font("Courier New", 9.818182F, FontStyle.Regular, GraphicsUnit.Point);
            tbRequest.Location = new Point(0, 0);
            tbRequest.Multiline = true;
            tbRequest.Name = "tbRequest";
            tbRequest.ScrollBars = ScrollBars.Vertical;
            tbRequest.Size = new Size(500, 461);
            tbRequest.TabIndex = 0;
            tbRequest.KeyDown += tbRequest_KeyDown;
            // 
            // tbResponse
            // 
            tbResponse.Dock = DockStyle.Fill;
            tbResponse.Font = new Font("Courier New", 9.818182F, FontStyle.Regular, GraphicsUnit.Point);
            tbResponse.Location = new Point(0, 0);
            tbResponse.Multiline = true;
            tbResponse.Name = "tbResponse";
            tbResponse.ReadOnly = true;
            tbResponse.ScrollBars = ScrollBars.Vertical;
            tbResponse.Size = new Size(535, 461);
            tbResponse.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(397, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 19);
            label1.TabIndex = 14;
            label1.Text = "Procedure name:";
            // 
            // tbProcedure
            // 
            tbProcedure.Location = new Point(545, 23);
            tbProcedure.Margin = new Padding(4);
            tbProcedure.Name = "tbProcedure";
            tbProcedure.Size = new Size(361, 26);
            tbProcedure.TabIndex = 13;
            // 
            // btInvoke
            // 
            btInvoke.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btInvoke.Location = new Point(965, 583);
            btInvoke.Name = "btInvoke";
            btInvoke.Size = new Size(86, 26);
            btInvoke.TabIndex = 15;
            btInvoke.Text = "Invoke";
            btInvoke.UseVisualStyleBackColor = true;
            btInvoke.Click += btInvoke_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(397, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 19);
            label2.TabIndex = 17;
            label2.Text = "Company ID:";
            // 
            // tbCompID
            // 
            tbCompID.Location = new Point(545, 57);
            tbCompID.Margin = new Padding(4);
            tbCompID.Name = "tbCompID";
            tbCompID.Size = new Size(361, 26);
            tbCompID.TabIndex = 16;
            // 
            // GenericApiInvoke
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 621);
            Controls.Add(label2);
            Controls.Add(tbCompID);
            Controls.Add(btInvoke);
            Controls.Add(label1);
            Controls.Add(tbProcedure);
            Controls.Add(splitContainer1);
            Controls.Add(label4);
            Controls.Add(tbSubsys);
            Name = "GenericApiInvoke";
            Text = "Generic API Invoke";
            FormClosed += GenericApiInvoke_FormClosed;
            Load += GenericApiInvoke_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox tbSubsys;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox tbProcedure;
        private Button btInvoke;
        private TextBox tbRequest;
        private TextBox tbResponse;
        private Label label2;
        private TextBox tbCompID;
    }
}