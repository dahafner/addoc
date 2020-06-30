using Addoc.Shared.Logic;
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

            try
            {
                var groups = ActiveDirectorySearchers.GetGroups("home.local", "bla");

                result = ActiveDirectorySearchers.GetAllOUs("home.local");

                foreach (var group in result)
                {
                    Console.WriteLine($" --- {group} ---");
                    var users = ActiveDirectorySearchers.GetUsersFromUnit("home.local", group);
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
