using System;

namespace DotnetSitemapGenerator.Routing
{
    internal interface IReflectionHelper
    {
        UrlPropertyModel GetPropertyModel(Type type);
    }
}