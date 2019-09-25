namespace Exe_Morphing_Util
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnMorph = new System.Windows.Forms.Button();
            this.tbfilehere = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.cbFLS = new System.Windows.Forms.CheckBox();
            this.cbMallocTrick = new System.Windows.Forms.CheckBox();
            this.cbProcessMem = new System.Windows.Forms.CheckBox();
            this.cbSpecial = new System.Windows.Forms.CheckBox();
            this.cbAntiDebug = new System.Windows.Forms.CheckBox();
            this.cbNuma = new System.Windows.Forms.CheckBox();
            this.rbConvBP2NOP = new System.Windows.Forms.RadioButton();
            this.rbConvBP2XCHG = new System.Windows.Forms.RadioButton();
            this.rbConvBP2FNOP = new System.Windows.Forms.RadioButton();
            this.rbBP2WAIT = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbJunkBytes = new System.Windows.Forms.TextBox();
            this.cbPEChar = new System.Windows.Forms.CheckBox();
            this.cbRandomSectionNames = new System.Windows.Forms.CheckBox();
            this.cbTimeStamp = new System.Windows.Forms.CheckBox();
            this.cbJunkBytes = new System.Windows.Forms.CheckBox();
            this.cbResourceChars = new System.Windows.Forms.CheckBox();
            this.cbNullMZ = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.cbRegionSpecific = new System.Windows.Forms.CheckBox();
            this.cbDateSpecific = new System.Windows.Forms.CheckBox();
            this.cbDetectIdle = new System.Windows.Forms.CheckBox();
            this.cbCores = new System.Windows.Forms.CheckBox();
            this.cbAntiEmu = new System.Windows.Forms.CheckBox();
            this.cbFakeWindows = new System.Windows.Forms.CheckBox();
            this.cbSpecialStall = new System.Windows.Forms.CheckBox();
            this.cbLongStall = new System.Windows.Forms.CheckBox();
            this.cbAntiVM = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbKkrunchy = new System.Windows.Forms.RadioButton();
            this.rbCExe = new System.Windows.Forms.RadioButton();
            this.rbMPRESS = new System.Windows.Forms.RadioButton();
            this.rbXPack = new System.Windows.Forms.RadioButton();
            this.rbUPX = new System.Windows.Forms.RadioButton();
            this.mymenustrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriouslyHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbTLS = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbUnpackMeth1 = new System.Windows.Forms.RadioButton();
            this.rbUnpackMeth2 = new System.Windows.Forms.RadioButton();
            this.cbFakeExports = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.mymenustrip.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMorph
            // 
            this.btnMorph.Location = new System.Drawing.Point(10, 528);
            this.btnMorph.Name = "btnMorph";
            this.btnMorph.Size = new System.Drawing.Size(304, 28);
            this.btnMorph.TabIndex = 2;
            this.btnMorph.Text = "Make Changes";
            this.btnMorph.UseVisualStyleBackColor = true;
            this.btnMorph.Click += new System.EventHandler(this.btnMorph_Click);
            // 
            // tbfilehere
            // 
            this.tbfilehere.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbfilehere.Location = new System.Drawing.Point(10, 216);
            this.tbfilehere.Name = "tbfilehere";
            this.tbfilehere.ReadOnly = true;
            this.tbfilehere.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbfilehere.Size = new System.Drawing.Size(610, 24);
            this.tbfilehere.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            // 
            // cbFLS
            // 
            this.cbFLS.AutoSize = true;
            this.cbFLS.Location = new System.Drawing.Point(108, 23);
            this.cbFLS.Name = "cbFLS";
            this.cbFLS.Size = new System.Drawing.Size(68, 17);
            this.cbFLS.TabIndex = 3;
            this.cbFLS.Text = "FLS trick";
            this.cbFLS.UseVisualStyleBackColor = true;
            // 
            // cbMallocTrick
            // 
            this.cbMallocTrick.AutoSize = true;
            this.cbMallocTrick.Location = new System.Drawing.Point(6, 23);
            this.cbMallocTrick.Name = "cbMallocTrick";
            this.cbMallocTrick.Size = new System.Drawing.Size(80, 17);
            this.cbMallocTrick.TabIndex = 3;
            this.cbMallocTrick.Text = "Malloc trick";
            this.cbMallocTrick.UseVisualStyleBackColor = true;
            // 
            // cbProcessMem
            // 
            this.cbProcessMem.AutoSize = true;
            this.cbProcessMem.Location = new System.Drawing.Point(108, 46);
            this.cbProcessMem.Name = "cbProcessMem";
            this.cbProcessMem.Size = new System.Drawing.Size(89, 17);
            this.cbProcessMem.TabIndex = 3;
            this.cbProcessMem.Text = "ProcMemInfo";
            this.cbProcessMem.UseVisualStyleBackColor = true;
            // 
            // cbSpecial
            // 
            this.cbSpecial.AutoSize = true;
            this.cbSpecial.Location = new System.Drawing.Point(6, 46);
            this.cbSpecial.Name = "cbSpecial";
            this.cbSpecial.Size = new System.Drawing.Size(88, 17);
            this.cbSpecial.TabIndex = 3;
            this.cbSpecial.Text = "Joe\'s Special";
            this.cbSpecial.UseVisualStyleBackColor = true;
            // 
            // cbAntiDebug
            // 
            this.cbAntiDebug.AutoSize = true;
            this.cbAntiDebug.Location = new System.Drawing.Point(108, 69);
            this.cbAntiDebug.Name = "cbAntiDebug";
            this.cbAntiDebug.Size = new System.Drawing.Size(79, 17);
            this.cbAntiDebug.TabIndex = 3;
            this.cbAntiDebug.Text = "Anti-Debug";
            this.cbAntiDebug.UseVisualStyleBackColor = true;
            // 
            // cbNuma
            // 
            this.cbNuma.AutoSize = true;
            this.cbNuma.Location = new System.Drawing.Point(6, 69);
            this.cbNuma.Name = "cbNuma";
            this.cbNuma.Size = new System.Drawing.Size(81, 17);
            this.cbNuma.TabIndex = 3;
            this.cbNuma.Text = "NUMA trick";
            this.cbNuma.UseVisualStyleBackColor = true;
            // 
            // rbConvBP2NOP
            // 
            this.rbConvBP2NOP.AutoSize = true;
            this.rbConvBP2NOP.Location = new System.Drawing.Point(16, 24);
            this.rbConvBP2NOP.Name = "rbConvBP2NOP";
            this.rbConvBP2NOP.Size = new System.Drawing.Size(129, 17);
            this.rbConvBP2NOP.TabIndex = 8;
            this.rbConvBP2NOP.TabStop = true;
            this.rbConvBP2NOP.Text = "Convert BP\'s to NOPs";
            this.rbConvBP2NOP.UseVisualStyleBackColor = true;
            // 
            // rbConvBP2XCHG
            // 
            this.rbConvBP2XCHG.AutoSize = true;
            this.rbConvBP2XCHG.Location = new System.Drawing.Point(16, 46);
            this.rbConvBP2XCHG.Name = "rbConvBP2XCHG";
            this.rbConvBP2XCHG.Size = new System.Drawing.Size(131, 17);
            this.rbConvBP2XCHG.TabIndex = 8;
            this.rbConvBP2XCHG.TabStop = true;
            this.rbConvBP2XCHG.Text = "Convert BP\'s to XCHG";
            this.rbConvBP2XCHG.UseVisualStyleBackColor = true;
            // 
            // rbConvBP2FNOP
            // 
            this.rbConvBP2FNOP.AutoSize = true;
            this.rbConvBP2FNOP.Location = new System.Drawing.Point(154, 23);
            this.rbConvBP2FNOP.Name = "rbConvBP2FNOP";
            this.rbConvBP2FNOP.Size = new System.Drawing.Size(137, 17);
            this.rbConvBP2FNOP.TabIndex = 8;
            this.rbConvBP2FNOP.TabStop = true;
            this.rbConvBP2FNOP.Text = "Convert BP\'s to FNOP\'s";
            this.rbConvBP2FNOP.UseVisualStyleBackColor = true;
            // 
            // rbBP2WAIT
            // 
            this.rbBP2WAIT.AutoSize = true;
            this.rbBP2WAIT.Location = new System.Drawing.Point(154, 46);
            this.rbBP2WAIT.Name = "rbBP2WAIT";
            this.rbBP2WAIT.Size = new System.Drawing.Size(136, 17);
            this.rbBP2WAIT.TabIndex = 8;
            this.rbBP2WAIT.TabStop = true;
            this.rbBP2WAIT.Text = "Convert BP\'s to WAIT\'s";
            this.rbBP2WAIT.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbJunkBytes);
            this.groupBox1.Controls.Add(this.rbConvBP2NOP);
            this.groupBox1.Controls.Add(this.cbPEChar);
            this.groupBox1.Controls.Add(this.rbConvBP2XCHG);
            this.groupBox1.Controls.Add(this.cbRandomSectionNames);
            this.groupBox1.Controls.Add(this.rbBP2WAIT);
            this.groupBox1.Controls.Add(this.cbTimeStamp);
            this.groupBox1.Controls.Add(this.rbConvBP2FNOP);
            this.groupBox1.Controls.Add(this.cbJunkBytes);
            this.groupBox1.Controls.Add(this.cbResourceChars);
            this.groupBox1.Controls.Add(this.cbNullMZ);
            this.groupBox1.Location = new System.Drawing.Point(8, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 196);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Morph Options";
            // 
            // tbJunkBytes
            // 
            this.tbJunkBytes.Location = new System.Drawing.Point(164, 98);
            this.tbJunkBytes.Multiline = true;
            this.tbJunkBytes.Name = "tbJunkBytes";
            this.tbJunkBytes.Size = new System.Drawing.Size(136, 88);
            this.tbJunkBytes.TabIndex = 16;
            // 
            // cbPEChar
            // 
            this.cbPEChar.AutoSize = true;
            this.cbPEChar.Location = new System.Drawing.Point(6, 169);
            this.cbPEChar.Name = "cbPEChar";
            this.cbPEChar.Size = new System.Drawing.Size(155, 17);
            this.cbPEChar.TabIndex = 14;
            this.cbPEChar.Text = "Random PE Characteristics";
            this.cbPEChar.UseVisualStyleBackColor = true;
            // 
            // cbRandomSectionNames
            // 
            this.cbRandomSectionNames.AutoSize = true;
            this.cbRandomSectionNames.Location = new System.Drawing.Point(6, 145);
            this.cbRandomSectionNames.Name = "cbRandomSectionNames";
            this.cbRandomSectionNames.Size = new System.Drawing.Size(141, 17);
            this.cbRandomSectionNames.TabIndex = 15;
            this.cbRandomSectionNames.Text = "Random Section Names";
            this.cbRandomSectionNames.UseVisualStyleBackColor = true;
            // 
            // cbTimeStamp
            // 
            this.cbTimeStamp.AutoSize = true;
            this.cbTimeStamp.Location = new System.Drawing.Point(6, 122);
            this.cbTimeStamp.Name = "cbTimeStamp";
            this.cbTimeStamp.Size = new System.Drawing.Size(128, 17);
            this.cbTimeStamp.TabIndex = 13;
            this.cbTimeStamp.Text = "Modify PE Timestamp";
            this.cbTimeStamp.UseVisualStyleBackColor = true;
            // 
            // cbJunkBytes
            // 
            this.cbJunkBytes.AutoSize = true;
            this.cbJunkBytes.Location = new System.Drawing.Point(164, 75);
            this.cbJunkBytes.Name = "cbJunkBytes";
            this.cbJunkBytes.Size = new System.Drawing.Size(128, 17);
            this.cbJunkBytes.TabIndex = 11;
            this.cbJunkBytes.Text = "Insert junk characters";
            this.cbJunkBytes.UseVisualStyleBackColor = true;
            // 
            // cbResourceChars
            // 
            this.cbResourceChars.AutoSize = true;
            this.cbResourceChars.Location = new System.Drawing.Point(6, 98);
            this.cbResourceChars.Name = "cbResourceChars";
            this.cbResourceChars.Size = new System.Drawing.Size(120, 17);
            this.cbResourceChars.TabIndex = 12;
            this.cbResourceChars.Text = "Write Chars To .rsrc";
            this.cbResourceChars.UseVisualStyleBackColor = true;
            // 
            // cbNullMZ
            // 
            this.cbNullMZ.AutoSize = true;
            this.cbNullMZ.Location = new System.Drawing.Point(6, 75);
            this.cbNullMZ.Name = "cbNullMZ";
            this.cbNullMZ.Size = new System.Drawing.Size(111, 17);
            this.cbNullMZ.TabIndex = 10;
            this.cbNullMZ.Text = "Nullify MZ Header";
            this.cbNullMZ.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFakeExports);
            this.groupBox2.Controls.Add(this.cbRegion);
            this.groupBox2.Controls.Add(this.dtp);
            this.groupBox2.Controls.Add(this.cbRegionSpecific);
            this.groupBox2.Controls.Add(this.cbDateSpecific);
            this.groupBox2.Controls.Add(this.cbMallocTrick);
            this.groupBox2.Controls.Add(this.cbDetectIdle);
            this.groupBox2.Controls.Add(this.cbCores);
            this.groupBox2.Controls.Add(this.cbFLS);
            this.groupBox2.Controls.Add(this.cbProcessMem);
            this.groupBox2.Controls.Add(this.cbSpecial);
            this.groupBox2.Controls.Add(this.cbAntiDebug);
            this.groupBox2.Controls.Add(this.cbAntiEmu);
            this.groupBox2.Controls.Add(this.cbFakeWindows);
            this.groupBox2.Controls.Add(this.cbSpecialStall);
            this.groupBox2.Controls.Add(this.cbLongStall);
            this.groupBox2.Controls.Add(this.cbAntiVM);
            this.groupBox2.Controls.Add(this.cbNuma);
            this.groupBox2.Location = new System.Drawing.Point(320, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 196);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AV / Sandbox Evasion Options";
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Items.AddRange(new object[] {
            "Russia",
            "United Kingdom",
            "United States",
            "Japan",
            "China",
            "Iraq",
            "Iran",
            "Syria",
            "Israel",
            "Mexico",
            "Venezuela",
            "Brazil",
            "India",
            "Indonesia",
            "North Korea",
            "South Korea",
            "Pakistan",
            "Saudi Arabia",
            "Afghanistan",
            "Canada",
            "Cuba",
            "Hong Kong SAR",
            "Australia",
            "New Zealand ",
            "Netherlands",
            "Norway"});
            this.cbRegion.Location = new System.Drawing.Point(107, 164);
            this.cbRegion.Margin = new System.Windows.Forms.Padding(2);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(131, 21);
            this.cbRegion.TabIndex = 8;
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(6, 165);
            this.dtp.Margin = new System.Windows.Forms.Padding(2);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(86, 20);
            this.dtp.TabIndex = 6;
            // 
            // cbRegionSpecific
            // 
            this.cbRegionSpecific.AutoSize = true;
            this.cbRegionSpecific.Location = new System.Drawing.Point(108, 140);
            this.cbRegionSpecific.Name = "cbRegionSpecific";
            this.cbRegionSpecific.Size = new System.Drawing.Size(101, 17);
            this.cbRegionSpecific.TabIndex = 5;
            this.cbRegionSpecific.Text = "Region Specific";
            this.cbRegionSpecific.UseVisualStyleBackColor = true;
            // 
            // cbDateSpecific
            // 
            this.cbDateSpecific.AutoSize = true;
            this.cbDateSpecific.Location = new System.Drawing.Point(6, 140);
            this.cbDateSpecific.Name = "cbDateSpecific";
            this.cbDateSpecific.Size = new System.Drawing.Size(90, 17);
            this.cbDateSpecific.TabIndex = 4;
            this.cbDateSpecific.Text = "Date Specific";
            this.cbDateSpecific.UseVisualStyleBackColor = true;
            // 
            // cbDetectIdle
            // 
            this.cbDetectIdle.AutoSize = true;
            this.cbDetectIdle.Enabled = false;
            this.cbDetectIdle.Location = new System.Drawing.Point(6, 116);
            this.cbDetectIdle.Name = "cbDetectIdle";
            this.cbDetectIdle.Size = new System.Drawing.Size(78, 17);
            this.cbDetectIdle.TabIndex = 3;
            this.cbDetectIdle.Text = "Detect Idle";
            this.cbDetectIdle.UseVisualStyleBackColor = true;
            // 
            // cbCores
            // 
            this.cbCores.AutoSize = true;
            this.cbCores.Location = new System.Drawing.Point(196, 46);
            this.cbCores.Name = "cbCores";
            this.cbCores.Size = new System.Drawing.Size(87, 17);
            this.cbCores.TabIndex = 3;
            this.cbCores.Text = "Check Cores";
            this.cbCores.UseVisualStyleBackColor = true;
            // 
            // cbAntiEmu
            // 
            this.cbAntiEmu.AutoSize = true;
            this.cbAntiEmu.Location = new System.Drawing.Point(108, 116);
            this.cbAntiEmu.Name = "cbAntiEmu";
            this.cbAntiEmu.Size = new System.Drawing.Size(93, 17);
            this.cbAntiEmu.TabIndex = 3;
            this.cbAntiEmu.Text = "Anti-Emulation";
            this.cbAntiEmu.UseVisualStyleBackColor = true;
            // 
            // cbFakeWindows
            // 
            this.cbFakeWindows.AutoSize = true;
            this.cbFakeWindows.Location = new System.Drawing.Point(196, 23);
            this.cbFakeWindows.Name = "cbFakeWindows";
            this.cbFakeWindows.Size = new System.Drawing.Size(97, 17);
            this.cbFakeWindows.TabIndex = 3;
            this.cbFakeWindows.Text = "Fake Windows";
            this.cbFakeWindows.UseVisualStyleBackColor = true;
            // 
            // cbSpecialStall
            // 
            this.cbSpecialStall.AutoSize = true;
            this.cbSpecialStall.Location = new System.Drawing.Point(196, 93);
            this.cbSpecialStall.Name = "cbSpecialStall";
            this.cbSpecialStall.Size = new System.Drawing.Size(98, 17);
            this.cbSpecialStall.TabIndex = 3;
            this.cbSpecialStall.Text = "Special Stalling";
            this.cbSpecialStall.UseVisualStyleBackColor = true;
            // 
            // cbLongStall
            // 
            this.cbLongStall.AutoSize = true;
            this.cbLongStall.Location = new System.Drawing.Point(108, 93);
            this.cbLongStall.Name = "cbLongStall";
            this.cbLongStall.Size = new System.Drawing.Size(73, 17);
            this.cbLongStall.TabIndex = 3;
            this.cbLongStall.Text = "Long Stall";
            this.cbLongStall.UseVisualStyleBackColor = true;
            // 
            // cbAntiVM
            // 
            this.cbAntiVM.AutoSize = true;
            this.cbAntiVM.Location = new System.Drawing.Point(6, 93);
            this.cbAntiVM.Name = "cbAntiVM";
            this.cbAntiVM.Size = new System.Drawing.Size(102, 17);
            this.cbAntiVM.TabIndex = 3;
            this.cbAntiVM.Text = "Anti-VM Checks";
            this.cbAntiVM.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbNone);
            this.groupBox3.Controls.Add(this.rbKkrunchy);
            this.groupBox3.Controls.Add(this.rbCExe);
            this.groupBox3.Controls.Add(this.rbMPRESS);
            this.groupBox3.Controls.Add(this.rbXPack);
            this.groupBox3.Controls.Add(this.rbUPX);
            this.groupBox3.Location = new System.Drawing.Point(10, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Packing Options";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(168, 43);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(83, 17);
            this.rbNone.TabIndex = 9;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None (clear)";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // rbKkrunchy
            // 
            this.rbKkrunchy.AutoSize = true;
            this.rbKkrunchy.Location = new System.Drawing.Point(96, 41);
            this.rbKkrunchy.Name = "rbKkrunchy";
            this.rbKkrunchy.Size = new System.Drawing.Size(70, 17);
            this.rbKkrunchy.TabIndex = 9;
            this.rbKkrunchy.TabStop = true;
            this.rbKkrunchy.Text = "Kkrunchy";
            this.rbKkrunchy.UseVisualStyleBackColor = true;
            // 
            // rbCExe
            // 
            this.rbCExe.AutoSize = true;
            this.rbCExe.Location = new System.Drawing.Point(96, 20);
            this.rbCExe.Name = "rbCExe";
            this.rbCExe.Size = new System.Drawing.Size(50, 17);
            this.rbCExe.TabIndex = 9;
            this.rbCExe.TabStop = true;
            this.rbCExe.Text = "CExe";
            this.rbCExe.UseVisualStyleBackColor = true;
            // 
            // rbMPRESS
            // 
            this.rbMPRESS.AutoSize = true;
            this.rbMPRESS.Location = new System.Drawing.Point(14, 43);
            this.rbMPRESS.Name = "rbMPRESS";
            this.rbMPRESS.Size = new System.Drawing.Size(70, 17);
            this.rbMPRESS.TabIndex = 9;
            this.rbMPRESS.TabStop = true;
            this.rbMPRESS.Text = "MPRESS";
            this.rbMPRESS.UseVisualStyleBackColor = true;
            // 
            // rbXPack
            // 
            this.rbXPack.AutoSize = true;
            this.rbXPack.Location = new System.Drawing.Point(169, 19);
            this.rbXPack.Name = "rbXPack";
            this.rbXPack.Size = new System.Drawing.Size(60, 17);
            this.rbXPack.TabIndex = 9;
            this.rbXPack.TabStop = true;
            this.rbXPack.Text = "XPACK";
            this.rbXPack.UseVisualStyleBackColor = true;
            // 
            // rbUPX
            // 
            this.rbUPX.AutoSize = true;
            this.rbUPX.Location = new System.Drawing.Point(14, 20);
            this.rbUPX.Name = "rbUPX";
            this.rbUPX.Size = new System.Drawing.Size(47, 17);
            this.rbUPX.TabIndex = 9;
            this.rbUPX.TabStop = true;
            this.rbUPX.Text = "UPX";
            this.rbUPX.UseVisualStyleBackColor = true;
            // 
            // mymenustrip
            // 
            this.mymenustrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mymenustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mymenustrip.Location = new System.Drawing.Point(0, 0);
            this.mymenustrip.Name = "mymenustrip";
            this.mymenustrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mymenustrip.Size = new System.Drawing.Size(631, 24);
            this.mymenustrip.TabIndex = 12;
            this.mymenustrip.Text = "mymenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadExeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadExeToolStripMenuItem
            // 
            this.loadExeToolStripMenuItem.Name = "loadExeToolStripMenuItem";
            this.loadExeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loadExeToolStripMenuItem.Text = "Load Exe";
            this.loadExeToolStripMenuItem.Click += new System.EventHandler(this.loadExeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.seriouslyHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // seriouslyHelpToolStripMenuItem
            // 
            this.seriouslyHelpToolStripMenuItem.Name = "seriouslyHelpToolStripMenuItem";
            this.seriouslyHelpToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.seriouslyHelpToolStripMenuItem.Text = "Seriously help!";
            this.seriouslyHelpToolStripMenuItem.Click += new System.EventHandler(this.seriouslyHelpToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbTLS);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.rbUnpackMeth1);
            this.groupBox4.Controls.Add(this.rbUnpackMeth2);
            this.groupBox4.Location = new System.Drawing.Point(327, 446);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(293, 110);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Internal Unpacking Method";
            // 
            // cbTLS
            // 
            this.cbTLS.AutoSize = true;
            this.cbTLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTLS.Location = new System.Drawing.Point(4, 61);
            this.cbTLS.Name = "cbTLS";
            this.cbTLS.Size = new System.Drawing.Size(177, 17);
            this.cbTLS.TabIndex = 2;
            this.cbTLS.Text = "Place Evasions in TLS Callback";
            this.cbTLS.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(100, 39);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Create Section";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(190, 17);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(89, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Control Break";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(4, 39);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "APC Way";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbUnpackMeth1
            // 
            this.rbUnpackMeth1.AutoSize = true;
            this.rbUnpackMeth1.Location = new System.Drawing.Point(4, 17);
            this.rbUnpackMeth1.Margin = new System.Windows.Forms.Padding(2);
            this.rbUnpackMeth1.Name = "rbUnpackMeth1";
            this.rbUnpackMeth1.Size = new System.Drawing.Size(96, 17);
            this.rbUnpackMeth1.TabIndex = 0;
            this.rbUnpackMeth1.TabStop = true;
            this.rbUnpackMeth1.Text = "Proc Hollowing";
            this.rbUnpackMeth1.UseVisualStyleBackColor = true;
            // 
            // rbUnpackMeth2
            // 
            this.rbUnpackMeth2.AutoSize = true;
            this.rbUnpackMeth2.Enabled = false;
            this.rbUnpackMeth2.Location = new System.Drawing.Point(100, 17);
            this.rbUnpackMeth2.Margin = new System.Windows.Forms.Padding(2);
            this.rbUnpackMeth2.Name = "rbUnpackMeth2";
            this.rbUnpackMeth2.Size = new System.Drawing.Size(89, 17);
            this.rbUnpackMeth2.TabIndex = 0;
            this.rbUnpackMeth2.TabStop = true;
            this.rbUnpackMeth2.Text = "Transactional";
            this.rbUnpackMeth2.UseVisualStyleBackColor = true;
            // 
            // cbFakeExports
            // 
            this.cbFakeExports.AutoSize = true;
            this.cbFakeExports.Location = new System.Drawing.Point(196, 70);
            this.cbFakeExports.Name = "cbFakeExports";
            this.cbFakeExports.Size = new System.Drawing.Size(88, 17);
            this.cbFakeExports.TabIndex = 9;
            this.cbFakeExports.Text = "Fake Exports";
            this.cbFakeExports.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 562);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbfilehere);
            this.Controls.Add(this.btnMorph);
            this.Controls.Add(this.mymenustrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mymenustrip;
            this.Name = "FormMain";
            this.Text = "AV Testing Utility";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.mymenustrip.ResumeLayout(false);
            this.mymenustrip.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMorph;
        private System.Windows.Forms.TextBox tbfilehere;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.CheckBox cbFLS;
        private System.Windows.Forms.CheckBox cbMallocTrick;
        private System.Windows.Forms.CheckBox cbProcessMem;
        private System.Windows.Forms.CheckBox cbSpecial;
        private System.Windows.Forms.CheckBox cbAntiDebug;
        private System.Windows.Forms.CheckBox cbNuma;
        private System.Windows.Forms.RadioButton rbConvBP2NOP;
        private System.Windows.Forms.RadioButton rbConvBP2XCHG;
        private System.Windows.Forms.RadioButton rbConvBP2FNOP;
        private System.Windows.Forms.RadioButton rbBP2WAIT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbJunkBytes;
        private System.Windows.Forms.CheckBox cbPEChar;
        private System.Windows.Forms.CheckBox cbRandomSectionNames;
        private System.Windows.Forms.CheckBox cbTimeStamp;
        private System.Windows.Forms.CheckBox cbJunkBytes;
        private System.Windows.Forms.CheckBox cbResourceChars;
        private System.Windows.Forms.CheckBox cbNullMZ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCExe;
        private System.Windows.Forms.RadioButton rbMPRESS;
        private System.Windows.Forms.RadioButton rbUPX;
        private System.Windows.Forms.RadioButton rbKkrunchy;
        private System.Windows.Forms.RadioButton rbXPack;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.CheckBox cbAntiEmu;
        private System.Windows.Forms.CheckBox cbFakeWindows;
        private System.Windows.Forms.CheckBox cbLongStall;
        private System.Windows.Forms.CheckBox cbAntiVM;
        private System.Windows.Forms.MenuStrip mymenustrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadExeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seriouslyHelpToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.CheckBox cbRegionSpecific;
        private System.Windows.Forms.CheckBox cbDateSpecific;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbUnpackMeth1;
        private System.Windows.Forms.RadioButton rbUnpackMeth2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.CheckBox cbCores;
        private System.Windows.Forms.CheckBox cbTLS;
        private System.Windows.Forms.CheckBox cbDetectIdle;
        private System.Windows.Forms.CheckBox cbSpecialStall;
        private System.Windows.Forms.CheckBox cbFakeExports;
    }
}

