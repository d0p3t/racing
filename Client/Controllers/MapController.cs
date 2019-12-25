﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Source https://github.com/blattersturm/expeditious-execution/blob/master/resources/%5Bexpeditious%5D/%5Bgameplay%5D/base-rush/client/BaseRushMapManager.cs
namespace Client.Controllers
{
    public class MapState
    {
        private dynamic m_state;

        internal MapState(dynamic state)
        {
            m_state = state;
        }

        public void Add(string key, object value)
        {
            m_state.add(key, value);
        }
    }

    public abstract class MapDirective
    {
        public abstract dynamic Do(MapState state, dynamic arg);

        public abstract void Undo(dynamic state);
    }

    public abstract class TwoArgMapDirective : MapDirective
    {
        public sealed override dynamic Do(MapState state, dynamic arg)
        {
            return new Func<dynamic, dynamic>(arg2 =>
            {
                return this.Do(state, arg, arg2);
            });
        }

        public abstract dynamic Do(MapState state, dynamic arg, dynamic arg2);
    }

    public class KeyDirective : MapDirective
    {
        private SortedDictionary<string, dynamic> m_items = new SortedDictionary<string, dynamic>();
        private int m_index = 0;

        public override dynamic Do(MapState state, dynamic arg)
        {
            var key = GenerateKey();
            m_items[key] = arg;

            state.Add("key", key);

            return null;
        }

        public override void Undo(dynamic state)
        {
            m_items.Remove(state.key);
        }

        public IEnumerable<dynamic> Items => m_items.Values;

        private string GenerateKey()
        {
            m_index++;

            return m_index.ToString("X16");
        }
    }

    public class MapController : BaseController
    {
        public static Lazy<MapController> Instance = new Lazy<MapController>(() => new MapController());

        private Dictionary<string, MapDirective> m_directives = new Dictionary<string, MapDirective>();

        private Dictionary<string, KeyDirective> m_keyDirectives = new Dictionary<string, KeyDirective>();

        private MapController(): base(nameof(MapController))
        {
            RegisterScript(this);

            EventHandlers["getMapDirectives"] += new Action<dynamic>(GetMapDirectives);
        }

        public void GetMapDirectives(dynamic add)
        {
            foreach (var directive in m_directives)
            {
                var d = directive.Value;

                add(directive.Key, new Func<dynamic, dynamic, dynamic>((state, arg) =>
                {
                    return d.Do(new MapState(state), arg);
                }), new Func<dynamic, dynamic>(state =>
                {
                    d.Undo(state);
                    return null;
                }));
            }
        }

        public void RegisterDirective(string key, MapDirective directive)
        {
            m_directives[key] = directive;
        }

        public void RegisterKeyDirective(string key)
        {
            var kd = new KeyDirective();
            m_keyDirectives[key] = kd;

            RegisterDirective(key, kd);
        }

        public IEnumerable<dynamic> GetDirectives(string key)
        {
            if (!m_keyDirectives.ContainsKey(key))
            {
                return new dynamic[0];
            }

            return m_keyDirectives[key].Items;
        }
    }
}
