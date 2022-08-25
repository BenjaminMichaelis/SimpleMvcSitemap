using System;
using DotnetSitemapGenerator.Routing;

namespace DotnetSitemapGenerator.Website.SampleBusiness
{
    public class BaseUrlProvider : IBaseUrlProvider
    {
        public Uri BaseUrl => new Uri("http://example.com");
    }
}