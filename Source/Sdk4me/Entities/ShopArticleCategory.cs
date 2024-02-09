using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/shop_article_categories/">shop article categories</see> object.
    /// </summary>
    public class ShopArticleCategory : BaseItem
    {
        private string fullDescription;
        private string name;
        private string pictureUri;
        private string shortDescription;
        private string source;
        private string sourceID;

        #region Full description

        /// <summary>
        /// The Full description field is used to enter a description of the shop article category.
        /// </summary>
        [JsonProperty("full_description")]
        public string FullDescription
        {
            get => fullDescription;
            set => fullDescription = SetValue("full_description", fullDescription, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the shop article category.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the shop article category.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Short description

        /// <summary>
        /// The Short description field is used to enter the a plain text short description to promote the shop article category.
        /// </summary>
        [JsonProperty("short_description")]
        public string ShortDescription
        {
            get => shortDescription;
            set => shortDescription = SetValue("short_description", shortDescription, value);
        }

        #endregion

        #region Source

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion
    }
}
