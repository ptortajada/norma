﻿using EC.Norma.Core;
using EC.Norma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Norma.Json.Providers
{
    public class JsonNormaProvider : INormaProvider
    {

        NormaContext context;

        public JsonNormaProvider(NormaContext context)
        {
            this.context = context;
        }

        public ICollection<Assignment> GetAssignmentsForRoles(string permissionName, IEnumerable<string> profiles)
        {
            return context.Assignments.Where(a => a.Permission.Name == permissionName && profiles.Contains(a.Profile.Name)).ToList();
        }
        
        public ICollection<Permission> GetPermissions(string action, string resource)
        {
            return context.Permissions.Where(p => p.Action.Name == action && p.Resource.Name == resource).ToList();
        }

        public ICollection<Permission> GetPermissions(string permissionName)
        {
            return context.Permissions.Where(p => p.Name == permissionName).ToList();
        }

        public ICollection<Policy> GetPoliciesForActionResource(string actionName, string resourceName)
        {
            return new List<Policy>();
        }

        public ICollection<Policy> GetPoliciesForPermission(string permissionName)
        {

            var actions = context.Permissions.Where(p => p.Name == permissionName).Select(p => p.Action);

            var list = context.ActionsPolicies.Where(ap => actions.Contains(ap.Action)).Select(ap => ap.Policy);

            return list.ToList();
        }
    }
}
