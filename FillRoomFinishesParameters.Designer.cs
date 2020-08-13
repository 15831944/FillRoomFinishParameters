namespace RoomFinishes
{
    partial class FillRoomFinishesParameters
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
            this.buttonRun = new System.Windows.Forms.Button();
            this.comboBoxLevels = new System.Windows.Forms.ComboBox();
            this.labelLevels = new System.Windows.Forms.Label();
            this.labelFFAC = new System.Windows.Forms.Label();
            this.labelFWAC = new System.Windows.Forms.Label();
            this.labelFFK = new System.Windows.Forms.Label();
            this.labelFWK = new System.Windows.Forms.Label();
            this.labelCAC = new System.Windows.Forms.Label();
            this.labelCK = new System.Windows.Forms.Label();
            this.labelFFD = new System.Windows.Forms.Label();
            this.labelFWD = new System.Windows.Forms.Label();
            this.labelCD = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBoxKeynotes = new System.Windows.Forms.ListBox();
            this.textBoxFFK = new System.Windows.Forms.TextBox();
            this.buttonRemFFK = new System.Windows.Forms.Button();
            this.buttonAddFFK = new System.Windows.Forms.Button();
            this.buttonAddFFD = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonRemFFD = new System.Windows.Forms.Button();
            this.textBoxFFD = new System.Windows.Forms.TextBox();
            this.buttonRemFWK = new System.Windows.Forms.Button();
            this.buttonAddFWK = new System.Windows.Forms.Button();
            this.textBoxFWK = new System.Windows.Forms.TextBox();
            this.buttonRemFWD = new System.Windows.Forms.Button();
            this.buttonAddFWD = new System.Windows.Forms.Button();
            this.textBoxFWD = new System.Windows.Forms.TextBox();
            this.buttonRemCK = new System.Windows.Forms.Button();
            this.buttonAddCK = new System.Windows.Forms.Button();
            this.textBoxCK = new System.Windows.Forms.TextBox();
            this.buttonRemCD = new System.Windows.Forms.Button();
            this.buttonAddCD = new System.Windows.Forms.Button();
            this.textBoxCD = new System.Windows.Forms.TextBox();
            this.listBoxAssemblyCodes = new System.Windows.Forms.ListBox();
            this.buttonRemFFAC = new System.Windows.Forms.Button();
            this.buttonAddFFAC = new System.Windows.Forms.Button();
            this.buttonRemFWAC = new System.Windows.Forms.Button();
            this.buttonAddFWAC = new System.Windows.Forms.Button();
            this.buttonAddCAC = new System.Windows.Forms.Button();
            this.buttonRemCAC = new System.Windows.Forms.Button();
            this.textBoxFFAC = new System.Windows.Forms.TextBox();
            this.textBoxFWAC = new System.Windows.Forms.TextBox();
            this.textBoxCAC = new System.Windows.Forms.TextBox();
            this.AvailableAssemblyCodes = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(28, 543);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(482, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // comboBoxLevels
            // 
            this.comboBoxLevels.FormattingEnabled = true;
            this.comboBoxLevels.Location = new System.Drawing.Point(28, 41);
            this.comboBoxLevels.Name = "comboBoxLevels";
            this.comboBoxLevels.Size = new System.Drawing.Size(576, 21);
            this.comboBoxLevels.TabIndex = 1;
            this.comboBoxLevels.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevels_SelectedIndexChanged);
            // 
            // labelLevels
            // 
            this.labelLevels.AutoSize = true;
            this.labelLevels.Location = new System.Drawing.Point(25, 24);
            this.labelLevels.Name = "labelLevels";
            this.labelLevels.Size = new System.Drawing.Size(33, 13);
            this.labelLevels.TabIndex = 2;
            this.labelLevels.Text = "Level";
            this.labelLevels.Click += new System.EventHandler(this.labelLevels_Click);
            // 
            // labelFFAC
            // 
            this.labelFFAC.AutoSize = true;
            this.labelFFAC.Location = new System.Drawing.Point(374, 77);
            this.labelFFAC.Name = "labelFFAC";
            this.labelFFAC.Size = new System.Drawing.Size(156, 13);
            this.labelFFAC.TabIndex = 3;
            this.labelFFAC.Text = "Finishing Floors\' Assembly Code";
            this.labelFFAC.Click += new System.EventHandler(this.labelFFAC_Click);
            // 
            // labelFWAC
            // 
            this.labelFWAC.AutoSize = true;
            this.labelFWAC.Location = new System.Drawing.Point(376, 130);
            this.labelFWAC.Name = "labelFWAC";
            this.labelFWAC.Size = new System.Drawing.Size(154, 13);
            this.labelFWAC.TabIndex = 5;
            this.labelFWAC.Text = "Finishing Walls\' Assembly Code";
            this.labelFWAC.Click += new System.EventHandler(this.labelFWAC_Click);
            // 
            // labelFFK
            // 
            this.labelFFK.AutoSize = true;
            this.labelFFK.Location = new System.Drawing.Point(374, 241);
            this.labelFFK.Name = "labelFFK";
            this.labelFFK.Size = new System.Drawing.Size(172, 13);
            this.labelFFK.TabIndex = 9;
            this.labelFFK.Text = "Finishing Floors Keynote Parameter";
            this.labelFFK.Click += new System.EventHandler(this.labelFFK_Click);
            // 
            // labelFWK
            // 
            this.labelFWK.AutoSize = true;
            this.labelFWK.Location = new System.Drawing.Point(374, 340);
            this.labelFWK.Name = "labelFWK";
            this.labelFWK.Size = new System.Drawing.Size(170, 13);
            this.labelFWK.TabIndex = 10;
            this.labelFWK.Text = "Finishing Walls Keynote Parameter";
            this.labelFWK.Click += new System.EventHandler(this.labelFWK_Click);
            // 
            // labelCAC
            // 
            this.labelCAC.AutoSize = true;
            this.labelCAC.Location = new System.Drawing.Point(376, 181);
            this.labelCAC.Name = "labelCAC";
            this.labelCAC.Size = new System.Drawing.Size(120, 13);
            this.labelCAC.TabIndex = 11;
            this.labelCAC.Text = "Ceilings\' Assembly Code";
            this.labelCAC.Click += new System.EventHandler(this.labelCAC_Click);
            // 
            // labelCK
            // 
            this.labelCK.AutoSize = true;
            this.labelCK.Location = new System.Drawing.Point(374, 438);
            this.labelCK.Name = "labelCK";
            this.labelCK.Size = new System.Drawing.Size(136, 13);
            this.labelCK.TabIndex = 14;
            this.labelCK.Text = "Ceilings Keynote Parameter";
            this.labelCK.Click += new System.EventHandler(this.labelCK_Click);
            // 
            // labelFFD
            // 
            this.labelFFD.AutoSize = true;
            this.labelFFD.Location = new System.Drawing.Point(374, 290);
            this.labelFFD.Name = "labelFFD";
            this.labelFFD.Size = new System.Drawing.Size(186, 13);
            this.labelFFD.TabIndex = 16;
            this.labelFFD.Text = "Finishing Floors Description Parameter";
            this.labelFFD.Click += new System.EventHandler(this.labelFFD_Click);
            // 
            // labelFWD
            // 
            this.labelFWD.AutoSize = true;
            this.labelFWD.Location = new System.Drawing.Point(374, 389);
            this.labelFWD.Name = "labelFWD";
            this.labelFWD.Size = new System.Drawing.Size(184, 13);
            this.labelFWD.TabIndex = 18;
            this.labelFWD.Text = "Finishing Walls Description Parameter";
            this.labelFWD.Click += new System.EventHandler(this.labelFWD_Click);
            // 
            // labelCD
            // 
            this.labelCD.AutoSize = true;
            this.labelCD.Location = new System.Drawing.Point(376, 487);
            this.labelCD.Name = "labelCD";
            this.labelCD.Size = new System.Drawing.Size(150, 13);
            this.labelCD.TabIndex = 20;
            this.labelCD.Text = "Ceilings Description Parameter";
            this.labelCD.Click += new System.EventHandler(this.labelCD_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 589);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(576, 23);
            this.progressBar1.TabIndex = 24;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // labelPercentage
            // 
            this.labelPercentage.AutoSize = true;
            this.labelPercentage.Location = new System.Drawing.Point(28, 617);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(21, 13);
            this.labelPercentage.TabIndex = 25;
            this.labelPercentage.Text = "0%";
            this.labelPercentage.Click += new System.EventHandler(this.labelPercentage_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBoxKeynotes
            // 
            this.listBoxKeynotes.FormattingEnabled = true;
            this.listBoxKeynotes.Location = new System.Drawing.Point(28, 257);
            this.listBoxKeynotes.Name = "listBoxKeynotes";
            this.listBoxKeynotes.Size = new System.Drawing.Size(227, 264);
            this.listBoxKeynotes.TabIndex = 26;
            this.listBoxKeynotes.SelectedIndexChanged += new System.EventHandler(this.listBoxKeynotes_SelectedIndexChanged);
            // 
            // textBoxFFK
            // 
            this.textBoxFFK.AccessibleDescription = "Finishing Floors Keynote Parameter";
            this.textBoxFFK.Location = new System.Drawing.Point(377, 257);
            this.textBoxFFK.Name = "textBoxFFK";
            this.textBoxFFK.Size = new System.Drawing.Size(227, 20);
            this.textBoxFFK.TabIndex = 27;
            this.textBoxFFK.TextChanged += new System.EventHandler(this.textBoxFFK_TextChanged);
            // 
            // buttonRemFFK
            // 
            this.buttonRemFFK.Location = new System.Drawing.Point(277, 256);
            this.buttonRemFFK.Name = "buttonRemFFK";
            this.buttonRemFFK.Size = new System.Drawing.Size(34, 20);
            this.buttonRemFFK.TabIndex = 28;
            this.buttonRemFFK.Text = "<-";
            this.buttonRemFFK.UseVisualStyleBackColor = true;
            this.buttonRemFFK.Click += new System.EventHandler(this.buttonRemFFK_Click);
            // 
            // buttonAddFFK
            // 
            this.buttonAddFFK.Location = new System.Drawing.Point(316, 256);
            this.buttonAddFFK.Name = "buttonAddFFK";
            this.buttonAddFFK.Size = new System.Drawing.Size(35, 20);
            this.buttonAddFFK.TabIndex = 29;
            this.buttonAddFFK.Text = "->";
            this.buttonAddFFK.UseVisualStyleBackColor = true;
            this.buttonAddFFK.Click += new System.EventHandler(this.buttonAddFFK_Click);
            // 
            // buttonAddFFD
            // 
            this.buttonAddFFD.Location = new System.Drawing.Point(277, 305);
            this.buttonAddFFD.Name = "buttonAddFFD";
            this.buttonAddFFD.Size = new System.Drawing.Size(34, 20);
            this.buttonAddFFD.TabIndex = 30;
            this.buttonAddFFD.Text = "<-";
            this.buttonAddFFD.UseVisualStyleBackColor = true;
            this.buttonAddFFD.Click += new System.EventHandler(this.buttonRemFFD_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Available parameters:";
            this.label12.Click += new System.EventHandler(this.labelAvailableParameters_Click);
            // 
            // buttonRemFFD
            // 
            this.buttonRemFFD.Location = new System.Drawing.Point(316, 305);
            this.buttonRemFFD.Name = "buttonRemFFD";
            this.buttonRemFFD.Size = new System.Drawing.Size(35, 20);
            this.buttonRemFFD.TabIndex = 32;
            this.buttonRemFFD.Text = "->";
            this.buttonRemFFD.UseVisualStyleBackColor = true;
            this.buttonRemFFD.Click += new System.EventHandler(this.buttonAddFFD_Click);
            // 
            // textBoxFFD
            // 
            this.textBoxFFD.AccessibleDescription = "Finishing Floors Description Parameter";
            this.textBoxFFD.Location = new System.Drawing.Point(377, 306);
            this.textBoxFFD.Name = "textBoxFFD";
            this.textBoxFFD.Size = new System.Drawing.Size(227, 20);
            this.textBoxFFD.TabIndex = 33;
            this.textBoxFFD.TextChanged += new System.EventHandler(this.textBoxFFD_TextChanged);
            // 
            // buttonRemFWK
            // 
            this.buttonRemFWK.Location = new System.Drawing.Point(277, 356);
            this.buttonRemFWK.Name = "buttonRemFWK";
            this.buttonRemFWK.Size = new System.Drawing.Size(34, 20);
            this.buttonRemFWK.TabIndex = 34;
            this.buttonRemFWK.Text = "<-";
            this.buttonRemFWK.UseVisualStyleBackColor = true;
            this.buttonRemFWK.Click += new System.EventHandler(this.buttonRemFWK_Click);
            // 
            // buttonAddFWK
            // 
            this.buttonAddFWK.Location = new System.Drawing.Point(316, 356);
            this.buttonAddFWK.Name = "buttonAddFWK";
            this.buttonAddFWK.Size = new System.Drawing.Size(35, 20);
            this.buttonAddFWK.TabIndex = 35;
            this.buttonAddFWK.Text = "->";
            this.buttonAddFWK.UseVisualStyleBackColor = true;
            this.buttonAddFWK.Click += new System.EventHandler(this.buttonAddFWK_Click);
            // 
            // textBoxFWK
            // 
            this.textBoxFWK.AccessibleDescription = "Finishing Walls Keynote Parameter";
            this.textBoxFWK.Location = new System.Drawing.Point(377, 356);
            this.textBoxFWK.Name = "textBoxFWK";
            this.textBoxFWK.Size = new System.Drawing.Size(227, 20);
            this.textBoxFWK.TabIndex = 36;
            this.textBoxFWK.TextChanged += new System.EventHandler(this.textBoxFWK_TextChanged);
            // 
            // buttonRemFWD
            // 
            this.buttonRemFWD.Location = new System.Drawing.Point(277, 402);
            this.buttonRemFWD.Name = "buttonRemFWD";
            this.buttonRemFWD.Size = new System.Drawing.Size(34, 20);
            this.buttonRemFWD.TabIndex = 37;
            this.buttonRemFWD.Text = "<-";
            this.buttonRemFWD.UseVisualStyleBackColor = true;
            this.buttonRemFWD.Click += new System.EventHandler(this.buttonRemFWD_Click);
            // 
            // buttonAddFWD
            // 
            this.buttonAddFWD.Location = new System.Drawing.Point(316, 402);
            this.buttonAddFWD.Name = "buttonAddFWD";
            this.buttonAddFWD.Size = new System.Drawing.Size(35, 20);
            this.buttonAddFWD.TabIndex = 38;
            this.buttonAddFWD.Text = "->";
            this.buttonAddFWD.UseVisualStyleBackColor = true;
            this.buttonAddFWD.Click += new System.EventHandler(this.buttonAddFWD_Click);
            // 
            // textBoxFWD
            // 
            this.textBoxFWD.AccessibleDescription = "Finishing Walls Description Parameter";
            this.textBoxFWD.Location = new System.Drawing.Point(377, 405);
            this.textBoxFWD.Name = "textBoxFWD";
            this.textBoxFWD.Size = new System.Drawing.Size(227, 20);
            this.textBoxFWD.TabIndex = 39;
            this.textBoxFWD.TextChanged += new System.EventHandler(this.textBoxFWD_TextChanged);
            // 
            // buttonRemCK
            // 
            this.buttonRemCK.Location = new System.Drawing.Point(277, 452);
            this.buttonRemCK.Name = "buttonRemCK";
            this.buttonRemCK.Size = new System.Drawing.Size(34, 20);
            this.buttonRemCK.TabIndex = 40;
            this.buttonRemCK.Text = "<-";
            this.buttonRemCK.UseVisualStyleBackColor = true;
            this.buttonRemCK.Click += new System.EventHandler(this.buttonRemCK_Click);
            // 
            // buttonAddCK
            // 
            this.buttonAddCK.Location = new System.Drawing.Point(316, 452);
            this.buttonAddCK.Name = "buttonAddCK";
            this.buttonAddCK.Size = new System.Drawing.Size(35, 19);
            this.buttonAddCK.TabIndex = 41;
            this.buttonAddCK.Text = "->";
            this.buttonAddCK.UseVisualStyleBackColor = true;
            this.buttonAddCK.Click += new System.EventHandler(this.buttonAddCK_Click);
            // 
            // textBoxCK
            // 
            this.textBoxCK.AccessibleDescription = "Ceilings Keynote Parameter";
            this.textBoxCK.Location = new System.Drawing.Point(377, 454);
            this.textBoxCK.Name = "textBoxCK";
            this.textBoxCK.Size = new System.Drawing.Size(227, 20);
            this.textBoxCK.TabIndex = 42;
            this.textBoxCK.TextChanged += new System.EventHandler(this.textBoxCK_TextChanged);
            // 
            // buttonRemCD
            // 
            this.buttonRemCD.Location = new System.Drawing.Point(277, 503);
            this.buttonRemCD.Name = "buttonRemCD";
            this.buttonRemCD.Size = new System.Drawing.Size(34, 19);
            this.buttonRemCD.TabIndex = 43;
            this.buttonRemCD.Text = "<-";
            this.buttonRemCD.UseVisualStyleBackColor = true;
            this.buttonRemCD.Click += new System.EventHandler(this.buttonRemCD_Click);
            // 
            // buttonAddCD
            // 
            this.buttonAddCD.Location = new System.Drawing.Point(316, 503);
            this.buttonAddCD.Name = "buttonAddCD";
            this.buttonAddCD.Size = new System.Drawing.Size(35, 18);
            this.buttonAddCD.TabIndex = 44;
            this.buttonAddCD.Text = "->";
            this.buttonAddCD.UseVisualStyleBackColor = true;
            this.buttonAddCD.Click += new System.EventHandler(this.buttonAddCD_Click);
            // 
            // textBoxCD
            // 
            this.textBoxCD.AccessibleDescription = "Ceilings Description Parameter";
            this.textBoxCD.Location = new System.Drawing.Point(379, 501);
            this.textBoxCD.Name = "textBoxCD";
            this.textBoxCD.Size = new System.Drawing.Size(225, 20);
            this.textBoxCD.TabIndex = 45;
            this.textBoxCD.TextChanged += new System.EventHandler(this.textBoxCD_TextChanged);
            // 
            // listBoxAssemblyCodes
            // 
            this.listBoxAssemblyCodes.FormattingEnabled = true;
            this.listBoxAssemblyCodes.Location = new System.Drawing.Point(28, 96);
            this.listBoxAssemblyCodes.Name = "listBoxAssemblyCodes";
            this.listBoxAssemblyCodes.Size = new System.Drawing.Size(227, 121);
            this.listBoxAssemblyCodes.TabIndex = 46;
            this.listBoxAssemblyCodes.SelectedIndexChanged += new System.EventHandler(this.listBoxAssemblyCodes_SelectedIndexChanged);
            // 
            // buttonRemFFAC
            // 
            this.buttonRemFFAC.Location = new System.Drawing.Point(277, 94);
            this.buttonRemFFAC.Name = "buttonRemFFAC";
            this.buttonRemFFAC.Size = new System.Drawing.Size(34, 20);
            this.buttonRemFFAC.TabIndex = 47;
            this.buttonRemFFAC.Text = "<-";
            this.buttonRemFFAC.UseVisualStyleBackColor = true;
            this.buttonRemFFAC.Click += new System.EventHandler(this.buttonRemFFAC_Click);
            // 
            // buttonAddFFAC
            // 
            this.buttonAddFFAC.Location = new System.Drawing.Point(316, 94);
            this.buttonAddFFAC.Name = "buttonAddFFAC";
            this.buttonAddFFAC.Size = new System.Drawing.Size(35, 20);
            this.buttonAddFFAC.TabIndex = 48;
            this.buttonAddFFAC.Text = "->";
            this.buttonAddFFAC.UseVisualStyleBackColor = true;
            this.buttonAddFFAC.Click += new System.EventHandler(this.buttonAddFFAC_Click);
            // 
            // buttonRemFWAC
            // 
            this.buttonRemFWAC.Location = new System.Drawing.Point(277, 146);
            this.buttonRemFWAC.Name = "buttonRemFWAC";
            this.buttonRemFWAC.Size = new System.Drawing.Size(34, 20);
            this.buttonRemFWAC.TabIndex = 49;
            this.buttonRemFWAC.Text = "<-";
            this.buttonRemFWAC.UseVisualStyleBackColor = true;
            this.buttonRemFWAC.Click += new System.EventHandler(this.buttonRemFWAC_Click);
            // 
            // buttonAddFWAC
            // 
            this.buttonAddFWAC.Location = new System.Drawing.Point(316, 146);
            this.buttonAddFWAC.Name = "buttonAddFWAC";
            this.buttonAddFWAC.Size = new System.Drawing.Size(35, 20);
            this.buttonAddFWAC.TabIndex = 50;
            this.buttonAddFWAC.Text = "->";
            this.buttonAddFWAC.UseVisualStyleBackColor = true;
            this.buttonAddFWAC.Click += new System.EventHandler(this.buttonAddFWAC_Click);
            // 
            // buttonAddCAC
            // 
            this.buttonAddCAC.Location = new System.Drawing.Point(277, 197);
            this.buttonAddCAC.Name = "buttonAddCAC";
            this.buttonAddCAC.Size = new System.Drawing.Size(34, 20);
            this.buttonAddCAC.TabIndex = 51;
            this.buttonAddCAC.Text = "<-";
            this.buttonAddCAC.UseVisualStyleBackColor = true;
            this.buttonAddCAC.Click += new System.EventHandler(this.buttonAddCAC_Click);
            // 
            // buttonRemCAC
            // 
            this.buttonRemCAC.Location = new System.Drawing.Point(316, 197);
            this.buttonRemCAC.Name = "buttonRemCAC";
            this.buttonRemCAC.Size = new System.Drawing.Size(35, 20);
            this.buttonRemCAC.TabIndex = 52;
            this.buttonRemCAC.Text = "->";
            this.buttonRemCAC.UseVisualStyleBackColor = true;
            this.buttonRemCAC.Click += new System.EventHandler(this.buttonRemCAC_Click);
            // 
            // textBoxFFAC
            // 
            this.textBoxFFAC.AccessibleDescription = "Finishing Floors\' Assembly Code";
            this.textBoxFFAC.Location = new System.Drawing.Point(377, 94);
            this.textBoxFFAC.Name = "textBoxFFAC";
            this.textBoxFFAC.Size = new System.Drawing.Size(227, 20);
            this.textBoxFFAC.TabIndex = 53;
            this.textBoxFFAC.TextChanged += new System.EventHandler(this.textBoxFFAC_TextChanged);
            // 
            // textBoxFWAC
            // 
            this.textBoxFWAC.AccessibleDescription = "Finishing Walls\' Assembly Code";
            this.textBoxFWAC.Location = new System.Drawing.Point(377, 146);
            this.textBoxFWAC.Name = "textBoxFWAC";
            this.textBoxFWAC.Size = new System.Drawing.Size(227, 20);
            this.textBoxFWAC.TabIndex = 54;
            this.textBoxFWAC.TextChanged += new System.EventHandler(this.textBoxFWAC_TextChanged);
            // 
            // textBoxCAC
            // 
            this.textBoxCAC.AccessibleDescription = "Ceilings\' Assembly Code";
            this.textBoxCAC.Location = new System.Drawing.Point(377, 197);
            this.textBoxCAC.Name = "textBoxCAC";
            this.textBoxCAC.Size = new System.Drawing.Size(227, 20);
            this.textBoxCAC.TabIndex = 55;
            this.textBoxCAC.TextChanged += new System.EventHandler(this.textBoxCAC_TextChanged);
            // 
            // AvailableAssemblyCodes
            // 
            this.AvailableAssemblyCodes.AutoSize = true;
            this.AvailableAssemblyCodes.Location = new System.Drawing.Point(28, 79);
            this.AvailableAssemblyCodes.Name = "AvailableAssemblyCodes";
            this.AvailableAssemblyCodes.Size = new System.Drawing.Size(133, 13);
            this.AvailableAssemblyCodes.TabIndex = 56;
            this.AvailableAssemblyCodes.Text = "Available Assembly Codes:";
            this.AvailableAssemblyCodes.Click += new System.EventHandler(this.labelAvailableAssemblyCodes_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(520, 543);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(84, 23);
            this.buttonExit.TabIndex = 57;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FillRoomFinishesParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 643);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.AvailableAssemblyCodes);
            this.Controls.Add(this.textBoxCAC);
            this.Controls.Add(this.textBoxFWAC);
            this.Controls.Add(this.textBoxFFAC);
            this.Controls.Add(this.buttonRemCAC);
            this.Controls.Add(this.buttonAddCAC);
            this.Controls.Add(this.buttonAddFWAC);
            this.Controls.Add(this.buttonRemFWAC);
            this.Controls.Add(this.buttonAddFFAC);
            this.Controls.Add(this.buttonRemFFAC);
            this.Controls.Add(this.listBoxAssemblyCodes);
            this.Controls.Add(this.textBoxCD);
            this.Controls.Add(this.buttonAddCD);
            this.Controls.Add(this.buttonRemCD);
            this.Controls.Add(this.textBoxCK);
            this.Controls.Add(this.buttonAddCK);
            this.Controls.Add(this.buttonRemCK);
            this.Controls.Add(this.textBoxFWD);
            this.Controls.Add(this.buttonAddFWD);
            this.Controls.Add(this.buttonRemFWD);
            this.Controls.Add(this.textBoxFWK);
            this.Controls.Add(this.buttonAddFWK);
            this.Controls.Add(this.buttonRemFWK);
            this.Controls.Add(this.textBoxFFD);
            this.Controls.Add(this.buttonRemFFD);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonAddFFD);
            this.Controls.Add(this.buttonAddFFK);
            this.Controls.Add(this.buttonRemFFK);
            this.Controls.Add(this.textBoxFFK);
            this.Controls.Add(this.listBoxKeynotes);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelCD);
            this.Controls.Add(this.labelFWD);
            this.Controls.Add(this.labelFFD);
            this.Controls.Add(this.labelCK);
            this.Controls.Add(this.labelCAC);
            this.Controls.Add(this.labelFWK);
            this.Controls.Add(this.labelFFK);
            this.Controls.Add(this.labelFWAC);
            this.Controls.Add(this.labelFFAC);
            this.Controls.Add(this.labelLevels);
            this.Controls.Add(this.comboBoxLevels);
            this.Controls.Add(this.buttonRun);
            this.Name = "FillRoomFinishesParameters";
            this.Text = "Fill Room Finishes Parameters";
            this.Load += new System.EventHandler(this.FillRoomFinishesParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ComboBox comboBoxLevels;
        private System.Windows.Forms.Label labelLevels;
        private System.Windows.Forms.Label labelFFAC;
        private System.Windows.Forms.Label labelFWAC;
        private System.Windows.Forms.Label labelFFK;
        private System.Windows.Forms.Label labelFWK;
        private System.Windows.Forms.Label labelCAC;
        private System.Windows.Forms.Label labelCK;
        private System.Windows.Forms.Label labelFFD;
        private System.Windows.Forms.Label labelFWD;
        private System.Windows.Forms.Label labelCD;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBoxKeynotes;
        private System.Windows.Forms.TextBox textBoxFFK;
        private System.Windows.Forms.Button buttonRemFFK;
        private System.Windows.Forms.Button buttonAddFFK;
        private System.Windows.Forms.Button buttonAddFFD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonRemFFD;
        private System.Windows.Forms.TextBox textBoxFFD;
        private System.Windows.Forms.Button buttonRemFWK;
        private System.Windows.Forms.Button buttonAddFWK;
        private System.Windows.Forms.TextBox textBoxFWK;
        private System.Windows.Forms.Button buttonRemFWD;
        private System.Windows.Forms.Button buttonAddFWD;
        private System.Windows.Forms.TextBox textBoxFWD;
        private System.Windows.Forms.Button buttonRemCK;
        private System.Windows.Forms.Button buttonAddCK;
        private System.Windows.Forms.TextBox textBoxCK;
        private System.Windows.Forms.Button buttonRemCD;
        private System.Windows.Forms.Button buttonAddCD;
        private System.Windows.Forms.TextBox textBoxCD;
        private System.Windows.Forms.ListBox listBoxAssemblyCodes;
        private System.Windows.Forms.Button buttonRemFFAC;
        private System.Windows.Forms.Button buttonAddFFAC;
        private System.Windows.Forms.Button buttonRemFWAC;
        private System.Windows.Forms.Button buttonAddFWAC;
        private System.Windows.Forms.Button buttonAddCAC;
        private System.Windows.Forms.Button buttonRemCAC;
        private System.Windows.Forms.TextBox textBoxFFAC;
        private System.Windows.Forms.TextBox textBoxFWAC;
        private System.Windows.Forms.TextBox textBoxCAC;
        private System.Windows.Forms.Label AvailableAssemblyCodes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button buttonExit;
    }
}