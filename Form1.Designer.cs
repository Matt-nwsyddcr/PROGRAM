namespace 图像编辑
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            open_picture = new Button();
            EXIT_PROGRAM = new Button();
            SAVE_PICTURE = new Button();
            textBox1 = new TextBox();
            LIGHTNESS = new TrackBar();
            CONTRAST = new TrackBar();
            RECTANGLE = new Button();
            LINE = new Button();
            ANGLE = new Button();
            CURVE = new Button();
            lightness_label = new Label();
            contrast_label = new Label();
            RGB_R = new TrackBar();
            RGB_R_label = new Label();
            IMAGE_MEMORY1 = new PictureBox();
            OPERATE_DELETE = new Button();
            IMAGE_MEMORY2 = new PictureBox();
            IMAGE_MEMORY3 = new PictureBox();
            IMAGE_MEMORY_MAIN = new PictureBox();
            RGB_G = new TrackBar();
            RGB_B = new TrackBar();
            RGB_G_label = new Label();
            RGB_B_label = new Label();
            IMAGE_MEMORY4 = new PictureBox();
            tips = new Label();
            SCREEN_SHOT = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LIGHTNESS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CONTRAST).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RGB_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY_MAIN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RGB_G).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RGB_B).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(539, 84);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2000, 1186);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // open_picture
            // 
            open_picture.Image = (Image)resources.GetObject("open_picture.Image");
            open_picture.Location = new Point(11, 8);
            open_picture.Name = "open_picture";
            open_picture.Size = new Size(70, 70);
            open_picture.TabIndex = 3;
            open_picture.UseVisualStyleBackColor = true;
            open_picture.Click += open_picture_Click;
            // 
            // EXIT_PROGRAM
            // 
            EXIT_PROGRAM.BackColor = Color.FromArgb(255, 192, 192);
            EXIT_PROGRAM.Image = (Image)resources.GetObject("EXIT_PROGRAM.Image");
            EXIT_PROGRAM.Location = new Point(2487, 8);
            EXIT_PROGRAM.Name = "EXIT_PROGRAM";
            EXIT_PROGRAM.Size = new Size(52, 52);
            EXIT_PROGRAM.TabIndex = 4;
            EXIT_PROGRAM.UseVisualStyleBackColor = false;
            EXIT_PROGRAM.Click += EXIT_PROGRAM_Click;
            // 
            // SAVE_PICTURE
            // 
            SAVE_PICTURE.Image = (Image)resources.GetObject("SAVE_PICTURE.Image");
            SAVE_PICTURE.Location = new Point(87, 8);
            SAVE_PICTURE.Name = "SAVE_PICTURE";
            SAVE_PICTURE.Size = new Size(70, 70);
            SAVE_PICTURE.TabIndex = 6;
            SAVE_PICTURE.UseVisualStyleBackColor = true;
            SAVE_PICTURE.Click += SAVE_PICTURE_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("华文中宋", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(11, 505);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(522, 765);
            textBox1.TabIndex = 7;
            // 
            // LIGHTNESS
            // 
            LIGHTNESS.Location = new Point(100, 84);
            LIGHTNESS.Maximum = 100;
            LIGHTNESS.Minimum = -100;
            LIGHTNESS.Name = "LIGHTNESS";
            LIGHTNESS.Size = new Size(431, 90);
            LIGHTNESS.TabIndex = 8;
            LIGHTNESS.Tag = "";
            LIGHTNESS.Scroll += LIGHTNESS_Scroll;
            LIGHTNESS.MouseDown += LIGHTNESS_MouseDown;
            LIGHTNESS.MouseUp += LIGHTNESS_MouseUp;
            // 
            // CONTRAST
            // 
            CONTRAST.Location = new Point(100, 146);
            CONTRAST.Maximum = 100;
            CONTRAST.Name = "CONTRAST";
            CONTRAST.Size = new Size(431, 90);
            CONTRAST.TabIndex = 9;
            CONTRAST.Value = 50;
            CONTRAST.Scroll += CONTRAST_Scroll;
            CONTRAST.MouseDown += CONTRAST_MouseDown;
            CONTRAST.MouseUp += CONTRAST_MouseUp;
            // 
            // RECTANGLE
            // 
            RECTANGLE.BackColor = Color.White;
            RECTANGLE.Image = (Image)resources.GetObject("RECTANGLE.Image");
            RECTANGLE.Location = new Point(239, 8);
            RECTANGLE.Name = "RECTANGLE";
            RECTANGLE.Size = new Size(70, 70);
            RECTANGLE.TabIndex = 10;
            RECTANGLE.UseVisualStyleBackColor = false;
            RECTANGLE.Click += RECTANGLE_Click;
            // 
            // LINE
            // 
            LINE.BackColor = Color.White;
            LINE.Image = (Image)resources.GetObject("LINE.Image");
            LINE.Location = new Point(315, 8);
            LINE.Name = "LINE";
            LINE.Size = new Size(70, 70);
            LINE.TabIndex = 11;
            LINE.UseVisualStyleBackColor = false;
            LINE.Click += LINE_Click;
            // 
            // ANGLE
            // 
            ANGLE.BackColor = Color.White;
            ANGLE.Image = (Image)resources.GetObject("ANGLE.Image");
            ANGLE.Location = new Point(391, 8);
            ANGLE.Name = "ANGLE";
            ANGLE.Size = new Size(70, 70);
            ANGLE.TabIndex = 12;
            ANGLE.UseVisualStyleBackColor = false;
            ANGLE.Click += ANGLE_Click;
            // 
            // CURVE
            // 
            CURVE.BackColor = Color.White;
            CURVE.BackgroundImageLayout = ImageLayout.Stretch;
            CURVE.Image = (Image)resources.GetObject("CURVE.Image");
            CURVE.Location = new Point(467, 8);
            CURVE.Name = "CURVE";
            CURVE.Size = new Size(70, 70);
            CURVE.TabIndex = 13;
            CURVE.UseVisualStyleBackColor = false;
            CURVE.Click += CURVE_Click;
            // 
            // lightness_label
            // 
            lightness_label.Location = new Point(11, 81);
            lightness_label.Name = "lightness_label";
            lightness_label.Size = new Size(97, 62);
            lightness_label.TabIndex = 14;
            lightness_label.Text = "亮   度";
            lightness_label.TextAlign = ContentAlignment.MiddleCenter;
            lightness_label.Click += lightness_label_Click;
            // 
            // contrast_label
            // 
            contrast_label.Location = new Point(11, 146);
            contrast_label.Name = "contrast_label";
            contrast_label.Size = new Size(97, 57);
            contrast_label.TabIndex = 15;
            contrast_label.Text = "对比度";
            contrast_label.TextAlign = ContentAlignment.MiddleCenter;
            contrast_label.Click += contrast_label_Click;
            // 
            // RGB_R
            // 
            RGB_R.Location = new Point(100, 275);
            RGB_R.Maximum = 150;
            RGB_R.Minimum = -150;
            RGB_R.Name = "RGB_R";
            RGB_R.Size = new Size(433, 90);
            RGB_R.TabIndex = 16;
            RGB_R.Scroll += RGB_R_Scroll;
            RGB_R.MouseDown += RGB_R_MouseDown;
            RGB_R.MouseUp += RGB_R_MouseUp;
            // 
            // RGB_R_label
            // 
            RGB_R_label.Location = new Point(11, 275);
            RGB_R_label.Name = "RGB_R_label";
            RGB_R_label.Size = new Size(97, 57);
            RGB_R_label.TabIndex = 17;
            RGB_R_label.Text = "RGB_R";
            RGB_R_label.TextAlign = ContentAlignment.MiddleCenter;
            RGB_R_label.Click += RGB_R_label_Click;
            // 
            // IMAGE_MEMORY1
            // 
            IMAGE_MEMORY1.BackColor = Color.White;
            IMAGE_MEMORY1.Location = new Point(1511, 1275);
            IMAGE_MEMORY1.Name = "IMAGE_MEMORY1";
            IMAGE_MEMORY1.Size = new Size(480, 320);
            IMAGE_MEMORY1.SizeMode = PictureBoxSizeMode.Zoom;
            IMAGE_MEMORY1.TabIndex = 18;
            IMAGE_MEMORY1.TabStop = false;
            IMAGE_MEMORY1.Click += IMAGE_MEMORY1_Click;
            IMAGE_MEMORY1.DoubleClick += IMAGE_MEMORY1_DoubleClick;
            // 
            // OPERATE_DELETE
            // 
            OPERATE_DELETE.BackColor = Color.White;
            OPERATE_DELETE.Image = (Image)resources.GetObject("OPERATE_DELETE.Image");
            OPERATE_DELETE.Location = new Point(163, 8);
            OPERATE_DELETE.Name = "OPERATE_DELETE";
            OPERATE_DELETE.Size = new Size(70, 70);
            OPERATE_DELETE.TabIndex = 19;
            OPERATE_DELETE.UseVisualStyleBackColor = false;
            OPERATE_DELETE.Click += OPERATE_DELETE_Click;
            // 
            // IMAGE_MEMORY2
            // 
            IMAGE_MEMORY2.BackColor = Color.White;
            IMAGE_MEMORY2.Location = new Point(1025, 1276);
            IMAGE_MEMORY2.Name = "IMAGE_MEMORY2";
            IMAGE_MEMORY2.Size = new Size(480, 320);
            IMAGE_MEMORY2.SizeMode = PictureBoxSizeMode.Zoom;
            IMAGE_MEMORY2.TabIndex = 21;
            IMAGE_MEMORY2.TabStop = false;
            IMAGE_MEMORY2.Click += IMAGE_MEMORY2_Click;
            IMAGE_MEMORY2.DoubleClick += IMAGE_MEMORY2_DoubleClick;
            // 
            // IMAGE_MEMORY3
            // 
            IMAGE_MEMORY3.BackColor = Color.White;
            IMAGE_MEMORY3.Location = new Point(539, 1275);
            IMAGE_MEMORY3.Name = "IMAGE_MEMORY3";
            IMAGE_MEMORY3.Size = new Size(480, 320);
            IMAGE_MEMORY3.SizeMode = PictureBoxSizeMode.Zoom;
            IMAGE_MEMORY3.TabIndex = 22;
            IMAGE_MEMORY3.TabStop = false;
            IMAGE_MEMORY3.Click += IMAGE_MEMORY3_Click;
            IMAGE_MEMORY3.DoubleClick += IMAGE_MEMORY3_DoubleClick;
            // 
            // IMAGE_MEMORY_MAIN
            // 
            IMAGE_MEMORY_MAIN.BackColor = Color.White;
            IMAGE_MEMORY_MAIN.Location = new Point(1996, 1275);
            IMAGE_MEMORY_MAIN.Name = "IMAGE_MEMORY_MAIN";
            IMAGE_MEMORY_MAIN.Size = new Size(542, 320);
            IMAGE_MEMORY_MAIN.SizeMode = PictureBoxSizeMode.Zoom;
            IMAGE_MEMORY_MAIN.TabIndex = 25;
            IMAGE_MEMORY_MAIN.TabStop = false;
            IMAGE_MEMORY_MAIN.Click += IMAGE_MEMORY_MAIN_Click;
            // 
            // RGB_G
            // 
            RGB_G.Location = new Point(100, 345);
            RGB_G.Maximum = 150;
            RGB_G.Minimum = -150;
            RGB_G.Name = "RGB_G";
            RGB_G.Size = new Size(432, 90);
            RGB_G.TabIndex = 26;
            RGB_G.Scroll += RGB_G_Scroll;
            RGB_G.MouseDown += RGB_G_MouseDown;
            RGB_G.MouseUp += RGB_G_MouseUp;
            // 
            // RGB_B
            // 
            RGB_B.Location = new Point(100, 409);
            RGB_B.Maximum = 150;
            RGB_B.Minimum = -150;
            RGB_B.Name = "RGB_B";
            RGB_B.Size = new Size(431, 90);
            RGB_B.TabIndex = 27;
            RGB_B.Scroll += RGB_B_Scroll;
            RGB_B.MouseDown += RGB_B_MouseDown;
            RGB_B.MouseUp += RGB_B_MouseUp;
            // 
            // RGB_G_label
            // 
            RGB_G_label.Location = new Point(12, 345);
            RGB_G_label.Name = "RGB_G_label";
            RGB_G_label.Size = new Size(96, 57);
            RGB_G_label.TabIndex = 28;
            RGB_G_label.Text = "RGB_G";
            RGB_G_label.TextAlign = ContentAlignment.MiddleCenter;
            RGB_G_label.Click += RGB_G_label_Click;
            // 
            // RGB_B_label
            // 
            RGB_B_label.Location = new Point(11, 409);
            RGB_B_label.Name = "RGB_B_label";
            RGB_B_label.Size = new Size(97, 57);
            RGB_B_label.TabIndex = 29;
            RGB_B_label.Text = "RGB_B";
            RGB_B_label.TextAlign = ContentAlignment.MiddleCenter;
            RGB_B_label.Click += RGB_B_label_Click;
            // 
            // IMAGE_MEMORY4
            // 
            IMAGE_MEMORY4.BackColor = Color.White;
            IMAGE_MEMORY4.Location = new Point(12, 1275);
            IMAGE_MEMORY4.Name = "IMAGE_MEMORY4";
            IMAGE_MEMORY4.Size = new Size(521, 321);
            IMAGE_MEMORY4.SizeMode = PictureBoxSizeMode.Zoom;
            IMAGE_MEMORY4.TabIndex = 30;
            IMAGE_MEMORY4.TabStop = false;
            IMAGE_MEMORY4.Click += IMAGE_MEMORY4_Click;
            IMAGE_MEMORY4.DoubleClick += IMAGE_MEMORY4_DoubleClick;
            // 
            // tips
            // 
            tips.AutoSize = true;
            tips.Font = new Font("华文中宋", 13.8749981F, FontStyle.Regular, GraphicsUnit.Point);
            tips.Location = new Point(2156, 1552);
            tips.Name = "tips";
            tips.Size = new Size(240, 42);
            tips.TabIndex = 31;
            tips.Text = "当前操作图片";
            // 
            // SCREEN_SHOT
            // 
            SCREEN_SHOT.BackColor = Color.White;
            SCREEN_SHOT.Image = (Image)resources.GetObject("SCREEN_SHOT.Image");
            SCREEN_SHOT.ImageAlign = ContentAlignment.BottomRight;
            SCREEN_SHOT.Location = new Point(543, 8);
            SCREEN_SHOT.Name = "SCREEN_SHOT";
            SCREEN_SHOT.Size = new Size(70, 70);
            SCREEN_SHOT.TabIndex = 32;
            SCREEN_SHOT.UseVisualStyleBackColor = false;
            SCREEN_SHOT.Click += SCREEN_SHOT_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(224, 224, 224);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(2550, 1608);
            Controls.Add(SCREEN_SHOT);
            Controls.Add(tips);
            Controls.Add(IMAGE_MEMORY4);
            Controls.Add(RGB_B_label);
            Controls.Add(RGB_G_label);
            Controls.Add(RGB_B);
            Controls.Add(RGB_G);
            Controls.Add(IMAGE_MEMORY_MAIN);
            Controls.Add(IMAGE_MEMORY3);
            Controls.Add(IMAGE_MEMORY2);
            Controls.Add(OPERATE_DELETE);
            Controls.Add(IMAGE_MEMORY1);
            Controls.Add(RGB_R_label);
            Controls.Add(RGB_R);
            Controls.Add(contrast_label);
            Controls.Add(lightness_label);
            Controls.Add(CURVE);
            Controls.Add(ANGLE);
            Controls.Add(LINE);
            Controls.Add(RECTANGLE);
            Controls.Add(CONTRAST);
            Controls.Add(LIGHTNESS);
            Controls.Add(textBox1);
            Controls.Add(SAVE_PICTURE);
            Controls.Add(EXIT_PROGRAM);
            Controls.Add(open_picture);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LIGHTNESS).EndInit();
            ((System.ComponentModel.ISupportInitialize)CONTRAST).EndInit();
            ((System.ComponentModel.ISupportInitialize)RGB_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY2).EndInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY3).EndInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY_MAIN).EndInit();
            ((System.ComponentModel.ISupportInitialize)RGB_G).EndInit();
            ((System.ComponentModel.ISupportInitialize)RGB_B).EndInit();
            ((System.ComponentModel.ISupportInitialize)IMAGE_MEMORY4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button open_picture;
        private Button EXIT_PROGRAM;
        private Button SAVE_PICTURE;
        private TextBox textBox1;
        private TrackBar LIGHTNESS;
        private TrackBar CONTRAST;
        private Button RECTANGLE;
        private Button LINE;
        private Button ANGLE;
        private Button CURVE;
        private Label lightness_label;
        private Label contrast_label;
        private TrackBar RGB_R;
        private Label RGB_R_label;
        private PictureBox IMAGE_MEMORY1;
        private Button OPERATE_DELETE;
        private PictureBox IMAGE_MEMORY2;
        private PictureBox IMAGE_MEMORY3;
        private PictureBox IMAGE_MEMORY_MAIN;
        private TrackBar RGB_G;
        private TrackBar RGB_B;
        private Label RGB_G_label;
        private Label RGB_B_label;
        private PictureBox IMAGE_MEMORY4;
        private Label tips;
        private Button SCREEN_SHOT;
    }
}