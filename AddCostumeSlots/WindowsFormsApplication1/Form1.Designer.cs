namespace WindowsFormsApplication1
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
            this.ModelFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.WorkspaceDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chr00 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chr11 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chr13 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stock90 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.characterLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.costumeNum = new System.Windows.Forms.TextBox();
            this.soundSE = new System.Windows.Forms.TextBox();
            this.soundVC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.model2 = new System.Windows.Forms.TextBox();
            this.model3 = new System.Windows.Forms.TextBox();
            this.model4 = new System.Windows.Forms.TextBox();
            this.eightPlayerModel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.updateCharacterParam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModelFolder
            // 
            this.ModelFolder.AllowDrop = true;
            this.ModelFolder.Location = new System.Drawing.Point(13, 68);
            this.ModelFolder.Name = "ModelFolder";
            this.ModelFolder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ModelFolder.Size = new System.Drawing.Size(242, 20);
            this.ModelFolder.TabIndex = 0;
            this.ModelFolder.TextChanged += new System.EventHandler(this.ModelFolder_TextChanged);
            this.ModelFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.ModelFolder_DragDrop);
            this.ModelFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.ModelFolder_DragEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkspaceDirectory
            // 
            this.WorkspaceDirectory.AcceptsTab = true;
            this.WorkspaceDirectory.AllowDrop = true;
            this.WorkspaceDirectory.Location = new System.Drawing.Point(13, 25);
            this.WorkspaceDirectory.Name = "WorkspaceDirectory";
            this.WorkspaceDirectory.Size = new System.Drawing.Size(532, 20);
            this.WorkspaceDirectory.TabIndex = 2;
            this.WorkspaceDirectory.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.WorkspaceDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.WorkspaceDirectory_DragDrop);
            this.WorkspaceDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.WorkspaceDirectory_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Model Folder";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chr00
            // 
            this.chr00.AllowDrop = true;
            this.chr00.Location = new System.Drawing.Point(303, 68);
            this.chr00.Name = "chr00";
            this.chr00.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chr00.Size = new System.Drawing.Size(242, 20);
            this.chr00.TabIndex = 5;
            this.chr00.TextChanged += new System.EventHandler(this.chr00_TextChanged);
            this.chr00.DragDrop += new System.Windows.Forms.DragEventHandler(this.chr00_DragDrop);
            this.chr00.DragEnter += new System.Windows.Forms.DragEventHandler(this.chr00_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "chr_00";
            // 
            // chr11
            // 
            this.chr11.AllowDrop = true;
            this.chr11.Location = new System.Drawing.Point(303, 111);
            this.chr11.Name = "chr11";
            this.chr11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chr11.Size = new System.Drawing.Size(242, 20);
            this.chr11.TabIndex = 7;
            this.chr11.TextChanged += new System.EventHandler(this.chr11_TextChanged);
            this.chr11.DragDrop += new System.Windows.Forms.DragEventHandler(this.chr11_DragDrop);
            this.chr11.DragEnter += new System.Windows.Forms.DragEventHandler(this.chr11_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "chr_11";
            // 
            // chr13
            // 
            this.chr13.AllowDrop = true;
            this.chr13.Location = new System.Drawing.Point(303, 154);
            this.chr13.Name = "chr13";
            this.chr13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chr13.Size = new System.Drawing.Size(242, 20);
            this.chr13.TabIndex = 9;
            this.chr13.TextChanged += new System.EventHandler(this.chr13_TextChanged);
            this.chr13.DragDrop += new System.Windows.Forms.DragEventHandler(this.chr13_DragDrop);
            this.chr13.DragEnter += new System.Windows.Forms.DragEventHandler(this.chr13_DragEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "chr_13";
            // 
            // stock90
            // 
            this.stock90.AllowDrop = true;
            this.stock90.Location = new System.Drawing.Point(303, 198);
            this.stock90.Name = "stock90";
            this.stock90.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stock90.Size = new System.Drawing.Size(242, 20);
            this.stock90.TabIndex = 11;
            this.stock90.TextChanged += new System.EventHandler(this.stock90_TextChanged);
            this.stock90.DragDrop += new System.Windows.Forms.DragEventHandler(this.stock90_DragDrop);
            this.stock90.DragEnter += new System.Windows.Forms.DragEventHandler(this.stock90_DragEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "stock_90";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Character:";
            // 
            // characterLabel
            // 
            this.characterLabel.AutoSize = true;
            this.characterLabel.Location = new System.Drawing.Point(367, 316);
            this.characterLabel.Name = "characterLabel";
            this.characterLabel.Size = new System.Drawing.Size(13, 13);
            this.characterLabel.TabIndex = 14;
            this.characterLabel.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Costume Number:";
            // 
            // costumeNum
            // 
            this.costumeNum.Location = new System.Drawing.Point(508, 313);
            this.costumeNum.Name = "costumeNum";
            this.costumeNum.Size = new System.Drawing.Size(31, 20);
            this.costumeNum.TabIndex = 16;
            this.costumeNum.TextChanged += new System.EventHandler(this.costumeNum_TextChanged);
            // 
            // soundSE
            // 
            this.soundSE.AllowDrop = true;
            this.soundSE.Location = new System.Drawing.Point(15, 316);
            this.soundSE.Name = "soundSE";
            this.soundSE.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.soundSE.Size = new System.Drawing.Size(118, 20);
            this.soundSE.TabIndex = 17;
            this.soundSE.DragDrop += new System.Windows.Forms.DragEventHandler(this.soundSE_DragDrop);
            this.soundSE.DragEnter += new System.Windows.Forms.DragEventHandler(this.soundSE_DragEnter);
            // 
            // soundVC
            // 
            this.soundVC.AllowDrop = true;
            this.soundVC.Location = new System.Drawing.Point(146, 316);
            this.soundVC.Name = "soundVC";
            this.soundVC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.soundVC.Size = new System.Drawing.Size(108, 20);
            this.soundVC.TabIndex = 18;
            this.soundVC.DragDrop += new System.Windows.Forms.DragEventHandler(this.soundVC_DragDrop);
            this.soundVC.DragEnter += new System.Windows.Forms.DragEventHandler(this.soundVC_DragEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "se";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "vc";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(277, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "hardknuckle / kassar / stethoscope / gun / mantle / kart";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(169, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "leftarm / spearhand / remainclown";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "rightarm / waterdragon";
            // 
            // model2
            // 
            this.model2.AllowDrop = true;
            this.model2.Location = new System.Drawing.Point(13, 153);
            this.model2.Name = "model2";
            this.model2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.model2.Size = new System.Drawing.Size(242, 20);
            this.model2.TabIndex = 24;
            this.model2.DragDrop += new System.Windows.Forms.DragEventHandler(this.model2_DragDrop);
            this.model2.DragEnter += new System.Windows.Forms.DragEventHandler(this.model2_DragEnter);
            // 
            // model3
            // 
            this.model3.AllowDrop = true;
            this.model3.Location = new System.Drawing.Point(13, 196);
            this.model3.Name = "model3";
            this.model3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.model3.Size = new System.Drawing.Size(242, 20);
            this.model3.TabIndex = 25;
            this.model3.DragDrop += new System.Windows.Forms.DragEventHandler(this.model3_DragDrop);
            this.model3.DragEnter += new System.Windows.Forms.DragEventHandler(this.model3_DragEnter);
            // 
            // model4
            // 
            this.model4.AllowDrop = true;
            this.model4.Location = new System.Drawing.Point(13, 241);
            this.model4.Name = "model4";
            this.model4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.model4.Size = new System.Drawing.Size(243, 20);
            this.model4.TabIndex = 26;
            this.model4.DragDrop += new System.Windows.Forms.DragEventHandler(this.model4_DragDrop);
            this.model4.DragEnter += new System.Windows.Forms.DragEventHandler(this.model4_DragEnter);
            // 
            // eightPlayerModel
            // 
            this.eightPlayerModel.AllowDrop = true;
            this.eightPlayerModel.Location = new System.Drawing.Point(13, 111);
            this.eightPlayerModel.Name = "eightPlayerModel";
            this.eightPlayerModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.eightPlayerModel.Size = new System.Drawing.Size(236, 20);
            this.eightPlayerModel.TabIndex = 27;
            this.eightPlayerModel.DragDrop += new System.Windows.Forms.DragEventHandler(this.eightPlayerModel_DragDrop);
            this.eightPlayerModel.DragEnter += new System.Windows.Forms.DragEventHandler(this.eightPlayerModel_DragEnter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "8-Player Model";
            // 
            // updateCharacterParam
            // 
            this.updateCharacterParam.Location = new System.Drawing.Point(12, 343);
            this.updateCharacterParam.Name = "updateCharacterParam";
            this.updateCharacterParam.Size = new System.Drawing.Size(136, 23);
            this.updateCharacterParam.TabIndex = 29;
            this.updateCharacterParam.Text = "Update ui_character_db";
            this.updateCharacterParam.UseVisualStyleBackColor = true;
            this.updateCharacterParam.Click += new System.EventHandler(this.updateCharacterParam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 378);
            this.Controls.Add(this.updateCharacterParam);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.eightPlayerModel);
            this.Controls.Add(this.model4);
            this.Controls.Add(this.model3);
            this.Controls.Add(this.model2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.soundVC);
            this.Controls.Add(this.soundSE);
            this.Controls.Add(this.costumeNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.characterLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stock90);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chr13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chr11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chr00);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkspaceDirectory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ModelFolder);
            this.Name = "Form1";
            this.Text = "Add Costume Slots";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ModelFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox WorkspaceDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chr00;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chr11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chr13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stock90;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label characterLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox costumeNum;
        private System.Windows.Forms.TextBox soundSE;
        private System.Windows.Forms.TextBox soundVC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox model2;
        private System.Windows.Forms.TextBox model3;
        private System.Windows.Forms.TextBox model4;
        private System.Windows.Forms.TextBox eightPlayerModel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button updateCharacterParam;
    }
}

