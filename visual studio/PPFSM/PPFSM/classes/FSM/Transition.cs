using System;

namespace FSM
{
    /// <summary>
    /// FSM Transition
    /// </summary>
    public class Transition : UniqueKeyGenerator
    {
        // Internal counter for new State Names. Easy way to assign unique names for now
        static private UInt64 _nextState = 1;
        static public string TransitionTag = "TRANSITION";

        public string Name { get; set; }

        // Unique Name of the states that make up the transition
        public string ToStateUniqueName { get; set; }
        public string FromStateUniqueName { get; set; }

        /// <summary>
        /// State Constructor
        /// </summary>
        public Transition(string fromState, string toState)
        {
            // Some default place holders that user can change
            Name = String.Format(TransitionTag + "{0}", _nextState.ToString());

            // Use a unique key so we don't have to constantly change lists if user changes name
            UniqueKey = GenerateUniqueKey(TransitionTag, _nextState++);

            // Unique names used
            ToStateUniqueName = toState;
            FromStateUniqueName = fromState;
        }
    }
}
