/*****************************************************************************/
/* SportsMEDIA Technology Corporation                     Copyright (c) 2007 */
/*****************************************************************************/
/*                                                                           */
/* FILE NAME:    MMtestForm.Designer.cs                                      */
/* DESCRIPTION:  Partial Class definition for the main MasterMind test form  */
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
/*                             REVISION HISTORY                              */
/*                                                                           */
/* 20-Feb-07 Mark D. Bowers                                                  */
/*           Original Creation                                               */
/*****************************************************************************/

using System;
using System.Drawing;  // defines Point
using System.Windows.Forms;

using SportsMEDIA.Gemini.MasterMindSharp.MMLib;      // defines IMMMaster
using SportsMEDIA.Gemini.MasterMindSharp.MMtestLib;  // defines TestSet<T>

// the namespace unique to this tester Window
namespace MMEngineTesterWindow
{
    // the main Windows Form class
    public partial class MMtestForm : Form
    {
        // the local class variable used to retain the list of tests to execute.  This  
        // is set by the constructor
        private TestSet<IMMMaster>[] MMtestForm_testsets;
        // the local class variable used to retain the list of implementations to test.  
        // this is set by the constructor
        private IMMMaster [] MMtestForm_master_implementations;
        // the master actively being tested.  This is selected by the user clicking on a button.
        private IMMMaster active_master;

        #region Controls added by Programmer not controlled/managed by Windows Form Designer
            // The buttons dynamically created -- one for each TestSet in the MMtestForm_testsets array
            private System.Windows.Forms.Button[] runtest_buttons;
            // The radio buttons dynamically created -- one for each master implementation in
            // the MMtestForm_master_implementations array
            private System.Windows.Forms.RadioButton[] radioButtons;
        #endregion

