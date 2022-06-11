﻿using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/requests/">request</see> API endpoint.
    /// </summary>
    public class RequestHandler : BaseHandler<Request, PredefinedRequestFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me project handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/requests", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me project handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RequestHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/requests", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Affected service level agreements

        /// <summary>
        /// Get a list of affected service level agreements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<AffectedServiceLevelAgreement> GetAffectedServiceLevelAgreements(Request request, params string[] fieldNames)
        {
            return GetChildHandler<AffectedServiceLevelAgreement>(request, "affected_slas").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        /// <summary>
        /// Get all configuration item related to a request.
        /// </summary>
        /// <param name="request">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(Request request, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(request, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all configuration item related to a request.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="request">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Request request, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(request, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return CreateRelation(request, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item from a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(Request request, ConfigurationItem configurationItem)
        {
            return DeleteRelation(request, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items from a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItems(Request request)
        {
            return DeleteAllRelations(request, "cis");
        }

        #endregion

        #region Grouped requests

        /// <summary>
        /// Get all grouped requests of the request group.
        /// </summary>
        /// <param name="requestGroup">The request group.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetGroupedRequests(Request requestGroup, params string[] fieldNames)
        {
            return GetChildHandler<Request>(requestGroup, "grouped_requests").Get(fieldNames);
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Request request, params string[] fieldNames)
        {
            return GetChildHandler<Note>(request, "notes", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Get all notes related to a request.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="request">The request.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(PredefinedRequestNoteFilter filter, Request request, params string[] fieldNames)
        {
            return GetChildHandler<Note>(request, $"notes/{filter.To4meString()}", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Satisfaction

        /// <summary>
        /// The requester is satisfied with the manner in which the given request has been handled.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool Satisfied(Request request)
        {
            return GetChildHandler<RequestDissatisfied>(request, "satisfied").InvokeNoContent("Post");
        }

        /// <summary>
        /// The requester is dissatisfied with the manner in which the given request has been handled.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="dissatisfied">The dissatisfied reason and action.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool Dissatisfied(Request request, RequestDissatisfied dissatisfied)
        {
            return GetChildHandler<RequestDissatisfied>(request, "dissatisfied").Insert(dissatisfied) is null;
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The archived request.</returns>
        public Request Archive(Request request)
        {
            return GetChildHandler<Request>(request, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The trashed request.</returns>
        public Request Trash(Request request)
        {
            return GetChildHandler<Request>(request, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a request.
        /// </summary>
        /// <param name="archive">The archived request.</param>
        /// <returns>The restored request.</returns>
        public Request Restore(Archive archive)
        {
            return GetChildHandler<Request>(new Request() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a request.
        /// </summary>
        /// <param name="trash">The trashed request.</param>
        /// <returns>The restored request.</returns>
        public Request Restore(Trash trash)
        {
            return GetChildHandler<Request>(new Request() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
