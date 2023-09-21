<%@ Page Title="News | Shah Developers" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">News</h1>
                    <h2 class="pgsubtitle text-center">Latest news Shah Developers</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <%-- News start --%>
    <div class="container">
        <div class="text-center">
            <h2 class="semiBold medium colorPrime mb-2">News</h2>
            <p class="shorline"></p>
        </div>
        <span class="space20"></span>
        <div class="row gy-3">
            <%=nwsstr %>
            <%--<div class="col-lg-4">
                <img src="images/residental-1.jpg" class="img-fluid" />
            </div>
            <div class="col-lg-8">
                <a href="#" class="semiBold fontRegular colorPrime text-decoration-none">Welcome to a London Lifestyle.</a>
                <span class="space5"></span>
                <span class="light clrGrey">Shah Developers | 06/09/2023</span>
                <span class="space10"></span>
                <p class="fontRegular light line-ht-7 mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                <a href="#" class="text-decoration-none">Continue Reading...</a>
            </div>
            <span class="greyLine"></span>
            

            <div class="col-lg-4">
                <img src="images/residental-1.jpg" class="img-fluid" />
            </div>
            <div class="col-lg-8">
                <a href="#" class="semiBold fontRegular colorPrime text-decoration-none">Welcome to a London Lifestyle.</a>
                <span class="space5"></span>
                <span class="light clrGrey">Shah Developers | 06/09/2023</span>
                <span class="space10"></span>
                <p class="fontRegular light line-ht-7 mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                <a href="#" class="text-decoration-none">Continue Reading...</a>
            </div>
              <span class="greyLine"></span>
             <div class="col-lg-4">
                <img src="images/residental-1.jpg" class="img-fluid" />
            </div>
            <div class="col-lg-8">
                <a href="#" class="semiBold fontRegular colorPrime text-decoration-none">Welcome to a London Lifestyle.</a>
                <span class="space5"></span>
                <span class="light clrGrey">Shah Developers | 06/09/2023</span>
                <span class="space10"></span>
                <p class="fontRegular light line-ht-7 mb-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                <a href="#" class="text-decoration-none">Continue Reading...</a>
            </div>--%>
        </div>
    </div>
    <%-- News end --%>
</asp:Content>

