using Addoc.Shared.ObjectModel;
using Addoc.UI.Shared;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Addoc.Shared.Logic
{
    public class ActiveDirectorySearcher
    {
        private readonly Credentials creds;

        public ActiveDirectorySearcher(Credentials creds)
        {
            this.creds = creds;
        }

        public List<User> GetUsersFromUnit(string orgUnit)
        {
            var allUsers = new List<User>();

            using var searcher = this.GetSearcher(orgUnit);
            searcher.SearchScope = SearchScope.OneLevel;
            searcher.Filter = "(objectCategory=user)";

            foreach (SearchResult res in searcher.FindAll())
            {
                var user = new User();
                user.LoadFrom(res);
                allUsers.Add(user);
            }

            return allUsers;
        }

        public List<string> GetAllOUs()
        {
            var orgUnits = new List<string>();

            using var searcher = this.GetSearcher(null);
            searcher.Filter = "(objectCategory=organizationalUnit)";

            foreach (SearchResult res in searcher.FindAll())
            {
                orgUnits.Add(res.Path);
            }

            return orgUnits;
        }

        public List<Group> GetGroups(string groupPath)
        {
            var orgUnits = new List<Group>();

            using var searcher = this.GetSearcher(groupPath);
            searcher.Filter = "(objectClass=group)";

            foreach (SearchResult res in searcher.FindAll())
            {
                orgUnits.Add(new Group(res));
            }

            return orgUnits;
        }

        private DirectorySearcher GetSearcher(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                var domainContext = new PrincipalContext(ContextType.Domain, this.creds.DomainName);
                path = $"LDAP://{domainContext.Name}";
            }
            var searcher = new DirectorySearcher(new DirectoryEntry(path, $"{this.creds.DomainName}\\{this.creds.Username}", this.creds.Password));

            return searcher;
        }
    }
}
