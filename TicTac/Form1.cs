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
        bool xTurn;

        public bool isTurnEnd = false;
        public bool isGameStarted = false;



        public MainLayout()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, EventArgs e)
        {
            isGameStarted = true;

            //отключить радиобаттоны выбора первого хода
            OwillNext.Enabled = false;
            XwillNext.Enabled = false;

            Button senderBu = (Button)sender;

            if (xTurn)
            {
                senderBu.Text = "X";
            }
            else
            {
                senderBu.Text = "O";
            }

            //перекрасить кнопку
            paintButton(senderBu);


            //дизейблим нажатую кнопку
            senderBu.Enabled = false;

            //переход хода
            xTurn = !xTurn;

            isTurnEnd = true;

            //проверяем победу
            CheckWin(senderBu.Text);

            //проверяем ничью
            CheckDraw();

        }




        //есть ли на поле выйгрышная ситуация
        void CheckWin(string whoLastTurn)
        {
            if (
                //проверка горизонталей на одиаковый текст
                (button1.Text == button2.Text && button2.Text == button3.Text && button1.Enabled == false)
                || (button4.Text == button5.Text && button5.Text == button6.Text && button4.Enabled == false)
                  || (button7.Text == button8.Text && button8.Text == button9.Text && button7.Enabled == false)

                //вертикали
                || (button1.Text == button4.Text && button4.Text == button7.Text && button1.Enabled == false)
                  || (button2.Text == button5.Text && button5.Text == button8.Text && button2.Enabled == false)
                    || (button3.Text == button6.Text && button6.Text == button9.Text && button3.Enabled == false)

                //диагонали    
                || (button1.Text == button5.Text && button5.Text == button9.Text && button1.Enabled == false)
                  || (button3.Text == button5.Text && button5.Text == button7.Text && button3.Enabled == false)
               )
            {
               //MessageBox.Show("УРРРЯЯ! Выйграли " + whoLastTurn);
                MessageBox.Show($"   УРРРЯЯ!\n Выйграли {whoLastTurn}", "Победа!", MessageBoxButtons.OK);
                Application.Restart();
            }
        }

        //Если все кнопки уже прокликаны, то ничья
        void CheckDraw()
        {
            if (
                button1.Enabled == false
                    && button2.Enabled == false
                    && button3.Enabled == false
                    && button4.Enabled == false
                    && button5.Enabled == false
                    && button6.Enabled == false
                    && button7.Enabled == false
                    && button8.Enabled == false
                    && button9.Enabled == false
                )
            {
                MessageBox.Show("O_x НИЧЬЯ! x_O");
                Application.Restart();
            }
        }

        //начинают нолики (если тыцкнули радиобаттон)
        private void OwillNext_CheckedChanged(object sender, EventArgs e)
        {
            if (!isGameStarted)
            {
                xTurn = false;
            }

        }

        //или крестики
        private void XwillNext_CheckedChanged(object sender, EventArgs e)
        {
            if (!isGameStarted)
            {
                xTurn = true;
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void paintButton(Button button)
        {
            if (xTurn)
            {
                button.BackColor = Color.Magenta;
            }
            else
            {
                button.BackColor = Color.Yellow;
            }
        }
    }
}



