using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Permission : BaseItem
    {
        private Account account;
        private List<string> roles;

        #region ID (new)

        [Sdk4meIgnoreInFieldSelection()]
        public new string ID
        {
            get => Account?.ID;
        }

        #endregion

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region account

        [JsonProperty(PropertyName = "account")]
        public Account Account
        {
            get => account;
            set => account = value;
        }
    
        #endregion

        #region roles
    
        [JsonProperty(PropertyName = "roles")]
        private List<string> RolesPrivate
        {
            get => roles;
            set => roles = value;
        }

        [JsonIgnore()]
        public AccessRoleType Roles
        {
            set
            {
                if (RolesPrivate == null)
                    RolesPrivate = new List<string>();
                else
                    RolesPrivate.Clear();
            
                if (value.HasFlag(AccessRoleType.KeyContact))
                    RolesPrivate.Add("key_contact");
                if (value.HasFlag(AccessRoleType.Auditor))
                    RolesPrivate.Add("auditor");
                if (value.HasFlag(AccessRoleType.DirectoryAuditor))
                    RolesPrivate.Add("directory_auditor");
                if (value.HasFlag(AccessRoleType.Specialist))
                    RolesPrivate.Add("specialist");
                if (value.HasFlag(AccessRoleType.ServiceDeskAnalyst))
                    RolesPrivate.Add("service_desk_analyst");
                if (value.HasFlag(AccessRoleType.ServiceDeskManager))
                    RolesPrivate.Add("service_desk_manager");
                if (value.HasFlag(AccessRoleType.KnowledgeManager))
                    RolesPrivate.Add("knowledge_manager");
                if (value.HasFlag(AccessRoleType.ProblemManager))
                    RolesPrivate.Add("problem_manager");
                if (value.HasFlag(AccessRoleType.ChangeManager))
                    RolesPrivate.Add("change_manager");
                if (value.HasFlag(AccessRoleType.ReleaseManager))
                    RolesPrivate.Add("release_manager");
                if (value.HasFlag(AccessRoleType.ProjectManager))
                    RolesPrivate.Add("project_manager");
                if (value.HasFlag(AccessRoleType.ServiceLevelManager))
                    RolesPrivate.Add("service_level_manager");
                if (value.HasFlag(AccessRoleType.ConfigurationManager))
                    RolesPrivate.Add("configuration_manager");
                if (value.HasFlag(AccessRoleType.AccountDesigner))
                    RolesPrivate.Add("account_designer");
                if (value.HasFlag(AccessRoleType.AccountAdministrator))
                    RolesPrivate.Add("account_administrator");
                if (value.HasFlag(AccessRoleType.DirectoryDesigner))
                    RolesPrivate.Add("directory_designer");
                if (value.HasFlag(AccessRoleType.DirectoryAdministrator))
                    RolesPrivate.Add("directory_administrator");
                if (value.HasFlag(AccessRoleType.AccountOwner))
                    RolesPrivate.Add("account_owner");
            }

            get
            {
                AccessRoleType retval = AccessRoleType.None;
                if (RolesPrivate != null)
                {
                    for (int i = 0; i < RolesPrivate.Count; i++)
                    {
                        switch (RolesPrivate[i])
                        {
                            case "key_contact":
                                retval |= AccessRoleType.KeyContact;
                                break;
                            case "auditor":
                                retval |= AccessRoleType.Auditor;
                                break;
                            case "directory_auditor":
                                retval |= AccessRoleType.DirectoryAuditor;
                                break;
                            case "specialist":
                                retval |= AccessRoleType.Specialist;
                                break;
                            case "service_desk_analyst":
                                retval |= AccessRoleType.ServiceDeskAnalyst;
                                break;
                            case "service_desk_manager":
                                retval |= AccessRoleType.ServiceDeskManager;
                                break;
                            case "knowledge_manager":
                                retval |= AccessRoleType.KnowledgeManager;
                                break;
                            case "problem_manager":
                                retval |= AccessRoleType.ProblemManager;
                                break;
                            case "change_manager":
                                retval |= AccessRoleType.ChangeManager;
                                break;
                            case "release_manager":
                                retval |= AccessRoleType.ReleaseManager;
                                break;
                            case "project_manager":
                                retval |= AccessRoleType.ProjectManager;
                                break;
                            case "service_level_manager":
                                retval |= AccessRoleType.ServiceLevelManager;
                                break;
                            case "configuration_manager":
                                retval |= AccessRoleType.ConfigurationManager;
                                break;
                            case "account_designer":
                                retval |= AccessRoleType.AccountDesigner;
                                break;
                            case "account_administrator":
                                retval |= AccessRoleType.AccountAdministrator;
                                break;
                            case "directory_designer":
                                retval |= AccessRoleType.DirectoryDesigner;
                                break;
                            case "directory_administrator":
                                retval |= AccessRoleType.DirectoryAdministrator;
                                break;
                            case "account_owner":
                                retval |= AccessRoleType.AccountOwner;
                                break;
                        }
                    }
                }
                return retval;
            }
        }

        public string GetRolesInSingleString()
        {
            return RolesPrivate == null ? "" : string.Join(",", RolesPrivate);
        }

        #endregion
    }
}
