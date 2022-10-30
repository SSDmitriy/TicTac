using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class MainLayout : Form
    {

        //чей ход
        bool xTurn = true;
        public MainLayout()
        {
            InitializeComponent();
        }

      

        private void Button_Click(object sender, EventArgs e)
        {
            Button senderBu = (Button)sender;

            if (xTurn)
            {

                senderBu.Text = "X";
            }
            else
            {
                senderBu.Text = "O";
            }

            //переход хода
            xTurn = !xTurn;

            //дизейблим нажатую кнопку
            senderBu.Enabled = false;

            //проверяем победу
            //CheckWin(senderBu.Text);

        }
    }
}
