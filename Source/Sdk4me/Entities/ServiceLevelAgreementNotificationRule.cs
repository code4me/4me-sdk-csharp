using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/sla_notification_schemes/sla_notification_rules/">service level agreement notification rule</see> object.
    /// </summary>
    public class ServiceLevelAgreementNotificationRule : BaseItem
    {
        private bool notifyCurrentAssignee;
        private bool notifyFirstLineTeamCoordinator;
        private bool notifyFirstLineTeamManager;
        private bool notifyServiceOwner;
        private bool notifySupportTeamCoordinator;
        private bool notifySupportTeamManager;
        private int thresholdPercentage;

        #region Notify current assignee

        /// <summary>
        /// Whether to notify the current assignee of the request.
        /// </summary>
        [JsonProperty("notify_current_assignee")]
        public bool NotifyCurrentAssignee
        {
            get => notifyCurrentAssignee;
            set => notifyCurrentAssignee = SetValue("notify_current_assignee", notifyCurrentAssignee, value);
        }

        #endregion

        #region Notify first line team coordinator

        /// <summary>
        /// Whether to notify the first line team coordinator of the service instance of the affected SLA.
        /// </summary>
        [JsonProperty("notify_first_line_team_coordinator")]
        public bool NotifyFirstLineTeamCoordinator
        {
            get => notifyFirstLineTeamCoordinator;
            set => notifyFirstLineTeamCoordinator = SetValue("notify_first_line_team_coordinator", notifyFirstLineTeamCoordinator, value);
        }

        #endregion

        #region Notify first line team manager

        /// <summary>
        /// Whether to notify the first line team manager of the service instance of the affected SLA.
        /// </summary>
        [JsonProperty("notify_first_line_team_manager")]
        public bool NotifyFirstLineTeamManager
        {
            get => notifyFirstLineTeamManager;
            set => notifyFirstLineTeamManager = SetValue("notify_first_line_team_manager", notifyFirstLineTeamManager, value);
        }

        #endregion

        #region Notify service owner

        /// <summary>
        /// Whether to notify the service owner of the service of the affected SLA.
        /// </summary>
        [JsonProperty("notify_service_owner")]
        public bool NotifyServiceOwner
        {
            get => notifyServiceOwner;
            set => notifyServiceOwner = SetValue("notify_service_owner", notifyServiceOwner, value);
        }

        #endregion

        #region Notify support team coordinator

        /// <summary>
        /// Whether to notify the support team coordinator of the service instance of the affected SLA.
        /// </summary>
        [JsonProperty("notify_support_team_coordinator")]
        public bool NotifySupportTeamCoordinator
        {
            get => notifySupportTeamCoordinator;
            set => notifySupportTeamCoordinator = SetValue("notify_support_team_coordinator", notifySupportTeamCoordinator, value);
        }

        #endregion

        #region Notify support team manager

        /// <summary>
        /// Whether to notify the support team manager of the service instance of the affected SLA.
        /// </summary>
        [JsonProperty("notify_support_team_manager")]
        public bool NotifySupportTeamManager
        {
            get => notifySupportTeamManager;
            set => notifySupportTeamManager = SetValue("notify_support_team_manager", notifySupportTeamManager, value);
        }

        #endregion

        #region Threshold percentage

        /// <summary>
        /// The percentage of the resolution target duration when a notification should be generated.
        /// </summary>
        [JsonProperty("threshold_percentage")]
        public int ThresholdPercentage
        {
            get => thresholdPercentage;
            set => thresholdPercentage = SetValue("threshold_percentage", thresholdPercentage, value);
        }

        #endregion
    }
}
