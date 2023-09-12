<%@ Page Title="Team of Shah developers" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="our-team.aspx.cs" Inherits="our_team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">Team</h1>
                    <h2 class="pgsubtitle text-center">Team of Shah Developers</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space20"></span>

    <%-- Team start --%>
    <div class="container">
        <div class="text-center">
            <h2 class="semiBold medium colorPrime mb-2">Our Team</h2>
            <p class="shorline"></p>
        </div>
        <div class="row gx-4">
            <span class="space10"></span>
            <div class="col-lg-4 rounded">
                <div class="bg-white shadow teambox rounded">
                    <div class="themeBGPrime rounded-top">
                        <div class="p-2">
                            <p class="semiBold semiMedium text-white text-center mt-2">Mr. Aroon Popatlal Shah</p>
                        </div>
                    </div>
                    <div class="p-4">
                        <p class="semiBold colorSec regular">Designation : <span class="clrGrey light line-ht-5">Partners In Company</span></p>
                        <span class="space5"></span>
                        <p class="light line-ht-5 clrGrey">He holds over 23 years of enriched experience in the area of Real Estate & Infrastructure Projects like development of residential colony, eco-tourism projects etc.
                            <span class="space10"></span>
                            Specialize & most experience in area of developing residential plots with infrastructures.
                              <span class="space10"></span>
                            With the support of son Akshay, Aroon Shah Enterprise is entering in the field of construction of residential & commercial complex in the name of “Shah Developers”.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="bg-white shadow teambox rounded">
                    <div class="themeBGPrime rounded-top">
                        <div class="p-2">
                            <p class="semiBold semiMedium text-white text-center mt-2">Mr. Akshay Aroon Shah</p>
                        </div>
                    </div>
                    <div class="p-4">
                        <p class="semiBold colorSec regular">Qualification  : <span class="clrGrey light line-ht-5"> B.E. Civil, PGPCM NICMAR, MBA (Finance)</span></p>
                        <p class="semiBold colorSec regular">Designation : <span class="clrGrey light line-ht-5">Partners In Company</span></p>
                        <span class="space5"></span>
                        <p class="light line-ht-5 clrGrey">Handling Residential & Commercial Projects at Sangli, Pune, Mumbai around 50,00,000 sq.fts. of Construction.
                        </p>
                    </div>
                     <span class="space80"></span>
                 <span class="space60"></span>
                </div>
               
            </div>
            <div class="col-lg-4 ">
                <div class="bg-white shadow teambox rounded">
                    <div class="themeBGPrime rounded-top">
                        <div class="p-2">
                            <p class="semiBold semiMedium text-white text-center mt-2">Mr. Amey Aroon Shah</p>
                        </div>
                    </div>
                    <div class="p-4">
                        <p class="semiBold colorSec regular">Qualification  : <span class="clrGrey light line-ht-5"> B.Tech (Mechanical), MBA (Finance) USA</span></p>
                        <p class="semiBold colorSec regular">Designation : <span class="clrGrey light line-ht-5">Partners In Company</span></p>
                        <span class="space5"></span>
                        <p class="light line-ht-5 clrGrey">Handling Planning & Execution of different Residential & Commercial Projects.
                        </p>
                    </div>
                    <span class="space80"></span>
                 <span class="space80"></span>
                </div>
            </div>
        </div>
    </div>
    <%-- Team end --%>
</asp:Content>

