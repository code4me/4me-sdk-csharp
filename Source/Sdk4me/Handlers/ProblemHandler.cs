using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/problems/">problem</see> API endpoint.
    /// </summary>
    public class ProblemHandler : BaseHandler<Problem, PredefinedProblemFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me problem handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProblemHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/problems", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me problem handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProblemHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/problems", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        /// <summary>
        /// Get all configuration item related to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(problem, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all configuration item related to a problem.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(problem, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(Problem problem, ConfigurationItem configurationItem)
        {
            return CreateRelation(problem, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration from a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(Problem problem, ConfigurationItem configurationItem)
        {
            return DeleteRelation(problem, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration item from a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllConfigurationItem(Problem problem)
        {
            return DeleteAllRelations(problem, "cis");
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Note>(problem, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Requests

        /// <summary>
        /// Get all requests related to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of requests.</returns>
        public List<Request> GetRequests(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(problem, "requests").Get(fieldNames);
        }

        /// <summary>
        /// Get all requests related to a problem.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of requests.</returns>
        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(problem, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a request to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="request">The request to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddRequest(Problem problem, Request request)
        {
            return CreateRelation(problem, "requests", request);
        }

        /// <summary>
        /// Remove a request from a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="request">The request to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveRequest(Problem problem, Request request)
        {
            return DeleteRelation(problem, "requests", request);
        }

        /// <summary>
        /// Remove all requests from a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllRequests(Problem problem)
        {
            return DeleteAllRelations(problem, "requests");
        }

        #endregion

        #region Services instances

        /// <summary>
        /// Get all services instances related to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(problem, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all services instances related to a problem.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="problem">The problem.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(problem, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance to a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddServiceInstance(Problem problem, ServiceInstance serviceInstance)
        {
            return CreateRelation(problem, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance from a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstance(Problem problem, ServiceInstance serviceInstance)
        {
            return DeleteRelation(problem, "service_instances", serviceInstance);
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <returns>The archived problem.</returns>
        public Problem Archive(Problem problem)
        {
            return GetChildHandler<Problem>(problem, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a problem.
        /// </summary>
        /// <param name="problem">The problem.</param>
        /// <returns>The trashed problem.</returns>
        public Problem Trash(Problem problem)
        {
            return GetChildHandler<Problem>(problem, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a problem.
        /// </summary>
        /// <param name="archive">The archived problem.</param>
        /// <returns>The restored problem.</returns>
        public Problem Restore(Archive archive)
        {
            return GetChildHandler<Problem>(new Problem() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a problem.
        /// </summary>
        /// <param name="trash">The trashed problem.</param>
        /// <returns>The restored problem.</returns>
        public Problem Restore(Trash trash)
        {
            return GetChildHandler<Problem>(new Problem() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
