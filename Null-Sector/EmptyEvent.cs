using System;
using System.Collections.Generic;
using Events;

namespace Null_Sector
{
    class EmptyEvent : IEvent
    {
        public string Name { get; } = "Empty";
        public string DialogSchemePath { get; }
        public Dictionary<string, Tuple<Action, string>> Answers { get; private set; } = new Dictionary<string, Tuple<Action, string>>();
        public void Start()
        {
            Terminal.NewMessage("Никто не отвечает...");
            Answers.Add("empty", new Tuple<Action, string>(() => Terminal.NewMessage("Никто..."), "Никто."));
        }

        public void Reaction(string answerId)
        {
            Answers["empty"].Item1();
        }
    }
}
