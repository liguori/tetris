using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tetris.Properties;
using System.Drawing;

namespace Tetris {
    /// <summary>This class contains all the information on a little square of the game</summary>
    class Square {

        public Square(){
            this.P = new PictureBox();
            this.IsOccuped = Occuped.No;            
        }

        private PictureBox p;
        /// <summary>The picturebox representing a square of the game</summary>
        public PictureBox P {
            get { return p; }
            set { p = value; }          
        }

        private Occuped isOccuped;
        /// <summary>It indicates if in a square that composes the interface is a part of the blocks</summary>
        public Occuped IsOccuped {
            get { return isOccuped; }            
            set { 
                isOccuped = value;
                if (value == Occuped.Yes) {
                    if (TetrisSettings.SourceImage == TetrisSettings.SingleImageSource.File)
                        this.P.Image = Image.FromFile(TetrisSettings.SingleImage);
                    else
                        this.P.Image = Resources.block;                                       
                } else {
                    this.p.Image = null;
                }
            }
        }

    }
}
