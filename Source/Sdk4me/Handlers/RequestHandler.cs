using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class RequestHandler : BaseHandler<Request, PredefinedRequestFilter>
    {
        public RequestHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/requests", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RequestHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/requests", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Affected service level agreements

        public List<AffectedServiceLevelAgreement> GetAffectedServiceLevelAgreements(Request request, params string[] fieldNames)
        {
            return GetChildHandler<AffectedServiceLevelAgreement>(request, "affected_slas").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(Request request, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(request, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Request request, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(request, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return CreateRelation(request, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return DeleteRelation(request, "cis", configurationItem);
        }

        public bool RemoveConfigurationItems(Request request)
        {
            return DeleteAllRelations(request, "cis");
        }

        #endregion

        #region Grouped requests

        public List<Request> GetGroupedRequests(Request requestGroup, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestGroup, "grouped_requests").Get(fieldNames);
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(Request request, params string[] fieldNames)
        {
            return GetChildHandler<Note>(request, "notes", SortOrder.None).Get(fieldNames);
        }

        public List<Note> GetNotes(PredefinedRequestNoteFilter filter, Request request, params string[] fieldNames)
        {
            return GetChildHandler<Note>(request, $"notes/{filter.To4meString()}", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Satisfaction

        public bool Satisfied(Request request)
        {
            return GetChildHandler<RequestDissatisfied>(request, "satisfied").InvokeNoContent("Post");
        }

        public bool Dissatisfied(Request request, RequestDissatisfied dissatisfied)
        {
            return GetChildHandler<RequestDissatisfied>(request, "dissatisfied").Insert(dissatisfied) is null;
        }

        #endregion

        #region Archive, trash and restore

        public Request Archive(Request request)
        {
            return GetChildHandler<Request>(request, "archive").Invoke("Post");
        }

        public Request Trash(Request request)
        {
            return GetChildHandler<Request>(request, "trash").Invoke("Post");
        }

        public Request Restore(Archive archive)
        {
            return GetChildHandler<Request>(new Request() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Request Restore(Trash trash)
        {
            return GetChildHandler<Request>(new Request() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
