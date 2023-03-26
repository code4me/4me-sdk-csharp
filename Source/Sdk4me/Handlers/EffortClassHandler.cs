using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/effort_classes/">effort class</see> API endpoint.
    /// </summary>
    public class EffortClassHandler : BaseHandler<EffortClass, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me effort class handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public EffortClassHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/effort_classes", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me effort class handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public EffortClassHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/effort_classes", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Timesheet Settings

        /// <summary>
        /// Get all related timesheet settings.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of timesheet settings.</returns>
        public List<TimesheetSetting> GetTimesheetSettings(EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<TimesheetSetting>(effortClass, "timesheet_settings").Get(fieldNames);
        }

        /// <summary>
        /// Get all related timesheet settings.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of timesheet settings.</returns>
        public List<TimesheetSetting> GetTimesheetSettings(PredefinedEnabledDisabledFilter filter, EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<TimesheetSetting>(effortClass, $"timesheet_settings/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a timesheet setting.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="timesheetSetting">The timesheet setting to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddTimesheetSetting(EffortClass effortClass, TimesheetSetting timesheetSetting)
        {
            return CreateRelation(effortClass, "timesheet_settings", timesheetSetting);
        }

        /// <summary>
        /// Remove a timesheet setting.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="timesheetSetting">The timesheet setting to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTimesheetSetting(EffortClass effortClass, TimesheetSetting timesheetSetting)
        {
            return DeleteRelation(effortClass, "timesheet_settings", timesheetSetting);
        }

        /// <summary>
        /// Remove all timesheet settings.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTimesheetSettings(EffortClass effortClass)
        {
            return DeleteAllRelations(effortClass, "timesheet_settings");
        }

        #endregion

        #region Skill pools

        /// <summary>
        /// Get all related skill pools.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(effortClass, "skill_pools").Get(fieldNames);
        }

        /// <summary>
        /// Get all related skill pools.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(PredefinedEnabledDisabledFilter filter, EffortClass effortClass, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(effortClass, $"skill_pools/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a skill pool.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="skillPool">The skill pool to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSkillPool(EffortClass effortClass, SkillPool skillPool)
        {
            return CreateRelation(effortClass, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove a skill pool.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <param name="skillPool">The skill pool to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSkillPool(EffortClass effortClass, SkillPool skillPool)
        {
            return DeleteRelation(effortClass, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove all skill pools.
        /// </summary>
        /// <param name="effortClass">The effort class.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSkillPools(EffortClass effortClass)
        {
            return DeleteAllRelations(effortClass, "skill_pools");
        }

        #endregion
    }
}
