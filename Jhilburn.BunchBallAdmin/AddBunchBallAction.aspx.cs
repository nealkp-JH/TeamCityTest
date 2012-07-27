using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;


namespace Jhilburn.BunchBallAdmin
{
    public partial class AddBunchBallAction : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Jhilburn.BunchBallAdmin.Helpers.BunchBall bb = new Helpers.BunchBall();
                string sessionKey = bb.GetAdminSessionKey();
                if (sessionKey != null)
                {
                    ddlAction.DataSource = GetActionTags(sessionKey);
                    ddlAction.DataBind();
                }
            }
        }

        private static List<string> GetActionTags(string sessionKey)
        {
            Jhilburn.BunchBallAdmin.Helpers.BunchBall bb = new Helpers.BunchBall();
            List<string> actionList = new List<string>();
            XmlDocument response = null;
            string url = string.Format("http://jhilburn.nitro.bunchball.net/nitro/api?method=admin.getActionTags&sessionKey={0}", sessionKey);
            response = bb.getHttpResponseAsXml(url);
            XmlNodeList tags = response.SelectNodes("//Nitro/tags/Tag");
            foreach (XmlNode x in tags)
            {
               actionList.Add( x.Attributes["name"].Value);
            }


            return actionList;
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] users;
            users = txtUserId.Text.Split(',');
            
            Jhilburn.BunchBallAdmin.Helpers.BunchBall bb = new Helpers.BunchBall();

            foreach (string u in users)
            {
                bb.LogAction(ddlAction.SelectedItem.ToString(), u.ToString(), txtValue.Text, bb.GetAdminSessionKey());
            }

            Response.Redirect("~/finished.aspx");

        }
        

        
    }
    
}