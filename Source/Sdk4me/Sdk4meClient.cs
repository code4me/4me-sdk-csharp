using System.Collections.Generic;

namespace Sdk4me
{
    public class Sdk4meClient
    {
        private readonly Dictionary<string, IBaseHandler> handlers = null;
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly EnvironmentType environmentType = EnvironmentType.Production;
        private int itemsPerRequest = 100;
        private int maximumRecursiveRequests = 50;

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication object.</param>
        /// <param name="accountID">The 4me account identifier, in case no accountID specified (null) it used account in which the token's identity exists.</param>
        /// <param name="environmentType">The 4me environment.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public Sdk4meClient(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = new AuthenticationTokenCollection(authenticationToken);
            this.accountID = accountID;
            this.environmentType = environmentType;
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
            this.handlers = new Dictionary<string, IBaseHandler>();
        }

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationTokens">A collection of 4me authorization objects.</param>
        /// <param name="accountID">The 4me account identifier, in case no accountID specified (null) it used account in which the token's identity exists.</param>
        /// <param name="environmentType">The 4me environment.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public Sdk4meClient(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.environmentType = environmentType;
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
            this.handlers = new Dictionary<string, IBaseHandler>();
        }

        public AccountHandler Account
        {
            get
            {
                if (!handlers.ContainsKey("account"))
                    handlers.Add("account", new AccountHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (AccountHandler)handlers["account"];
            }
        }

        public AffectedServiceLevelAgreementHandler AffectedServiceLevelAgreements
        {
            get
            {
                if (!handlers.ContainsKey("affectedServiceLevelAgreements"))
                    handlers.Add("affectedServiceLevelAgreements", new AffectedServiceLevelAgreementHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (AffectedServiceLevelAgreementHandler)handlers["affectedServiceLevelAgreements"];
            }
        }

        public BroadcastHandler Broadcasts
        {
            get
            {
                if (!handlers.ContainsKey("broadcasts"))
                    handlers.Add("broadcasts", new BroadcastHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (BroadcastHandler)handlers["broadcasts"];
            }
        }

        public CalendarHandler Calendars
        {
            get
            {
                if (!handlers.ContainsKey("calendars"))
                    handlers.Add("calendars", new CalendarHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (CalendarHandler)handlers["calendars"];
            }
        }

        public ChangeHandler Changes
        {
            get
            {
                if (!handlers.ContainsKey("changes"))
                    handlers.Add("changes", new ChangeHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ChangeHandler)handlers["changes"];
            }
        }

        public ChangeTemplateHandler ChangeTemplates
        {
            get
            {
                if (!handlers.ContainsKey("changeTemplates"))
                    handlers.Add("changeTemplates", new ChangeTemplateHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ChangeTemplateHandler)handlers["changeTemplates"];
            }
        }

        public ConfigurationItemHandler ConfigurationItems
        {
            get
            {
                if (!handlers.ContainsKey("configurationItems"))
                    handlers.Add("configurationItems", new ConfigurationItemHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ConfigurationItemHandler)handlers["configurationItems"];
            }
        }

        public ContractHandler Contracts
        {
            get
            {
                if (!handlers.ContainsKey("contracts"))
                    handlers.Add("contracts", new ContractHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ContractHandler)handlers["contracts"];
            }
        }

        public FirstLineSupportAgreementHandler FirstLineSupportAgreements
        {
            get
            {
                if (!handlers.ContainsKey("firstLineSupportAgreements"))
                    handlers.Add("firstLineSupportAgreements", new FirstLineSupportAgreementHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (FirstLineSupportAgreementHandler)handlers["firstLineSupportAgreements"];
            }
        }

        public HolidayHandler Holidays
        {
            get
            {
                if (!handlers.ContainsKey("holidays"))
                    handlers.Add("holidays", new HolidayHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (HolidayHandler)handlers["holidays"];
            }
        }

        public KnowledgeArticleHandler KnowledgeArticles
        {
            get
            {
                if (!handlers.ContainsKey("knowledgeArticles"))
                    handlers.Add("knowledgeArticles", new KnowledgeArticleHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (KnowledgeArticleHandler)handlers["knowledgeArticles"];
            }
        }

        public OrganizationHandler Organizations
        {
            get
            {
                if (!handlers.ContainsKey("organizations"))
                    handlers.Add("organizations", new OrganizationHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (OrganizationHandler)handlers["organizations"];
            }
        }

        public PeopleHandler People
        {
            get
            {
                if (!handlers.ContainsKey("people"))
                    handlers.Add("people", new PeopleHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (PeopleHandler)handlers["people"];
            }
        }

        public ProblemHandler Problems
        {
            get
            {
                if (!handlers.ContainsKey("problems"))
                    handlers.Add("problems", new ProblemHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProblemHandler)handlers["problems"];
            }
        }

        public ProductCategoryHandler ProductCategories
        {
            get
            {
                if (!handlers.ContainsKey("productCategories"))
                    handlers.Add("productCategories", new ProductCategoryHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProductCategoryHandler)handlers["productCategories"];
            }
        }

        public ProductHandler Products
        {
            get
            {
                if (!handlers.ContainsKey("products"))
                    handlers.Add("products", new ProductHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProductHandler)handlers["products"];
            }
        }

        public ProjectCategoryHandler ProjectCategories
        {
            get
            {
                if (!handlers.ContainsKey("projectCategories"))
                    handlers.Add("projectCategories", new ProjectCategoryHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectCategoryHandler)handlers["projectCategories"];
            }
        }

        public ProjectHandler Projects
        {
            get
            {
                if (!handlers.ContainsKey("projects"))
                    handlers.Add("projects", new ProjectHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectHandler)handlers["projects"];
            }
        }

        public ProjectRiskLevelHandler ProjectRiskLevels
        {
            get
            {
                if (!handlers.ContainsKey("projectRiskLevels"))
                    handlers.Add("projectRiskLevels", new ProjectRiskLevelHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectRiskLevelHandler)handlers["projectRiskLevels"];
            }
        }

        public ProjectTaskHandler ProjectTasks
        {
            get
            {
                if (!handlers.ContainsKey("projectTasks"))
                    handlers.Add("projectTasks", new ProjectTaskHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTaskHandler)handlers["projectTasks"];
            }
        }

        public ProjectTaskTemplateHandler ProjectTaskTemplates
        {
            get
            {
                if (!handlers.ContainsKey("projectTaskTemplates"))
                    handlers.Add("projectTaskTemplates", new ProjectTaskTemplateHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTaskTemplateHandler)handlers["projectTaskTemplates"];
            }
        }

        public ProjectTemplateHandler ProjectTemplates
        {
            get
            {
                if (!handlers.ContainsKey("projectTemplates"))
                    handlers.Add("projectTemplates", new ProjectTemplateHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTemplateHandler)handlers["projectTemplates"];
            }
        }

        public ReleaseHandler Releases
        {
            get
            {
                if (!handlers.ContainsKey("releases"))
                    handlers.Add("releases", new ReleaseHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ReleaseHandler)handlers["releases"];
            }
        }

        public RequestHandler Requests
        {
            get
            {
                if (!handlers.ContainsKey("requests"))
                    handlers.Add("requests", new RequestHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (RequestHandler)handlers["requests"];
            }
        }

        public RequestTemplateHandler RequestTemplates
        {
            get
            {
                if (!handlers.ContainsKey("requestTemplates"))
                    handlers.Add("requestTemplates", new RequestTemplateHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (RequestTemplateHandler)handlers["requestTemplates"];
            }
        }

        public ServiceCategoryHandler ServiceCategories
        {
            get
            {
                if (!handlers.ContainsKey("serviceCategories"))
                    handlers.Add("serviceCategories", new ServiceCategoryHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceCategoryHandler)handlers["serviceCategories"];
            }
        }

        public ServiceHandler Services
        {
            get
            {
                if (!handlers.ContainsKey("services"))
                    handlers.Add("services", new ServiceHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceHandler)handlers["services"];
            }
        }

        public ServiceInstanceHandler ServiceInstances
        {
            get
            {
                if (!handlers.ContainsKey("serviceInstances"))
                    handlers.Add("serviceInstances", new ServiceInstanceHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceInstanceHandler)handlers["serviceInstances"];
            }
        }

        public ServiceLevelAgreementHandler ServiceLevelAgreements
        {
            get
            {
                if (!handlers.ContainsKey("serviceLevelAgreements"))
                    handlers.Add("serviceLevelAgreements", new ServiceLevelAgreementHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceLevelAgreementHandler)handlers["serviceLevelAgreements"];
            }
        }

        public ServiceOfferingHandler ServiceOfferings
        {
            get
            {
                if (!handlers.ContainsKey("serviceOfferings"))
                    handlers.Add("serviceOfferings", new ServiceOfferingHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceOfferingHandler)handlers["serviceOfferings"];
            }
        }

        public ShortUniformResourceLocatorHandler ShortUniformResourceLocators
        {
            get
            {
                if (!handlers.ContainsKey("shortUniformResourceLocators"))
                    handlers.Add("shortUniformResourceLocators", new ShortUniformResourceLocatorHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (ShortUniformResourceLocatorHandler)handlers["shortUniformResourceLocators"];
            }
        }

        public SiteHandler Sites
        {
            get
            {
                if (!handlers.ContainsKey("sites"))
                    handlers.Add("sites", new SiteHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (SiteHandler)handlers["sites"];
            }
        }

        public TaskHandler Tasks
        {
            get
            {
                if (!handlers.ContainsKey("tasks"))
                    handlers.Add("tasks", new TaskHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TaskHandler)handlers["tasks"];
            }
        }

        public TaskTemplateHandler TaskTemplates
        {
            get
            {
                if (!handlers.ContainsKey("taskTemplates"))
                    handlers.Add("taskTemplates", new TaskTemplateHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TaskTemplateHandler)handlers["taskTemplates"];
            }
        }

        public TeamHandler Teams
        {
            get
            {
                if (!handlers.ContainsKey("teams"))
                    handlers.Add("teams", new TeamHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TeamHandler)handlers["teams"];
            }
        }

        public TimeAllocationHandler TimeAllocations
        {
            get
            {
                if (!handlers.ContainsKey("timeAllocations"))
                    handlers.Add("timeAllocations", new TimeAllocationHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TimeAllocationHandler)handlers["timeAllocations"];
            }
        }

        public TimeEntryHandler TimeEntries
        {
            get
            {
                if (!handlers.ContainsKey("timeEntries"))
                    handlers.Add("timeEntries", new TimeEntryHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TimeEntryHandler)handlers["timeEntries"];
            }
        }

        public TimesheetSettingHandler TimesheetSettings
        {
            get
            {
                if (!handlers.ContainsKey("timesheetSettings"))
                    handlers.Add("timesheetSettings", new TimesheetSettingHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TimesheetSettingHandler)handlers["timesheetSettings"];
            }
        }

        public TrashHandler Trash
        {
            get
            {
                if (!handlers.ContainsKey("trash"))
                    handlers.Add("trash", new TrashHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (TrashHandler)handlers["trash"];
            }
        }

        public UIExtensionHandler UIExtensions
        {
            get
            {
                if (!handlers.ContainsKey("uiExtensions"))
                    handlers.Add("uiExtensions", new UIExtensionHandler(authenticationTokens, accountID, environmentType, itemsPerRequest, maximumRecursiveRequests));
                return (UIExtensionHandler)handlers["uiExtensions"];
            }
        }

        /// <summary>
        /// Sets the amount of items returned in one request.
        /// </summary>
        /// <param name="value">The value must be at least 1 and maximum 100.</param>
        public void UpdateItemsPerRequest(int value)
        {
            this.itemsPerRequest = value;
            foreach (string key in handlers.Keys)
                handlers[key].ItemsPerRequest = value;
        }

        /// <summary>
        /// Sets the amount of recursive requests.
        /// </summary>
        /// <param name="value">The value must be at least 1 and maximum 1000.</param>
        public void UpdateMaximumRecursiveRequests(int value)
        {
            this.maximumRecursiveRequests = value;
            foreach (string key in handlers.Keys)
                handlers[key].MaximumRecursiveRequests = value;
        }
    }
}
