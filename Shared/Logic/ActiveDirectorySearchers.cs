using Addoc.Shared.ObjectModel;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Addoc.Shared.Logic
{
    public static class ActiveDirectorySearchers
    {
        public static List<User> GetUsersFromUnit(string domainName, string orgUnit)
        {
            var allUsers = new List<User>();

            using (var domainContext = new PrincipalContext(ContextType.Domain, domainName))
            using (var searcher = new DirectorySearcher(new DirectoryEntry(orgUnit, "home.local\\maintenance", "Guguseli123")))
            {
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
        }

        public static List<string> GetAllOUs(string domainName)
        {
            var orgUnits = new List<string>();

            using (var domainContext = new PrincipalContext(ContextType.Domain, domainName))
            using (var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainContext.Name, "home.local\\maintenance", "Guguseli123")))
            {
                searcher.Filter = "(objectCategory=organizationalUnit)";

                foreach (SearchResult res in searcher.FindAll())
                {
                    orgUnits.Add(res.Path);
                }

                return orgUnits;
            }
        }

        public static List<Group> GetGroups(string domainName, string groupPath)
        {
            var orgUnits = new List<Group>();

            using (var domainContext = new PrincipalContext(ContextType.Domain, domainName))
            using (var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainContext.Name, "home.local\\maintenance", "Guguseli123")))
            {
                searcher.Filter = "(objectClass=group)";

                foreach (SearchResult res in searcher.FindAll())
                {
                    orgUnits.Add(new Group(res));
                }

                return orgUnits;
            }
        }
    }
}
