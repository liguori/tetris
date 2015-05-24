using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tetris {
    class Scores {
        const string FILE_HEADER = "[Scores]";

        /// <summary>The relative path to the file score.txt</summary>
        static string Path = Application.StartupPath + @"\data\score.txt";

        /// <summary>It indicates the maximum number of scores to be treated</summary>
        const int N_MAX_SCORE = 10;

        static Score[] score = new Score[N_MAX_SCORE];
        public static Score[] CurrentScores {
            get { return score; }
            set { score = value; }
        }

        /// <summary>The data structure containing the information on scores</summary>
        public struct Score {
            /// <summary>Player name</summary>
            public string PlayerName;
            /// <summary>The score performed by the player</summary>
            public string Value;
            /// <summary>Return the string containing the name and score on a row</summary>
            public string StringaPerFile() {
                return PlayerName + "|" + Value;
            }
        }

        static int scoreCount = -1;
        /// <summary>Contains the number of the scores stored in the class</summary>
        public static int ScoreCount {
            get { return scoreCount; }
            set { scoreCount = value; }
        }

        //Load scores from the class file
        public static void LoadScores() {
            scoreCount = -1;
            if (File.Exists(Path) == false) {
                ResetScores();
            } else {
                TextReader F = File.OpenText(Path);
                if (F.ReadLine() == FILE_HEADER)
                {
                    string acquistion = F.ReadLine();
                    while (acquistion != null) {
                        scoreCount++;
                        string[] temp = acquistion.Split('|');
                        acquistion = F.ReadLine();
                        CurrentScores[scoreCount].PlayerName = temp[0];
                        CurrentScores[scoreCount].Value = temp[1];
                    }

                } else {
                    F.Close();
                    ResetScores();                    
                }
                F.Close();             
            }
        }

        /// <summary>Save the scores in the file</summary>
        public static void ScoreSave() {
            TextWriter F = File.CreateText(Path);
            F.WriteLine(FILE_HEADER);
            for (int i = 0; i <= scoreCount; i++) {
                F.WriteLine(CurrentScores[i].PlayerName + "|" + CurrentScores[i].Value);
            }
            F.Close();
        }

        /// <summary>Delete all the scores saved on file by creating a new file instead of the old</summary>
        public static void ResetScores() {
            TextWriter F = File.CreateText(Path);
            F.WriteLine(FILE_HEADER);
            F.Close();
            LoadScores();
        }

        /// <summary>Displays a message asking the user name and controls the insertion</summary>
        private static string AskName() {
            string playerName;
            do {
                playerName = Microsoft.VisualBasic.Interaction.InputBox("Insert your name", "Save score", "Insert your name here", 512, 385);
                if (playerName.Trim() == "") MessageBox.Show("Insert your name");
            } while (playerName.Trim() == "");
            return playerName;
        }

        /// <summary>Check if there is space for the insertion of a new score</summary>
        /// <param name="Punteggio">Player score</param>
        public static void CheckIfSaveScore(int Punt) {
            if (scoreCount == -1) {
                scoreCount++;
                CurrentScores[0].PlayerName = AskName();
                CurrentScores[0].Value = Punt.ToString();
                ScoreSave();
            } else {              
                for (int i = 0; i <= scoreCount; i++) {
                    if (Punt > int.Parse(CurrentScores[i].Value))
                    {
                        int inizio = scoreCount + 1;
                        if (inizio == N_MAX_SCORE) inizio--;
                        for (int k = inizio; k >= i + 1; k--) {
                            CurrentScores[k] = CurrentScores[k - 1];
                        }
                        scoreCount++;
                        CurrentScores[i].PlayerName = AskName();
                        CurrentScores[i].Value = Punt.ToString();
                        ScoreSave();
                        break;
                    } else if (i == scoreCount && scoreCount < N_MAX_SCORE - 1) {
                        scoreCount++;
                        CurrentScores[scoreCount].PlayerName = AskName();
                        CurrentScores[scoreCount].Value = Punt.ToString();
                        ScoreSave();
                        break;
                    }                   
                }
            }
        }
    }
}