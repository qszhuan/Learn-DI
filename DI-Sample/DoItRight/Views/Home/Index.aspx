<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DoItRight.Models.FeaturedProductsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Featured Products</h2>
    <div>
    <% foreach (var product in Model.Products)
       {%>
         <div>
         <%= Html.Encode(product.SummaryText) %>
         </div>  
       <% } %>
    </div>
</asp:Content>
