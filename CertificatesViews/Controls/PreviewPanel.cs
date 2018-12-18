using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CertificatesViews.Interfaces;
using CertificatesModel;

namespace CertificatesViews.Controls
{
    public partial class PreviewPanel : UserControl, IView<Pages>
    {
        public PreviewPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(Pages pages)
        {
            // Очищаем пикбоксы предыдущего запроса 
            List<PictureBox> removePicBoxes = new List<PictureBox>();

            foreach (Control pb in panPages.Controls)
            {
                if (pb.Name == "")
                    removePicBoxes.Add(pb as PictureBox);
            }
            foreach (PictureBox pb in removePicBoxes)
            {
                panPages.Controls.Remove(pb);
                pb.Dispose();
            }

            // Создаем пикбоксы для вывода списка полученных изображений
            int x = 0, y = 0, panWidth = panPages.Width, panHeight = panPages.Height;
            if (pages != null) // Если список изображений пуст, то выходим из метода
            {
                foreach (Image pic in pages)
                {
                    PictureBox pb = new PictureBox()
                    {
                        Location = new Point(x, y),
                        Width = panWidth,
                        Height = panHeight,
                        Image = pic,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                    };
                    panPages.Controls.Add(pb);
                    y += pb.Height;
                }
            }
        }
    }
}
