using System;
using System.Collections.Generic;

namespace Events
{
    public interface IEvent
    {
        string Name { get; }
        string DialogSchemePath { get; }
        Dictionary<string, Tuple<Action, string>> Answers { get; } // name : action : message

        void Start();
        void Reaction(string answerId);
    }
}
