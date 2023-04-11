namespace Get_Screen_Show
{
    internal class GetScreenShow
    {
        //以电脑屏幕为基准
        public Image CaptureScreen(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x, y, 0, 0, bmp.Size);
            }
            return bmp;
        }
    }
}
