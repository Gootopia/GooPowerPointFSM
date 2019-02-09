using System;
using System.Collections.Specialized;

namespace FSM
{
    public class UniqueKeyGenerator
    {
        public string UniqueKey { get; set; }

        static public string GenerateUniqueKey(string prefix, UInt64 index)
        {
            return String.Format("{0}{1}", prefix, index.ToString());
        }
    }
}