<%@ Page Title="Projects | Shah Developers" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="projects.aspx.cs" Inherits="projects" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .btnviewproj{background:#383737; color:#ffffff; border-radius:10px; padding:8px; font-size:13px; text-decoration:none; margin-left:0 !important; font-weight:600; border:1px solid #383737; transition:0.5s}
        .btnviewproj:hover{background:none; color:#383737}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">Projects</h1>
                    <h2 class="pgsubtitle text-center">Land Development Projects</h2>
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
            <ul class="nav nav-tabs d-flex justify-content-center">

                    <li class="nav-item">
                        <a class="nav-link active show" data-bs-toggle="tab" data-bs-target="#allprojects">
                            <h4 class="fontRegular semiBold border p-2">Land Development</h4>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" data-bs-toggle="tab" data-bs-target="#civileng">
                            <h4 class="fontRegular semiBold border p-2">Constructions</h4>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" data-bs-toggle="tab" data-bs-target="#mecheng">
                            <h4 class="fontRegular semiBold border p-2">Infrastructure</h4>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-bs-toggle="tab" data-bs-target="#architech">
                            <h4 class="fontRegular semiBold border p-2">Completed</h4>
                        </a>
                    </li>
                </ul>

            <span class="semiBold regular colorPrime">Project Status</span>
            <asp:DropDownList ID="ddrProjStatus" CssClass="form-control  w-25 mt-2" runat="server">
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
                        <%--<div class="col-sm-4 gy-3 animate__animated animate__zoomIn">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/civil-engineering-1'">
                                <img src="images/projects/civil-eng-cover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Civil Engineering
                                            <br />
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/civil-engineering-1">View More</a></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4 gy-3 animate__animated animate__zoomIn">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/mechanical-engineering-2'">
                                <img src="images/projects/mech-projcover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Mechanical Engineering
                                            <br />
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/mechanical-engineering-2">View More</a></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4 gy-3">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/architectural-3'">
                                <img src="images/projects/archi-proj-cover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Architectural
                                            <br />
                                        <!--<span class="space20"></span>-->
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/architectural-3">View More</a></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4 gy-3">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/lightning-protection-system-design-4'">
                                <img src="images/projects/lightnig-protection-cover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Lightning Protection System
                                            <br />
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/lightning-protection-system-design-4">View More</a></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4 gy-3">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/geo-technical-engineering-5'">
                                <img src="images/projects/geo-technical-cover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Geo-technical Engineering
                                            <br />
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/geo-technical-engineering-5">View More</a></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4 gy-3">
                            <div class="butFrame" onclick="window.location='https://www.idssglobal.com/projects/international/information-technology-6'">
                                <img src="images/projects/informtion-techono-cover-img.jpg" class="img-fluid" />
                                <div class="butTextWrap">
                                    <div class="butHeading">
                                        Information Techonology
                                            <br />
                                        <div class="butText">For More Projects</div>
                                    </div>
                                    <p><a class="text-decoration-none colorWhite" href="https://www.idssglobal.com/projects/international/information-technology-6">View More</a></p>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

