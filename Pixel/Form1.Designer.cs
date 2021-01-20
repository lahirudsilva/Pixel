namespace Pixel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CropBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.GrayscalBtn = new System.Windows.Forms.Button();
            this.InvertBtn = new System.Windows.Forms.Button();
            this.VerticalFlipBtn = new System.Windows.Forms.Button();
            this.HorizontalFlipBtn = new System.Windows.Forms.Button();
            this.ContrastBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RotateRightBtn = new System.Windows.Forms.Button();
            this.BlurBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.EmbossBtn = new System.Windows.Forms.Button();
            this.selectAreaBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DiffuseBtn = new System.Windows.Forms.Button();
            this.SepiaBtn = new System.Windows.Forms.Button();
            this.SharpenBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RotateLeftBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BrightDown = new System.Windows.Forms.Button();
            this.BrightUp = new System.Windows.Forms.Button();
            this.BlueColorBtn = new System.Windows.Forms.Button();
            this.GreenColorBtn = new System.Windows.Forms.Button();
            this.RedColorBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.undoBtn = new System.Windows.Forms.Button();
            this.redoBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ThresholdBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "PIXEL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(122, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(829, 593);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(41, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(143, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CropBtn
            // 
            this.CropBtn.Image = ((System.Drawing.Image)(resources.GetObject("CropBtn.Image")));
            this.CropBtn.Location = new System.Drawing.Point(12, 104);
            this.CropBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CropBtn.Name = "CropBtn";
            this.CropBtn.Size = new System.Drawing.Size(64, 66);
            this.CropBtn.TabIndex = 5;
            this.CropBtn.Text = "Crop selected";
            this.CropBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CropBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CropBtn.UseVisualStyleBackColor = true;
            this.CropBtn.Click += new System.EventHandler(this.CropBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetBtn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.Location = new System.Drawing.Point(41, 64);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(64, 24);
            this.ResetBtn.TabIndex = 6;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(143, 65);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(64, 23);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // GrayscalBtn
            // 
            this.GrayscalBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GrayscalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GrayscalBtn.Image = ((System.Drawing.Image)(resources.GetObject("GrayscalBtn.Image")));
            this.GrayscalBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GrayscalBtn.Location = new System.Drawing.Point(23, 26);
            this.GrayscalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GrayscalBtn.Name = "GrayscalBtn";
            this.GrayscalBtn.Size = new System.Drawing.Size(65, 50);
            this.GrayscalBtn.TabIndex = 8;
            this.GrayscalBtn.Text = "Grayscale";
            this.GrayscalBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GrayscalBtn.UseVisualStyleBackColor = true;
            this.GrayscalBtn.Click += new System.EventHandler(this.GrayscalBtn_Click);
            // 
            // InvertBtn
            // 
            this.InvertBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InvertBtn.Image = ((System.Drawing.Image)(resources.GetObject("InvertBtn.Image")));
            this.InvertBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InvertBtn.Location = new System.Drawing.Point(105, 26);
            this.InvertBtn.Margin = new System.Windows.Forms.Padding(2);
            this.InvertBtn.Name = "InvertBtn";
            this.InvertBtn.Size = new System.Drawing.Size(60, 50);
            this.InvertBtn.TabIndex = 9;
            this.InvertBtn.Text = "Invert";
            this.InvertBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InvertBtn.UseVisualStyleBackColor = true;
            this.InvertBtn.Click += new System.EventHandler(this.InvertBtn_Click);
            // 
            // VerticalFlipBtn
            // 
            this.VerticalFlipBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VerticalFlipBtn.Image = ((System.Drawing.Image)(resources.GetObject("VerticalFlipBtn.Image")));
            this.VerticalFlipBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.VerticalFlipBtn.Location = new System.Drawing.Point(14, 18);
            this.VerticalFlipBtn.Margin = new System.Windows.Forms.Padding(2);
            this.VerticalFlipBtn.Name = "VerticalFlipBtn";
            this.VerticalFlipBtn.Size = new System.Drawing.Size(64, 58);
            this.VerticalFlipBtn.TabIndex = 10;
            this.VerticalFlipBtn.Text = "Vertical ";
            this.VerticalFlipBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.VerticalFlipBtn.UseVisualStyleBackColor = true;
            this.VerticalFlipBtn.Click += new System.EventHandler(this.VerticalFlipBtn_Click);
            // 
            // HorizontalFlipBtn
            // 
            this.HorizontalFlipBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HorizontalFlipBtn.Image = ((System.Drawing.Image)(resources.GetObject("HorizontalFlipBtn.Image")));
            this.HorizontalFlipBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HorizontalFlipBtn.Location = new System.Drawing.Point(14, 97);
            this.HorizontalFlipBtn.Margin = new System.Windows.Forms.Padding(2);
            this.HorizontalFlipBtn.Name = "HorizontalFlipBtn";
            this.HorizontalFlipBtn.Size = new System.Drawing.Size(64, 56);
            this.HorizontalFlipBtn.TabIndex = 11;
            this.HorizontalFlipBtn.Text = "Horizontal";
            this.HorizontalFlipBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HorizontalFlipBtn.UseVisualStyleBackColor = true;
            this.HorizontalFlipBtn.Click += new System.EventHandler(this.HorizontalFlipBtn_Click);
            // 
            // ContrastBtn
            // 
            this.ContrastBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContrastBtn.Image = ((System.Drawing.Image)(resources.GetObject("ContrastBtn.Image")));
            this.ContrastBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ContrastBtn.Location = new System.Drawing.Point(193, 26);
            this.ContrastBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ContrastBtn.Name = "ContrastBtn";
            this.ContrastBtn.Size = new System.Drawing.Size(56, 50);
            this.ContrastBtn.TabIndex = 12;
            this.ContrastBtn.Text = "Contrast";
            this.ContrastBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ContrastBtn.UseVisualStyleBackColor = true;
            this.ContrastBtn.Click += new System.EventHandler(this.ContrastBtn_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 36);
            this.label2.TabIndex = 21;
            this.label2.Text = "Brightness";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RotateRightBtn
            // 
            this.RotateRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateRightBtn.Image")));
            this.RotateRightBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RotateRightBtn.Location = new System.Drawing.Point(12, 28);
            this.RotateRightBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RotateRightBtn.Name = "RotateRightBtn";
            this.RotateRightBtn.Size = new System.Drawing.Size(64, 57);
            this.RotateRightBtn.TabIndex = 25;
            this.RotateRightBtn.Text = "Right";
            this.RotateRightBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RotateRightBtn.UseVisualStyleBackColor = true;
            this.RotateRightBtn.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // BlurBtn
            // 
            this.BlurBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BlurBtn.Image = ((System.Drawing.Image)(resources.GetObject("BlurBtn.Image")));
            this.BlurBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BlurBtn.Location = new System.Drawing.Point(274, 26);
            this.BlurBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BlurBtn.Name = "BlurBtn";
            this.BlurBtn.Size = new System.Drawing.Size(56, 50);
            this.BlurBtn.TabIndex = 26;
            this.BlurBtn.Text = "Blur";
            this.BlurBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BlurBtn.UseVisualStyleBackColor = true;
            this.BlurBtn.Click += new System.EventHandler(this.BlurBtn_Click);
            // 
            // EmbossBtn
            // 
            this.EmbossBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmbossBtn.Image = ((System.Drawing.Image)(resources.GetObject("EmbossBtn.Image")));
            this.EmbossBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.EmbossBtn.Location = new System.Drawing.Point(435, 26);
            this.EmbossBtn.Margin = new System.Windows.Forms.Padding(2);
            this.EmbossBtn.Name = "EmbossBtn";
            this.EmbossBtn.Size = new System.Drawing.Size(56, 50);
            this.EmbossBtn.TabIndex = 27;
            this.EmbossBtn.Text = "Emboss";
            this.EmbossBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EmbossBtn.UseVisualStyleBackColor = true;
            this.EmbossBtn.Click += new System.EventHandler(this.EmbossBtn_Click);
            // 
            // selectAreaBtn
            // 
            this.selectAreaBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectAreaBtn.Image")));
            this.selectAreaBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectAreaBtn.Location = new System.Drawing.Point(12, 29);
            this.selectAreaBtn.Name = "selectAreaBtn";
            this.selectAreaBtn.Size = new System.Drawing.Size(64, 61);
            this.selectAreaBtn.TabIndex = 28;
            this.selectAreaBtn.Text = "Select Area";
            this.selectAreaBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selectAreaBtn.UseVisualStyleBackColor = true;
            this.selectAreaBtn.Click += new System.EventHandler(this.selectAreaBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CropBtn);
            this.groupBox1.Controls.Add(this.selectAreaBtn);
            this.groupBox1.Location = new System.Drawing.Point(17, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 199);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crop Image";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VerticalFlipBtn);
            this.groupBox2.Controls.Add(this.HorizontalFlipBtn);
            this.groupBox2.Location = new System.Drawing.Point(17, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(90, 172);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flip Image";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ThresholdBtn);
            this.groupBox3.Controls.Add(this.DiffuseBtn);
            this.groupBox3.Controls.Add(this.SepiaBtn);
            this.groupBox3.Controls.Add(this.SharpenBtn);
            this.groupBox3.Controls.Add(this.GrayscalBtn);
            this.groupBox3.Controls.Add(this.InvertBtn);
            this.groupBox3.Controls.Add(this.ContrastBtn);
            this.groupBox3.Controls.Add(this.EmbossBtn);
            this.groupBox3.Controls.Add(this.BlurBtn);
            this.groupBox3.Location = new System.Drawing.Point(159, 658);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 100);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Effects";
            // 
            // DiffuseBtn
            // 
            this.DiffuseBtn.Image = ((System.Drawing.Image)(resources.GetObject("DiffuseBtn.Image")));
            this.DiffuseBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DiffuseBtn.Location = new System.Drawing.Point(596, 26);
            this.DiffuseBtn.Name = "DiffuseBtn";
            this.DiffuseBtn.Size = new System.Drawing.Size(55, 50);
            this.DiffuseBtn.TabIndex = 30;
            this.DiffuseBtn.Text = "Diffuse";
            this.DiffuseBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DiffuseBtn.UseVisualStyleBackColor = true;
            this.DiffuseBtn.Click += new System.EventHandler(this.DiffuseBtn_Click);
            // 
            // SepiaBtn
            // 
            this.SepiaBtn.Image = ((System.Drawing.Image)(resources.GetObject("SepiaBtn.Image")));
            this.SepiaBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SepiaBtn.Location = new System.Drawing.Point(516, 26);
            this.SepiaBtn.Name = "SepiaBtn";
            this.SepiaBtn.Size = new System.Drawing.Size(57, 50);
            this.SepiaBtn.TabIndex = 29;
            this.SepiaBtn.Text = "Sepia";
            this.SepiaBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SepiaBtn.UseVisualStyleBackColor = true;
            this.SepiaBtn.Click += new System.EventHandler(this.SepiaBtn_Click);
            // 
            // SharpenBtn
            // 
            this.SharpenBtn.Image = ((System.Drawing.Image)(resources.GetObject("SharpenBtn.Image")));
            this.SharpenBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SharpenBtn.Location = new System.Drawing.Point(353, 26);
            this.SharpenBtn.Name = "SharpenBtn";
            this.SharpenBtn.Size = new System.Drawing.Size(58, 50);
            this.SharpenBtn.TabIndex = 28;
            this.SharpenBtn.Text = "Sharpen";
            this.SharpenBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SharpenBtn.UseVisualStyleBackColor = true;
            this.SharpenBtn.Click += new System.EventHandler(this.SharpenBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RotateLeftBtn);
            this.groupBox4.Controls.Add(this.RotateRightBtn);
            this.groupBox4.Location = new System.Drawing.Point(17, 473);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(90, 182);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rotate Image";
            // 
            // RotateLeftBtn
            // 
            this.RotateLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateLeftBtn.Image")));
            this.RotateLeftBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RotateLeftBtn.Location = new System.Drawing.Point(12, 100);
            this.RotateLeftBtn.Name = "RotateLeftBtn";
            this.RotateLeftBtn.Size = new System.Drawing.Size(64, 65);
            this.RotateLeftBtn.TabIndex = 26;
            this.RotateLeftBtn.Text = "Rotate Left";
            this.RotateLeftBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RotateLeftBtn.UseVisualStyleBackColor = true;
            this.RotateLeftBtn.Click += new System.EventHandler(this.RotateLeftBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BrightDown);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.BrightUp);
            this.groupBox5.Controls.Add(this.BlueColorBtn);
            this.groupBox5.Controls.Add(this.GreenColorBtn);
            this.groupBox5.Controls.Add(this.RedColorBtn);
            this.groupBox5.Location = new System.Drawing.Point(965, 380);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 258);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Color Adjustment";
            // 
            // BrightDown
            // 
            this.BrightDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightDown.Location = new System.Drawing.Point(41, 30);
            this.BrightDown.Name = "BrightDown";
            this.BrightDown.Size = new System.Drawing.Size(33, 36);
            this.BrightDown.TabIndex = 39;
            this.BrightDown.Text = "-";
            this.BrightDown.UseVisualStyleBackColor = true;
            this.BrightDown.Click += new System.EventHandler(this.BrightDown_Click);
            // 
            // BrightUp
            // 
            this.BrightUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightUp.Location = new System.Drawing.Point(166, 30);
            this.BrightUp.Name = "BrightUp";
            this.BrightUp.Size = new System.Drawing.Size(29, 36);
            this.BrightUp.TabIndex = 38;
            this.BrightUp.Text = "+";
            this.BrightUp.UseVisualStyleBackColor = true;
            this.BrightUp.Click += new System.EventHandler(this.BrightUp_Click);
            // 
            // BlueColorBtn
            // 
            this.BlueColorBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BlueColorBtn.Location = new System.Drawing.Point(91, 184);
            this.BlueColorBtn.Name = "BlueColorBtn";
            this.BlueColorBtn.Size = new System.Drawing.Size(75, 49);
            this.BlueColorBtn.TabIndex = 40;
            this.BlueColorBtn.Text = "Blue Effect";
            this.BlueColorBtn.UseVisualStyleBackColor = false;
            this.BlueColorBtn.Click += new System.EventHandler(this.BlueColorBtn_Click);
            // 
            // GreenColorBtn
            // 
            this.GreenColorBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GreenColorBtn.Location = new System.Drawing.Point(143, 112);
            this.GreenColorBtn.Name = "GreenColorBtn";
            this.GreenColorBtn.Size = new System.Drawing.Size(75, 51);
            this.GreenColorBtn.TabIndex = 39;
            this.GreenColorBtn.Text = "Green Effect";
            this.GreenColorBtn.UseVisualStyleBackColor = false;
            this.GreenColorBtn.Click += new System.EventHandler(this.GreenColorBtn_Click);
            // 
            // RedColorBtn
            // 
            this.RedColorBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RedColorBtn.Location = new System.Drawing.Point(30, 112);
            this.RedColorBtn.Name = "RedColorBtn";
            this.RedColorBtn.Size = new System.Drawing.Size(75, 51);
            this.RedColorBtn.TabIndex = 38;
            this.RedColorBtn.Text = "Red Effect";
            this.RedColorBtn.UseVisualStyleBackColor = false;
            this.RedColorBtn.Click += new System.EventHandler(this.RedColorBtn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.clearBtn);
            this.groupBox6.Controls.Add(this.ResetBtn);
            this.groupBox6.Location = new System.Drawing.Point(965, 79);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 100);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Menu";
            // 
            // undoBtn
            // 
            this.undoBtn.Image = ((System.Drawing.Image)(resources.GetObject("undoBtn.Image")));
            this.undoBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.undoBtn.Location = new System.Drawing.Point(995, 222);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 52);
            this.undoBtn.TabIndex = 35;
            this.undoBtn.Text = "Undo";
            this.undoBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // redoBtn
            // 
            this.redoBtn.Image = ((System.Drawing.Image)(resources.GetObject("redoBtn.Image")));
            this.redoBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.redoBtn.Location = new System.Drawing.Point(1119, 222);
            this.redoBtn.Name = "redoBtn";
            this.redoBtn.Size = new System.Drawing.Size(75, 52);
            this.redoBtn.TabIndex = 36;
            this.redoBtn.Text = "Redo";
            this.redoBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.redoBtn.UseVisualStyleBackColor = true;
            this.redoBtn.Click += new System.EventHandler(this.redoBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(1056, 292);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 37;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ThresholdBtn
            // 
            this.ThresholdBtn.Image = ((System.Drawing.Image)(resources.GetObject("ThresholdBtn.Image")));
            this.ThresholdBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ThresholdBtn.Location = new System.Drawing.Point(667, 26);
            this.ThresholdBtn.Name = "ThresholdBtn";
            this.ThresholdBtn.Size = new System.Drawing.Size(66, 50);
            this.ThresholdBtn.TabIndex = 38;
            this.ThresholdBtn.Text = "Threshold";
            this.ThresholdBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ThresholdBtn.UseVisualStyleBackColor = true;
            this.ThresholdBtn.Click += new System.EventHandler(this.ThresholdBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1225, 768);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.redoBtn);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "PIXEL";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CropBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button GrayscalBtn;
        private System.Windows.Forms.Button InvertBtn;
        private System.Windows.Forms.Button VerticalFlipBtn;
        private System.Windows.Forms.Button HorizontalFlipBtn;
        private System.Windows.Forms.Button ContrastBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RotateRightBtn;
        private System.Windows.Forms.Button BlurBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button EmbossBtn;
        private System.Windows.Forms.Button selectAreaBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button RotateLeftBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button redoBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button BrightUp;
        private System.Windows.Forms.Button BrightDown;
        private System.Windows.Forms.Button RedColorBtn;
        private System.Windows.Forms.Button GreenColorBtn;
        private System.Windows.Forms.Button BlueColorBtn;
        private System.Windows.Forms.Button SharpenBtn;
        private System.Windows.Forms.Button DiffuseBtn;
        private System.Windows.Forms.Button SepiaBtn;
        private System.Windows.Forms.Button ThresholdBtn;
    }
}

