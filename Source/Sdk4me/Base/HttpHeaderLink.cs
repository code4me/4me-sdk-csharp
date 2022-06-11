using System.Text.RegularExpressions;

namespace Sdk4me
{
    /// <summary>
    /// A HTTP header pagination link parser.
    /// </summary>
    internal class HttpHeaderLink
    {
        private string firstLink = null;
        private string previousLink = null;
        private string nextLink = null;

        /// <summary>
        /// Get the first pagination link.
        /// </summary>
        public string FirstLink
        {
            get => firstLink;
            protected set => firstLink = value;
        }

        /// <summary>
        /// Get the previous pagination link.
        /// </summary>
        public string PreviousLink
        {
            get => previousLink;
            protected set => previousLink = value;
        }

        /// <summary>
        /// Get the next pagination link.
        /// </summary>
        public string NextLink
        {
            get => nextLink;
            protected set => nextLink = value;
        }

        /// <summary>
        /// Returns the links specified in the HTTP response header.
        /// </summary>
        /// <param name="linkHeader">The parsed link header.</param>
        /// <returns>A <see cref="HttpHeaderLink"/> value.</returns>
        public static HttpHeaderLink GetLinksFromHeader(string linkHeader)
        {
            HttpHeaderLink retval = new HttpHeaderLink();

            if (!string.IsNullOrWhiteSpace(linkHeader))
            {
                string[] links = Regex.Split(linkHeader, ",(?![^<]*>)");
                if (links != null && links.GetUpperBound(0) > -1)
                {
                    foreach (string link in links)
                    {
                        Match relMatch = Regex.Match(link, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                        Match linkMatch = Regex.Match(link, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                        if (relMatch.Success && linkMatch.Success)
                        {
                            switch (relMatch.Value.ToLowerInvariant())
                            {
                                case "first":
                                    retval.FirstLink = linkMatch.Value;
                                    break;

                                case "prev":
                                    retval.PreviousLink = linkMatch.Value;
                                    break;

                                case "next":
                                    retval.NextLink = linkMatch.Value;
                                    break;
                            }
                        }
                    }
                }
            }

            return retval;
        }
    }
}
