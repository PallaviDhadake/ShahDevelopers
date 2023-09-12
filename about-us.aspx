<%@ Page Title="About us | Shah developers sangli" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="about-us.aspx.cs" Inherits="about_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">About</h1>
                    <h2 class="pgsubtitle text-center">About Shah Developers</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space20"></span>

    <%-- About start --%>
    <div class="container text-center">
        <h2 class="semiBold medium colorPrime mb-2">About us</h2>
        <p class="shorline"></p>
        <p class="light clrGrey line-ht-5 mb-4">Shah Developers is a leading group engaged in Land Development & Construction. The company had started its activities way back in 1988, with a view to develop lands & Unique Residential / Commercial Complexes. With just two decades of continuous contribution, Shah Developers, today, is a class by themselves in the Real Estate & Construction industry in and around Sangli. Beauty & versatility, strength & simplicity and indomitable dependability are few of the focus areas of the company, when it comes to its projects.
            <span class="space10"></span>
            The company is equipped with modern amenities. The Main Vision is to “Explore New Avenues Reach the Consumers and satisfy them”. In order to meet the said requirement, The company has employed a team of highly qualified and experienced Engineers , Architects, Contractors, Network Engineers, Chartered Accountants, Management Executives, Tax Consultants, etc.
        </p>
        <div class="row p-0 m-0">
            <div class="col-md-6 themeBGPrime">
                <div class="p-3">
                    <img src="images/icons/mission.png" class="img-fluid mb-3"/>
                    <h5 class="semiBold semiMedium text-white mb-3">Our Mission </h5>
                    <p class="light line-ht-5 text-white">The Company is committed to build long-term relationships based on integrity, performance, value, and customer’s satisfaction. We will continue to meet the changing needs of our customers with our quality services delivered by the most qualified people.</p>
                </div>
            </div>
            <div class="col-md-6 themeBGSec">
                <div class="p-3">
                    <img src="images/icons/vision.png" class="img-fluid mb-3"/>
                     <h5 class="semiBold semiMedium text-white mb-3">Our Vision </h5>
                   <p class="light line-ht-5 text-white">Shah Developers is not just a Real Estate & construction company but is a dedicated team striving to bring growth to the community, assist our customers in making their dreams become a reality.</p>
                </div>
            </div>
        </div>
    </div>
    <%-- About end --%>

</asp:Content>

