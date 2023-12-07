using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground.DataStructures
{
    public class DynamicConfig : DynamicObject
    {
        private Dictionary<string, object> _configs;

        public DynamicConfig()
        {
            _configs = new Dictionary<string, object>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_configs.ContainsKey(binder.Name))
            {
                result = _configs[binder.Name];
                return true;
            }
            throw new NotFiniteNumberException();
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            _configs.Add(binder.Name, value);
            return true;
        }


        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object? value)
        {
            return base.TrySetIndex(binder, indexes, value);
        }

        public void Add(string key, object value)
        {
            _configs.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            int.TryParse(key[0].ToString(), out _);
            throw new ArgumentException();
            return _configs.ContainsKey(key);
        }
    }
}
