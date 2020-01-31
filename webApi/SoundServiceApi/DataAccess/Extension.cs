using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public static class Extension
    {
        public static IDictionary<string, bool> Convert(this PlayingExtensionConfiguration m)
        {
            return m.GetType().GetProperties().ToDictionary(k => k.Name.ToLower(), v => (bool)v.GetValue(m));
        }
    }
}
