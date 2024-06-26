using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Toc_Tak_Orignal.Properties;

namespace Tic_Toc_Tak_Orignal
{
    public partial class Form1 : Form
    {

        enPlayerTurn PlayerTurn;
         stGameStatus GameStatus;
        

       enum enPlayerTurn
        {
            Player1, Player2
        }
        enum enWinner
        {
            Player1,Player2,Drow,Inprogress
        }
         struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short GameCount;
        }


        void EndGame()
        {

            lblPlayerTurn.Text = "Game Over";

            switch(GameStatus.Winner)
            {

                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;
                case enWinner.Drow:
                    lblWinner.Text = "Drow";
                    break;


            }



        }

       public bool  CheckValues(Button btn1,Button btn2,Button btn3)
        {

          

            if (btn1.Tag.ToString()!="?"&&btn1.Tag.ToString()==btn2.Tag.ToString()&&btn1.Tag.ToString()==btn3.Tag.ToString())
            {  
                  btn1.BackColor = Color.GreenYellow;
                  btn2.BackColor = Color.GreenYellow;
                  btn3.BackColor = Color.GreenYellow;


                if(btn1.Tag.ToString()=="X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
              

            }


           GameStatus.GameOver = false;
                return false;
        }
        public void CheckWinner()
        {

            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button4, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

            

        }





        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString()=="?")
            {

                switch(PlayerTurn)
                {

                    case enPlayerTurn.Player1:
                        btn.Image = Resources.X;
                        btn.Tag = "X";
                        PlayerTurn = enPlayerTurn.Player2;
                        lblPlayerTurn.Text = "Player2";
                        GameStatus.GameCount++;
                        CheckWinner();

                        break;
                        case enPlayerTurn.Player2:

                        btn .Image = Resources.O;
                        btn .Tag = "O";
                        PlayerTurn = enPlayerTurn.Player1;
                        lblPlayerTurn.Text = "Player1";
                        GameStatus.GameCount++;
                        CheckWinner();
                        break;







                }


            }else
            {
                MessageBox.Show("Wrong Choise", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(GameStatus.GameCount==9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Drow;
                EndGame();
            }
        }

        void RestartButtons(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

      



















        public Form1()
        {
            InitializeComponent();
        }












      

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartButtons(button1);
            RestartButtons(button2);
            RestartButtons(button3);
            RestartButtons(button4);
            RestartButtons(button5);
            RestartButtons(button6);
            RestartButtons(button7);
            RestartButtons(button8);
            RestartButtons(button9);




            lblPlayerTurn.Text = "Player1";
            lblWinner.Text = "InPrograss";


            PlayerTurn = enPlayerTurn.Player1;
            GameStatus.GameCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.Inprogress;





        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
