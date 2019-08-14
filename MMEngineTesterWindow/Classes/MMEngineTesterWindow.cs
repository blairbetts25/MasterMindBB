/*****************************************************************************/
/* SportsMEDIA Technology Corporation                     Copyright (c) 2007 */
/*****************************************************************************/
/*                                                                           */
/* FILE NAME:    MMEngineTesterWindow.cs                                     */
/* DESCRIPTION:  A Window form based MasterMind Engine tester                */
/* PROPERTY OF:  SportsMEDIA Technology Corporation                          */
/*               3511 University Drive                                       */
/*               Durham, North Carolina USA                                  */
/*               www.SportsMEDIA.com  (919) 493-9390                         */
/*                                                                           */
/* This Source Code and the associated Documentation contain proprietary     */
/* information of SportsMEDIA Technology Corporation may not be copied or    */
/* distributed in any form without the written permission of SportsMEDIA     */
/* Technology Corporation Copies of the source code may be made only for     */
/* backup purposes.                                                          */
/*                                                                           */
/*****************************************************************************/
/* Description:                                                              */
/*                                                                           */
/* This Windows forms based application can be used to test multiple         */
/* MasterMind engine implementations in the same run-time application.       */
/*****************************************************************************/
/*                             REVISION HISTORY                              */
/*                                                                           */
/* 20-Feb-07 Mark D. Bowers                                                  */
/*           Original Creation                                               */
/*****************************************************************************/

// To test your class, replace the "FML" below with your Namespace
// (e.g., "JDD").  Similarly, replace the
// "MMMasterFML" (where FML are initials for First-Middle-Last) below with
// your class name (e.g., "MMMasterJDD").

using System;
using System.Windows.Forms;

// This set of core MasterMind tester namespaces is required
using SportsMEDIA.Gemini.MasterMindSharp.MMLib;      // defines IMMMaster
using SportsMEDIA.Gemini.MasterMindSharp.MMtestLib;  // defines TestSet<T>
using SportsMEDIA.Gemini.MasterMindSharp.MMtestSets; // defines MMtestSetn

// This is all the possible namespaces that include MasterMind Engines 
// that are to be tested.  
using SportsMEDIA.Gemini.MasterMindSharp.BB;         

// the namespace unique to this tester Window
namespace MMEngineTesterWindow
{
    static class MMEngineTesterWindow
    {
        // the Main() method for this Windows Form based application
        static void Main()
        {
            // This is the list of all master implementations that are to be tested.  This is
            // the only place that a change needs to be made to add or delete a MasterMind
            // implementation to be tested.  No other edits or Windows form changes need to
            // be done.  A radio button for each implementation will dynamically and
            // automatically appear on the Main Windows form for each implementation listed here.
            IMMMaster[] master_implementations = 
            {
                new MMMasterBB(),
            };

            // This is the list of all test sets that will be executed against the MasterMind
            // implementations.  To add or subtract test sets, add or delete from this list.
            // Buttons for each test set will be dynamically and automatically added to the
            // main Windows form.  No other edits or graphical changes are necessary.
            TestSet<IMMMaster>[] testsets = 
            {
                new MMtestSet1(),
                new MMtestSet2(),
                new MMtestSet3(),
                new MMtestSet4(),
                new MMtestSet5(),
                new MMtestSet6(),
                new MMtestSet7()
            };

            // Simply run the application and the main form -- passing to the two arrays defined above
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MMtestForm(master_implementations,testsets));

        } // end Main()
    } // end class MMEngineTesterWindow
} // end namespace MMEngineTesterWindow

/*****************************************************************************/
/*                       end MMEngineTesterWindow.cs                         */
/*****************************************************************************/
