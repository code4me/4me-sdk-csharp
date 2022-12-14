using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/shop_order_lines/">shop order line</see> object.
    /// </summary>
    public class ShopOrderLine : CustomFieldsBaseItem
    {
        private DateTime? completedAt;
        private string deliveryAddress;
        private string deliveryCity;
        private string deliveryCountry;
        private string deliveryState;
        private string deliveryZip;
        private Request fulfillmentRequest;
        private Task fulfillmentTask;
        private RequestTemplate fulfillmentTemplate;
        private string name;
        private Request order;
        private DateTime? orderedAt;
        private float price;
        private string priceCurrency;
        private ShopRecurringPeriod? recurringPeriod;
        private float? recurringPrice;
        private string recurringPriceCurrency;
        private DateTime? providerOrderedAt;
        private float providerPrice;
        private string providerPriceCurrency;
        private ShopRecurringPeriod? providerRecurringPeriod;
        private float? providerRecurringPrice;
        private string providerRecurringPriceCurrency;
        private float quantity;
        private float providerTotalPrice;
        private float? providerTotalRecurringPrice;
        private Person requestedFor;
        private string shopArticle;
        private string source;
        private string sourceID;
        private ShopOrderLineStatus status;
        private float totalPrice;
        private float? totalRecurringPrice;

        #region Completed at

        /// <summary>
        /// The date and time at which the shop order line was completed.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime? CompletedAt
        {
            get => completedAt;
            internal set => completedAt = value;
        }

        #endregion

        #region Delivery address

        /// <summary>
        /// The delivery address lines.
        /// </summary>
        [JsonProperty("delivery_address")]
        public string DeliveryAddress
        {
            get => deliveryAddress;
            internal set => deliveryAddress = value;
        }

        #endregion

        #region Delivery city

        /// <summary>
        /// The delivery city name.
        /// </summary>
        [JsonProperty("delivery_city")]
        public string DeliveryCity
        {
            get => deliveryCity;
            internal set => deliveryCity = value;
        }

        #endregion

        #region Delivery country

        /// <summary>
        /// The delivery country name.
        /// </summary>
        [JsonProperty("delivery_country")]
        public string DeliveryCountry
        {
            get => deliveryCountry;
            internal set => deliveryCountry = value;
        }

        #endregion

        #region Delivery state

        /// <summary>
        /// The delivery state name.
        /// </summary>
        [JsonProperty("delivery_state")]
        public string DeliveryState
        {
            get => deliveryState;
            internal set => deliveryState = value;
        }

        #endregion

        #region Delivery zip

        /// <summary>
        /// The delivery zip code.
        /// </summary>
        [JsonProperty("delivery_zip")]
        public string DeliveryZip
        {
            get => deliveryZip;
            internal set => deliveryZip = value;
        }

        #endregion

        #region Fulfillment request

        /// <summary>
        /// The request generated for the fulfillment of this shop order line.
        /// </summary>
        [JsonProperty("fulfillment_request")]
        public Request FulfillmentRequest
        {
            get => fulfillmentRequest;
            internal set => fulfillmentRequest = value;
        }

        [JsonProperty("fulfillment_request_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FulfillmentRequestID => fulfillmentRequest?.ID;

        #endregion

        #region Fulfillment task

        /// <summary>
        /// The fulfillment task in the order workflow related to this shop order line.
        /// </summary>
        [JsonProperty("fulfillment_task")]
        public Task FulfillmentTask
        {
            get => fulfillmentTask;
            internal set => fulfillmentTask = value;
        }

        [JsonProperty("fulfillment_task_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FulfillmentTaskID => fulfillmentTask?.ID;

        #endregion

        #region Fulfillment template

        /// <summary>
        /// The request template linked to the fulfillment task used to generate the fulfillment request.
        /// </summary>
        [JsonProperty("fulfillment_template")]
        public RequestTemplate FulfillmentTemplate
        {
            get => fulfillmentTemplate;
            internal set => fulfillmentTemplate = value;
        }

        [JsonProperty("fulfillment_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FulfillmentTemplateID => fulfillmentTemplate?.ID;

        #endregion

        #region Name

        /// <summary>
        /// The Name of the shop order line.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region Order

        /// <summary>
        /// The order request related to this shop order line.
        /// </summary>
        [JsonProperty("order")]
        public Request Order
        {
            get => order;
            internal set => order = value;
        }

        [JsonProperty("order_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? OrderID => order?.ID;

        #endregion

        #region Ordered at

        /// <summary>
        /// The date and time at which the shop article was ordered. This corresponds to the time the order request was registered by the user.
        /// </summary>
        [JsonProperty("ordered_at")]
        public DateTime? OrderedAt
        {
            get => orderedAt;
            internal set => orderedAt = value;
        }

        #endregion

        #region Price

        /// <summary>
        /// The price to be charged per unit at the time the shop article was ordered.
        /// </summary>
        [JsonProperty("price")]
        public float Price
        {
            get => price;
            internal set => price = value;
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
            internal set => priceCurrency = value;
        }

        #endregion

        #region Recurring period

        /// <summary>
        /// The Recurring period field is used to select the interval for the recurring price. 
        /// </summary>
        [JsonProperty("recurring_period")]
        public ShopRecurringPeriod? RecurringPeriod
        {
            get => recurringPeriod;
            internal set => recurringPeriod = value;
        }

        #endregion

        #region Recurring price

        /// <summary>
        /// The recurring price to be charged recurrently per unit for the shop article that was ordered.
        /// </summary>
        [JsonProperty("recurring_price")]
        public float? RecurringPrice
        {
            get => recurringPrice;
            internal set => recurringPrice = value;
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
            internal set => recurringPriceCurrency = value;
        }

        #endregion

        #region Provider ordered at

        /// <summary>
        /// The date and time at which the shop article was ordered at the provider. This corresponds to the time at which the fulfillment request was generated.
        /// </summary>
        [JsonProperty("provider_ordered_at")]
        public DateTime? ProviderOrderedAt
        {
            get => providerOrderedAt;
            internal set => providerOrderedAt = value;
        }

        #endregion

        #region Provider price

        /// <summary>
        /// The price to be charged by the provider per unit at the time the shop article was ordered.
        /// </summary>
        [JsonProperty("provider_price")]
        public float ProviderPrice
        {
            get => providerPrice;
            internal set => providerPrice = value;
        }

        #endregion

        #region Provider price currency

        /// <summary>
        /// The currency of the provider price.
        /// </summary>
        [JsonProperty("provider_price_currency")]
        public string ProviderPriceCurrency
        {
            get => providerPriceCurrency;
            internal set => providerPriceCurrency = value;
        }

        #endregion

        #region Provider recurring period

        /// <summary>
        /// The Recurring period field is used to select the interval for the provider recurring price. 
        /// </summary>
        [JsonProperty("provider_recurring_period")]
        public ShopRecurringPeriod? ProviderRecurringPeriod
        {
            get => providerRecurringPeriod;
            internal set => providerRecurringPeriod = value;
        }

        #endregion

        #region Provider recurring price

        /// <summary>
        /// The recurring price to be charged recurrently per unit by the provider for the shop article that was ordered.
        /// </summary>
        [JsonProperty("provider_recurring_price")]
        public float? ProviderRecurringPrice
        {
            get => providerRecurringPrice;
            internal set => providerRecurringPrice = value;
        }

        #endregion

        #region Provider recurring price currency

        /// <summary>
        /// The currency of the provider recurrent price.
        /// </summary>
        [JsonProperty("provider_recurring_price_currency")]
        public string ProviderRecurringPriceCurrency
        {
            get => providerRecurringPriceCurrency;
            internal set => providerRecurringPriceCurrency = value;
        }

        #endregion

        #region Quantity

        /// <summary>
        /// The Quantity field is used to enter the number of units of the shop article that is being ordered.
        /// </summary>
        [JsonProperty("quantity")]
        public float Quantity
        {
            get => quantity;
            set => quantity = SetValue("quantity", quantity, value);
        }

        #endregion

        #region Provider total price

        /// <summary>
        /// The total (non-recurrent) price to be charged by the provider for all units combined.
        /// </summary>
        [JsonProperty("provider_total_price")]
        public float ProviderTotalPrice
        {
            get => providerTotalPrice;
            internal set => providerTotalPrice = value;
        }

        #endregion

        #region Provider total recurring price

        /// <summary>
        /// The total yearly recurrent price to be charged by the provider for all units combined.
        /// </summary>
        [JsonProperty("provider_total_recurring_price")]
        public float? ProviderTotalRecurringPrice
        {
            get => providerTotalRecurringPrice;
            internal set => providerTotalRecurringPrice = value;
        }

        #endregion

        #region Requested for

        /// <summary>
        /// The person who submitted the order.
        /// </summary>
        [JsonProperty("requested_for")]
        public Person RequestedFor
        {
            get => requestedFor;
            internal set => requestedFor = value;
        }

        [JsonProperty("requested_for_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestedForID => requestedFor?.ID;

        #endregion

        #region Shop article

        /// <summary>
        /// The reference of the shop article that was ordered.
        /// </summary>
        [JsonProperty("shop_article")]
        public string ShopArticle
        {
            get => shopArticle;
            internal set => shopArticle = value;
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
            internal set => source = value;
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
            internal set => sourceID = value;
        }

        #endregion

        #region Status

        /// <summary>
        /// The status of the shop order line. 
        /// </summary>
        [JsonProperty("status")]
        public ShopOrderLineStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region Total price

        /// <summary>
        /// The total (non-recurrent) price to be charged for all units combined.
        /// </summary>
        [JsonProperty("total_price")]
        public float TotalPrice
        {
            get => totalPrice;
            internal set => totalPrice = value;
        }

        #endregion

        #region Total recurring price

        /// <summary>
        /// The total yearly recurrent price to be charged for all units combined.
        /// </summary>
        [JsonProperty("total_recurring_price")]
        public float? TotalRecurringPrice
        {
            get => totalRecurringPrice;
            internal set => totalRecurringPrice = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            fulfillmentRequest?.ResetPropertySerializationCollection();
            fulfillmentTask?.ResetPropertySerializationCollection();
            fulfillmentTemplate?.ResetPropertySerializationCollection();
            requestedFor?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
