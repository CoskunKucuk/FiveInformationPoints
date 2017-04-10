using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchButton.ServerClick += SearchButton_ServerClick;
    }

    private void SearchButton_ServerClick(object sender, EventArgs e)
    {
        
        Session["company"] = SearchBar_txt.Value;
        Response.Redirect("index2.aspx");
        //Response.Write("<script>alert('"+CompanyName+"')</script>");
    }
}