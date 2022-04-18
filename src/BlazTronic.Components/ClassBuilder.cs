using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazTronic.Components
{
    public class ClassBuilder
    {
        public List<Func<string>> Items = new List<Func<string>>();

        public string AsString()
        {
            return string.Join(" ", Items.Select(i => i()).Where(i => i != null));
        }


        public override string ToString()
        {
            return AsString();
        }
    }
    public static class ClassBuilderExtensions
    {
        public static T Add<T>(this T m, string name) where T : ClassBuilder
        {
            m.Items.Add(() => name);
            return m;
        }


        public static T Get<T>(this T m, Func<string> funcName) where T : ClassBuilder
        {
            m.Items.Add(funcName);
            return m;
        }

        public static T GetIf<T>(this T m, Func<string> funcName, Func<bool> func) where T : ClassBuilder
        {
            m.Items.Add(() => func() ? funcName() : null);
            return m;
        }

        public static T If<T>(this T m, string name, Func<bool> func) where T : ClassBuilder
        {
            m.Items.Add(() => func() ? name : null);
            return m;
        }
    }
}
