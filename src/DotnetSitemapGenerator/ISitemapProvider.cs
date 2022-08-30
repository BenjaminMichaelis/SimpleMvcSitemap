using Microsoft.AspNetCore.Mvc;

namespace DotnetSitemapGenerator
{
    /// <summary>
    /// Provides sitemap files that can be returned from the controllers.
    /// </summary>
    public interface ISitemapProvider
    {
        /// <summary>
        /// Creates a sitemap file.
        /// </summary>
        /// <param name="sitemapModel">The sitemap model</param>
        ActionResult CreateSitemap(SitemapModel sitemapModel);

        /// <summary>
        /// Creates a physical sitemap file.
        /// </summary>
        /// <param name="sitemapModel">The <see cref="SitemapModel"/> to parse into a file.</param>
        /// <param name="fileLocation">The file name for the resulting file (preferably a .xml file)</param>
        ActionResult CreateSitemap(SitemapModel sitemapModel, string fileLocation);

        /// <summary>
        /// Creates a sitemap index file.
        /// </summary>
        /// <param name="sitemapIndexModel">The sitemap index model</param>
        ActionResult CreateSitemapIndex(SitemapIndexModel sitemapIndexModel);
    }
}