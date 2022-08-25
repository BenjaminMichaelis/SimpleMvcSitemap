using System.Collections.Generic;

namespace DotnetSitemapGenerator.Website.SampleBusiness
{
    public interface ISampleSitemapNodeBuilder
    {
        IEnumerable<SitemapIndexNode> BuildSitemapIndex();
        SitemapModel BuildSitemapModel();
    }
}