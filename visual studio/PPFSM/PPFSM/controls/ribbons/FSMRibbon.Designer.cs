namespace PPFSM
{
    partial class FSMRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public FSMRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.PRESENTATION = this.Factory.CreateRibbonGroup();
            this.btnFSM_Create = this.Factory.CreateRibbonButton();
            this.btnFSM_GenerateAll = this.Factory.CreateRibbonButton();
            this.SLIDE = this.Factory.CreateRibbonGroup();
            this.btnFSM_Parameters = this.Factory.CreateRibbonButton();
            this.btnFSM_GenerateSlide = this.Factory.CreateRibbonButton();
            this.FSM = this.Factory.CreateRibbonGroup();
            this.btnFSM_NewState = this.Factory.CreateRibbonButton();
            this.btnFSM_NewTransition = this.Factory.CreateRibbonButton();
            this.DEBUG = this.Factory.CreateRibbonGroup();
            this.Debug_Break = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.PRESENTATION.SuspendLayout();
            this.SLIDE.SuspendLayout();
            this.FSM.SuspendLayout();
            this.DEBUG.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.PRESENTATION);
            this.tab1.Groups.Add(this.SLIDE);
            this.tab1.Groups.Add(this.FSM);
            this.tab1.Groups.Add(this.DEBUG);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // PRESENTATION
            // 
            this.PRESENTATION.Items.Add(this.btnFSM_Create);
            this.PRESENTATION.Items.Add(this.btnFSM_GenerateAll);
            this.PRESENTATION.Label = "PRESENTATION";
            this.PRESENTATION.Name = "PRESENTATION";
            // 
            // btnFSM_Create
            // 
            this.btnFSM_Create.Label = "New FSM";
            this.btnFSM_Create.Name = "btnFSM_Create";
            this.btnFSM_Create.ScreenTip = "Create a new state machine.";
            this.btnFSM_Create.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFSM_Create_Click);
            // 
            // btnFSM_GenerateAll
            // 
            this.btnFSM_GenerateAll.Label = "Generate Code (All)";
            this.btnFSM_GenerateAll.Name = "btnFSM_GenerateAll";
            // 
            // SLIDE
            // 
            this.SLIDE.Items.Add(this.btnFSM_Parameters);
            this.SLIDE.Items.Add(this.btnFSM_GenerateSlide);
            this.SLIDE.Label = "SLIDE";
            this.SLIDE.Name = "SLIDE";
            // 
            // btnFSM_Parameters
            // 
            this.btnFSM_Parameters.Label = "Parameters";
            this.btnFSM_Parameters.Name = "btnFSM_Parameters";
            // 
            // btnFSM_GenerateSlide
            // 
            this.btnFSM_GenerateSlide.Label = "Generate (Slide)";
            this.btnFSM_GenerateSlide.Name = "btnFSM_GenerateSlide";
            // 
            // FSM
            // 
            this.FSM.Items.Add(this.btnFSM_NewState);
            this.FSM.Items.Add(this.btnFSM_NewTransition);
            this.FSM.Label = "FSM";
            this.FSM.Name = "FSM";
            // 
            // btnFSM_NewState
            // 
            this.btnFSM_NewState.Label = "New State";
            this.btnFSM_NewState.Name = "btnFSM_NewState";
            this.btnFSM_NewState.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFSM_NewState_Click);
            // 
            // btnFSM_NewTransition
            // 
            this.btnFSM_NewTransition.Label = "New Transition";
            this.btnFSM_NewTransition.Name = "btnFSM_NewTransition";
            // 
            // DEBUG
            // 
            this.DEBUG.Items.Add(this.Debug_Break);
            this.DEBUG.Label = "DEBUG";
            this.DEBUG.Name = "DEBUG";
            // 
            // Debug_Break
            // 
            this.Debug_Break.Label = "Break";
            this.Debug_Break.Name = "Debug_Break";
            this.Debug_Break.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Debug_Break_Click);
            // 
            // FSMRibbon
            // 
            this.Name = "FSMRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.FSMRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.PRESENTATION.ResumeLayout(false);
            this.PRESENTATION.PerformLayout();
            this.SLIDE.ResumeLayout(false);
            this.SLIDE.PerformLayout();
            this.FSM.ResumeLayout(false);
            this.FSM.PerformLayout();
            this.DEBUG.ResumeLayout(false);
            this.DEBUG.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup PRESENTATION;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup SLIDE;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup FSM;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_Create;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_GenerateAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_Parameters;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_GenerateSlide;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_NewState;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFSM_NewTransition;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup DEBUG;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Debug_Break;
    }

    partial class ThisRibbonCollection
    {
        internal FSMRibbon FSMRibbon
        {
            get { return this.GetRibbon<FSMRibbon>(); }
        }
    }
}
