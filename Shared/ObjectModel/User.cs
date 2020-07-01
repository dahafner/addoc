using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace Addoc.Shared.ObjectModel
{
    public class User
    {
        public string DisplayName { get; set; }

        public string UserName { get; set; }
        
        public string Path { get; set; }

        public List<string> MemberOf { get; set; }

        public void LoadFrom(SearchResult res)
        {
            this.DisplayName = res.Properties["displayname"][0].ToString();
            this.UserName = res.Properties["username"][0].ToString();

            var bla = res.Properties["memberof"];
            foreach (var blaa in bla)
            {
                this.MemberOf.Add(blaa.ToString());
            }

            this.Path = res.Path;
        }
    }
}