        /*****************************************************************************/
        /* MMtestForm() -- the Main Form constructor                                 */
        /*                                                                           */
        /* Parameters:  master_implementations = the list of Master Mind masters     */
        /*                                       that are to be tested               */
        /*              testsets = the list of test sets to be executed against      */
        /*                         the master implementations.                       */
        /*****************************************************************************/
        public MMtestForm(IMMMaster[] master_implementations,
                          TestSet<IMMMaster> [] testsets )
        {
            // set the local class variables with the values from the passed parameters
            MMtestForm_master_implementations = master_implementations;
            MMtestForm_testsets = testsets;

            // create and initialize all form components that were created with the form designer
            InitializeComponent();

            #region Controls added by Programmer not controlled/managed by Windows Form Designer
                // this is where we dynamically create test buttons for each configured TestSet, and where
                // we dynamically create radiobuttons for each MasterMind master implementation to test

                // Note that there are better ways to do this.  This, for example, does not move the 
                // dynamically created buttons when the outer window is resized.  But for a simple testing
                // environment, this is sufficient.

                // first allocate the arrays of buttons and radio buttons according to the length
                // of the testset and  master implementations array
                this.runtest_buttons = new System.Windows.Forms.Button[MMtestForm_testsets.Length];
                this.radioButtons = new System.Windows.Forms.RadioButton[MMtestForm_master_implementations.Length];

                // Now suspend the layout while we add controls to the form.  We will resume and perform
                // the layout when we are done (below).
                this.SuspendLayout();

                // hard-code the number of columns of testSet buttons to display
                const int num_columns_of_test_buttons = 4;

                // Create and fill the properties of the created TestSet buttons
                for (int i = 0; i < MMtestForm_testsets.Length; i++)
                {
                    // allocate a button for each TestSet
                    this.runtest_buttons[i] = new System.Windows.Forms.Button();

                    // Use the location of the "Test All" button as set within the Form Designer to set
                    // the other buttons adjacent and alligned.  Note that the button given 9/8 spacing.
                    this.runtest_buttons[i].Location = 
                        new System.Drawing.Point(this.runAlltests_button.Location.X + ((i + 1) % num_columns_of_test_buttons) * this.runAlltests_button.Size.Width*9/8,
                                                 this.runAlltests_button.Location.Y + ((i + 1) / num_columns_of_test_buttons) * this.runAlltests_button.Size.Height*9/8);

                    // the name of the button is not displayed
                    this.runtest_buttons[i].Name = "testButton" + i.ToString();

                    // set the size of the button to be the same as the "Test All" button
                    this.runtest_buttons[i].Size = new System.Drawing.Size(
                        this.runAlltests_button.Size.Width,
                        this.runAlltests_button.Size.Height);

                    // set the tab index to increment with each button
                    this.runtest_buttons[i].TabIndex = 1+i;

                    // use the name of the testset to display text in the button.  Note that we are not worried
                    // about if the name is too large to display in the button.
                    this.runtest_buttons[i].Text = MMtestForm_testsets[i].name;

                    // Set the style
                    this.runtest_buttons[i].UseVisualStyleBackColor = true;

                    // Set the method to call when the button is clicked
                    this.runtest_buttons[i].Click += new System.EventHandler(this.runtest_button_click);

                    // Add a reference to the testset as the tag to the button so the button knows what to 
                    // to uniquely do when it is clicked.
                    this.runtest_buttons[i].Tag = MMtestForm_testsets[i];
                }

                // Now configure the radio buttons

                // First determine the starting point for the radio buttons to be to the right of 
                // the test buttons by an amount equal to an extra button column
                Point radio_start_point =
                    new Point(this.runAlltests_button.Location.X + (num_columns_of_test_buttons+1) * this.runAlltests_button.Size.Width * 9 / 8,
                              this.runAlltests_button.Location.Y);

                // Create and fill the properties of the created Master implementations RadioButtons
                for (int i = 0; i < MMtestForm_master_implementations.Length; i++)
                {
                    // create the radiobutton
                    this.radioButtons[i] = new System.Windows.Forms.RadioButton();

                    // set the size and location arbitrarily (through experimentation) and to 
                    // use three radio buttons per column
                    this.radioButtons[i].AutoSize = true;
                    this.radioButtons[i].Size = new System.Drawing.Size(126, 21);
                    this.radioButtons[i].Location = radio_start_point + new System.Drawing.Size((i / 3) * 120, 
                                                                                                (i % 3) * 30);

                    // the name of the button is not displayed
                    this.radioButtons[i].Name = "radioButton" + i.ToString();

                    // set the tab index to increment with each button and to extend beyond the number
                    // of tabs used for the Test buttons above
                    this.radioButtons[i].TabIndex = 1 + MMtestForm_testsets.Length + i;
                    this.radioButtons[i].TabStop = true;

                    // set the text to display with the radio button to show the name of the 
                    // student submitting a master implementation, and the version of the submission
                    this.radioButtons[i].Text = MMtestForm_master_implementations[i].GetStudentName() +
                                                "\nV" + MMtestForm_master_implementations[i].GetType().Assembly.GetName().Version.ToString();

                    // set the style
                    this.radioButtons[i].UseVisualStyleBackColor = true;

                    // Set the method to call when the button is clicked
                    this.radioButtons[i].CheckedChanged += new System.EventHandler(this.radio_button_check_changed);

                    // Add a reference to the testset as the tag to the button so the button knows what to 
                    // to uniquely do when it is clicked.
                    this.radioButtons[i].Tag = MMtestForm_master_implementations[i];
                }

                // make the first (zeroth) button the default button checked
                this.radioButtons[0].Checked = true;

                // Now add the controls to the form
                foreach (System.Windows.Forms.Control control in this.radioButtons) { this.Controls.Add(control); }
                foreach (System.Windows.Forms.Control control in this.runtest_buttons) { this.Controls.Add(control); }

                // finally, resume the layout, and perform it!
                this.ResumeLayout(false);
                this.PerformLayout();

            #endregion
        
        } // end MMtestForm() constructor

        /*****************************************************************************/
        /* display_string() -- used to display text strings in the main Form text    */
        /*                     box.  Usually called through a delegate from the      */
        /*                     MMtestSet.display_tests_results() function.           */
        /*****************************************************************************/
        private void display_string(string string_to_display)
        {
            test_results_box.Items.Add(string_to_display);
            // This line makes sure the listbox scrolls if necessary to show the last line added
            test_results_box.TopIndex = test_results_box.Items.Count - 1;

        } /* end display_string() */

