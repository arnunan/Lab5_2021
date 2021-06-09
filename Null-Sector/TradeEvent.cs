using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Events;
using User;

namespace Null_Sector
{
    class TradeEvent : IEvent
    {
        public string Name { get; }
        public string DialogSchemePath { get; }
        public Dictionary<string, Tuple<Action, string>> Answers { get; } = new Dictionary<string, Tuple<Action, string>>();

        public TradeEvent(string name, string dialogSchemePath)
        {
            Name = name;
            DialogSchemePath = dialogSchemePath;
            UpdateAnswers();
        }

        private void UpdateAnswers()
        {
            string info = File.ReadAllText(DialogSchemePath);
            string[][] tags = info
                .Split(new [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Split(new [] {"<", ">"}, StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            foreach (var tag in tags)
            {
                var t = ParseTag(tag);
                Answers.Add(t.Item1, new Tuple<Action, string>(t.Item2, t.Item3));
            }

        }

        private Tuple<string, Action, string> ParseTag(string[] tag)
        {
            switch (tag[2])
            {
                case "welcome":
                    return new Tuple<string, Action, string>("welcome", () => Terminal.NewMessage(tag[1]), tag[1]);
                case "goodbye":
                    return new Tuple<string, Action, string>("goodbye", 
                        () =>
                    {
                        Terminal.NewMessage(tag[1]);
                        Game.NextEvent();
                    }, 
                        tag[1]);
                case "unknown":
                    return new Tuple<string, Action, string>("unknown", () => Terminal.NewMessage(tag[1]), tag[1]);
                default:
                {
                    var p = tag[0].Split(';').Skip(1).ToArray();
                    return new Tuple<string, Action, string>(ParseTagName(p[0]), ParseTagReaction(p[1]), tag[1]);
                }
            }
        }

        private string ParseTagName(string property) => property.Substring(6, property.Length - 7);

        private Action ParseTagReaction(string property)
        {
            string command = property.Substring(10, property.Length - 11);
            if (command.Substring(0, 5) == "call:")
            {
                return () => { Reaction(command.Replace("call:", "")); };
            }

            List<Action> actions = new List<Action>();
            var acts = command.FindMatches(@"[{]\w+[}][+,-]\d+");
            List<Tuple<string, char, int>> actsList = new List<Tuple<string, char, int>>();

            // there are always 2 acts
            foreach (Match act in acts)
            {
                string resource = act.Value.FindMatch(@"[{]\w+[}]").Value;
                char symbol = act.Value.FindMatch(@"[+,-]").Value[0];
                int num = int.Parse(act.Value.FindMatch(@"\d+").Value);
                actsList.Add(new Tuple<string, char, int>(resource, symbol, num));
            }

            int payResource = 0;

            foreach (var act in actsList)
            {
                if (Equals(actsList.First(), act))
                {
                    switch (act.Item1)
                    {
                        case "{metal}":
                            payResource = Character.Metal;
                            break;
                        case "{electronics}":
                            payResource = Character.Electronics;
                            break;
                        case "{food}":
                            payResource = Character.Food;
                            break;
                    }
                    ParseFirstAction(actions, act);
                }
                else
                {
                    ParseSecondAction(actions, act, payResource, actsList.First().Item1);
                }
            }

            return (Action) Delegate.Combine(actions[0], actions[1]);
        }

        private static void ParseFirstAction(List<Action> actions, Tuple<string, char, int> act)
        {
            switch (act.Item1)
            {
                case "{metal}":
                    actions.Add(() => { 
                        Character.Metal += (act.Item2 == '+' ? 1 : -1) * act.Item3; 
                        Character.UpdateInfo(); });
                    break;
                case "{electronics}":
                    actions.Add(() => { 
                        Character.Electronics += (act.Item2 == '+' ? 1 : -1) * act.Item3; 
                        Character.UpdateInfo(); });
                    break;
                case "{food}":
                    actions.Add(() => { 
                        Character.Food += (act.Item2 == '+' ? 1 : -1) * act.Item3; 
                        Character.UpdateInfo(); });
                    break;
            }
        }
        private static void ParseSecondAction(List<Action> actions, Tuple<string, char, int> act, int payResource, string currentResource)
        {
            switch (act.Item1)
            {
                case "{metal}":
                    actions.Add(() =>
                    {
                        var currentValue = GetCurrentValue(currentResource);
                        if (payResource != currentValue)
                        {
                            Character.Metal += (act.Item2 == '+' ? 1 : -1) * act.Item3;
                            Character.UpdateInfo();
                        }
                    });
                    break;
                case "{electronics}":
                    actions.Add(() =>
                    {
                        var currentValue = GetCurrentValue(currentResource);
                        if (payResource != currentValue)
                        {
                            Character.Electronics += (act.Item2 == '+' ? 1 : -1) * act.Item3;
                            Character.UpdateInfo();
                        }
                    });
                    break;
                case "{food}":
                    actions.Add(() =>
                    {
                        var currentValue = GetCurrentValue(currentResource);
                        if (payResource != currentValue)
                        {
                            Character.Food += (act.Item2 == '+' ? 1 : -1) * act.Item3;
                            Character.UpdateInfo();
                        }
                    });
                    break;
            }
        }

        private static int GetCurrentValue(string currentResource)
        {
            int currentValue = 0;
            switch (currentResource)
            {
                case "{metal}":
                    currentValue = Character.Metal;
                    break;
                case "{electronics}":
                    currentValue = Character.Electronics;
                    break;
                case "{food}":
                    currentValue = Character.Food;
                    break;
            }

            return currentValue;
        }

        public void Start()
        {
            Reaction("welcome");
            string mes = "";
            foreach (var answer in Answers)
            {
                if (!(new[] {"welcome", "goodbye", "unknown"}).Contains(answer.Key))
                {
                    mes += answer.Value.Item2 + "\r\n";
                }
            }
            Terminal.NewMessage(mes.Substring(0, mes.Length - 3));
        }

        public void Reaction(string answerId)
        {
            if (!Answers.ContainsKey(answerId))
            {
                Answers["unknown"].Item1();
                return;
            }
            Answers[answerId].Item1();
        }
    }

    public static class StringExtensions
    {
        public static Match FindMatch(this string input, string pattern)
        {
            Regex r = new Regex(pattern);
            return r.Match(input);
        }

        public static MatchCollection FindMatches(this string input, string pattern)
        {
            Regex r = new Regex(pattern);
            return r.Matches(input);
        }
    }
}
