using System;
using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// Finite State Machine
    /// </summary>
    public class FiniteStateMachine : UniqueKeyGenerator
    {
        // Keeps track of all FSM with "UniqueKey" as the key entry
        static Dictionary<string, FiniteStateMachine> _fsmList = new Dictionary<string, FiniteStateMachine>();
        static private UInt64 _nextFSM = 1;
        static public string FSMTag = "FSM";

        // FSM name.
        public string Name { get; set; }

        // All states which are part of this FSM
        public Dictionary<String,State> _states = new Dictionary<String,State>();

        // All transitions which are part of this FSM
        public Dictionary<String, Transition> _transitions = new Dictionary<String, Transition>();

        /// <summary>
        /// Return finite state machine instance based on the key
        /// </summary>
        /// <param name="key">fsm UniqueKey</param>
        /// <returns></returns>
        static public FiniteStateMachine GetInstance(string key)
        {
            FiniteStateMachine fsm = null;

            if(IsValidKey(key) == true)
            {
                fsm = _fsmList[key];
            }

            return fsm;
        }

        /// <summary>
        /// FSM key validator
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static public Boolean IsValidKey(string key)
        {
            return _fsmList.ContainsKey(key);
        }

        /// <summary>
        /// Attach a state instance to the FSM
        /// </summary>
        /// <param name="state"></param>
        public void AddState(State state)
        {
            _states.Add(state.UniqueKey, state);
        }

        /// <summary>
        /// Attach a transition to the FSM
        /// </summary>
        /// <param name="transition"></param>
        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition.UniqueKey, transition);
        }

        /// <summary>
        /// Remove a state instance from the FSM
        /// </summary>
        /// <param name="state"></param>
        public void RemoveState(State state)
        {
            if(_states.ContainsKey(state.UniqueKey))
            {
                _states.Remove(state.UniqueKey);
            }
        }

        // Constructor
        public FiniteStateMachine()
        {
            Name = String.Format(FSMTag +"{0}", _nextFSM.ToString());
            UniqueKey = GenerateUniqueKey(FSMTag, _nextFSM++);

            // keep track of this FSM
            _fsmList.Add(UniqueKey, this);
        }

        // Destructor (Cleanup)
        ~FiniteStateMachine()
        {
            // Clean up the FSM from the list
            _fsmList.Remove(UniqueKey);
        }
    }
}
