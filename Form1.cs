using Get_Screen_Show;
using History_Back_Forward;
using Picture_Change;
using Screen_Exchange;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace 图像编辑
{
    public partial class Form1 : Form
    {
        //计算物体长度的修正参数
        double change = 6;

        //对象实例化
        PictureChange PC = new PictureChange();
        GetScreenShow GSS = new GetScreenShow();
        ScreenExchange SE = new ScreenExchange();
        HistoryBackForward HBF = new HistoryBackForward();

        //RGB原始图像
        private Image currentImage;

        private System.Drawing.Point start_rectangle; //矩形的起始点
        private System.Drawing.Point start_line;//直线的起始点
        private System.Drawing.Point end_line;  //直线的结束点
        private System.Drawing.Point start_angle;//直线的起始点
        private System.Drawing.Point middle_angle1;
        private System.Drawing.Point middle_angle2;//角度的结束点
        private System.Drawing.Point end_angle;  //角度的结束点
        private int times = 0;
        Rectangle rect;

        private List<System.Drawing.Point> nodes = new List<System.Drawing.Point>(); // 用于存储节点的列表
        private double curveLength = 0; // 存储已绘制曲线的长度

        //是否按下按钮的判定
        private bool isDrawing_rectangle = false;
        private bool isDrawing_line = false;
        private bool isDrawing_angle = false;
        private bool isDrawing_curve = false;

        //用于计算长度的起始终止点坐标
        System.Drawing.Point Begin, final;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        ////////////////////////////////打开图片按钮////////////////////////////////
        private void open_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFile.FileName);
                pictureBox1.Image = image;
                // 加载原始图像并将其转换为字节数组和Mat对象
                Bitmap bmp = new Bitmap(image);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);

                // 获取当前显示的图片
                currentImage = pictureBox1.Image;
                IMAGE_MEMORY_MAIN.Image = currentImage;

                HBF.historyList.Add(HISTORY_TYPE.Main_picture);
                HBF.Main_picture.Add(currentImage);
            }
        }

        ////////////////////////////////退出程序按钮////////////////////////////////
        private void EXIT_PROGRAM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ////////////////////////////////保存图片按钮////////////////////////////////
        private void SAVE_PICTURE_Click(object sender, EventArgs e)
        {
            Image image = GSS.CaptureScreen(Location.X + pictureBox1.Location.X, Location.Y + pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);

            // 创建SaveFileDialog实例
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 设置保存文件对话框的初始目录和文件名过滤器
            saveFileDialog.InitialDirectory = "D:\\";
            saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";

            // 显示保存文件对话框
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取要保存的图像文件名
                string fileName = saveFileDialog.FileName;

                // 将PictureBox控件中的图像保存到文件中
                image.Save(fileName);

                textBox1.Clear();
                textBox1.AppendText(fileName + "已成功保存！！");
            }
        }

        ////////////////////////////////划线测量部份////////////////////////////////
        private void RECTANGLE_Click(object sender, EventArgs e)
        {
            start_rectangle.X = 0; start_rectangle.Y = 0;
            rect.X = start_rectangle.X; rect.Y = start_rectangle.Y;
            rect.Width = 0; rect.Height = 0;
            textBox1.Clear();

            isDrawing_rectangle = !isDrawing_rectangle;
            RECTANGLE.BackColor = isDrawing_rectangle ? Color.Silver : Color.White;

            LINE.BackColor = Color.White;
            ANGLE.BackColor = Color.White;
            CURVE.BackColor = Color.White;

            isDrawing_line = false;
            isDrawing_angle = false;
            isDrawing_curve = false;

            pictureBox1.Invalidate();
        }
        private void LINE_Click(object sender, EventArgs e)
        {
            start_line.X = 0; start_line.Y = 0;
            end_line.X = 0; end_line.Y = 0;
            textBox1.Clear();

            isDrawing_line = !isDrawing_line;
            LINE.BackColor = isDrawing_line ? Color.Silver : Color.White;

            RECTANGLE.BackColor = Color.White;
            ANGLE.BackColor = Color.White;
            CURVE.BackColor = Color.White;

            isDrawing_rectangle = false;
            isDrawing_angle = false;
            isDrawing_curve = false;

            pictureBox1.Invalidate();
        }
        private void ANGLE_Click(object sender, EventArgs e)
        {
            start_angle.X = 0; start_angle.Y = 0;
            middle_angle1 = start_angle;
            middle_angle2 = start_angle;
            end_angle = start_angle;
            textBox1.Clear();

            isDrawing_angle = !isDrawing_angle;
            ANGLE.BackColor = isDrawing_angle ? Color.Silver : Color.White;

            RECTANGLE.BackColor = Color.White;
            LINE.BackColor = Color.White;
            CURVE.BackColor = Color.White;

            isDrawing_rectangle = false;
            isDrawing_line = false;
            isDrawing_curve = false;

            pictureBox1.Invalidate();
        }
        private void CURVE_Click(object sender, EventArgs e)
        {
            // 按下 CURVE 按钮后，开始绘制曲线
            nodes.Clear(); // 清空节点列表
            textBox1.Clear();
            isDrawing_curve = !isDrawing_curve;
            CURVE.BackColor = isDrawing_curve ? Color.Silver : Color.White;

            RECTANGLE.BackColor = Color.White;
            LINE.BackColor = Color.White;
            ANGLE.BackColor = Color.White;

            isDrawing_rectangle = false;
            isDrawing_line = false;
            isDrawing_angle = false;

            curveLength = 0;
            pictureBox1.Invalidate(); // 使图片框失效并强制重新绘制
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawing_rectangle)
            {
                start_rectangle = e.Location;
                Begin = e.Location;
            }
            if (isDrawing_line)
            {
                start_line = e.Location;
                Begin = e.Location;
            }
            if (isDrawing_angle)
            {
                if (times == 0)
                {
                    start_angle = e.Location;
                }
                if (times == 1)
                {
                    middle_angle2 = e.Location;
                }
            }
            if (isDrawing_curve && e.Button == MouseButtons.Left)
            {
                // 如果正在绘制曲线并且按下了鼠标左键，就添加一个新节点到节点列表中
                nodes.Add(new System.Drawing.Point(e.X, e.Y));
                pictureBox1.Invalidate(); // 使图片框失效并强制重新绘制
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing_rectangle)
            {
                final = e.Location;
                double myDouble = ((double)final.X - (double)Begin.X) / change;
                myDouble = Math.Abs(myDouble);
                double myDouble1 = ((double)final.Y - (double)Begin.Y) / change;
                myDouble1 = Math.Abs(myDouble1);
                textBox1.Clear();
                textBox1.Text = $"长：{myDouble:F2} mm" + Environment.NewLine + $"高：{myDouble1:F2} mm";
            }
            if (isDrawing_line)
            {
                final = e.Location;
                double myDouble = (Math.Sqrt((final.X - Begin.X) * (final.X - Begin.X) + (final.Y - Begin.Y) * (final.Y - Begin.Y))) / change;
                myDouble = Math.Abs(myDouble);
                textBox1.Clear();
                textBox1.Text = $"线段长度: {myDouble:F2} mm";
            }
            if (isDrawing_angle)
            {
                times++;
                if (times == 2)
                {
                    times = 0;
                
                final = e.Location;



                // 计算向量1和向量2
                double v1x = middle_angle1.X - start_angle.X;
                double v1y = middle_angle1.Y - start_angle.Y;
                double v2x = end_angle.X - middle_angle2.X;
                double v2y = end_angle.Y - middle_angle2.Y;

                // 计算向量1和向量2的模
                double v1Length = Math.Sqrt(v1x * v1x + v1y * v1y);
                double v2Length = Math.Sqrt(v2x * v2x + v2y * v2y);

                // 计算向量1和向量2的点积
                double dotProduct = v1x * v2x + v1y * v2y;

                // 计算夹角（弧度制）
                double angle = Math.Acos(dotProduct / (v1Length * v2Length));

                // 将弧度制转换为角度制
                double degreeAngle = angle * 180 / Math.PI;
                if (degreeAngle > 90)
                {
                    degreeAngle = 180 - degreeAngle;
                }

                textBox1.Clear();
                textBox1.Text = $"两线段夹角: {degreeAngle:F2} °";
                }//结束绘制
            }
            if (isDrawing_curve && e.Button == MouseButtons.Left)
            {
                if (nodes.Count >= 2)
                {
                    // 如果节点数大于等于 2，则表示已经确定了至少一条线段
                    int lastNodeIndex = nodes.Count - 1;
                    double lastSegmentLength = Math.Round(Distance(nodes[lastNodeIndex], nodes[lastNodeIndex - 1]));
                    curveLength += lastSegmentLength; // 计算已绘制曲线的长度
                    textBox1.Clear();
                    textBox1.Text = $"线段长度: {curveLength / change:F2} mm。";

                    if (Distance(nodes[lastNodeIndex], nodes[0]) < 10)
                    {
                        // 如果新添加的节点与第一个节点之间的距离小于 10 像素，则连接上一个节点与此节点的同时连接最后一个节点与第一个节点
                        nodes[lastNodeIndex] = nodes[0];
                    }
                    pictureBox1.Invalidate(); // 使图片框失效并强制重新绘制
                }
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing_rectangle)
            {
                if (pictureBox1.Image != null)
                {
                    if (rect != null && rect.Width > 0 && rect.Height > 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Red, 3), rect);//重新绘制颜色为红色
                    }
                }
            }

            if (isDrawing_line)
            {
                if (pictureBox1.Image != null)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red, 3), start_line, end_line);
                }
            }
            if (isDrawing_angle)
            {
                if (pictureBox1.Image != null && times == 0)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red, 3), start_angle, middle_angle1);
                }
                if (pictureBox1.Image != null && times == 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red, 3), start_angle, middle_angle1);
                    e.Graphics.DrawLine(new Pen(Color.Red, 3), middle_angle2, end_angle);
                }

            }
            if (isDrawing_curve && nodes.Count >= 2)
            {
                // 如果正在绘制曲线并且节点数大于等于 2，则开始绘制曲线
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                // 绘制节点
                foreach (System.Drawing.Point node in nodes)
                {
                    e.Graphics.FillEllipse(Brushes.Red, node.X - 3, node.Y - 3, 6, 6);
                }
                // 绘制线段
                Pen pen = new Pen(Color.Red, 3);
                for (int i = 1; i < nodes.Count; i++)
                {
                    e.Graphics.DrawLine(pen, nodes[i - 1], nodes[i]);
                }
                if (Distance(nodes[nodes.Count - 1], nodes[0]) < 10)
                {
                    // 如果新添加的节点与第一个节点之间的距离小于 10 像素，则连接上一个节点与此节点的同时连接最后一个节点与第一个节点
                    e.Graphics.DrawLine(pen, nodes[nodes.Count - 1], nodes[0]);
                    isDrawing_curve = false;
                    nodes[nodes.Count - 1] = nodes[0]; // 修改最后一个节点的位置，使它与第一个节点重合
                                                       // 绘制封闭图形
                    e.Graphics.DrawLine(pen, nodes[nodes.Count - 1], nodes[0]);
                    double area = CalculatePolygonArea(nodes);
                    textBox1.Clear();
                    textBox1.Text = $"曲线长度：{curveLength / change:F2} mm" + Environment.NewLine + $"区块面积：{area:F1} mm^2";
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing_rectangle)
            {
                if (e.Button != MouseButtons.Left)//判断是否按下左键
                    return;
                System.Drawing.Point tempEndPoint = e.Location; //记录框的位置和大小
                rect.Location = new System.Drawing.Point(
                Math.Min(start_rectangle.X, tempEndPoint.X),
                Math.Min(start_rectangle.Y, tempEndPoint.Y));
                rect.Size = new System.Drawing.Size(
                Math.Abs(start_rectangle.X - tempEndPoint.X),
                Math.Abs(start_rectangle.Y - tempEndPoint.Y));
                pictureBox1.Invalidate();
            }
            if (isDrawing_line)
            {
                if (e.Button == MouseButtons.Left)
                {
                    end_line = e.Location;
                    pictureBox1.Invalidate(); // 触发Paint事件重新绘制PictureBox
                }
            }
            if (isDrawing_angle)
            {
                if (e.Button == MouseButtons.Left && times == 0)
                {
                    middle_angle1 = e.Location;
                    pictureBox1.Invalidate(); // 触发Paint事件重新绘制PictureBox
                }
                if (e.Button == MouseButtons.Left && times == 1)
                {
                    end_angle = e.Location;
                    pictureBox1.Invalidate(); // 触发Paint事件重新绘制PictureBox
                }
            }
            if (isDrawing_curve && e.Button == MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // 如果正在绘制曲线并且按下了鼠标左键，就更新最后一个节点的位置
                    int lastNodeIndex = nodes.Count() - 1;
                    nodes[lastNodeIndex] = new System.Drawing.Point(e.X, e.Y);
                    pictureBox1.Invalidate(); // 使图片框失效并强制重新绘制
                }
            }
        }
        private double Distance(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        private double CalculatePolygonArea(List<System.Drawing.Point> points)
        {
            double area = 0.0;
            int j = points.Count - 1;
            for (int i = 0; i < points.Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y);
                j = i;
            }
            return Math.Abs(area / 2) / change / change;
        }

        ////////////////////////////////亮度拖动条////////////////////////////////
        private void LIGHTNESS_Scroll(object sender, EventArgs e)
        {
            CONTRAST.Value = 50;
            RGB_R.Value = 0;
            RGB_G.Value = 0;
            RGB_B.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.LIGHT, LIGHTNESS.Value, currentImage);
        }
        private void lightness_label_Click(object sender, EventArgs e)
        {
            HBF.lightnessList.Add(LIGHTNESS.Value);
            HBF.historyList.Add(HISTORY_TYPE.lightness);

            LIGHTNESS.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.LIGHT, LIGHTNESS.Value, currentImage);
        }


        ////////////////////////////////对比度拖动条////////////////////////////////
        private unsafe void CONTRAST_Scroll(object sender, EventArgs e)
        {
            LIGHTNESS.Value = 0;
            RGB_R.Value = 0;
            RGB_G.Value = 0;
            RGB_B.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.CONTRAST, CONTRAST.Value, currentImage);

        }
        private void contrast_label_Click(object sender, EventArgs e)
        {
            HBF.contractList.Add(CONTRAST.Value);
            HBF.historyList.Add(HISTORY_TYPE.contract);

            CONTRAST.Value = 50;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.CONTRAST, CONTRAST.Value, currentImage);
        }


        ////////////////////////////////RGB拖动条////////////////////////////////
        private void RGB_R_Scroll(object sender, EventArgs e)
        {
            LIGHTNESS.Value = 0;
            CONTRAST.Value = 50;
            RGB_G.Value = 0;
            RGB_B.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.RED, RGB_R.Value, currentImage);

        }
        private void RGB_R_label_Click(object sender, EventArgs e)
        {
            HBF.RGB_RList.Add(RGB_R.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_R);

            RGB_R.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.RED, RGB_R.Value, currentImage);
        }



        private void RGB_G_Scroll(object sender, EventArgs e)
        {
            LIGHTNESS.Value = 0;
            CONTRAST.Value = 50;
            RGB_R.Value = 0;
            RGB_B.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.GREEN, RGB_G.Value, currentImage);

        }
        private void RGB_G_label_Click(object sender, EventArgs e)
        {
            HBF.RGB_RList.Add(RGB_G.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_G);

            RGB_G.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.GREEN, RGB_G.Value, currentImage);
        }


        private void RGB_B_Scroll(object sender, EventArgs e)
        {
            LIGHTNESS.Value = 0;
            CONTRAST.Value = 50;
            RGB_R.Value = 0;
            RGB_G.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.BLUE, RGB_B.Value, currentImage);

        }
        private void RGB_B_label_Click(object sender, EventArgs e)
        {
            HBF.RGB_RList.Add(RGB_B.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_B);

            RGB_B.Value = 0;
            pictureBox1.Image = PC.Picture_change_operate(PictureChange.CHANGE_TYPE.BLUE, RGB_B.Value, currentImage);
        }


        ////////////////////////////////////更换操作图像////////////////////////////////////
        private void IMAGE_MEMORY1_DoubleClick(object sender, EventArgs e)
        {
            HBF.historyList.Add(HISTORY_TYPE.Main_picture);
            HBF.Main_picture.Add(currentImage);

            IMAGE_MEMORY_MAIN.Image = IMAGE_MEMORY1.Image;
            currentImage = IMAGE_MEMORY1.Image;
        }
        private void IMAGE_MEMORY2_DoubleClick(object sender, EventArgs e)
        {
            HBF.historyList.Add(HISTORY_TYPE.Main_picture);
            HBF.Main_picture.Add(currentImage);

            IMAGE_MEMORY_MAIN.Image = IMAGE_MEMORY2.Image;
            currentImage = IMAGE_MEMORY2.Image;
        }
        private void IMAGE_MEMORY3_DoubleClick(object sender, EventArgs e)
        {
            HBF.historyList.Add(HISTORY_TYPE.Main_picture);
            HBF.Main_picture.Add(currentImage);

            IMAGE_MEMORY_MAIN.Image = IMAGE_MEMORY3.Image;
            currentImage = IMAGE_MEMORY3.Image;
        }
        private void IMAGE_MEMORY4_DoubleClick(object sender, EventArgs e)
        {
            HBF.historyList.Add(HISTORY_TYPE.Main_picture);
            HBF.Main_picture.Add(currentImage);

            IMAGE_MEMORY_MAIN.Image = IMAGE_MEMORY4.Image;
            currentImage = IMAGE_MEMORY4.Image;
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            HBF.historyList.Add(HISTORY_TYPE.Main_picture);
            HBF.Main_picture.Add(currentImage);

            Image image = GSS.CaptureScreen(Location.X + pictureBox1.Location.X, Location.Y + pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            IMAGE_MEMORY_MAIN.Image = image;
            currentImage = image;
        }


        ////////////////////////////////////屏幕截图////////////////////////////////////
        private void SCREEN_SHOT_Click(object sender, EventArgs e)
        {
            Image image = GSS.CaptureScreen(Location.X + pictureBox1.Location.X, Location.Y + pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);

            if (IMAGE_MEMORY3 != null)
            {
                IMAGE_MEMORY4.Image = IMAGE_MEMORY3.Image;
            }
            if (IMAGE_MEMORY2 != null)
            {
                IMAGE_MEMORY3.Image = IMAGE_MEMORY2.Image;
            }
            if (IMAGE_MEMORY1 != null)
            {
                IMAGE_MEMORY2.Image = IMAGE_MEMORY1.Image;
            }

            IMAGE_MEMORY1.Image = image;
        }

        ///////////////////////////////////截图框点击操作////////////////////////////////
        private void IMAGE_MEMORY1_Click(object sender, EventArgs e)
        {
            SE.ScreenChangeOperation(IMAGE_MEMORY1, pictureBox1);
        }
        private void IMAGE_MEMORY2_Click(object sender, EventArgs e)
        {
            SE.ScreenChangeOperation(IMAGE_MEMORY2, pictureBox1);
        }
        private void IMAGE_MEMORY3_Click(object sender, EventArgs e)
        {
            SE.ScreenChangeOperation(IMAGE_MEMORY3, pictureBox1);
        }
        private void IMAGE_MEMORY4_Click(object sender, EventArgs e)
        {
            SE.ScreenChangeOperation(IMAGE_MEMORY4, pictureBox1);
        }
        private void IMAGE_MEMORY_MAIN_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IMAGE_MEMORY_MAIN.Image;
        }


        /////////////////////////////////撤回操作/////////////////////////////////
        private void OPERATE_DELETE_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (HBF.historyList.Count() == 0)
            {
                textBox1.Clear();
                textBox1.Text = "已无上一步骤！";
                return;
            }
            HISTORY_TYPE backlist = new HISTORY_TYPE();
            backlist = HBF.historyList[HBF.historyList.Count() - 1];
            switch (backlist)
            {
                case HISTORY_TYPE.lightness:
                    {
                        HBF.Lightness_History(pictureBox1, LIGHTNESS, currentImage);
                        break;
                    }
                case HISTORY_TYPE.contract:
                    {
                        HBF.Contract_History(pictureBox1, CONTRAST, currentImage);
                        break;
                    }
                case HISTORY_TYPE.RGB_R:
                    {
                        HBF.RGB_R_History(pictureBox1, RGB_R, currentImage);
                        break;
                    }
                case HISTORY_TYPE.RGB_G:
                    {
                        HBF.RGB_G_History(pictureBox1, RGB_G, currentImage);
                        break;
                    }
                case HISTORY_TYPE.RGB_B:
                    {
                        HBF.RGB_B_History(pictureBox1, RGB_B, currentImage);
                        break;
                    }
                case HISTORY_TYPE.Main_picture:
                    {
                        HBF.MainPicture_history(IMAGE_MEMORY_MAIN);
                        currentImage = IMAGE_MEMORY_MAIN.Image;
                        return;
                    }
            }
        }
        private void LIGHTNESS_MouseDown(object sender, MouseEventArgs e)
        {
            HBF.lightnessList.Add(LIGHTNESS.Value);
            HBF.historyList.Add(HISTORY_TYPE.lightness);
        }

        private void CONTRAST_MouseDown(object sender, MouseEventArgs e)
        {
            HBF.contractList.Add(CONTRAST.Value);
            HBF.historyList.Add(HISTORY_TYPE.contract);
        }

        private void RGB_R_MouseDown(object sender, MouseEventArgs e)
        {
            HBF.RGB_RList.Add(RGB_R.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_R);
        }

        private void RGB_G_MouseDown(object sender, MouseEventArgs e)
        {
            HBF.RGB_GList.Add(RGB_G.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_G);
        }

        private void RGB_B_MouseDown(object sender, MouseEventArgs e)
        {
            HBF.RGB_BList.Add(RGB_B.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_B);
        }

        private void LIGHTNESS_MouseUp(object sender, MouseEventArgs e)
        {
            HBF.lightnessList.Add(LIGHTNESS.Value);
            HBF.historyList.Add(HISTORY_TYPE.lightness);
        }

        private void CONTRAST_MouseUp(object sender, MouseEventArgs e)
        {
            HBF.contractList.Add(CONTRAST.Value);
            HBF.historyList.Add(HISTORY_TYPE.contract);
        }

        private void RGB_R_MouseUp(object sender, MouseEventArgs e)
        {
            HBF.RGB_RList.Add(RGB_R.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_R);
        }

        private void RGB_G_MouseUp(object sender, MouseEventArgs e)
        {
            HBF.RGB_GList.Add(RGB_G.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_G);
        }

        private void RGB_B_MouseUp(object sender, MouseEventArgs e)
        {
            HBF.RGB_BList.Add(RGB_B.Value);
            HBF.historyList.Add(HISTORY_TYPE.RGB_B);
        }
    }
}
