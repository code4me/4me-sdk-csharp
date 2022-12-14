using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/shop_articles/">shop article</see> object.
    /// </summary>
    public class ShopArticle : BaseItem
    {
        private Calendar calendar;
        private int deliveryDuration;
        private bool disabled;
        private DateTime? endAt;
        private RequestTemplate fulfillmentTemplate;
        private string fullDescription;
        private float? maxQuantity;
        private string name;
        private string pictureUri;
        private float? price;
        private string priceCurrency;
        private Product product;
        private ShopRecurringPeriod? recurringPeriod;
        private float? recurringPrice;
        private string recurringPriceCurrency;
        private string reference;
        private bool requiresShipping;
        private string shortDescription;
        private DateTime? startAt;
        private string source;
        private string sourceID;
        private string timeZone;
        private UIExtension uiExtension;

        #region Calendar

        /// <summary>
        /// The Calendar field is used to select the Calendar that defines the work hours related to the fulfillment/delivery.
        /// </summary>
        [JsonProperty("calendar")]
        public Calendar Calendar
        {
            get => calendar;
            set => calendar = SetValue("calendar_id", calendar, value);
        }

        [JsonProperty("calendar_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CalendarID => calendar?.ID;

        #endregion

        #region Delivery duration

        /// <summary>
        /// The Delivery duration field is used to specify the time it takes to deliver the shop article.
        /// </summary>
        [JsonProperty("delivery_duration")]
        public int DeliveryDuration
        {
            get => deliveryDuration;
            set => deliveryDuration = SetValue("delivery_duration", deliveryDuration, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the shop article is not visible in the shop.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region End at

        /// <summary>
        /// The End field is used to select the end date and time at which the article needs to be disabled and thereby removed from the shop.
        /// </summary>
        [JsonProperty("end_at")]
        public DateTime? EndAt
        {
            get => endAt;
            set => endAt = SetValue("end_at", endAt, value);
        }

        #endregion

        #region Fulfillment template

        /// <summary>
        /// The fulfillment template related to the shop article. The request template is used to order one of more units of this shop article.
        /// </summary>
        [JsonProperty("fulfillment_template")]
        public RequestTemplate FulfillmentTemplate
        {
            get => fulfillmentTemplate;
            set => fulfillmentTemplate = SetValue("fulfillment_template_id", fulfillmentTemplate, value);
        }

        [JsonProperty("fulfillment_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FulfillmentTemplateID => fulfillmentTemplate?.ID;

        #endregion

        #region Full description

        /// <summary>
        /// The Full description field is used to enter a description of the shop article.
        /// </summary>
        [JsonProperty("full_description")]
        public string FullDescription
        {
            get => fullDescription;
            set => fullDescription = SetValue("full_description", fullDescription, value);
        }

        #endregion

        #region Max quantity

        /// <summary>
        /// The Quantity field is used to enter the maximum number of units that are allowed to be ordered in a single fulfillment request.
        /// </summary>
        [JsonProperty("max_quantity")]
        public float? MaxQuantity
        {
            get => maxQuantity;
            set => maxQuantity = SetValue("max_quantity", maxQuantity, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the shop article.
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
        /// The hyperlink to the image file for the shop article.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Price

        /// <summary>
        /// The Price field is used to enter the amount to be charged per unit that was ordered.
        /// </summary>
        [JsonProperty("price")]
        public float? Price
        {
            get => price;
            set => price = SetValue("price", price, value);
        }

        #endregion

        #region Price currency

        /// <summary>
        /// The currency of the price.
        /// </summary>
        [JsonProperty("price_currency")]
        public string PriceCurrency
        {
            get => priceCurrency;
            set => priceCurrency = SetValue("price_currency", priceCurrency, value);
        }

        #endregion

        #region Product

        /// <summary>
        /// The Product field can be used to relate the shop article to a product.
        /// </summary>
        [JsonProperty("product")]
        public Product Product
        {
            get => product;
            set => product = SetValue("product_id", product, value);
        }

        [JsonProperty("product_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProductID => product?.ID;

        #endregion

        #region Recurring period

        /// <summary>
        /// The Recurring period field is used to select the interval for a recurring price. 
        /// </summary>
        [JsonProperty("recurring_period")]
        public ShopRecurringPeriod? RecurringPeriod
        {
            get => recurringPeriod;
            set => recurringPeriod = SetValue("recurring_period", recurringPeriod, value);
        }

        #endregion

        #region Recurring price

        /// <summary>
        /// The Recurring price field is used to enter the amount to be charged recurrently per unit that was ordered.
        /// </summary>
        [JsonProperty("recurring_price")]
        public float? RecurringPrice
        {
            get => recurringPrice;
            set => recurringPrice = SetValue("recurring_price", recurringPrice, value);
        }

        #endregion

        #region Recurring price currency

        /// <summary>
        /// The currency of the recurrent price.
        /// </summary>
        [JsonProperty("recurring_price_currency")]
        public string RecurringPriceCurrency
        {
            get => recurringPriceCurrency;
            set => recurringPriceCurrency = SetValue("recurring_price_currency", recurringPriceCurrency, value);
        }

        #endregion

        #region Reference

        /// <summary>
        /// The Reference field can be used to identify the shop article. It must be unique within the account.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference
        {
            get => reference;
            set => reference = SetValue("reference", reference, value);
        }

        #endregion

        #region Requires shipping

        /// <summary>
        /// Set to the value true if the shop articles requires shipping and therefore a shipping address must be present in the order.
        /// </summary>
        [JsonProperty("requires_shipping")]
        public bool RequiresShipping
        {
            get => requiresShipping;
            set => requiresShipping = SetValue("requires_shipping", requiresShipping, value);
        }

        #endregion

        #region Short description

        /// <summary>
        /// The Short description field is used to enter the a plain text short description to promote the shop article.
        /// </summary>
        [JsonProperty("short_description")]
        public string ShortDescription
        {
            get => shortDescription;
            set => shortDescription = SetValue("short_description", shortDescription, value);
        }

        #endregion

        #region Start at

        /// <summary>
        /// The Start field is used to select the start date and time at which the article needs to be enabled and thereby become visible in the shop.
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime? StartAt
        {
            get => startAt;
            set => startAt = SetValue("start_at", startAt, value);
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

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected calendar.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field is used to select the UI extension that is to be filled out before the shop article is added to the cart.
        /// </summary>
        [JsonProperty("ui_extension")]
        public UIExtension UiExtension
        {
            get => uiExtension;
            set => uiExtension = SetValue("ui_extension_id", uiExtension, value);
        }

        [JsonProperty("ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UiExtensionID => uiExtension?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            calendar?.ResetPropertySerializationCollection();
            fulfillmentTemplate?.ResetPropertySerializationCollection();
            product?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
