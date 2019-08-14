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

using System.Windows.Forms;  // for Application name and version

// the namespace unique to this tester Window
namespace MMEngineTesterWindow
{
    // the main Windows Form class
    partial class MMtestForm
    {
        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        /*****************************************************************************/
        /* Dispose() -- Clean up any resources being used.                           */
        /*                                                                           */
        /* Parameters:  disposing = true if managed resources should be disposed     */
        /*                        = false otherwise                                  */
        /*****************************************************************************/
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        } // end Dispose();

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.test_results_box = new System.Windows.Forms.ListBox();
            this.runAlltests_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Successes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Warnings = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Failures = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // test_results_box
            // 
            this.test_results_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.test_results_box.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_results_box.FormattingEnabled = true;
            this.test_results_box.HorizontalScrollbar = true;
            this.test_results_box.ItemHeight = 12;
            this.test_results_box.Location = new System.Drawing.Point(4, 104);
            this.test_results_box.Margin = new System.Windows.Forms.Padding(2);
            this.test_results_box.Name = "test_results_box";
            this.test_results_box.Size = new System.Drawing.Size(766, 340);
            this.test_results_box.TabIndex = 0;
            // 
            // runAlltests_button
            // 
            this.runAlltests_button.Location = new System.Drawing.Point(4, 10);
            this.runAlltests_button.Margin = new System.Windows.Forms.Padding(2);
            this.runAlltests_button.Name = "runAlltests_button";
            this.runAlltests_button.Size = new System.Drawing.Size(75, 24);
            this.runAlltests_button.TabIndex = 1;
            this.runAlltests_button.Text = "Test All";
            this.runAlltests_button.UseVisualStyleBackColor = true;
            this.runAlltests_button.Click += new System.EventHandler(this.runalltests_button_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Successes:";
            // 
            // Successes
            // 
            this.Successes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Successes.Location = new System.Drawing.Point(69, 80);
            this.Successes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Successes.Name = "Successes";
            this.Successes.Size = new System.Drawing.Size(35, 15);
            this.Successes.TabIndex = 3;
            this.Successes.Text = "label2";
            this.Successes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Warnings:";
            // 
            // Warnings
            // 
            this.Warnings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Warnings.Location = new System.Drawing.Point(169, 79);
            this.Warnings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Warnings.Name = "Warnings";
            this.Warnings.Size = new System.Drawing.Size(35, 15);
            this.Warnings.TabIndex = 5;
            this.Warnings.Text = "label4";
            this.Warnings.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Failures:";
            // 
            // Failures
            // 
            this.Failures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Failures.Location = new System.Drawing.Point(261, 80);
            this.Failures.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Failures.Name = "Failures";
            this.Failures.Size = new System.Drawing.Size(35, 15);
            this.Failures.TabIndex = 7;
            this.Failures.Text = "label6";
            this.Failures.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MMtestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 450);
            this.Controls.Add(this.Failures);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Warnings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Successes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runAlltests_button);
            this.Controls.Add(this.test_results_box);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MMtestForm";
            this.Text = "Microsoft® Visual Studio® 2005 8.0.50727.42";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // the largest display window that displays all the test results
        private System.Windows.Forms.ListBox test_results_box;
        // the single button that is created by the Form editor; all
        // other buttons copy this button's properties
        private System.Windows.Forms.Button runAlltests_button;
        // The labels that preceed the counter boxes to display successfully
        // passed tests, warnings, and failed tests
        private Label label1;
        private Label label3;
        private Label label5;
        // the boxes that display the counts of successes, warnings, and failures
        private Label Successes;
        private Label Warnings;
        private Label Failures;

    } // end partial class MMtestForm
} // end namespace MMEngineTesterWindow

/*****************************************************************************/
/*                       end MMtestForm.Designer.cs                          */
/*****************************************************************************/

