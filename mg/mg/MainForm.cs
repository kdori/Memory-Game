using mgMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mg
{
    public partial class MainForm : Form
    {
        private void Start()
        {

            (new MemoryGame(PlayGround, 4, 6, imageList))
            .OnFinished(success =>    
            {
                MessageBox.Show(success ? "Nyertél" : "Vesztettél", "Vége");
            });
        }
        public MainForm()
        {
            InitializeComponent();
            Start();
        }

       
    }
}
