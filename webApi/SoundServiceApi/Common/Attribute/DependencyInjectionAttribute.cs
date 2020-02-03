using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class DependencyInjectionAttribute : System.Attribute
    {
        public DependencyInjectionAttribute(Type _t)
        {
            var t = _t;
        }
    }
}
