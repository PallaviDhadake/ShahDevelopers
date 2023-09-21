<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <title>Real Estate Projects & Plot Projects Developers Compnay Of Shah Developer</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Font Roboto -->
    <!--<link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700&family=Varela+Round&display=swap" rel="stylesheet" />-->

    <!-- Bootstrap -->
    <link href="Vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- aos -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>

    <!-- FancyBox -->
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.fancybox.js"></script>

    <!-- Swiper slider -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>

    <!--Animate Css  -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />

    <!-- Main Css -->
    <link href="css/shahDev.css" rel="stylesheet" />

    <!-- Bootstrap icon -->
    <link href="Vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <!--<a href="Vendor/bootstrap-icons/bootstrap-icons.json"></a>-->

    <style>
        .regbutton {display: inline-block; padding: 10px 20px; background-color: transparent; color: #f3e7e7 !important; font-size: 18px; border: none; position: relative; overflow: hidden; border:3px solid #f3e7e7; font-weight:600; text-decoration:none;}

        .regbutton :hover{color:#fff !important;}

    .btnborder{position: absolute; animation: 1s 1s linear infinite;}

        .btnborder-left { animation-name: to-top; background: linear-gradient(to bottom, #F93400, transparent);
            left: 0; bottom: -100%; width: 0.2em; height: 100%;}

        .btnborder-right { animation-name: to-bottom; background: linear-gradient(to bottom, transparent, #F93400);
            right: 0; top: -100%; width: 0.2em; height: 100%;}

        .btnborder-top {animation-delay: 1.5s; animation-name: to-right; background: linear-gradient(to right, transparent, #F93400); width: 100%; height: 0.2em; top: 0; left: -100%;}


        .btnborder-bottom {animation-delay: 1.5s; animation-name: to-left; background: linear-gradient(to right, #F93400, transparent); bottom: 0; right: -100%; width: 100%; height: 0.2em;}

        @keyframes to-top {
            to { bottom: 200%;}
        }

        @keyframes to-bottom {
            to {top: 200%;}
        }

        @keyframes to-left {
            to {right: 200%;}
        }

        @keyframes to-right {
            to {left: 200%;}
        }
    </style>

</head>
<body>
        <!-- Header start -->
    <section id="header">
        <div class="header">
        </div>
        <div class="">
            <div class="container-fluid">
                <div class="">

                </div>
            </div>
        </div>
    </section>
    <!-- Header End -->
    <!-- Navigation Start -->
    <section id="navbar" class="mb-0 mt-0">
        <a href="<%=rootPath %>" title="" class="txtDecNone">
            <img src="images/shah-logo.png" class="img-fluid mb-2 shahlogo p-2" />
            <!-- icons -->
            <div class="float-end me-4 mt-2" id="soacilico">
                <a href="https://www.facebook.com/shahdevelopers1" target="_blank" class="topFb me-1" title="Follow Us on facebook"></a>

                <a href="#" target="_blank" class="topyouTube me-1" title="Follow Us on Youtube"></a>
                <a href="#" target="_blank" class="demo" title="Follow Us on Instagram"></a>
            </div>
        </a>
        <div id="nav">
            <div id="topNavPanel" class="shadow">
                <div class="container-fluid">
                    <ul id="topNav" class="">
                        <a href="javascript:void(0)" class="closeBtn mb-5" onclick="closeNav()">&times;</a>
                        <li><a href="<%=rootPath%>">Home</a></li>
                        <li><a href="about-us">About Us</a></li>
                        <li><a href="our-team">Our Team</a></li>
                        <li><a href="projects/land-developement">Projects</a></li>
                        <li><a href="energy">Energy</a></li>
                        <li class=""><a class="" href="news">News</a></li>
                        <li class=""><a class="" href="testimonials">Testimonials</a></li>
                        <li class=""><a class="" href="contact-us" style="color: #2e9bca" id="bemem">Contact Us</a></li>
                    </ul>
                    <div class="float_clear"></div>
                    <div id="mobNav">
                        <div class="p-5">
                            <span class="regular upperCase text-white letter-sp-3 mrg_B_15">Phone:</span>
                            <a href="tel:+(0233) 2377585" class="medium text-white light text-decoration-none">(0233) 2377585</a>
                            <span class="space30"></span>
                            <span class="regular upperCase text-white letter-sp-3 mrg_B_15">Email:</span>
                            <a href="mailto:demo@gmail.com" class="text-white breakWord txtDecNone">san&#64;apshah&#46;gmail&#46;com</a>
                            <span class="space30"></span>
                            <span class="regular upperCase text-white letter-sp-3 mrg_B_15">Follow Us:</span>
                            <a href="#" target="_blank" class="me-2" title="Follow us on facebook"><img src="images/icons/tFb.png" /></a>
                            <a href="#" target="_blank" class="me-2" title="Follow us on Twitter"><img src="images/icons/twitter-top.png" /></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="float_clear"></div>
            <a id="navBtn" onclick="openNav()"></a>
        </div>
    </section>
    <!-- Navigation End -->
    <!-- banner start -->
    <section id="banner" class="position-relative">
        <div id="carouselExampleFade" class="carousel slide carousel-fade" data-bs-ride="carousel">
            <%=bannerstr %>
           <%-- <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="images/banner-1.jpg" class="d-block w-100" alt="..." />
                </div>
                <div class="carousel-item">
                    <img src="images/banner-2.jpg" class="d-block w-100" alt="..." />
                </div>
                <div class="carousel-item">
                    <img src="images/banner-3.jpg" class="d-block w-100" alt="..." />
                </div>
            </div>--%>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </section>

    <section id="form">
        <div class="container">
            <div class="row">
                <div class="col-9 bg-white shadow rounded Searchfrm">
                    <div class="p-4">
                        <form>
                            <div class="row g-4">
                                <div class="form-row">
                                    <div class="row">
                                        <div class="form-group col-3">
                                            <select class="form-select" aria-label="Default select example">
                                                <option selected>Category</option>
                                                <option value="1">Apartment</option>
                                                <option value="2">Houses</option>
                                                <option value="3">Industrial</option>
                                                <option value="1">Bunglow</option>
                                            </select>
                                        </div>
                                        <div class="form-group col-3">
                                            <select class="form-select" aria-label="Default select example">
                                                <option selected>City</option>
                                                <option value="1">Sangli</option>
                                                <option value="2">Kolhapur</option>
                                                <option value="3">Pune</option>
                                            </select>
                                        </div>
                                        <div class="form-group col-3">
                                            <select class="form-select" aria-label="Default select example">
                                                <option selected>Rooms</option>
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="3">4</option>
                                            </select>
                                        </div>
                                        <div class="form-group col-3">
                                            <button type="submit" class="btn btn-primary w-100"><i class="bi-search"></i> Search</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- data-aos="fade-down" data-aos-duration="1000" -->

    <section id="about" class="mt-5">
        <span class="space60"></span>
        <div class="container text-center">
            <div class="p-3">
                <p class="semiBold medium mb-1">About Shah Developers</p>
                <p class="light clrGrey mb-3"> We understand your unique needs and tastes! Get started on buying your new home! </p>
                <p class="fontRegular light line-ht-5 clrmediumgrey mb-3"><span class="colorBlack light">" Shah Developers is a leading group engaged in Land Development & Construction. The company had started its activities way back in 1988 "</span>  with a view to develop lands & Unique Residential / Commercial Complexes. With just two decades of continuous contribution, Shah Developers, today, is a class by themselves in the Real Estate & Construction industry in and around Sangli. Beauty & versatility, strength & simplicity and indomitable dependability are few of the focus areas of the company, when it comes to its projects.</p>
                <div class="text-center mt-3">
                    <a href="about-us" class="btnViewMore">View More</a>
                </div>
            </div>
        </div>
    </section>

    <!-- data-aos="fade-right" data-aos-duration="1000" -->
    <section id="projbyCat" class="mt-5 projcatbgclr">
        <div class="p-5">
            <div class="container text-center">
                <div class="">
                    <p class="semiBold medium mb-3">Properties by Category</p>
                    <p class="light clrGrey mb-3">
                        Highlight the best of your properties by using the List Category shortcode.
                        <span class="space5"></span>
                        You can list specific properties categories, types, cities, areas.
                    </p>
                    <div class="row gy-3 gx-3">
                        <span class="space15"></span>
                        <div class="col-md-6" id="projCat">
                            <a href="projects/land-developement" class="text-decoration-none">
                                <div class="overlayBanner">
                                    <img src="images/plot-project.png" class="img-fluid rounded" />
                                    <div class="overlay">
                                        <div class="p-4">
                                            <p class="semiBold float-start text-white">Plot Project</p>
                                            <p class="text-white bottomele">17 listing</p>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-6" id="projCat">
                            <a href="projects/construction" class="text-decoration-none">
                                <div class="overlayBanner">
                                    <img src="images/residental-project.jpg" class="img-fluid rounded" />
                                    <div class="overlay">
                                        <div class="p-4">
                                            <p class="semiBold float-start text-white">Residential Project</p>
                                            <p class="text-white bottomele">17 listing</p>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <span class="space30"></span>
    </section>


    <!-- data-aos="fade-left" data-aos-duration="1000" -->
    <!-- stats -->
    <span class="space50"></span>
    <section id="endassist">
        <span class="space20"></span>
        <div class="">
            <!--<span class="space50"></span>-->
            <div class="container text-center">
                <div class="p-3">
                    <p class="semiBold  medium mb-1">End To End Assistance</p>
                    <p class="light clrGrey mb-5"> We understand your unique needs and tastes! Get started on buying your new home! </p>

                    <!--<div class="custom-section">
                        <h3 class="section-title " data-aos="fade-down" data-aos-duration="1000">About Us</h3>
                    </div>-->

                    <div class="statsbox reveal">
                        <!--<span class="space20"></span>-->
                        <div class="">
                            <div class="row justify-content-center gy-2">
                                <div class="col-lg position-relative">
                                    <div class="imgborder">
                                        <img src="images/icons/contact-us.png" class="img-fluid mt-4" />
                                    </div>
                                    <span class="line"></span>
                                    <div class="text-center">
                                        <p class="semiBold semiMedium mb-2 mt-3">Contact Us</p>
                                        <p class="line-ht-5 light clrGrey endtxt">We understand your unique needs and tastes! Get started on buying</p>
                                    </div>

                                </div>
                                <div class="col-lg position-relative">
                                    <div class="imgborder">
                                        <img src="images/icons/site-visite.png" class="img-fluid mt-4" />
                                    </div>
                                    <span class="line"></span>
                                    <p class="semiBold semiMedium mb-2 mt-3">Site Visit</p>
                                    <p class="line-ht-5 light clrGrey">We understand your unique needs and tastes! Get started on buying</p>
                                </div>
                                <div class="col-lg position-relative">
                                    <div class="imgborder">
                                        <img src="images/icons/home-assistance.png" class="img-fluid mt-4" />
                                    </div>
                                    <span class="line"></span>
                                    <p class="semiBold semiMedium mb-2 mt-3">Home Loan Assistance</p>
                                    <p class="line-ht-5 light clrGrey">We understand your unique needs and tastes! Get started on buying</p>
                                </div>
                                <div class="col-lg position-relative">
                                    <div class="imgborder">
                                        <img src="images/icons/legal-advice.png" class="img-fluid mt-4" />
                                    </div>
                                    <span class="line"></span>
                                    <p class="semiBold semiMedium mb-2 mt-3">Legal Advice</p>
                                    <p class="line-ht-5 light clrGrey">We understand your unique needs and tastes! Get started on buying</p>
                                </div>
                                <div class="col-lg position-relative">
                                    <div class="imgborder" id="lastele">
                                        <img src="images/icons/unit-booking.png" class="img-fluid mt-4" />
                                    </div>

                                    <p class="semiBold semiMedium mb-2 mt-3">
                                        Unit Booking
                                    </p>
                                    <p class="line-ht-5 light clrGrey">We understand your unique needs and tastes! Get started on buying</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- stat end -->
    <span class="space50"></span>

    <!--<section class="mt-5" id="expcat">
        <div class="container text-center" data-aos="fade-down" data-aos-duration="1000">
            <p class="semiBold medium mb-3">Explore the most attractive categories</p>
            <p class="fontRegular clrGrey mb-5">
                Our distinctive buildings fill the skyline and streetscapes of the city
            </p>

            <div class="swiper mySwiper show">
                <div class="swiper-wrapper">
                    <div class="swiper-slide"><a href="images/slide-1.jpg" data-fancybox="group1"><img src="images/slide-1.jpg" class="img-fluid" /></a></div>
                    <div class="swiper-slide"><a href="images/slide-2.jpg" data-fancybox="group1"><img src="images/slide-2.jpg" class="img-fluid" /></a></div>
                    <div class="swiper-slide"><a href="images/slide-3.jpg" data-fancybox="group1"><img src="images/slide-3.jpg" class="img-fluid" /></a></div>
                    <div class="swiper-slide"><a href="images/slide-1.jpg" data-fancybox="group1"><img src="images/slide-1.jpg" class="img-fluid" /></a></div>
                    <div class="swiper-slide"><a href="images/slide-2.jpg" data-fancybox="group1"><img src="images/slide-2.jpg" class="img-fluid" /></a></div>
                    <div class="swiper-slide"><a href="images/slide-3.jpg" data-fancybox="group1"><img src="images/slide-3.jpg" class="img-fluid" /></a></div>
                </div>
                <div class="swiper-buttons-container">
                    <div class="swiper-button-prev shadow"></div>
                    <div class="swiper-button-next shadow"></div>
                </div>
            </div>
        </div>

    </section>-->
    <!-- Stat start -->
    <section id="stat" class="mt-5">
        <div class="bgstat">
            <div class="overlyBannr">
                <div class="p-4">
                    <div class="container" data-aos="fade-left" data-aos-duration="1000">
                        <div class="row d-flex align-items-center justify-content-center" style="height:400px">
                            <div class="col-md-6">
                                <h3 class="semiBold semiMedium text-white line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</h3>
                            </div>
                            <div class="col-md-6">
                                <div class="p-4">
                                    <a href="#" class="regbutton float-end">
                                        <div><span class="btnborder btnborder-left"></span><span class="btnborder btnborder-right"></span><span class="btnborder btnborder-top"></span><span class="btnborder btnborder-bottom"></span></div>
                                        Register Now
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- stat end -->
    <!-- News starts -->
    <section class="mt-5" id="news">
        <div class="container" data-aos="zoom-in" data-aos-duration="1000">
            <p class="semiBold medium mb-3 text-center">Latest News</p>
            <p class="light clrGrey mb-4 text-center">
                Our distinctive buildings fill the skyline and streetscapes of the city
            </p>
            <div id="carouselExampleControls" class="carousel slide position-relative" data-bs-ride="carousel">
                <%=GetNewsData1() %>
                <%--<div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="p-3">
                            <div class="row gy-3">
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class=" light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-2">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" class="" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class="light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-5">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="p-3">
                            <div class="row gy-3">
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class="light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-5">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class="light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-5">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="p-3">
                            <div class="row gy-3">
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class="light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-5">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6">
                                    <div class="row bg-white g-0">
                                        <div class="col-md-4">
                                            <img src="images/slide-2.jpg" class="w-100 h-100 img-fluid p-0" />
                                        </div>
                                        <div class="col-md-8 shadow">
                                            <div class="p-3">
                                                <a class="semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack">Villa on Washington Avenue</a>
                                                <span class="space5"></span>
                                                <span class="fst-italic clrGrey">21 / 10 / 2023</span>
                                                <p class="light clrmediumgrey line-ht-5 mt-2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown .</p>
                                                <hr />
                                                <img src="images/icons/view-anch.png" class="me-2" /><span class="clrGrey me-3">10</span> <span class="clrGrey me-5">By - Miss Pallavi Dhadake.</span><a href="#"><img src="images/icons/arr-right.png" /></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                    <img src="images/icons/nws-slide-arr-prev.png" class="nwsConBtnprev" />
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                    <img src="images/icons/nws-slide-arr-nxt.png" class="nwsConBtnnxt" />
                </button>
            </div>
            <span class="space80"></span>
            <div class="text-center">
                <a href="news" class="btnViewMore">View More</a>
            </div>
        </div>
    </section>
    <!-- News End -->
    <!-- Top Projects -->
    <section class="mt-5" id="topproj">
        <span class="space60"></span>
        <div class="bgexhibition">
            <div class="overlyexhibi">
                <div class="container">
                    <span class="space80"></span>
                    <p class="semiBold large text-white text-center">Our Top Projects</p>
                    <p class="light text-white mb-3 text-center">
                        Highlight the best of your properties by using the List Category shortcode.
                        <span class="space5"></span>
                        You can list specific properties categories, types, cities, areas.
                    </p>
                    <span class="space30"></span>
                    <div class="row">
                        <%=GetTopProjects() %>
                        <%--<div class="col-lg-4" data-aos="fade-down" data-aos-easing="linear" data-aos-duration="1500" id="top1">
                            <div class="image-zoom">
                                <img src="images/interior-1.jpg" class="img-fluid shadow" />
                            </div>

                            <div class="p-4 bg-white shadow">
                                <p class="semiBold semiMedium colorPrime mb-2 projtitle">Royale Citee Phase I</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Address : </b> Opp.Kupwad Octori Naka, Kupwad</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Saleable Area :</b> 2000-5000 sq.ft.</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Price :</b> Not Mentioned</p>
                                <p class="light clrmediumgrey line-ht-5 mt-2">It is Centrally located in Kupwad city & Spread over 8 Acres of lush greenery. Royale Citee offers you </p>
                                <a href="#" class="text-decoration-none">View More <img src="images/icons/nws-slide-arr-nxt.png" class="ms-3" /></a>
                            </div>
                        </div>
                        <div class="col-lg-4" data-aos="fade-down" data-aos-easing="linear" data-aos-duration="1500" id="top2">
                            <div class="image-zoom">
                                <img src="images/interior-1.jpg" class="img-fluid shadow" />
                            </div>

                            <div class="p-4 bg-white shadow">
                                <p class="semiBold semiMedium colorPrime mb-2 projtitle">Royale Citee Phase I</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Address : </b> Opp.Kupwad Octori Naka, Kupwad</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Saleable Area :</b> 2000-5000 sq.ft.</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Price :</b> Not Mentioned</p>
                                <p class="light clrmediumgrey line-ht-5 mt-2">It is Centrally located in Kupwad city & Spread over 8 Acres of lush greenery. Royale Citee offers you </p>
                                <a href="#" class="text-decoration-none">View More <img src="images/icons/nws-slide-arr-nxt.png" class="ms-3" /></a>
                            </div>
                        </div>
                        <div class="col-lg-4" data-aos="fade-down" data-aos-easing="linear" data-aos-duration="1500" id="top3">
                            <div class="image-zoom">
                                <img src="images/interior-1.jpg" class="img-fluid shadow" />
                            </div>
                            <div class="p-4 bg-white shadow">
                                <p class="semiBold semiMedium colorPrime mb-2 projtitle">Royale Citee Phase I</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Address : </b> Opp.Kupwad Octori Naka, Kupwad</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Saleable Area :</b> 2000-5000 sq.ft.</p>
                                <p class="clrGrey light mb-2"><b class="semiBold">Price :</b> Not Mentioned</p>
                                <p class="light clrmediumgrey line-ht-5 mt-2">It is Centrally located in Kupwad city & Spread over 8 Acres of lush greenery. Royale Citee offers you </p>
                                <a href="#" class="text-decoration-none">View More <img src="images/icons/nws-slide-arr-nxt.png" class="ms-3" /></a>
                            </div>
                        </div>--%>
                        <span class="space40"></span>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </section>
    <!-- Top Projects -->
    <span class="topprojsp"></span>


    <!-- Testimonails start -->
    <section id="testimonials" class="mt-5">
        <span class="space30"></span>
        <div class="container">
            <p class="semiBold medium mb-3 text-center">Testimonials</p>
            <p class="fontRegular clrGrey mb-5 text-center">
                What People are saying to us
            </p>
            <div class="row">
                <%=GetTestData() %>
                <%--<div class="col-lg-4" data-aos="fade-right" data-aos-offset="300" data-aos-easing="ease-in-sine">
                    <a href="#" class="txtDecNo colorBlack">
                        <div class="p-3">
                            <span class="space10"></span>
                            <span class="clrGrey light small">01.02.2025   / CO-WORKING </span>
                            <span class="space10"></span>
                            <h4 class="semiBold semiMedium eventheading">Pallavi Ramesh Dhadake</h4>
                            <span class="clrGrey small">Happy Buyer</span>
                            <hr />
                            <p class="fontRegular light  line-ht-5 mb-4 mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum! Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum!</p>
                            <a href="#" class="semiBold fontRegular text-decoration-none colorBlack readevnt">Read More <img src="images/icons/rght-icon.png" class="ms-2" /></a>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4" data-aos="fade-down" data-aos-easing="linear" data-aos-duration="1500">
                    <div class="p-3">
                        <span class="space10"></span>
                        <span class="clrGrey light small">01.02.2025   / CO-WORKING </span>
                        <span class="space10"></span>
                        <h4 class="semiBold semiMedium eventheading">Pallavi Ramesh Dhadake</h4>
                        <span class="clrGrey small">Happy Buyer</span>
                        <hr />
                        <p class="fontRegular light  line-ht-5 mb-4 mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum! Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum!</p>
                        <a href="#" class="semiBold fontRegular text-decoration-none colorBlack readevnt">Read More <img src="images/icons/rght-icon.png" class="ms-2" /></a>
                    </div>
                </div>
                <div class="col-lg-4" data-aos="fade-left" data-aos-offset="300" data-aos-easing="ease-in-sine">
                    <div class="p-3">
                        <span class="space10"></span>
                        <span class="clrGrey light small">01.02.2025   / CO-WORKING </span>
                        <span class="space10"></span>
                        <h4 class="semiBold semiMedium eventheading">Pallavi Ramesh Dhadake</h4>
                        <span class="clrGrey small">Happy Buyer</span>
                        <hr />
                        <p class="fontRegular light  line-ht-5 mb-4 mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum! Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga soluta sit fugiat eum!</p>
                        <a href="#" class="semiBold fontRegular text-decoration-none colorBlack readevnt">Read More <img src="images/icons/rght-icon.png" class="ms-2" /></a>
                    </div>
                </div>--%>
            </div>
        </div>
        <span class="space30"></span>
        <div class="text-center">
            <a href="testimonials" class="btnViewMore">View More</a>
        </div>
    </section>
    <!-- Testimonails start -->
    <!-- Leader in land developemt -->
    <section id="landdelop" class="mt-5">
        <div class="row p-0 g-0">
            <div class="col-md-6 position-relative" data-aos="zoom-in" data-aos-duration="1000">
               <%-- <%=photogalimg %>--%>
                <img src="images/plot-project.png" class="img-fluid" />
                <div class="row">
                    <div class="col-5 shadow" id="landinfo">
                        <div class="bg-white shadow" style="position:absolute; bottom:0; left:120px; right:120px;">
                            <div class="p-3">
                                <h2 class="semiBold semiMedium mb-3 colorPrime">Leaders in Real Estate & Land Development</h2>
                                <p class="fontRegular light line-ht-5 clrmediumgrey">Shah Developers is a leading group engaged in Land Development & Construction. The company had started its activities way back in 1988, with a view to develop lands & Unique Residential / Commercial Complexes. With just two decades of continuous contribution, Shah Developers, today, is a class by themselves in the Real Estate & Construction industry in and around Sangli. Beauty & versatility, strength & simplicity and indomitable dependability are few of the focus areas of the company, when it comes to its projects.</p>
                                <a href="#" class="text-decoration-none"><img src="images/icons/nws-slide-arr-nxt.png" /></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           
            <div class="col-md-6">
                <div class="row g-0">
                     <%=GetPhotoGal() %>
                    <%--<div class="col-md-6" data-aos="zoom-in" data-aos-duration="1000">
                        <a href="images/slide-2.jpg" data-fancybox="group2"><img src="images/slide-2.jpg" class="img-fluid w-100" /></a>
                    </div>
                    <div class="col-md-6" data-aos="zoom-in" data-aos-duration="1000">
                        <a href="images/slide-3.jpg" data-fancybox="group2"><img src="images/slide-3.jpg" class="img-fluid" /></a>
                    </div>
                    <div class="col-md-6" data-aos="zoom-in" data-aos-duration="1000">
                        <a href="images/slide-1.jpg" data-fancybox="group2"><img src="images/slide-1.jpg" class="img-fluid" /></a>
                    </div>
                    <div class="col-md-6" data-aos="zoom-in" data-aos-duration="1000">
                        <a href="images/slide-3.jpg" data-fancybox="group2"><img src="images/slide-3.jpg" class="img-fluid" /></a>
                    </div>--%>
                </div>
            </div>
        </div>

    </section>
    <!-- Leader in land developemt -->
    <!-- Locatins start -->
    <section id="loaction" class="mt-5 mb-5">
        <div class="container text-center" data-aos="fade-right" data-aos-duration="1000">
            <p class="semiBold medium mb-1">Shah Group Presence</p>
            <p class="light fontRegular clrGrey mb-3"> Our Projects locations we work this ares  </p>
            <div class="row mt-4">
                <div class="col-sm-2">
                    <img src="images/sangli.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Sangli</p>
                </div>
                <div class="col-sm-2">
                    <img src="images/miraj.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Miraj</p>
                </div>
                <div class="col-sm-2">
                    <img src="images/kolhapur.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Kolhapur</p>
                </div>
                <div class="col-sm-2">
                    <img src="images/pune.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Pune</p>
                </div>
                <div class="col-sm-2">
                    <img src="images/Kalyan.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Mumbai</p>
                </div>
                <div class="col-sm-2">
                    <img src="images/Ahemdabad.png" class="w-50 img-fluid" />
                    <p class="semiBold light text-center mt-3">Ahmedabad</p>
                </div>
            </div>
        </div>
    </section>
    <!-- Locatins end -->
    <!-- Footer start -->
    <section id="footer" class="bgfooter">
        <!-- Footer Starts -->
        <div class="footerBanner">
            <div class="overlyFooter">
                <span class="space20"></span>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="p-3">
                                <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Navigation</h4>
                                <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                                <ul class="footerNav">
                                    <li><a href="<%=rootPath %>">Home</a></li>
                                    <li><a href="about-us">About Us</a></li>
                                    <li><a href="projects">Projects</a></li>
                                    <li><a href="energy">Enegry</a></li>
                                    <li><a href="testimonials">Testimonials</a></li>
                                    <li><a href="news">News</a></li>
                                    <li><a href="contact-us">Contact us</a></li>
                                </ul>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="p-3">
                                <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Contact Info</h4>
                                <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                                <span class="clrmediumgrey line-ht-5 small fontRegular addr">
                                    'Poshish', 1st Floor, Lale Plots, Madhavnagar Road, Sangli - 416416 Sangli, Maharashtra (India)
                                </span>
                                <span class="space10"></span>
                                <a href="#" class="email breakWord line-ht-5 small txtDecNone">san&#64;apshah&#46;com</a>
                                <span class="space15"></span>
                                <span class="foo_call line-ht-5 small txtDecNone">+(0233) 2377585</span>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="p-3">
                                <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Latest Properties</h4>
                                <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                                <div class="row gy-2 gx-0 p-0">
                                    <div class="col-6">
                                        <img src="images/residental-project.jpg" class="img-fluid rounded w-75" />
                                    </div>
                                    <div class="col-6">
                                        <p class="fontRegular footxtClr mt-3">Luxury House in Sangli</p>
                                    </div>
                                    <div class="col-6">
                                        <img src="images/plot-project.png" class="img-fluid rounded w-75" />
                                    </div>
                                    <div class="col-6">
                                        <p class="fontRegular footxtClr mt-3">Luxury House in <br />Miraj</p>
                                    </div>
                                    <div class="col-6">
                                        <img src="images/royale-vt-avenue-na-plots-3.jpg" class="img-fluid rounded w-75" />
                                    </div>
                                    <div class="col-6">
                                        <p class="fontRegular footxtClr mt-3">Luxury House in Kolhapur</p>
                                    </div>
                                </div>
                                <!--<div class="fLine mb-3"><span class="fAbsLine"></span></div>
                                <span class="footxtClr line-ht-5 small fontRegular">
                                    Our Real Estate Inc company is committed to delivering a high level of expertise, customer service, and attention to detail to the marketing and sales of luxury real estate, and rental properties.
                                </span>
                                <span class="space30"></span>-->
                            </div>
                        </div>
                    </div>
                </div>
                <span class="space20"></span>
                <span class="footerLine"></span>
                <span class="space20"></span>

                <div class="container text-center">
                    <span class="clrGrey mrg_B_5 small fontRegular">&copy; <%=currentyear %> | Shah Developers , All Rights Reserved</span>
                    <span class="clrGrey small fontRegular">Website By <a href="http://www.intellect-systems.com" target="_blank" class="intellect" title="Website Design and Development Service By Intellect Systems">Intellect Systems</a></span>
                    <span class="space20"></span>
                </div>

            </div>
        </div>
        <!-- Footer Ends -->
    </section>
    <!-- footer end -->
    <!-- banner end -->


    <script type="text/javascript">
        function openNav() {
            document.getElementById("topNavPanel").style.width = "320px";
            document.getElementById("navBtn").style.zIndex = "0";
        }

        function closeNav() {
            document.getElementById("topNavPanel").style.width = "0";
            document.getElementById("navBtn").style.zIndex = "5";
        }
    </script>


    <script>
        var swiper = new Swiper(".mySwiper", {
            slidesPerView: 3,
            spaceBetween: 20,
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },

            //pagination: {
            //    el: ".swiper-pagination",
            //    clickable: true,
            //},
        });
    </script>
    <script>
        AOS.init();
    </script>

    <script>
        var a = 0;
        $(window).scroll(function () {

            var oTop = $('#counter').offset().top - window.innerHeight;
            if (a == 0 && $(window).scrollTop() > oTop) {
                $('.count-num').each(function () {
                    var $this = $(this),
                        countTo = $this.attr('data-count');
                    $({
                        countNum: $this.text()
                    }).animate({
                        countNum: countTo
                    },

                        {

                            duration: 2000,
                            easing: 'swing',
                            step: function () {
                                $this.text(Math.floor(this.countNum));
                            },
                            complete: function () {
                                $this.text(this.countNum);
                                //alert('finished');
                            }

                        });
                });
                a = 1;
            }

        });
    </script>
</body>
</html>
