using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mgMVC
{
    class MemoryGame
    {
        //h = height, w = width
        private Grid grid;
        
        public MemoryGame(Control target, int h, int w, ImageList pic)
        {
            int cards = h * w;
            int pairs = cards / 2;

            int[,] playCards = new int[cards, 3]; //x,y,index
            int[,] choosePic = new int[pairs, 2]; //index, teszt;
            int[] rndCard = new int[pairs]; //index
            Random rnd = new Random();

            for (int i = 0; i < pairs; i++)
            {
                int r = rnd.Next(40);
                if(!rndCard.Contains(r))
                {
                    rndCard[i] = r;
                }    
            }

            //itt kellene lennie annak ami kiosztja a kártyákat
            for (int i = 0; i < pairs; i++)
            {
                choosePic[i,0] = rndCard[i];
            }
            


          grid = new Grid(target, h, w, pic);


            grid.OnCellClick((x,y) => grid.OpenCell(x, y, rnd.Next(cards)));
           

        }

        public void OnFinished(Action<bool> method)
        {

        }
    }
}
