using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tetris.Properties;

namespace Tetris {

    /// <summary>It indicates the type of piece for Tetris</summary>
    enum PieceType {

        //[*][*][*][*]   
        I,

        //[*][*]
        //[*][*] 
        O,

        //[*][*] 
        //   [*]
        //   [*]
        L,

        //[*][*]
        //[*]
        //[*]
        J,

        //[*]
        //[*][*]
        //[*] 
        T,
     
        //   [*]
        //[*][*]
        //[*]       
        Z,

        //[*]
        //[*][*]
        //   [*] 
        S
    }

    /// <summary>It indicates if the square of a game board is full or not</summary>
    enum Occuped {
        Yes,
        No
    }
}