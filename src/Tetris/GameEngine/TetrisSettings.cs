using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;

namespace Tetris {
    /// <summary>Manage tetris settings </summary>
    class TetrisSettings {


        //************************************Inteface******************************************************

        /// <summary>Color of the title interface</summary>
        public static Color TitleColor { get; set; }

        /// <summary>Color of the text in interface</summary>
        public static Color TextColor { get; set; }
        

        /// <summary>Background color of the game form</summary>
        public static Color FormBackgroundColor { get; set; }


        /// <summary>Background color of the picturebox</summary>
        public static Color PictureBoxBackgroundColor{ get; set; }

        /// <summary>Border color of the game board</summary>
        public static Color TetrisBorderColor{ get; set; }

       //**********************************Piece image******************************************************
        /// <summary>It indicates the source of the image that makes the piece</summary>
        public enum SingleImageSource {
            Resources,
            File
        }

        /// <summary>It indicates the source of the image that makes the piece</summary>
        public static SingleImageSource SourceImage { get; set; }

        /// <summary>Souce path for the image that make the piece</summary>
        public static string SingleImage { get; set; }
    }
}
