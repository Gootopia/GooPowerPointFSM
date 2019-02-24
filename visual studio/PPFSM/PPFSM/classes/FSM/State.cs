using System;

namespace FSM
{
    /// <summary>
    /// FSM State
    /// </summary>
    public class State : UniqueKeyGenerator
    {
        // Internal counter for new State Names. Easy way to assign unique names for now
        static private UInt64 _nextState = 1;
        static public string StateTag = "STATE";

        public string Name { get; set; }

        /// <summary>
        /// State Constructor
        /// </summary>
        public State()
        {
            // Some default place holders that user can change
            Name = String.Format(StateTag+"{0}", _nextState.ToString());

            // Use a unique key so we don't have to constantly change lists if user changes name
            UniqueKey = GenerateUniqueKey(StateTag, _nextState++);
        }
    }
}
