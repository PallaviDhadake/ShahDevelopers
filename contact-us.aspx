<%@ Page Title="Contact Us | Shah Developers" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvO0AHfg1cuND1KXbw3t5xZr5p4PVrEk4">
    </script>
    <script type="text/javascript">
        function initialize() {

            var myLatlng = new google.maps.LatLng(16.864602651367203, 74.57912492372752);

            var mapOptions = {
                center: myLatlng,
                zoom: 18, scrollwheel: false, draggable: true,
            };

            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
            var autoqed = {
                path: 'M95.35,50.645c0,13.98-11.389,25.322-25.438,25.322c-14.051,0-25.438-11.342-25.438-25.322   c0-13.984,11.389-25.322,25.438-25.322C83.964,25.322,95.35,36.66,95.35,50.645 M121.743,50.645C121.743,22.674,98.966,0,70.866,0   C42.768,0,19.989,22.674,19.989,50.645c0,12.298,4.408,23.574,11.733,32.345l39.188,56.283l39.761-57.104   c1.428-1.779,2.736-3.654,3.916-5.625l0.402-0.574h-0.066C119.253,68.516,121.743,59.874,121.743,50.645',
                fillColor: '#443252',
                fillOpacity: 1,
                scale: 0.3
            };
            var marker = new google.maps.Marker({
                position: myLatlng,
                icon: autoqed,
                map: map,
                title: "SHAH REAL ESTATE DEVELOPERS",
                animation: google.maps.Animation.DROP
            });
            //alert("test");
            marker.addListener('click', toggleBounce);
            function toggleBounce() {
                if (marker.getAnimation() !== null) {
                    marker.setAnimation(null);
                } else {
                    marker.setAnimation(google.maps.Animation.BOUNCE);
                }
            }
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <style>
        #map-canvas {
            height: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader1" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">Contact Us</h1>
                    <h2 class="pgsubtitle text-center">Contact Us Shah Developers</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space20"></span>

    <%-- contact us start --%>
    <div class="container">
        <div class="text-center">
            <h2 class="semiBold medium colorPrime mb-2">Get In Touch With Us</h2>
            <p class="shorline"></p>
        </div>
        <span class="space30"></span>
        <div class="row g-0 m-0">
            <div class="col-md-6">
                <div class="contctimg">
                    <div class="contctoverly d-flex align-items-center justify-content-center">
                        <div class="p-4">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <span class="con-addr line-ht-5 light colorWhite">'Poshish', 1st Floor, Lale Plots, Madhavnagar Road, Sangli - 416416 Sangli, Maharashtra (India)</span>
                                </div>
                                <span class="space15"></span>
                                <div class="col-md-12 col-sm-12">
                                    <a href="#" class="con-email line-ht-5 light colorWhite">san.apshah@gmail.com</a>
                                </div>
                                <span class="space15"></span>
                                <div class="col-md-12 col-sm-12">
                                    <%-- <%=contstr %>--%>
                                    <a href="tel:(0233)2377585" class="con_call line-ht-5 light text-white txtdecnone">(0233) 2377585</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6 shadow position-relative">
                <div class="p-4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="form-group col-md-12">

                                    <asp:TextBox ID="txtName" class="conTextBox" placeholder="Name *" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12">

                                    <asp:TextBox ID="txtEmail" class="conTextBox" placeholder="Email *" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-12">

                                    <asp:TextBox ID="txtPhone" class="conTextBox" placeholder="Mobile No *" runat="server" MaxLength="10"></asp:TextBox>
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <asp:TextBox ID="txtMsg" class="conTextBox" TextMode="MultiLine" Height="150" placeholder="Message *" runat="server"></asp:TextBox>
                            </div>
                            <span class="space20"></span>

                            <asp:Button ID="btnSubmit" CssClass="buttonForm text-uppercase" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div id="map-canvas"></div>
    </div>
</asp:Content>

