<%@ Page Title="Projects | Shah Developers" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="projects.aspx.cs" Inherits="projects" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .btnviewproj {
            background: #383737;
            color: #ffffff;
            border-radius: 10px;
            padding: 8px;
            font-size: 13px;
            text-decoration: none;
            margin-left: 0 !important;
            font-weight: 600;
            border: 1px solid #383737;
            transition: 0.5s
        }

            .btnviewproj:hover {
                background: none;
                color: #383737
            }

        table {
            border-collapse: collapse;
            width: 100%;
            background: #fff;
        }

        td, th {
            border: 1px solid #0087cf;
            text-align: left;
            padding: 10px;
        }

        /*tr:nth-child(even) {
            background-color: #d0d0d0;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">Projects</h1>
                    <h2 class="pgsubtitle text-center"><%=pgHeader %></h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <section id="project" class="menu">
        <div class="container">
            <div class="text-center">
                <h2 class="semiBold medium colorPrime mb-2">Projects</h2>
                <p class="shorline"></p>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <ul class="nav nav-tabs d-flex justify-content-center">
                <%--<% string rootPath = Request.ApplicationPath; %>--%>
                <li class="nav-item">
                    <a href="<%=rootPath + "land-developement" %>" class="nav-link <%=actclass %>" data-bs-toggle="tab" data-bs-target="#allprojects">
                        <h4 class="fontRegular semiBold border p-2">Land Development</h4>
                    </a>
                </li>
                <li class="nav-item">
                    <a href="<%=rootPath + "construction"%>" class="nav-link <%=actclass1 %>" data-bs-toggle="tab" data-bs-target="#civileng">
                        <h4 class="fontRegular semiBold border p-2">Constructions</h4>
                    </a>
                </li>

                <li class="nav-item">
                    <a href="<%=rootPath + "infrastructure" %>" class="nav-link <%=actclass2 %>" data-bs-toggle="tab" data-bs-target="#mecheng">
                        <h4 class="fontRegular semiBold border p-2">Infrastructure</h4>
                    </a>
                </li>
                <li class="nav-item">
                    <a href="<%=rootPath + "completed" %>" class="nav-link <%=actclass3 %>" data-bs-toggle="tab" data-bs-target="#architech">
                        <h4 class="fontRegular semiBold border p-2">Completed</h4>
                    </a>
                </li>
            </ul>

                    <div id="proData" runat="server">
                        <span class="semiBold regular colorPrime">Project Status</span>
                        <asp:DropDownList ID="ddrProjStatus" CssClass="form-control  w-25 mt-2" runat="server" OnSelectedIndexChanged="ddrProjStatus_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">-- All --</asp:ListItem>
                            <asp:ListItem Value="1">Current</asp:ListItem>
                            <asp:ListItem Value="2">Upcoming</asp:ListItem>
                            <asp:ListItem Value="3">Completed</asp:ListItem>
                        </asp:DropDownList>

                        <div class="tab-content">

                            <div class="tab-pane active show" id="allprojects">

                                <div class="tab-header text-center">
                                    <%--<span class="space30"></span>--%>
                                </div>

                                <div class="row gy-3">

                                    <%=projstr %>

                                    <%--<div class="col-lg-6 g-0 mb-3">
                                        <div class="p-3">
                                            <div class="row g-0 border">
                                                <div class="col-md-6">
                                                    <div class="p-3">
                                                        <a href="#" class="semiBold semiMedium mb-2 colorPrime text-decoration-none">Whispering Woods</a>
                                                        <p class="light clrGrey mb-1">2500 sqft Plots | Miraj</p>
                                                        <p class="light line-ht-5 mb-4">Area of Land - 15 Acres Residential Bungalow Plots</p>
                                                        <a href="#" class="btnviewproj">View Project</a>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <img src="images/residental-1.jpg" class="img-fluid w-100 h-100" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 g-0 mb-3">
                                        <div class="p-3">
                                            <div class="row g-0 border">
                                                <div class="col-md-6">
                                                    <div class="p-3">
                                                        <a href="#" class="semiBold semiMedium mb-2 colorPrime text-decoration-none">Whispering Woods</a>
                                                        <p class="light clrGrey mb-1">2500 sqft Plots | Miraj</p>
                                                        <p class="light line-ht-5 mb-4">Area of Land - 15 Acres Residential Bungalow Plots</p>
                                                        <a href="#" class="btnviewproj">View Project</a>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <img src="images/residental-1.jpg" class="img-fluid w-100 h-100" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 g-0 mb-3">
                                        <div class="p-3">
                                            <div class="row g-0 border">
                                                <div class="col-md-6">
                                                    <div class="p-3">
                                                        <a href="#" class="semiBold semiMedium mb-2 colorPrime text-decoration-none">Whispering Woods</a>
                                                        <p class="light clrGrey mb-1">2500 sqft Plots | Miraj</p>
                                                        <p class="light line-ht-5 mb-4">Area of Land - 15 Acres Residential Bungalow Plots</p>
                                                        <a href="#" class="btnviewproj">View Project</a>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <img src="images/residental-1.jpg" class="img-fluid w-100 h-100" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 g-0 mb-3">
                                        <div class="p-3">
                                            <div class="row g-0 border">
                                                <div class="col-md-6">
                                                    <div class="p-3">
                                                        <a href="#" class="semiBold semiMedium mb-2 colorPrime text-decoration-none">Whispering Woods</a>
                                                        <p class="light clrGrey mb-1">2500 sqft Plots | Miraj</p>
                                                        <p class="light line-ht-5 mb-4">Area of Land - 15 Acres Residential Bungalow Plots</p>
                                                        <a href="#" class="btnviewproj">View Project</a>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <img src="images/residental-1.jpg" class="img-fluid w-100 h-100" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="" id="proInfra" runat="server">
            <div class="container">
                <span class="space30"></span>
                <div class="row">
                    <div class="col-md-6">
                        <div class="pad_15">
                            <img src="../images/govt-admn-ispampur.jpg" alt="" class="img-fluid" />
                        </div>
                    </div>
                    <div class="col-md-6 d-flex align-items-center">
                        <div class="pad_15">
                            <h2 class="semiBold medium">Infrastructure</h2>
                            <ul class="light line-ht-7" style="list-style: none; margin-left: -30px">
                                <li><span class="">&raquo;</span> Islampur tahsil Govt. Office</li>
                                <li><span class="">&raquo;</span> Construction of multistory building</li>
                                <li><span class="">&raquo;</span> Amount of contract - 10 Cr</li>
                                <li><span class="">&raquo;</span> Work period - 2014 to 2016</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="" id="compProj" runat="server">
            <span class="space35"></span>
            <div class="container">
                <div style="overflow-x: auto; box-shadow: 3px 3px 6px rgba(0, 0, 0, 0.3), -3px -3px 6px rgba(255, 255, 255, 0.3);">
                    <table class="border-table mrgT10" style="width: 100%">
                        <tr>
                            <th colspan="6" class="blue-bg-1">Completed Projects</th>
                        </tr>
                        <tr class="text-white">
                            <td class="themeBGPrime">Sr. No.</td>
                            <td class="themeBGPrime">Scheme</td>
                            <td class="themeBGPrime">Town</td>
                            <td class="themeBGPrime">Ares (sq.mt)</td>
                            <td class="themeBGPrime">Year</td>
                            <td class="themeBGPrime">Type</td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Shrinagar</td>
                            <td>Kupwad</td>
                            <td>11900.00</td>
                            <td>1988</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Shrinagar-2</td>
                            <td>Wanlesswadi</td>
                            <td>3458.00</td>
                            <td>1998</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Ameynagar-1</td>
                            <td>Savali</td>
                            <td>89700.00</td>
                            <td>1990</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>Ameynagar-2</td>
                            <td>Savali</td>
                            <td>13800.00</td>
                            <td>1991</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td>Ameynagar-3</td>
                            <td>Savali</td>
                            <td>25272.00</td>
                            <td>1995</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>6</td>
                            <td>Samaninagar</td>
                            <td>Tanang</td>
                            <td>28700.00</td>
                            <td>1990</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>7</td>
                            <td>Shrinathnagar</td>
                            <td>Savali</td>
                            <td>62402.00</td>
                            <td>1996</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>8</td>
                            <td>ParanjpePark-1</td>
                            <td>Sangli</td>
                            <td>7527.60</td>
                            <td>1997</td>
                            <td>Residential project</td>
                        </tr>
                        <tr>
                            <td>9</td>
                            <td>Balajinagar</td>
                            <td>Kupwad</td>
                            <td>125800.00</td>
                            <td>1994</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>10</td>
                            <td>Arwade Park</td>
                            <td>Sangli</td>
                            <td>28700.00</td>
                            <td>2000</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>11</td>
                            <td>Siddhivinayaknagar</td>
                            <td>Miraj</td>
                            <td>14600.00</td>
                            <td>2001</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>12</td>
                            <td>Indraprastha 1</td>
                            <td>Sangli</td>
                            <td>41600.00</td>
                            <td>1997</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>13</td>
                            <td>Indraprastha 2</td>
                            <td>Sangli</td>
                            <td>9065.90</td>
                            <td>1996</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>14</td>
                            <td>Whispering Woods</td>
                            <td>Miraj</td>
                            <td>58600.00</td>
                            <td>2006</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>15</td>
                            <td>Mahanagar 1 </td>
                            <td>Salavi</td>
                            <td>221300.00</td>
                            <td>2004</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>16</td>
                            <td>Mahanagar 2 </td>
                            <td>Salavi</td>
                            <td>81200.00</td>
                            <td>2006</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>17</td>
                            <td>Mahanagar 3</td>
                            <td>Salavi</td>
                            <td>32900.00</td>
                            <td>2008</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>18</td>
                            <td>Mahanagar 4</td>
                            <td>Kupwad</td>
                            <td>5761.80</td>
                            <td>2010</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>19</td>
                            <td>Magdum Industrial Park</td>
                            <td>Sangli</td>
                            <td>8056.30</td>
                            <td>2008</td>
                            <td>Industrial Plots</td>
                        </tr>
                        <tr>
                            <td>20</td>
                            <td>Mahadev Bag</td>
                            <td>Sangli</td>
                            <td>20200.00</td>
                            <td>2001</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>21</td>
                            <td>Paranjpe Park 2</td>
                            <td>Sangli</td>
                            <td>8124.40</td>
                            <td>2009</td>
                            <td>Developed Plotted Colony</td>
                        </tr>
                        <tr>
                            <td>22</td>
                            <td>TK Environ</td>
                            <td>Sangli</td>
                            <td>1000.00</td>
                            <td>2010</td>
                            <td>Resi / Commercial Project</td>
                        </tr>
                        <tr>
                            <td>23</td>
                            <td>Royale Citee </td>
                            <td>Kupwad</td>
                            <td>32374.58</td>
                            <td>2012</td>
                            <td>Residential Project</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

