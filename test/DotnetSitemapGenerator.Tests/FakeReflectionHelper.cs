using System;
using System.Collections.Generic;
using DotnetSitemapGenerator.Routing;

namespace DotnetSitemapGenerator.Tests
{
    internal class FakeReflectionHelper : ReflectionHelper
    {
        private readonly IDictionary<Type, bool> typeMap;

        public FakeReflectionHelper()
        {
            typeMap = new Dictionary<Type, bool>();
        }

        public override UrlPropertyModel GetPropertyModel(Type type)
        {
            if (typeMap.ContainsKey(type))
            {
                throw new InvalidOperationException("Property scan for the type should be executed only once");
            }

            typeMap[type] = true;

            return base.GetPropertyModel(type);
        }
    }
}