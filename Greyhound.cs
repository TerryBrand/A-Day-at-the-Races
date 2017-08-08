using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            // Move forward either 1, 2, 3, or 4 spaces at random
            // Update the position of my PictureBox on the form like this:
            //   MyPicturePox.Left = StartingPosition + Location;
            // Return true if I won the race
            Location = Randomizer.Next(1, 4);
            MyPictureBox.Left += Location;
            if (MyPictureBox.Left >= RacetrackLength)
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            // Reset my location to 0 and my PictureBox to starting Position
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
