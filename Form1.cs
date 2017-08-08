using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Greyhound[] Greyhounds = new Greyhound[4];
        Guy[] Guys = new Guy[3];
        public Random MyRandomizer = new Random();
        Guy Bettor;

        public Form1()
        {
            InitializeComponent();
            InitializeGreyhounds();
            InitializeGuys();
            minimumBetLabel.Text = "Minimum Bet: " + numericUpDown1.Minimum + " bucks";
        }

        private void InitializeGreyhounds()
        {

            Greyhounds[0] = new Greyhound()
            {
                MyPictureBox = greyhoundPictureBox1,
                StartingPosition = greyhoundPictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox1.Width,
                Randomizer = MyRandomizer
            };

            Greyhounds[1] = new Greyhound()
            {
                MyPictureBox = greyhoundPictureBox2,
                StartingPosition = greyhoundPictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox2.Width,
                Randomizer = MyRandomizer
            };

            Greyhounds[2] = new Greyhound()
            {
                MyPictureBox = greyhoundPictureBox3,
                StartingPosition = greyhoundPictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox3.Width,
                Randomizer = MyRandomizer
            };

            Greyhounds[3] = new Greyhound()
            {
                MyPictureBox = greyhoundPictureBox4,
                StartingPosition = greyhoundPictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox4.Width,
                Randomizer = MyRandomizer
            };

        }

        private void InitializeGuys()
        {
            Guys[0] = new Guy()
            {
                Name = "Joe",
                MyBet = null,
                Cash = 50,
                MyRadioButton = radioButton1,
                MyLabel = betLabel1
            };

            Guys[0].UpdateLabel();

            Guys[1] = new Guy()
            {
                Name = "Bob",
                MyBet = null,
                Cash = 75,
                MyRadioButton = radioButton2,
                MyLabel = betLabel2
            };

            Guys[1].UpdateLabel();

            Guys[2] = new Guy()
            {
                Name = "Al",
                MyBet = null,
                Cash = 45,
                MyRadioButton = radioButton3,
                MyLabel = betLabel3
            };

            Guys[2].UpdateLabel();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls(0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls(2);
        }

        private void UpdateControls(int index)
        {
            Bettor = Guys[index];
            name.Text = Bettor.Name;
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;

        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            int betAmount = (int) numericUpDown1.Value;
            int dogNumber = (int) numericUpDown2.Value;
            if (Bettor.PlaceBet(betAmount, dogNumber) == false)
            {
                Bettor.MyLabel.Text = "Could not place bet";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int winner = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Greyhounds[i].Run() == true)
                {
                    timer1.Stop();
                    winner = i + 1;
                    MessageBox.Show("Greyhound #" + winner + " is the winner");
                    for (int x= 0; x < 3; x++)
                    {
                        Guys[x].Collect(winner);
                    }
                    for (int x= 0; x < 4; x++)
                    {
                        Greyhounds[x].TakeStartingPosition();
                    }
                }
            }
        }
    }
}