        /*****************************************************************************/
        /* display_zero_results()                                                    */
        /*                                                                           */
        /* used to clear the counts of errors, warnings and successes.  This may be  */
        /* called after a test against one MasterMind engine has been executed (and  */
        /* the displayed counts are non-zero) and then a different MasterMind engine */
        /* is selected to be tested (but before the test has begun).                 */
        /*****************************************************************************/
        private void display_zero_results()
        {
            Failures.Text = 0.ToString();
            Warnings.Text = 0.ToString();
            Successes.Text = 0.ToString();

        } // end display_zero_results()

        /*****************************************************************************/
        /* display_results()                                                         */
        /*                                                                           */
        /* used to display the counts of errors, warnings and successes.  This may   */
        /* be called after a test against one MasterMind engine has been executed    */
        /*****************************************************************************/
        private void display_results(TestSet<IMMMaster> testset)
        {
            int num_failures = testset.TestSet_num_errors();
            int num_warnings = testset.TestSet_num_warnings();

            Failures.Text = num_failures.ToString();
            Warnings.Text = num_warnings.ToString();
            Successes.Text = (testset.TestSet_num_tests() - num_failures - num_warnings).ToString();

        } // end display_results()

        /*****************************************************************************/
        /* runalltests_button_click()                                                */
        /*                                                                           */
        /* Called when the "test all" button is clicked.  Used to execute all tests  */
        /* in all test sets at once.                                                 */
        /*****************************************************************************/
        private void runalltests_button_click(object sender, EventArgs event_args)
        {
            // create a new testset which is a combination of all of the specified test sets
            TestSet<IMMMaster> testset = new TestSet<IMMMaster>("All Tests");
            foreach (TestSet<IMMMaster> individual_testset in MMtestForm_testsets)
            {
                testset += individual_testset;
            }

            // execute the tests, and display the resuults
            testset.execute_tests(active_master);
            testset.display_tests_results(display_string);  // displays to the text box
            display_results(testset); // updates the count of errors, warnings, and successes

        } // end runalltests_button_click()

        /*****************************************************************************/
        /* runtest_button_click()                                                    */
        /*                                                                           */
        /* Called when one of the individual test buttons is clicked.  Retrieves the */
        /* correct testset to execute from the button.tag.                           */
        /*****************************************************************************/
        private void runtest_button_click(object sender, EventArgs event_args)
        {
            // make sure the sender of this click is the button because we
            // have to get the tag from the sender, and to do that, we have
            // to typecast the sender.  We wouldn't want to typecast unless we
            // know for sure that the we are casting to the correct type.
            if (sender is System.Windows.Forms.Button)
            {
                // typecast the sender to a button
                System.Windows.Forms.Button button =
                    (System.Windows.Forms.Button)sender;

                // get the tag from the button, and casts that to a testset
                TestSet<IMMMaster> testset = ((TestSet<IMMMaster>)button.Tag);

                // execute the testset and display the results
                testset.execute_tests(active_master);
                testset.display_tests_results(display_string);  // displays to the text box
                display_results(testset); // updates the count of errors, warnings, and successes
            } // end if sender is a button
        } // end runtest_button_click()

        /*****************************************************************************/
        /* radio_button_check_changed()                                              */
        /*                                                                           */
        /* Called when one of the individual test buttons is clicked.  Retrieves the */
        /* correct testset to execute from the button.tag.                           */
        /*****************************************************************************/
        private void radio_button_check_changed(object sender, EventArgs event_args)
        {
            // make sure the sender of this click is a radiobutton because we
            // have to get the tag from the sender, and to do that, we have
            // to typecast the sender.  We wouldn't want to typecast unless we
            // know for sure that the we are casting to the correct type.
            if (sender is System.Windows.Forms.RadioButton)
            {
                // typecast the sender to a radiobutton
                System.Windows.Forms.RadioButton radioButton = 
                    (System.Windows.Forms.RadioButton)sender;

                // if we are checking the button (not un-checking it), then
                // set the active MasterMind master engine to test from the
                // retrieved and type casted tag
                if (radioButton.Checked)
                {
                    active_master = ((IMMMaster) radioButton.Tag);
                }

                // clear out the display of errors, warnings, and successes since
                // the master is now changed and that display no longer corresponds
                // to the new master
                display_zero_results();

            } // end if sender is a radiobutton
        } // end radio_button_check_changed()
    } // end partial class MMtestForm
} // end namespace MMEngineTesterWindow

/*****************************************************************************/
/*                            end MMtestForm.cs                              */
/*****************************************************************************/
