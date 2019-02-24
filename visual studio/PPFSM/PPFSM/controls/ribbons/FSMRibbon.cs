using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using FSM;
using System.Windows;

namespace PPFSM
{
    public partial class FSMRibbon
    {
        private void FSMRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        //
        private void Debug_Break_Click(object sender, RibbonControlEventArgs e)
        {

        }

        /// <summary>
        /// Ribbon button to create a new FSM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFSM_Create_Click(object sender, RibbonControlEventArgs e)
        {
            // Create a new slide just as if user created one manually in Power Point
            var slide = MyPowerPoint.NewSlide();

            // Create a new state machine instance and link it to the slide
            var fsm = new FiniteStateMachine();
            slide.Tags.Add(FiniteStateMachine.FSMTag, fsm.UniqueKey);
            
            // PP creates to text boxes in new slides, so we want to get rid of those in a new FSM
            slide.Shapes.Range(1).Delete();
            slide.Shapes.Range(1).Delete();
        }

        /// <summary>
        /// Ribbon button to create a new state in the currently active slide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFSM_NewState_Click(object sender, RibbonControlEventArgs e)
        {
            // Need to get link to the FSM associated with this slide.
            var tags = MyPowerPoint.GetCurrentSlideTags();
            var fsmKey = tags[FiniteStateMachine.FSMTag];
            var fsm = FiniteStateMachine.GetInstance(fsmKey);
 
            // No fsm means user is trying to create a state on a slide that was created using normal PP process and not the 'new slide' button
            if(fsm == null)
            {
                MessageBox.Show("Current slide is not a FSM. Create one using the add-in button","Not FSM",MessageBoxButton.OK);
            }
            else
            {
                var newState = new State();
                var rect = MyPowerPoint.NewRectangle(newState.Name);

                // Link the new state with the graphic instance
                rect.Tags.Add(State.StateTag, newState.UniqueKey);
                fsm.AddState(newState);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFSM_NewTransition_Click(object sender, RibbonControlEventArgs e)
        {
            var states = ThisAddIn.AppInstance.ActiveWindow.Selection;

            // user must select 2 states to create a transition
            if (states.ShapeRange.Count==2)
            {
                // "From" state is always the first shape selected. Connector will have arrow terminating at "To" state
                var stateFrom = states.ShapeRange[1];
                var stateTo = states.ShapeRange[2];
               
                // Both selections have to be states, which we can determine if the tags contain the proper text
                if(stateFrom.Tags[State.StateTag].Contains(State.StateTag) && stateTo.Tags[State.StateTag].Contains(State.StateTag))
                {
                    // Need to get link to the FSM associated with this slide.
                    var tags = MyPowerPoint.GetCurrentSlideTags();
                    var fsmKey = tags[FiniteStateMachine.FSMTag];
                    var fsm = FiniteStateMachine.GetInstance(fsmKey);

                    // Create a new transition
                    var newTransition = new Transition(stateFrom.Tags[State.StateTag], stateTo.Tags[State.StateTag]);
                    // Create a new connector between the two states with an arrow in the proper direction
                    Microsoft.Office.Interop.PowerPoint.Shape conn = MyPowerPoint.NewConnector(newTransition.UniqueKey);

                    // Powerpoint seems to automatically pick the best connection point based on shape locations
                    conn.ConnectorFormat.BeginConnect(stateFrom, 1);
                    conn.ConnectorFormat.EndConnect(stateTo, 1);
                    conn.RerouteConnections();

                    // Associate the connector and the transition
                    conn.Tags.Add(Transition.TransitionTag, newTransition.UniqueKey);

                    // Add a label to the text
                    var transitionLabel = MyPowerPoint.NewText(newTransition.UniqueKey, conn.Left+conn.Width/2, conn.Top+conn.Height/2, conn.Width, conn.Height);

                    // Add the transition to the FSM.
                    fsm.AddTransition(newTransition);
                }
            }
        }
    }
}
