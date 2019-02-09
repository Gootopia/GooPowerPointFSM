using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Windows.Shapes;
using System;
using System.Windows.Media;
using FSM;

namespace PPFSM
{
    public partial class ThisAddIn
    {
        public static PowerPoint.Application AppInstance { get; set; }
        public static PowerPoint.Presentation ActivePresentation { get; set; }
        public static PowerPoint.Slide CurrentSlide { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Convenience variables for use by our PowerPoint code. Can't set other stuff yet as it hasn't been initialized.
            AppInstance = this.Application;

            // Handlers needed
            this.Application.WindowSelectionChange += Application_WindowSelectionChange;
            this.Application.SlideSelectionChanged += Application_SlideSelectionChanged;
            this.Application.WindowBeforeDoubleClick += Application_WindowBeforeDoubleClick;
            this.Application.WindowBeforeRightClick += Application_WindowBeforeRightClick;
        }

        private void Application_WindowBeforeRightClick(PowerPoint.Selection Sel, ref bool Cancel)
        {

        }

        private void Application_WindowBeforeDoubleClick(PowerPoint.Selection Sel, ref bool Cancel)
        {

        }

        /// <summary>
        /// Get first slide in a selection range.
        /// </summary>
        /// <param name="SldRange"></param>
        private void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange)
        {
            // This is null at the start, so this is a convenient place to set it as this method will get called when PP starts up.
            ActivePresentation = AppInstance.ActivePresentation;

            // Count will be zero if user deletes everything or if click is not on a slide.
            if (SldRange.Count >= 1)
            {
                CurrentSlide = SldRange[1];

                // Enable ribbon controls based on whether or not the slide is associated with a Finite State Machine
                var isFSM = FiniteStateMachine.IsValidKey(CurrentSlide.Tags[FiniteStateMachine.FSMTag]);
                Globals.Ribbons.FSMRibbon.btnFSM_NewState.Enabled = isFSM;
                Globals.Ribbons.FSMRibbon.btnFSM_NewTransition.Enabled = isFSM;
                Globals.Ribbons.FSMRibbon.btnFSM_GenerateSlide.Enabled = isFSM;
                Globals.Ribbons.FSMRibbon.btnFSM_Parameters.Enabled = isFSM;
                var name = CurrentSlide.Name;
            }
        }

        private void Application_WindowSelectionChange(PowerPoint.Selection Sel)
        {
            // This code gets triggered every time you click on anything
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
