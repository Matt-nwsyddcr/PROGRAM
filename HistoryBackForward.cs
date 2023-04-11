using Picture_Change;

namespace History_Back_Forward
{

    public enum HISTORY_TYPE
    {
        lightness , contract, RGB_R , RGB_G , RGB_B , Main_picture
    }
    internal class HistoryBackForward
    {
        PictureChange SC = new PictureChange();
        public List<HISTORY_TYPE> historyList = new List<HISTORY_TYPE>();

        public List<int> lightnessList = new List<int>();
        public List<int> contractList = new List<int>();
        public List<int> RGB_RList = new List<int>();
        public List<int> RGB_GList = new List<int>();
        public List<int> RGB_BList = new List<int>();
        public List<Image> Main_picture = new List<Image>();


        public void Lightness_History(PictureBox box1,TrackBar LIGHTNESS, Image currentImage)
        {
            box1.Image = SC.Picture_change_operate(PictureChange.CHANGE_TYPE.LIGHT, lightnessList[lightnessList.Count() - 1], currentImage);
            LIGHTNESS.Value = lightnessList[lightnessList.Count() - 1];
            lightnessList.RemoveAt(lightnessList.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }

        public void Contract_History(PictureBox box1, TrackBar CONTRAST, Image currentImage)
        {
            box1.Image = SC.Picture_change_operate(PictureChange.CHANGE_TYPE.CONTRAST, contractList[contractList.Count() - 1], currentImage);
            CONTRAST.Value = contractList[contractList.Count() - 1];
            contractList.RemoveAt(contractList.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }

        public void RGB_R_History(PictureBox box1, TrackBar RGB_R, Image currentImage)
        {
            box1.Image = SC.Picture_change_operate(PictureChange.CHANGE_TYPE.RED, RGB_RList[RGB_RList.Count() - 1], currentImage);
            RGB_R.Value = RGB_RList[RGB_RList.Count() - 1];
            RGB_RList.RemoveAt(RGB_RList.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }

        public void RGB_G_History(PictureBox box1, TrackBar RGB_G, Image currentImage)
        {
            box1.Image = SC.Picture_change_operate(PictureChange.CHANGE_TYPE.GREEN, RGB_GList[RGB_GList.Count() - 1], currentImage);
            RGB_G.Value = RGB_GList[RGB_GList.Count() - 1];
            RGB_GList.RemoveAt(RGB_GList.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }

        public void RGB_B_History(PictureBox box1, TrackBar RGB_B, Image currentImage)
        {
            box1.Image = SC.Picture_change_operate(PictureChange.CHANGE_TYPE.BLUE, RGB_BList[RGB_BList.Count() - 1], currentImage);
            RGB_B.Value = RGB_BList[RGB_BList.Count() - 1];
            RGB_BList.RemoveAt(RGB_BList.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }

        public void MainPicture_history(PictureBox box)
        {
            box.Image = Main_picture[Main_picture.Count() - 1];
            Main_picture.RemoveAt(Main_picture.Count() - 1);
            historyList.RemoveAt(historyList.Count() - 1);
        }
    }
}
