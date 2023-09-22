<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="project-listings.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="project_listings" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #map-canvas {
            width: 100%;
            height: 350px;
            margin: 0;
            padding: 0;
        }

        #share-buttons img {
            width: 35px;
            padding: 5px;
            border: 0;
            box-shadow: 0;
            display: inline;
        }
        .pdfLink {
	background: url("/images/icons/pdf.png") no-repeat left center;
	padding-left: 30px;
	text-decoration: none;
	color: #EC3237;
	font-size: 1.3em;
	line-height: 2;
	font-weight: 400;
}

	.pdfLink:hover {
		border-bottom: 1px solid #EC3237;
        color:#EC3237;
	}


    .video-container{display:table;	width:100%}
    .video-box{display:table-cell; vertical-align:middle; width:100%; position:relative; height:500px}
    .YTPOverlay{background:rgba(30, 31, 33, 0.4); position:absolute; z-index:555; top:0; left:0; width:100%; height:100%}
    .inner-video{position:absolute; z-index:0;	min-width:100%; min-height:100%; left:0; top:0; overflow:hidden; opacity:1; height:350px}
    .container{position:relative; z-index:5;}
    .dis-block{display:block;}
    .vidAnch{text-decoration:none; background-color:transparent; border:2px solid #fff; display:inline-block; padding:12px 22px; color:#fff; -webkit-transition:all 0.7s ease; -moz-transition:all 0.7s ease; -o-transition:all 0.7s ease; transition:all 0.7s ease;}
    .vidAnch:hover{background:#fff; color:#0090d4;}
    .videobg{background:url("../images/img-video.jpg"); background-size:cover; width:100%; height:500px; box-shadow: inset 0 0 0 2000px rgba(30, 31, 33, 0.4);}
    </style>

    <%--<link href="css/jquery.mb.YTPlayer.min.css" rel="stylesheet" />--%>
    
    <!-- Google Maps scripts -->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvO0AHfg1cuND1KXbw3t5xZr5p4PVrEk4"></script>

    <script type="text/javascript">
        function initialize(latLong) {
            var latLngArr = latLong.split(',');
            var myLatlng = new google.maps.LatLng(latLngArr[0], latLngArr[1]);

            var mapOptions = {
                center: myLatlng,
                zoom: 15, scrollwheel: false, draggable: false
            };

            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);

            // To add the marker to the map, use the 'map' property
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: "Shah Developers, Sangli"
            });

        }
    //google.maps.event.addDomListener(window, 'load', initialize);
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Project basic info --%>
    <span class="space50"></span>
    <div class="container">
          <%=projstr %>
    </div>
  
    <%-- Project Information --%>
    <div class="container mt-5">
        <p class="medium colorPrime">More About <%=projTitle %></p>
        <%=projectInfo %>
    </div>


      <%-- Ploat  --%>
    <div class="container mt-5">
         <p class="medium colorPrime mb-4"><%=projTitle %> Floor Plans</p>
        <%=plotstr %>
    </div>
    <%-- ploat ends --%>


     <!--ammenties starts -->
    <div class="container">
        <span class="space30"></span>
        <p class="medium colorPrime"><%=projTitle %> Ammenities</p>

        <span class="space20"></span>
        <%=plotammenities %>
        <span class="space30"></span>
    </div>
    <!--ammenties ends-->

    <%-- project basic info end --%>
   

<%--    https://youtu.be/WMoXVQkGJJU?si=Lf96FVPHyTzHBrQv

    https://www.youtube.com/watch?v=wzPUYk2maj8--%>

    <%-- Project video starts --%>

    <%--<video src="images/HONDA_ELEVATE_MEMRISINF_MOVE.mp4" controls="controls" />--%>
    <div class="container">
         <p class="medium colorPrime mb-3">Project Video</p>
       <%-- <section id="video">--%>
        <div class="">
            <div class="video-container">
                <div class="video-box">
                    <div class="inner-video" id="v-pl">
                        <div id="player" class="player dis-block" data-property="{videoURL:'https://www.youtube.com/watch?v=WMoXVQkGJJU',containment:'#v-pl', autoplay: true, showControls: false, mute:true, loop:true, opacity:1}"></div>
                    </div>
                </div>
            </div>
        </div>
        <span class="space60"></span>
    <%--</section>--%>
    </div>
    
    <%-- Project video ends --%>

    <!--Projects Gal starts -->
    <div class="container">
        <p class="medium colorPrime">Gallery</p>
         <%--<p class="semiBold medium text-decoration-underline">Photo Gallery</p>--%>
        <div class="row gy-3">
            <%=photogal %>
        </div>
    </div>
    <!--Projects Gal ends -->

     <!--Map starts-->
    <span class="space30"></span>
    <div class="container">
        <div id="map-canvas"></div>
    </div>
    <!--Map ends-->

    <%-- Project Document starts --%>
    <div class="container">
        <span class="space20"></span>
        <%=document %>
    </div>
    <%-- project documents end --%>

    <%-- Enquiry form starts--%>
    <span class="space20"></span>
    <div class="container">
        <div class="">
            <p class="medium colorPrime">Send us enquiry about <%=projTitle %></p>
            <%--<p class="semiBold medium text-decoration-underline">Contact Us</p>--%>
            <div class="row g-0 bg-white shadow">
                <%--<div class="col-md-5">
                    <img src="<%=Master.rootPath + "images/shah-logo-pro-1.jpg"%>" class="img-fluid w-100"/>
                </div>--%>
                <div class="bgenquiry">
                    <div class="p-3">
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
                                <asp:TextBox ID="txtPhone" class="conTextBox" MaxLength="10" placeholder="Mobile No *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtcity" class="conTextBox" placeholder="City *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <span class="space30"></span>
                        <asp:Button ID="btnSubmit" CssClass="buttonForm text-uppercase" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                         </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
 
    </div>
                    
    <%-- Enquiry form ends--%>

</asp:Content>

