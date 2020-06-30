using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace Addoc.Shared.ObjectModel
{
    public class Group
    {
        public Group(SearchResult res)
        {
            this.LoadFrom(res);
        }

        public string DisplayName { get; set; }

        public string Path { get; set; }

        public void LoadFrom(SearchResult res)
        {
            this.DisplayName = res.Properties["name"][0].ToString();
            this.Path = res.Path;
        }
    }
}
