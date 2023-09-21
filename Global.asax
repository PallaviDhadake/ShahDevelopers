<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }
    void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("nws-route", "news/{newsId}", "~/news.aspx", false, new System.Web.Routing.RouteValueDictionary { { "newsId", string.Empty } });

       // routes.MapPageRoute("project-route", "projects/{protype}", "~/projects.aspx", false, new System.Web.Routing.RouteValueDictionary { { "protype", string.Empty } });


        routes.MapPageRoute("project-route", "projects/{protype}", "~/projects.aspx", false, new System.Web.Routing.RouteValueDictionary { { "protype", string.Empty } });


        routes.MapPageRoute("projectlist-route", "project-listings/{projectId}", "~/project-listings.aspx", false, new System.Web.Routing.RouteValueDictionary { { "projectId", string.Empty } });

        //routes.MapPageRoute("book-route", "book-publication/{bookId}", "~/book-publication.aspx", false, new System.Web.Routing.RouteValueDictionary { { "bookId", string.Empty } });
        //routes.MapPageRoute("tour-route", "tours/{trType}", "~/tours.aspx", false, new System.Web.Routing.RouteValueDictionary { { "trType", string.Empty } });
        //routes.MapPageRoute("events-route", "events/{eventId}", "~/events.aspx", false, new System.Web.Routing.RouteValueDictionary { { "eventId", string.Empty } });
        //routes.MapPageRoute("qt-route", "get-quote/{placeId}", "~/get-quote.aspx", false, new System.Web.Routing.RouteValueDictionary { { "placeId", string.Empty } });
        routes.MapPageRoute("album-route", "photo-gallery/{albumId}", "~/photo-gallery.aspx", false, new System.Web.Routing.RouteValueDictionary { { "albumId", string.Empty } });
        routes.MapPageRoute("case-route", "case-studies/{caseId}", "~/case-studies.aspx", false, new System.Web.Routing.RouteValueDictionary { { "caseId", string.Empty } });
        
        routes.MapPageRoute("abt-route", "about-us", "~/about-us.aspx");
       // routes.MapPageRoute("projects-route", "our-projects", "~/projects.aspx");
        routes.MapPageRoute("news-route", "news", "~/news.aspx");
        routes.MapPageRoute("career-route", "career", "~/career.aspx");
        routes.MapPageRoute("team-route", "our-team", "~/our-team.aspx");
        routes.MapPageRoute("video-route", "video-gallery", "~/video-gallery.aspx");
        routes.MapPageRoute("contact-route", "contact-us", "~/contact-us.aspx");
        routes.MapPageRoute("test-route", "testimonials", "~/testimonials.aspx");
        routes.MapPageRoute("energy-route", "energy", "~/energy-power-generation.aspx");
        routes.MapPageRoute("services-route", "services", "~/services.aspx");
        routes.MapPageRoute("loan-route", "loans", "~/loans.aspx");
        routes.MapPageRoute("deposite-route", "deposite", "~/deposite.aspx");
        routes.MapPageRoute("infertility-route", "infertility", "~/infertility.aspx");
        routes.MapPageRoute("facilities-route", "facilities", "~/facilities.aspx");
        //routes.MapPageRoute("vision-route", "vision", "~/vision.aspx");
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
