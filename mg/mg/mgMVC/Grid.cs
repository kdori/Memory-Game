using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mgMVC
{
    class Grid
    {
        private Button[,] grid;
        private ImageList images;
        private Action<int, int> clickAction;
        public int s = 0;
        public Grid(Control parent, int h, int w, ImageList pic)
        {
            CreatGrid(parent, h, w);
            CreatImageList(pic);
        }

        private void CreatImageList(ImageList pic)
        {
            images = pic;
        }

        public void OnCellClick(Action<int,int> method)
        {
            clickAction = method;
        }

        public void OpenCell(int x, int y, int value)
        {
            
            s++;
            grid[x, y].BackColor = Color.White;
            grid[x, y].ImageIndex = value;
            grid[x, y].ImageList = images;
            grid[x, y].Enabled = false;
            if(s>0 && s%2==0)
            {
                grid[x, y].ImageList = null;
                grid[x, y].BackColor = Color.Salmon;

            }
            

        }
        
       
        public int click;
        private void CreatGrid(Control parent, int h, int w)
        {
            grid = new Button[w, h];
            int height = parent.Height / h;
            int width = Convert.ToInt32(Math.Ceiling(height * 0.674));

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    grid[i, j] = new Button();

                    grid[i, j].Width = width;
                    grid[i, j].Height = height;
                    grid[i, j].Left = i * width;
                    grid[i, j].Top = j * height;
                    grid[i, j].TabStop = false;

                    parent.Controls.Add(grid[i, j]);

                    grid[i, j].Click += CellOpened;
                    
                    
                }
            }
        }

        private void CellOpened(object sender, EventArgs e)
        {
            if(clickAction != null)
            {
                Button btn = sender as Button;
                int x = btn.Left / btn.Width;
                int y = btn.Top / btn.Height;
                
                
                clickAction(x, y);

            }
           

           
        }
    }
}
