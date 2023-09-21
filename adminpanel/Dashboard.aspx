<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="adminpanel_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h2 class="pgTitle">Dashboard</h2>
    <span class="space20"></span>
    <%-- Card Box --%>
    <div class="container-fluid">
        <div class="row">

             <div class="col-lg-3 col-6">
                <div class="small-box bg-info">
                    <div class="inner">
                        <h3><%=arrCounts[3]%></h3>
                        <p>Total Banners</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>

                    </div>
                    <a href="banner-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>

            <%-- Small Boxces --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-info">
                    <div class="inner">
                        <h3><%=arrCounts[0]%></h3>
                        <p>News</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>

                    </div>
                    <a href="news-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>


            <div class="col-lg-3 col-6">
                <div class="small-box bg-pink">
                    <div class="inner">
                        <h3><%=arrCounts[1]%></h3>
                        <p>Testimonials </p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>

                    </div>
                    <a href="testimonials-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>

             <%-- Small Boxces --%>
             <div class="col-lg-3 col-6">
                <div class="small-box bg-red">
                    <div class="inner">
                        <h3><%=arrCounts[2]%></h3>
                        <p>Total Customers </p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="customers-data.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>

           

            <%-- Small Box --%>
            <%--<div class="col-lg-3 col-6">
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3><%=arrCounts[3] %></h3>
                        <p>Events & Gallery</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="Event-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>--%>

             <%-- Small Boxces --%>
             <%--<div class="col-lg-3 col-6">
                <div class="small-box bg-purple">
                    <div class="inner">
                        <h3><%=arrCounts[5]%></h3>
                        <p>Total Banners</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="banner-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>--%>


            <%-- Small Boxces --%>
             <%--<div class="col-lg-3 col-6">
                <div class="small-box bg-primary">
                    <div class="inner">
                        <h3><%=arrCounts[2]%></h3>
                        <p>News</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="news.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>--%>

            </div>
        </div>    
</asp:Content>

