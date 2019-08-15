// -----------------------------------------------------------------------------
// *** FILE ***
// Name:          MMMasterBB.cs
// Creator:       Blair Betts
// Creation Date: 2019-08-08
// 
// *** OVERVIEW ***
// MMMaster Implementation.     
// Student: Blair Betts
//		
// *** DEFINITIONS WITHIN THIS FILE ***
// CLASS:			MMMasterBB
// INTERFACES:		IMMMaster
// DELEGATES:		<none>
// -----------------------------------------------------------------------------

// *********************************************************************
// -------------------        REFERENCES       -------------------------
// *********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using SportsMEDIA.Gemini.MasterMindSharp.MMLib;

namespace SportsMEDIA.Gemini.MasterMindSharp.BB
{
    /// ------------------------------------------------------------------------
    /// <summary>
    /// [public Class] MMMasterBB is an implementation of the "Master" role in
    /// a game of MasterMind.
    /// </summary>
    /// 
    /// <remarks>
    /// </remarks>
    /// ------------------------------------------------------------------------
    [ProgId("SportsMEDIA.MMMasterBB")]

    public class MMMasterBB : IMMMaster
    {
        enum ColorEnum { empty,white, yellow, green, blue, black, red, brown, orange, purple, beige, pink };
        enum GuessFeedbackEnum {none,white,black};
        // max number of guesses a user can have in a given game
        int maxGuesses = 12;
        // the max number of pegs that can be in a solution
        int maxSolutionSpots = 5;
        // the colors avaliable
        string[] colors =  {"White", "Yellow", "Green", "Blue", "Black", "Red", "Brown", "Orange", "Purple", "Beige", "Pink" };
        // empty array to be able to set the pge colors
        string[] setPegColor;
        string[] guessFeedback =  { "None", "White", "Black" };
        // is the createSolution method called
        bool createSolutionCalled = false;
        // empty string to set the solutions too
        string solutions;
        string userGuess;
        string userFeedBack;
        ArrayList userGuesses = new ArrayList();
        ArrayList guessFeedbackArray = new ArrayList();
        int whatTurn = 0;
        // -------- PUBLIC -------- //

        // *********************************************************************
        // -------------------         EVENTS          -------------------------
        // *********************************************************************

        // *********************************************************************
        // -------------------        CONSTANTS        -------------------------
        // *********************************************************************

        // *********************************************************************
        // -------------------       PROPERTIES        -------------------------
        // *********************************************************************

        // *********************************************************************
        // -------------------         METHODS         -------------------------
        // *********************************************************************


        /// --------------------------------------------------------------------
        /// <summary>
        /// [public Method] Constructor.
        /// </summary>
        /// -
        /// <remarks>
        /// </remarks>
        /// "White"
        ///	"Yellow"
        ///	"Green"
        ///	"Blue"
        ///	"Black"
        ///	"Red"
        ///	"Brown"
        ///	"Orange"
        ///	"Purple"
        ///	"Beige"
        ///	"Pink"
        /// --------------------------------------------------------------------
        public MMMasterBB()
        {
        }

        /// --------------------------------------------------------------------
        /// <summary>
        /// [private Method] Destructor.
        /// </summary>
        /// -
        /// <remarks>
        /// </remarks>
        /// --------------------------------------------------------------------
        ~MMMasterBB()
        {
        }


