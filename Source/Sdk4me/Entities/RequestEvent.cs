using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/requests/events/">request event</see> object.
    /// </summary>
    public class RequestEvent
    {
        /// <summary>
        /// <para>Used to specify an option in the category field of the request. The available field options can be found in the Fields section of the Requests API page.</para>
        /// <br>By default set to incident if a service instance is to be related to the request. Otherwise, set to other.</br>
        /// </summary>
        public RequestCategory Category { get; set; }

        /// <summary>
        /// <para>Used to specify the configuration item that is to be related to the request.</para>
        /// <br>The <see cref="Sdk4me.ConfigurationItem"/>.ID value will be used during creation.</br>
        /// <br>When 0, The configuration item needs to be identified by its <see cref="Sdk4me.ConfigurationItem"/>.Label or, in case of a software CI, its <see cref="Sdk4me.ConfigurationItem"/>.Name field value.</br>
        /// </summary>
        public ConfigurationItem ConfigurationItem { get; set; }

        /// <summary>
        /// <br>Used together with the <see cref="ConfigurationItemSourceID"/> parameter to specify the configuration item that is to be related to the request.</br>
        /// <br>This parameter should be used to specify the configuration item’s Source field value.</br>
        /// </summary>
        public string ConfigurationItemSource { get; set; }

        /// <summary>
        /// <br>Used together with the optional <see cref="ConfigurationItemSource"/> parameter to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration item needs to be defined using its Source ID field value.</br>
        /// </summary>
        public string ConfigurationItemSourceID { get; set; }

        /// <summary>
        /// Used to specify an option in the Completion reason field of the request when its Status field is set to 'completed'.
        /// </summary>
        public RequestCompletionReason CompletionReason { get; set; }

        /// <summary>
        /// <para>Used to specify the date and time that has been agreed on for the completion of the request.</para>
        /// <br>The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA’s resolution target.</br>
        /// <br>By default, the requested_by receives a notification based on the 'Desired Completion Set for Request' email template whenever the value is set, updated or removed.</br>
        /// </summary>
        public DateTime? DesiredCompletionAt { get; set; }

        /// <summary>
        /// Used to specify the end date and time of a service outage.
        /// </summary>
        public DateTime? DownTimeEndAt { get; set; }

        /// <summary>
        /// Used to specify the start date and time of a service outage.
        /// </summary>
        public DateTime? DownTimeStartAt { get; set; }

        /// <summary>
        /// Used to specify an option in the Impact field of the request.
        /// <br>By default set to top if category is incident. Otherwise the Impact field of the request is left empty.</br>
        /// </summary>
        public RequestImpact Impact { get; set; }

        /// <summary>
        /// Used to provide the text that needs to be added as an Internal Note to the request.
        /// </summary>
        public string InternalNote { get; set; }

        /// <summary>
        /// <para>Used to specify the person to which the request is to be assigned.</para>
        /// <br>By default set to the current user if a valid member is not provided and a status is specified that causes the Member field of the request to be required.</br>
        /// <br>When the template_id parameter is used and the request template is linked to a workflow template, then the Member field of the request is set to the manager of the workflow.</br>
        /// <br>The ID will be used during creation. When 0, it will use the name.</br>
        /// </summary>
        public Person Member { get; set; }

        /// <summary>
        /// Used to provide the text that needs to be added as a Note to the request.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// <para>Used to specify the problem that is to be related to the request.</para>
        /// <br>The <see cref="Sdk4me.Problem"/>.ID value will be used during creation.</br>
        /// </summary>
        public Problem Problem { get; set; }

        /// <summary>
        /// <para>Used to specify the person who is to be selected in the Requested for field of the request.</para>
        /// <br>The <see cref="Person"/>.ID value will be used during creation. When 0, it will use the <see cref="Person"/>.Name.</br>
        /// <br>By default set to the current user.</br>
        /// </summary>
        public Person RequestedFor { get; set; }

        /// <summary>
        /// <para>Used to specify the service instance that is to be related to the request.</para>
        /// <br>The <see cref="Sdk4me.ServiceInstance"/>.ID value will be used during creation. When 0, it will use the <see cref="Sdk4me.ServiceInstance"/>.Name.</br>
        /// <br>By default set to the first service instance of the configuration item when a configuration item is specified for the request.</br>
        /// </summary>
        public ServiceInstance ServiceInstance { get; set; }

        /// <summary>
        /// <para>Used to specify the name of the monitoring tool. After the request has been created, this value is visible in its Audit Trail.</para>
        /// <br>By default set to Event.</br>
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Used to specify the unique ID of the event for which the request is to be registered. After the request has been created, this value is visible in its Audit Trail.
        /// </summary>
        public string SourceID { get; set; }

        /// <summary>
        /// <para>Used to specify an option in the Status field of the request.</para>
        /// <br>By default set to assigned. When the template_id parameter is used and the request template is linked to a workflow template, then set to workflow_pending.</br>
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Used to specify the Subject of the request.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// <para>Used to specify the Organization to which the request has been submitted.</para>
        /// <br>The <see cref="Organization"/>.ID value will be used during creation. When 0, it will use the <see cref="Organization"/>.Name.</br>
        /// </summary>
        public Organization Supplier { get; set; }

        /// <summary>
        /// Used to specify the identifier under which the request has been registered at the supplier organization.
        /// </summary>
        public string SupplierRequestID { get; set; }

        /// <summary>
        /// Used to specify the support domain account in which the request is to be registered. This parameter needs to be specified when the current user’s Person record is registered in a directory account.
        /// </summary>
        public AccountReference SupportDomain { get; set; }

        /// <summary>
        /// <para>Used to specify the team to which the request is to be assigned.</para>
        /// <br>The <see cref="Sdk4me.Team"/>.ID value will be used during creation. When 0, it will use the <see cref="Sdk4me.Team"/>.Name.</br>
        /// <br>By default, the team to which the person specified as the member belongs.</br>
        /// <br>Otherwise, if a service instance is to be related to the request, the First Line Team of this service instance or, if a First Line Team is not specified or the current user is a member of the First Line Team or the Support Team, the Support Team of this service instance.</br>
        /// <br>Else, set to the Service Desk Team of the first line support agreement that covers the account of the person selected in the Requested for field. Note: if an invalid team was specified in the API call, the default team is selected in the request.</br>
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// <para>Used to specify the request template that is to be applied to the request.</para>
        /// <br>The <see cref="Sdk4me.RequestTemplate"/>.ID value will be used during creation.</br>
        /// </summary>
        public RequestTemplate RequestTemplate { get; set; }

        /// <summary>
        /// Used to specify the date and time at which the status of the request is to be updated from waiting_for to assigned.
        /// </summary>
        public DateTime? WaitUntil { get; set; }

        /// <summary>
        /// <para>Used to specify the workflow that is to be related to the request.</para>
        /// <br>The <see cref="Sdk4me.Workflow"/>.ID value will be used during creation.</br>
        /// </summary>
        public Workflow Workflow { get; set; }
    }
}
