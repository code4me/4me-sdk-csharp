using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// The SDK 4me Client.
    /// </summary>
    public class Sdk4meClient
    {
        private readonly Dictionary<string, IBaseHandler> handlers = null;
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly EnvironmentType environment = EnvironmentType.Production;
        private readonly EnvironmentRegion environmentRegion = EnvironmentRegion.EU;
        private int itemsPerRequest = 25;
        private int maximumRecursiveRequests = 10;

        /// <summary>
        /// Returns the 4me account identifier used during initialization.
        /// </summary>
        public string AccountID
        {
            get => accountID;
        }

        /// <summary>
        /// Returns the 4me environment used during initialization.
        /// </summary>
        public EnvironmentType EnvironmentType
        {
            get => environment;
        }

        /// <summary>
        /// Gets or sets the number of items returned in one request.
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set
            {
                itemsPerRequest = value;
                foreach (string key in handlers.Keys)
                    handlers[key].ItemsPerRequest = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of maximum recursive requests.
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set
            {
                maximumRecursiveRequests = value;
                foreach (string key in handlers.Keys)
                    handlers[key].MaximumRecursiveRequests = value;
            }
        }

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public Sdk4meClient(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, EnvironmentRegion.EU, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public Sdk4meClient(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment, EnvironmentRegion environmentRegion, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public Sdk4meClient(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(authenticationTokens, accountID, environment, EnvironmentRegion.EU, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Creates a new instance of the Sdk4meClient.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public Sdk4meClient(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment, EnvironmentRegion environmentRegion, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));

            if (authenticationTokens is null)
                throw new ArgumentNullException(nameof(authenticationTokens));

            if (!authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be empty.", nameof(authenticationTokens));

            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.environment = environment;
            this.environmentRegion = environmentRegion;
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
            handlers = new Dictionary<string, IBaseHandler>();
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/account/">account</see> API endpoint.
        /// </summary>
        public AccountHandler Account
        {
            get
            {
                if (!handlers.ContainsKey("account"))
                    handlers.Add("account", new AccountHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (AccountHandler)handlers["account"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/affected_slas/">affected service level agreements</see> API endpoint.
        /// </summary>
        public AffectedServiceLevelAgreementHandler AffectedServiceLevelAgreements
        {
            get
            {
                if (!handlers.ContainsKey("affected_slas"))
                    handlers.Add("affected_slas", new AffectedServiceLevelAgreementHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (AffectedServiceLevelAgreementHandler)handlers["affected_slas"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/agile_boards/">affected service level agreements</see> API endpoint.
        /// </summary>
        public AgileBoardHandler AgileBoards
        {
            get
            {
                if (!handlers.ContainsKey("agile_boards"))
                    handlers.Add("agile_boards", new AgileBoardHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (AgileBoardHandler)handlers["agile_boards"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/archive/">archive</see> API endpoint.
        /// </summary>
        public ArchiveHandler Archive
        {
            get
            {
                if (!handlers.ContainsKey("archive"))
                    handlers.Add("archive", new ArchiveHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ArchiveHandler)handlers["archive"];

            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/audit_entries/">audit entry</see> API endpoint.
        /// </summary>
        public AuditEntryHandler AuditEntries
        {
            get
            {
                if (!handlers.ContainsKey("audit_entries"))
                    handlers.Add("audit_entries", new AuditEntryHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (AuditEntryHandler)handlers["audit_entries"];

            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/broadcasts/">broadcast</see> API endpoint.
        /// </summary>
        public BroadcastHandler Broadcasts
        {
            get
            {
                if (!handlers.ContainsKey("broadcasts"))
                    handlers.Add("broadcasts", new BroadcastHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (BroadcastHandler)handlers["broadcasts"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/calendars/">calendar</see> API endpoint.
        /// </summary>
        public CalendarHandler Calendars
        {
            get
            {
                if (!handlers.ContainsKey("calendars"))
                    handlers.Add("calendars", new CalendarHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (CalendarHandler)handlers["calendars"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/cis/">configuration item</see> API endpoint.
        /// </summary>
        public ConfigurationItemHandler ConfigurationItems
        {
            get
            {
                if (!handlers.ContainsKey("cis"))
                    handlers.Add("cis", new ConfigurationItemHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ConfigurationItemHandler)handlers["cis"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/contracts/">contract</see> API endpoint.
        /// </summary>
        public ContractHandler Contracts
        {
            get
            {
                if (!handlers.ContainsKey("contracts"))
                    handlers.Add("contracts", new ContractHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ContractHandler)handlers["contracts"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/custom_collections/">custom collection</see> API endpoint.
        /// </summary>
        public CustomCollectionHandler CustomCollections
        {
            get
            {
                if (!handlers.ContainsKey("custom_collections"))
                    handlers.Add("custom_collections", new CustomCollectionHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (CustomCollectionHandler)handlers["custom_collections"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/custom_collection_elements/">custom collection element</see> API endpoint.
        /// </summary>
        public CustomCollectionElementHandler CustomCollectionElements
        {
            get
            {
                if (!handlers.ContainsKey("custom_collection_elements"))
                    handlers.Add("custom_collection_elements", new CustomCollectionElementHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (CustomCollectionElementHandler)handlers["custom_collection_elements"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/effort_classes/">effort class</see> API endpoint.
        /// </summary>
        public EffortClassHandler EffortClasses
        {
            get
            {
                if (!handlers.ContainsKey("effort_classes"))
                    handlers.Add("effort_classes", new EffortClassHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (EffortClassHandler)handlers["effort_classes"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/requests/events/">event</see> API endpoint.
        /// </summary>
        public RequestEventHandler Events
        {
            get
            {
                if (!handlers.ContainsKey("events"))
                    handlers.Add("events", new RequestEventHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (RequestEventHandler)handlers["events"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/flsas/">first line support agreement</see> API endpoint.
        /// </summary>
        public FirstLineSupportAgreementHandler FirstLineSupportAgreements
        {
            get
            {
                if (!handlers.ContainsKey("flsas"))
                    handlers.Add("flsas", new FirstLineSupportAgreementHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (FirstLineSupportAgreementHandler)handlers["flsas"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/holidays/">holiday</see> API endpoint.
        /// </summary>
        public HolidayHandler Holidays
        {
            get
            {
                if (!handlers.ContainsKey("holidays"))
                    handlers.Add("holidays", new HolidayHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (HolidayHandler)handlers["holidays"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/invoices/">invoice</see> API endpoint.
        /// </summary>
        public InvoiceHandler Invoices
        {
            get
            {
                if (!handlers.ContainsKey("invoices"))
                    handlers.Add("invoices", new InvoiceHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (InvoiceHandler)handlers["invoices"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/knowledge_articles/">knowledge article</see> API endpoint.
        /// </summary>
        public KnowledgeArticleHandler KnowledgeArticles
        {
            get
            {
                if (!handlers.ContainsKey("knowledge_articles"))
                    handlers.Add("knowledge_articles", new KnowledgeArticleHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (KnowledgeArticleHandler)handlers["knowledge_articles"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/people/me/">Me</see> API endpoint.
        /// </summary>
        public MeHandler Me
        {
            get
            {
                if (!handlers.ContainsKey("me"))
                    handlers.Add("me", new MeHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (MeHandler)handlers["me"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/organizations/">organization</see> API endpoint.
        /// </summary>
        public OrganizationHandler Organizations
        {
            get
            {
                if (!handlers.ContainsKey("organizations"))
                    handlers.Add("organizations", new OrganizationHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (OrganizationHandler)handlers["organizations"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/out_of_office_periods/">out of office period</see> API endpoint.
        /// </summary>
        public OutOfOfficePeriodHandler OutOfOfficePeriods
        {
            get
            {
                if (!handlers.ContainsKey("out_of_office_periods"))
                    handlers.Add("out_of_office_periods", new OutOfOfficePeriodHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (OutOfOfficePeriodHandler)handlers["out_of_office_periods"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/people/">people</see> API endpoint.
        /// </summary>
        public PeopleHandler People
        {
            get
            {
                if (!handlers.ContainsKey("people"))
                    handlers.Add("people", new PeopleHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (PeopleHandler)handlers["people"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/projects/">project</see> API endpoint.
        /// </summary>
        public ProjectHandler Projects
        {
            get
            {
                if (!handlers.ContainsKey("projects"))
                    handlers.Add("projects", new ProjectHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectHandler)handlers["projects"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/project_categories/">project category</see> API endpoint.
        /// </summary>
        public ProjectCategoryHandler ProjectCategory
        {
            get
            {
                if (!handlers.ContainsKey("project_categories"))
                    handlers.Add("project_categories", new ProjectCategoryHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectCategoryHandler)handlers["project_categories"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/project_risk_levels/">project risk level</see> API endpoint.
        /// </summary>
        public ProjectRiskLevelHandler ProjectRiskLevels
        {
            get
            {
                if (!handlers.ContainsKey("project_risk_levels"))
                    handlers.Add("project_risk_levels", new ProjectRiskLevelHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectRiskLevelHandler)handlers["project_risk_levels"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/project_tasks/">project task</see> API endpoint.
        /// </summary>
        public ProjectTaskHandler ProjectTasks
        {
            get
            {
                if (!handlers.ContainsKey("project_tasks"))
                    handlers.Add("project_tasks", new ProjectTaskHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTaskHandler)handlers["project_tasks"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/project_task_templates/">project task template</see> API endpoint.
        /// </summary>
        public ProjectTaskTemplateHandler ProjectTaskTemplates
        {
            get
            {
                if (!handlers.ContainsKey("project_task_templates"))
                    handlers.Add("project_task_templates", new ProjectTaskTemplateHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTaskTemplateHandler)handlers["project_task_templates"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/project_templates/">project template</see> API endpoint.
        /// </summary>
        public ProjectTemplateHandler ProjectTemplates
        {
            get
            {
                if (!handlers.ContainsKey("project_templates"))
                    handlers.Add("project_templates", new ProjectTemplateHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProjectTemplateHandler)handlers["project_templates"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/problems/">problem</see> API endpoint.
        /// </summary>
        public ProblemHandler Problems
        {
            get
            {
                if (!handlers.ContainsKey("problems"))
                    handlers.Add("problems", new ProblemHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProblemHandler)handlers["problems"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/products/">product</see> API endpoint.
        /// </summary>
        public ProductHandler Products
        {
            get
            {
                if (!handlers.ContainsKey("products"))
                    handlers.Add("products", new ProductHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProductHandler)handlers["products"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/product_backlogs/">product backlog</see> API endpoint.
        /// </summary>
        public ProductBacklogHandler ProductBacklogs
        {
            get
            {
                if (!handlers.ContainsKey("product_backlogs"))
                    handlers.Add("product_backlogs", new ProductBacklogHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProductBacklogHandler)handlers["product_backlogs"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/product_categories/">product category</see> API endpoint.
        /// </summary>
        public ProductCategoryHandler ProductCategories
        {
            get
            {
                if (!handlers.ContainsKey("product_categories"))
                    handlers.Add("product_categories", new ProductCategoryHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ProductCategoryHandler)handlers["product_categories"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/requests/">request</see> API endpoint.
        /// </summary>
        public RequestHandler Requests
        {
            get
            {
                if (!handlers.ContainsKey("requests"))
                    handlers.Add("requests", new RequestHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (RequestHandler)handlers["requests"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/request_templates/">request template</see> API endpoint.
        /// </summary>
        public RequestTemplateHandler RequestTemplates
        {
            get
            {
                if (!handlers.ContainsKey("request_templates"))
                    handlers.Add("request_templates", new RequestTemplateHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (RequestTemplateHandler)handlers["request_templates"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/releases/">release</see> API endpoint.
        /// </summary>
        public ReleaseHandler Releases
        {
            get
            {
                if (!handlers.ContainsKey("releases"))
                    handlers.Add("releases", new ReleaseHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ReleaseHandler)handlers["releases"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/reservations/">reservation</see> API endpoint.
        /// </summary>
        public ReservationHandler Reservations
        {
            get
            {
                if (!handlers.ContainsKey("reservations"))
                    handlers.Add("reservations", new ReservationHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ReservationHandler)handlers["reservations"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/reservation_offerings/">reservation offering</see> API endpoint.
        /// </summary>
        public ReservationOfferingHandler ReservationOfferings
        {
            get
            {
                if (!handlers.ContainsKey("reservation_offerings"))
                    handlers.Add("reservation_offerings", new ReservationOfferingHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ReservationOfferingHandler)handlers["reservation_offerings"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/risks/">risk</see> API endpoint.
        /// </summary>
        public RiskHandler Risks
        {
            get
            {
                if (!handlers.ContainsKey("risks"))
                    handlers.Add("risks", new RiskHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (RiskHandler)handlers["risks"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/risk_severities/">risk severity</see> API endpoint.
        /// </summary>
        public RiskSeverityHandler RiskSeverities
        {
            get
            {
                if (!handlers.ContainsKey("risk_severities"))
                    handlers.Add("risk_severities", new RiskSeverityHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (RiskSeverityHandler)handlers["risk_severities"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/scrum_workspaces/">scrum workspace</see> API endpoint.
        /// </summary>
        public ScrumWorkspaceHandler ScrumWorkspaces
        {
            get
            {
                if (!handlers.ContainsKey("scrum_workspaces"))
                    handlers.Add("scrum_workspaces", new ScrumWorkspaceHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ScrumWorkspaceHandler)handlers["scrum_workspaces"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/services/">service</see> API endpoint.
        /// </summary>
        public ServiceHandler Services
        {
            get
            {
                if (!handlers.ContainsKey("services"))
                    handlers.Add("services", new ServiceHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceHandler)handlers["services"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/service_categories/">service category</see> API endpoint.
        /// </summary>
        public ServiceCategoryHandler ServiceCategories
        {
            get
            {
                if (!handlers.ContainsKey("service_categories"))
                    handlers.Add("service_categories", new ServiceCategoryHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceCategoryHandler)handlers["service_categories"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/service_instances/">service instance</see> API endpoint.
        /// </summary>
        public ServiceInstanceHandler ServiceInstances
        {
            get
            {
                if (!handlers.ContainsKey("service_instances"))
                    handlers.Add("service_instances", new ServiceInstanceHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceInstanceHandler)handlers["service_instances"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/service_offerings/">service offering</see> API endpoint.
        /// </summary>
        public ServiceOfferingHandler ServiceOfferings
        {
            get
            {
                if (!handlers.ContainsKey("service_offerings"))
                    handlers.Add("service_offerings", new ServiceOfferingHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceOfferingHandler)handlers["service_offerings"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/slas/">service level agreement</see> API endpoint.
        /// </summary>
        public ServiceLevelAgreementHandler ServiceLevelAgreements
        {
            get
            {
                if (!handlers.ContainsKey("slas"))
                    handlers.Add("slas", new ServiceLevelAgreementHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceLevelAgreementHandler)handlers["slas"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/sites/">sites</see> API endpoint.
        /// </summary>
        public SiteHandler Sites
        {
            get
            {
                if (!handlers.ContainsKey("sites"))
                    handlers.Add("sites", new SiteHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (SiteHandler)handlers["sites"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/skill_pools/">skill pool</see> API endpoint.
        /// </summary>
        public SkillPoolHandler SkillPools
        {
            get
            {
                if (!handlers.ContainsKey("skill_pools"))
                    handlers.Add("skill_pools", new SkillPoolHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (SkillPoolHandler)handlers["skill_pools"];
            }
        }

        //
        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/sla_notification_schemes/">service level agreement notification scheme</see> API endpoint.
        /// </summary>
        public ServiceLevelAgreementNotificationSchemeHandler ServiceLevelAgreementNotificationSchemes
        {
            get
            {
                if (!handlers.ContainsKey("sla_notification_schemes"))
                    handlers.Add("sla_notification_schemes", new ServiceLevelAgreementNotificationSchemeHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (ServiceLevelAgreementNotificationSchemeHandler)handlers["sla_notification_schemes"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/sprints/">sprint</see> API endpoint.
        /// </summary>
        public SprintHandler Sprints
        {
            get
            {
                if (!handlers.ContainsKey("sprints"))
                    handlers.Add("sprints", new SprintHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (SprintHandler)handlers["sprints"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/surveys/">survey</see> API endpoint.
        /// </summary>
        public SurveyHandler Surveys
        {
            get
            {
                if (!handlers.ContainsKey("surveys"))
                    handlers.Add("surveys", new SurveyHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (SurveyHandler)handlers["surveys"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/survey_responses/">survey response</see> API endpoint.
        /// </summary>
        public SurveyResponseHandler SurveyResponses
        {
            get
            {
                if (!handlers.ContainsKey("survey_responses"))
                    handlers.Add("survey_responses", new SurveyResponseHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (SurveyResponseHandler)handlers["survey_responses"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/tasks/">task</see> API endpoint.
        /// </summary>
        public TaskHandler Tasks
        {
            get
            {
                if (!handlers.ContainsKey("tasks"))
                    handlers.Add("tasks", new TaskHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TaskHandler)handlers["tasks"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/task_templates/">task template</see> API endpoint.
        /// </summary>
        public TaskTemplateHandler TaskTemplates
        {
            get
            {
                if (!handlers.ContainsKey("task_templates"))
                    handlers.Add("task_templates", new TaskTemplateHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TaskTemplateHandler)handlers["task_templates"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/teams/">team</see> API endpoint.
        /// </summary>
        public TeamHandler Teams
        {
            get
            {
                if (!handlers.ContainsKey("teams"))
                    handlers.Add("teams", new TeamHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TeamHandler)handlers["teams"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/time_allocations/">time allocation</see> API endpoint.
        /// </summary>
        public TimeAllocationHandler TimeAllocations
        {
            get
            {
                if (!handlers.ContainsKey("time_allocations"))
                    handlers.Add("time_allocations", new TimeAllocationHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TimeAllocationHandler)handlers["time_allocations"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/time_entries/">time entry</see> API endpoint.
        /// </summary>
        public TimeEntryHandler TimeEntries
        {
            get
            {
                if (!handlers.ContainsKey("time_entries"))
                    handlers.Add("time_entries", new TimeEntryHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TimeEntryHandler)handlers["time_entries"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/timesheet_settings/">timesheet setting</see> API endpoint.
        /// </summary>
        public TimesheetSettingHandler TimesheetSettings
        {
            get
            {
                if (!handlers.ContainsKey("timesheet_settings"))
                    handlers.Add("timesheet_settings", new TimesheetSettingHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TimesheetSettingHandler)handlers["timesheet_settings"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/trash/">trash</see> API endpoint.
        /// </summary>
        public TrashHandler Trash
        {
            get
            {
                if (!handlers.ContainsKey("trash"))
                    handlers.Add("trash", new TrashHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (TrashHandler)handlers["trash"];

            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/ui_extensions/">user interface extension</see> API endpoint.
        /// </summary>
        public UIExtensionHandler UIExtensions
        {
            get
            {
                if (!handlers.ContainsKey("ui_extensions"))
                    handlers.Add("ui_extensions", new UIExtensionHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (UIExtensionHandler)handlers["ui_extensions"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/workflows/">workflow</see> API endpoint.
        /// </summary>
        public WorkflowHandler Workflows
        {
            get
            {
                if (!handlers.ContainsKey("workflows"))
                    handlers.Add("workflows", new WorkflowHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (WorkflowHandler)handlers["workflows"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/workflow_templates/">workflow template</see> API endpoint.
        /// </summary>
        public WorkflowTemplateHandler WorkflowTemplates
        {
            get
            {
                if (!handlers.ContainsKey("workflow_templates"))
                    handlers.Add("workflow_templates", new WorkflowTemplateHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (WorkflowTemplateHandler)handlers["workflow_templates"];
            }
        }

        /// <summary>
        /// The 4me <see href="https://developer.4me.com/v1/workflow_types/">workflow type</see> API endpoint.
        /// </summary>
        public WorkflowTypeHandler WorkflowTypes
        {
            get
            {
                if (!handlers.ContainsKey("workflow_types"))
                    handlers.Add("workflow_types", new WorkflowTypeHandler(authenticationTokens, accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests));
                return (WorkflowTypeHandler)handlers["workflow_types"];
            }
        }
    }
}
