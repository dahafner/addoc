using Addoc.Shared.Logic;
using Addoc.UI.Shared;
using System;
using System.Collections.Generic;

namespace ConsoleTestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ListAllGroupsViaTokenGroups:");

            var result = new List<string>();
            var creds = new Credentials { DomainName = "home.local", Username = "maintenance", Password = "Guguseli123" };
            var searcher = new ActiveDirectorySearcher(creds);

            try
            {
                var groups = searcher.GetGroups( "bla");

                result = searcher.GetAllOUs();

                foreach (var group in result)
                {
                    Console.WriteLine($" --- {group} ---");
                    var users = searcher.GetUsersFromUnit(group);
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.DisplayName);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.Read();
        }

        
    }
}
