using System.Text.RegularExpressions;

namespace Sdk4me
{
    internal class LinkHeader
    {
        private string firstLink = null;
        private string previousLink = null;
        private string nextLink = null;

        public string FirstLink
        {
            get => firstLink;
            set => firstLink = value;
        }

        public string PreviousLink
        {
            get => previousLink;
            set => previousLink = value;
        }

        public string NextLink
        {
            get => nextLink;
            set => nextLink = value;
        }

        public static LinkHeader LinksFromHeader(string linkHeader)
        {
            LinkHeader retval = new LinkHeader();

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
