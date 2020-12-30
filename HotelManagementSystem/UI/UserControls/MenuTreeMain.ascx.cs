using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace HotelManagementSystem.UI.UserControls
{
    public partial class MenuTreeMain : System.Web.UI.UserControl, IWebPart
    {
        private string _calalogiconimageurl;
        private string _description;
        private string _subtitle;
        private string _title;
        private string _titleiconimageurl;
        private string _titleurl;

        string IWebPart.CatalogIconImageUrl
        {
            get { return _calalogiconimageurl; }
            set { _calalogiconimageurl = value; }
        }

        string IWebPart.Description
        {
            get { return _description; }
            set { _description = value; }
        }

        string IWebPart.Subtitle
        {
            get { return _subtitle; }
        }

        string IWebPart.Title
        {
            get { return _title; }
            set { _title = value; }
        }

        string IWebPart.TitleUrl
        {
            get { return _titleurl; }
            set { _titleurl = value; }
        }

        string IWebPart.TitleIconImageUrl
        {
            get { return _titleiconimageurl; }
            set { _titleiconimageurl = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _title = "  Menu";
            _description = "";
            _titleiconimageurl = "~/images/menuicon.jpg";

            if (!IsPostBack)
            {
                //if (Session.Count == 0)
                //    tblmenu.Visible = false;
                //else
                generatetreeview();
            }
        }

        private void generatetreeview()
        {
            XmlDataSource xml_sms = new XmlDataSource();
            if (Session.Count == 0)
            {
                xml_sms.DataFile = "~/UI/Xml/treeview.xml";
                xml_sms.XPath = "//Products/hotelmanagement";
                xml_sms.DataBind();
                MenuTreeView.DataSource = xml_sms;
                MenuTreeView.DataBind();
            }
            else
            {
                xml_sms.DataFile = "~/UI/Xml/SimplifiedTreeView.xml";
                xml_sms.XPath = "//Products/hotelmanagement";
                xml_sms.DataBind();
                MenuTreeView.DataSource = xml_sms;
                MenuTreeView.DataBind();
            }


        }

        protected void MenuTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            navigate_url(MenuTreeView);
        }

        private void navigate_url(TreeView exTree)
        {
            string nd, val, path, url, preurl;
            int indx;

            nd = exTree.SelectedNode.Text;
            val = exTree.SelectedNode.Value;
            path = exTree.SelectedNode.Target;

            if (path != "")
            {
                url = Request.Url.ToString();
                indx = url.IndexOf("UI", 1);
                preurl = url.Substring(0, indx);

                Response.Redirect(preurl + "UI/" + path);
                //Response.Redirect(path);

            }
            else
            {
                if (exTree.SelectedNode.ChildNodes.Count > 0)
                    exTree.SelectedNode.Expand();
            }
        }

        
    }
}