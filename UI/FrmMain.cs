using Addoc.Shared.Logic;
using Addoc.UI.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Addoc.UI
{
    public partial class FrmMain : Form
    {
        private readonly Credentials creds;
        private readonly ActiveDirectorySearcher searcher;

        public FrmMain(Credentials creds)
        {
            this.InitializeComponent();

            this.creds = creds;
            this.searcher = new ActiveDirectorySearcher(this.creds);

            var ous = this.searcher.GetAllOUs();
            foreach (var ou in ous)
            {
                this.LbxOrgUnits.Items.Add(ou);
            }
        }
    }
}
