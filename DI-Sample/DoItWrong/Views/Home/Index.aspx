<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="DoItWrong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Featured Products</h2>
    <div>
    <%
        var products = (IEnumerable<Product>)ViewData["Products"];
        foreach (var product in products)
        {%>
        <div>
          <%: Html.Encode(product.Name) %>
          <%: Html.Encode(product.UnitPrice.ToString("C")) %>
        </div>
       <% }%>
    </div>
</asp:Content>
