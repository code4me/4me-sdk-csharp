using Sdk4me.Extensions;
using System;
using System.Linq;
using System.Text;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/requests/events/">request event</see> API endpoint.
    /// </summary>
    public class RequestEventHandler : IBaseHandler
    {
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly string url = null;
        private int itemsPerRequest = 25;
        private int maximumRecursiveRequests = 10;
        private bool addAmpersand = false;

        /// <summary>
        /// <para>Gets or sets the number of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 25 : value;
        }

        /// <summary>
        /// <para>Gets or sets the number of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 10 : value;
        }

        /// <summary>
        /// Create a new instance of the 4me request event handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestEventHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me request event handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestEventHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            //validate string argument values
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));

            //validate authentication tokens
            if (authenticationTokens is null)
                throw new ArgumentNullException(nameof(authenticationTokens));

            if (!authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be empty.", nameof(authenticationTokens));

            //set global variables
            url = $"{EnvironmentURL.Get(environment, environmentRegion)}";
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 25 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 10 : maximumRecursiveRequests;
        }

        /// <summary>
        /// Create a new request event.
        /// </summary>
        /// <param name="event">The request event details.</param>
        /// <returns>A new or already existing request.</returns>
        public Request Create(RequestEvent @event)
        {
            return Create(@event, true);
        }

        /// <summary>
        /// Create a new request event.
        /// </summary>
        /// <param name="event">The request event details.</param>
        /// <param name="throwExecption">True to throw an exception in case of the values is incorrect; false to ignore the value.</param>
        /// <returns>A new or already existing request.</returns>
        public Request Create(RequestEvent @event, bool throwExecption)
        {
            StringBuilder builder = new StringBuilder();

            //add category
            if (@event.Category != 0)
                Append(builder, "category", @event.Category.To4meString());

            //add ci
            if (@event.ConfigurationItem != null)
            {
                if (@event.ConfigurationItem.ID != 0)
                    Append(builder, "ci_id", @event.ConfigurationItem.ID);
                else if (@event.ConfigurationItem.RuleSet == ConfigurationItemRuleSet.Software && !string.IsNullOrWhiteSpace(@event.ConfigurationItem.Name))
                    Append(builder, "ci_id", @event.ConfigurationItem.Name);
                else if (!string.IsNullOrWhiteSpace(@event.ConfigurationItem.Label))
                    Append(builder, "ci_id", @event.ConfigurationItem.Label);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID, Label or Name) in configuration item reference.");
            }

            //add ci source and sourceID
            if (!string.IsNullOrEmpty(@event.ConfigurationItemSource) && !string.IsNullOrEmpty(@event.ConfigurationItemSourceID))
            {
                Append(builder, "ci_source", @event.ConfigurationItemSource);
                Append(builder, "ci_sourceID", @event.ConfigurationItemSourceID);
            }

            //add completion reason
            if (@event.CompletionReason != 0)
                Append(builder, "completion_reason", @event.CompletionReason.To4meString());

            //add desired completion at
            if (@event.DesiredCompletionAt.HasValue)
                Append(builder, "desired_completion_at", @event.DesiredCompletionAt.Value);

            //add downtime end at
            if (@event.DownTimeEndAt.HasValue)
                Append(builder, "downtime_end_at", @event.DownTimeEndAt.Value);

            //add downtime start at
            if (@event.DownTimeStartAt.HasValue)
                Append(builder, "downtime_end_at", @event.DownTimeStartAt.Value);

            //add impact
            if (@event.Impact != 0)
                Append(builder, "impact", @event.Impact.To4meString());

            //add internal note
            if (!string.IsNullOrEmpty(@event.InternalNote))
                Append(builder, "internal_note", @event.InternalNote);

            //add member
            if (@event.Member != null)
            {
                if (@event.Member.ID != 0)
                    Append(builder, "member_id", @event.Member.ID);
                else if(!string.IsNullOrEmpty(@event.Member.PrimaryEmail))
                    Append(builder, "member", @event.Member.PrimaryEmail);
                else if(throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID or PrimaryEmail) in member reference.");
            }

            //add note
            if (!string.IsNullOrEmpty(@event.Note))
                Append(builder, "note", @event.Note);

            //add problem
            if (@event.Problem != null)
            {
                if (@event.Problem.ID != 0)
                    Append(builder, "problem_id", @event.Problem.ID);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID) in problem reference.");
            }

            //add requested for
            if (@event.RequestedFor != null)
            {
                if (@event.RequestedFor.ID != 0)
                    Append(builder, "requested_for_id", @event.RequestedFor.ID);
                else if (!string.IsNullOrEmpty(@event.RequestedFor.PrimaryEmail))
                    Append(builder, "requested_for", @event.RequestedFor.PrimaryEmail);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID or PrimaryEmail) in requested for reference.");
            }

            //add service instance
            if (@event.ServiceInstance != null)
            {
                if (@event.ServiceInstance.ID != 0)
                    Append(builder, "service_instance_id", @event.ServiceInstance.ID);
                else if (!string.IsNullOrEmpty(@event.ServiceInstance.Name))
                    Append(builder, "service_instance", @event.ServiceInstance.Name);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID or Name) in service instance reference.");
            }

            //add source
            if (!string.IsNullOrEmpty(@event.Source))
                Append(builder, "source", @event.Source);

            //add sourceID
            if (!string.IsNullOrEmpty(@event.SourceID))
                Append(builder, "source_id", @event.SourceID);
            
            //add status
            if (@event.Status != 0)
                Append(builder, "status", @event.Status.To4meString());

            //add note
            if (!string.IsNullOrEmpty(@event.Subject))
                Append(builder, "subject", @event.Subject);

            //add supplier
            if (@event.Supplier != null)
            {
                if (@event.Supplier.ID != 0)
                    Append(builder, "supplier_id", @event.Supplier.ID);
                else if (!string.IsNullOrEmpty(@event.Supplier.Name))
                    Append(builder, "supplier", @event.Supplier.Name);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID or Name) in supplier reference.");
            }

            //add supplier request ID
            if (!string.IsNullOrEmpty(@event.SupplierRequestID))
                Append(builder, "supplier_requestID", @event.SupplierRequestID);

            //add support domain
            if (@event.SupportDomain != null)
            {
                if (!string.IsNullOrEmpty(@event.SupportDomain.ID))
                    Append(builder, "support_domain", @event.SupportDomain.ID);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID) in support domain reference.");
            }

            //Add team
            if (@event.Team != null)
            {
                if (@event.Team.ID != 0)
                    Append(builder, "team_id", @event.Team.ID);
                else if (!string.IsNullOrEmpty(@event.Team.Name))
                    Append(builder, "team", @event.Team.Name);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID or Name) in team reference.");
            }

            //add template id
            if (@event.RequestTemplate != null)
            {
                if (@event.RequestTemplate.ID != 0)
                    Append(builder, "template_id", @event.RequestTemplate.ID);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID) in workflow reference.");
            }

            //waiting_until
            if (@event.WaitUntil.HasValue)
                Append(builder, "waiting_until", @event.WaitUntil.Value);

            //add workflow id
            if (@event.Workflow != null)
            {
                if (@event.Workflow.ID != 0)
                    Append(builder, "workflow_id", @event.Workflow.ID);
                else if (throwExecption)
                    throw new Sdk4meException("Missing or invalid value (ID) in workflow reference.");
            }

            return new DefaultBaseHandler<Request>($"{url}/events?{builder}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests).Invoke("Post");
        }

        private void Append(StringBuilder builder, string name, long value)
        {
            Append(builder, name, value.ToString());
        }

        private void Append(StringBuilder builder, string name, DateTime value)
        {
            Append(builder, name, value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
        }

        private void Append(StringBuilder builder, string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
                return;

            if (addAmpersand)
                builder.Append('&');
            builder.Append($"{name}={Uri.EscapeDataString(value)}");
            addAmpersand = true;
        }
    }
}