        /// --------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Begin a new game.  
        /// </summary>
        /// 
        /// <returns>
        /// void
        /// </returns>
        /// 
        /// <remarks>
        ///
        /// All internal data structures should be reset appropriately.
        ///
        /// </remarks>
        /// --------------------------------------------------------------------
        public void BeginGame()
        {
            
            for (int i = 0; i < maxSolutionSpots; i++)
            {
                ArrayList userGuessSlots = new ArrayList();
                ArrayList userFeedbackSlots = new ArrayList();

                for (int j = 0; j < maxGuesses; j++)
                {
                    userGuessSlots.Add(ColorEnum.empty);
                    userFeedbackSlots.Add(GuessFeedbackEnum.none);
                }
                userGuesses.Add(userGuessSlots);
                guessFeedbackArray.Add(userFeedbackSlots);
            }
            SetMaxTurns();
            whatTurn = 1;
        }


        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Create a solution pattern using the valid set 
        /// of pattern peg colors.
        /// </summary>
        /// 
        /// <returns>
        /// If successful in creating the solution, return the solution pattern, 
        /// otherwise, return the string "ERROR".
        /// </returns>
        /// 
        /// <remarks>
        /// The result should be in standard delimited form, using standard color
        /// string values (see "SetPatternPegColors()" below for valid color strings).  
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string CreateSolution()
        {

            Random random = new Random();
            string ret = "ERROR";
            // if a valid turn has been taken
            if (whatTurn == 1)
            {
                ret = "";
                // loop through the colors array and create a random solution
                for (int i = 0; i < maxSolutionSpots; i++)
                {
                    int index =  random.Next(1,11);
                    ret = ret + colors[index];
                    if (i < maxSolutionSpots - 1)
                    {
                        ret = ret + "|";

                    }
                    solutions = ret;
                }
                
            }
            createSolutionCalled = true;
            return ret;
        }


        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Get the feedback that was associated with Turn. This 
        /// function should, at a minimum, check for a valid Turn number within the 
        /// context of the current game, before returning this feedback.
        /// </summary>
        /// 
        /// <returns>
        /// If successful in determining the feedback, return the feedback string
        /// in standard delimited form.  Otherwise, return the string "ERROR".
        /// </returns>
        /// 
        /// <remarks>
        /// The existence of this function implies that the underlying data
        /// structures will store a history of feedback throughout the game.
        /// The feedback delimited string will consist of clue peg color values 
        /// coming from the set:
        ///
        ///	"Black" (color is correct, AND in the correct location)
        ///	"White" (color is correct, but in the incorrect location) 
        ///	"None"  (empty slot)
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string GetFeedback(int Turn)
        {

            string ret = "ERROR";
            
            if(whatTurn > 1 && Turn >0)
            {
                ret = userFeedBack;
            }

            return ret;
        }


        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Get the current solution pattern.
        /// </summary>
        /// 
        /// <returns>
        /// If successful in determining the solution, return the solution string
        /// in standard delimited form.  Otherwise, return the string
        /// "ERROR".
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string GetSolution()
        {

            string ret = "ERROR";
            {
                ret = solutions;
            }

            return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Set the peg colors which are valid for the game (default colors
        /// are "White", "Yellow", "Green", "Blue", "Black", "Red", "Brown" 
        /// and "Orange").
        /// </summary>
        /// 
        /// <returns>
        /// Return TRUE if the colors were successfully set, FALSE otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// The peg colors will be specified in standard delimited form
        /// and will consist of values from the following color set:
        ///
        ///	"White"
        ///	"Yellow"
        ///	"Green"
        ///	"Blue"
        ///	"Black"
        ///	"Red"
        ///	"Brown"
        ///	"Orange"
        ///	"Purple"
        ///	"Beige"
        ///	"Pink"
        ///
        /// This function should fail if a game has already begun (at least
        /// one valid turn has been taken).
        /// </remarks>
        /// ---------------------------------------------------------------------
        public bool SetPatternPegColors(string PegColors)
        {
            bool ret = false;
            // if a valid turn has been taken and the peg color string is not empty
            if (whatTurn == 1 && PegColors != "") 
            {
                setPegColor = PegColors.Split('|');
                ret = true;
                // see if the colors from the PegColors string is in the colors array
                for (int i = 0; i <setPegColor.Length; i++)
                {
                    int checkColors = Array.IndexOf(colors,setPegColor[i]);
                    if (checkColors == -1)
                    {
                        ret = false;
                    }
                }
                
            }

            return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Set the maximum number of turns allowed for 
        /// guessing within the game (default = 12).
        /// </summary>
        /// 
        /// <returns>
        /// Return TRUE if the value was successfully set, FALSE otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// One may assume that the specified value will be no more than 16.  If this
        /// assumption does not hold, then the value should not be accepted.
        ///
        /// This function should fail if a game has already begun (at least
        /// one valid turn has been taken).
        /// </remarks>
        /// ---------------------------------------------------------------------
        public bool SetMaxTurns(int Turns = 12)
        {
            bool ret = false;
            if (whatTurn == 1)
            {
                if (Turns <=16 && Turns >=1)
                {
                    ret = true;
                    maxGuesses = Turns;
                }

            }

                return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Set the pattern length for the game (default = 5).
        /// </summary>
        /// 
        /// <returns>
        /// Return TRUE if the value was successfully set, FALSE otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// One may assume that the specified value will be no more than 16.  If this
        /// assumption does not hold, then the value should not be accepted.
        ///
        /// This function should fail if a game has already begun (at least
        /// one valid turn has been taken).
        /// </remarks>
        /// ---------------------------------------------------------------------
        public bool SetPatternLength(int Length)
        {
            bool ret = false;
            if (whatTurn == 1)
            {
                if (Length <= 16 && Length >= 1)
                {
                    ret = true;
                    maxSolutionSpots = Length;
                }

            }
            return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Set the "feedback mode" for this master 
        /// player (default = "Difficult").
        /// </summary>
        /// 
        /// <returns>
        /// Return TRUE if the feedback mode was successfully set, FALSE otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// The possible feedback modes are:
        ///
        ///	"Easy" 
        ///
        ///			(all feedback will be done with clue pegs "in place", wherein
        ///	         a clue peg placed in slot i will be a clue for the pattern
        ///			 peg in slot i)
        ///
        ///	"Difficult 
        ///	
        ///			(all feedback patterns are totally free form; wherein there
        ///			 is no correspondence between clue peg positions and pattern
        ///			 peg positions)
        ///
        /// This function should fail if a game has already begun (at least
        /// one valid turn has been taken).
        /// </remarks>
        /// ---------------------------------------------------------------------
        public bool SetFeedbackMode(string Mode)
        {
            bool ret = false;
            Mode = "Difficult";

            if(whatTurn == 0)
            {
                ret = true;
            }

            return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Process a GuessPattern on turn number Turn.  
        /// </summary>
        /// 
        /// <returns>
        /// Return feedback as a standard delimited string which consists of clue 
        /// peg color values coming from the set:
        ///
        ///	"Black" (color is correct, AND in the correct location)
        ///	"White" (color is correct, but in the incorrect location) 
        ///	"None"  (empty slot)
        ///	           
        /// If feedback cannot be successfully created, return "ERROR".
        /// </returns>
        /// 
        /// <remarks>
        /// The GuessPattern will be in standard delimited form.  
        /// The GuessPattern should be evaluated for validity; i.e., only valid
        /// colors should be used, the correct number of pattern pegs should be
        /// used; etc.  
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string ProcessGuess(int Turn, string GuessPattern)
        {
            
            int blackCount = 0;
            int whiteCount = 0;
            string ret = "ERROR";
            
            // if a valid turn has been taken and the method createSolution has been called
            if (Turn <= 16 && Turn >= 1 && createSolutionCalled && whatTurn == Turn)
            {
                userGuess = GuessPattern;
                string[] copyGuessPattern = GuessPattern.Split('|');
                string[] solutionArray = solutions.Split('|');
                bool colorsValid = true;
                // make sure that the guessPattern are valid colors to choose from
                for (int i = 0; i < copyGuessPattern.Length; i++)
                {
                    int check = Array.IndexOf(setPegColor,copyGuessPattern[i]);
                    if(check < 0)
                    {
                        colorsValid = false;
                    }
                }
                // if the array lengths are equal and the colors ar valid see how many of the guesses match the solution identically
                if (copyGuessPattern.Length == solutionArray.Length && colorsValid)
                {
                    ret = "";
                    whatTurn++;
                    for (int i = 0; i < solutionArray.Length; i++)
                    {
                        int x = solutionArray[i].CompareTo(copyGuessPattern[i]);
                        if (x == 0)
                        {
                            Console.WriteLine("Black");
                            blackCount++;

                        }
                    }
                    //See how many of the colors are apart of the solution but may not be in the correct order
                    for (int j = 0; j < copyGuessPattern.Length; j++)
                    {
                        for (int k = 0; k < solutionArray.Length; k++)
                        {
                            int x = solutionArray[k].CompareTo(copyGuessPattern[j]);
                            if (x == 0)
                            {
                                Console.WriteLine("White");
                                whiteCount++;
                            }
                        }
                    }
                    for (int i = 0; i < blackCount; i++)
                    {
                        ret = ret + "Black|";
                    }
                    for (int i = 0; i < whiteCount; i++)
                    {
                        ret = ret + "White|";
                    }
                    for (int i = 0; i < (solutionArray.Length - blackCount - whiteCount); i++)
                    {
                        ret = ret + "None";
                        userFeedBack = ret;
                    }
                }
                
            }

                return ret;
        }


        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Suggest a guess to the guesser.  This guess should 
        /// move the guesser further toward a solution; i.e., a currently unknown 
        /// color or position should be added to the most recent guess.
        /// </summary>
        /// 
        /// <returns>
        /// Return a guess pattern in standard delimited form.  If no guesses have
        /// been made yet, return a random suggestion.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string SuggestGuess()
        {//have a counter of how many times a color has been guessed

            string ret = "ERROR";



            return ret;
        }

        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] A general test function.  
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// ---------------------------------------------------------------------
        public bool Test(string P1)
        {
            return true;
        }


        /// ---------------------------------------------------------------------
        /// <summary>
        /// [public  Method] Return your name.
        /// </summary>
        /// 
        /// <returns>
        /// Return your name in the form of: "John Dengler" (cased).
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// ---------------------------------------------------------------------
        public string GetStudentName()
        {
            return "Blair Betts";
        }



        // -------- PRIVATE ------- //


        // *********************************************************************
        // -------------------        CONSTANTS        -------------------------
        // *********************************************************************

        // *********************************************************************
        // -------------------         METHODS         -------------------------
        // *********************************************************************

        // *********************************************************************
        // -------------------         MEMBERS         -------------------------
        // *********************************************************************

    }
}

