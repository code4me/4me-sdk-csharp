using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProblemHandler : BaseHandler<Problem, PredefinedProblemFilter>
    {
        public ProblemHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/problems", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProblemHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/problems", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(problem, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(problem, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(Problem problem, ConfigurationItem configurationItem)
        {
            return CreateRelation(problem, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Problem problem, ConfigurationItem configurationItem)
        {
            return DeleteRelation(problem, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItem(Problem problem)
        {
            return DeleteAllRelations(problem, "cis");
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Note>(problem, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Requests

        public List<Request> GetRequests(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(problem, "requests").Get(fieldNames);
        }

        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(problem, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddRequest(Problem problem, Request request)
        {
            return CreateRelation(problem, "requests", request);
        }

        public bool RemoveRequest(Problem problem, Request request)
        {
            return DeleteRelation(problem, "requests", request);
        }

        public bool RemoveAllRequests(Problem problem)
        {
            return DeleteAllRelations(problem, "requests");
        }

        #endregion

        #region Services instances

        public List<ServiceInstance> GetServiceInstances(Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(problem, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Problem problem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(problem, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(Problem problem, ServiceInstance serviceInstance)
        {
            return CreateRelation(problem, "service_instances", serviceInstance);
        }

        public bool RemoveServiceInstance(Problem problem, ServiceInstance serviceInstance)
        {
            return DeleteRelation(problem, "service_instances", serviceInstance);
        }

        #endregion

        #region Archive, trash and restore

        public Problem Archive(Problem problem)
        {
            return GetChildHandler<Problem>(problem, "archive").Invoke("Post");
        }

        public Problem Trash(Problem problem)
        {
            return GetChildHandler<Problem>(problem, "trash").Invoke("Post");
        }

        public Problem Restore(Archive archive)
        {
            return GetChildHandler<Problem>(new Problem() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Problem Restore(Trash trash)
        {
            return GetChildHandler<Problem>(new Problem() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
