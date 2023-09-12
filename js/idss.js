//Get Element by Id

function id(ID)
  {
    return document.getElementById(ID);
  }
 
///Get Width
function getWidth()
{
    var width = 0;
    //IE
    if(!window.innerWidth)
    {
        //strict mode
        if(!(document.documentElement.clientWidth==0))
        {
            width = document.documentElement.clientWidth;
        }
        //quirks mode
        else
        {
            width = document.body.clientWidth;
        }
    }
    else
    {
        width = window.innerWidth;
    }
    return width;
}

//arrangeLayout
function arrangeLayout()
{
    var viewportWidth = getWidth();
    
//        if(viewportWidth <= 920)
//		{
//		    document.getElementById('navTop').style.display = 'none';
//		}
//		else
//		{
//		    document.getElementById('navTop').style.display = 'block';
    //		}

    //Homepage Slideshow Image height
    if (document.getElementById('Img1') != null) {
        var homeImgHt = document.getElementById('myMetro').clientWidth;
        //alert(homeImgHt);
        
        var colBoxes = getElementArray("div", "vkingMetro");
        if (colBoxes.length > 0) {
            for (i = 0; i < colBoxes.length; i++) {
                colBoxes[i].style.height = homeImgHt + "px";
            }
        }
        
    }
//    if (document.getElementById('homeImg') != null) {
//        var homeImgHt = document.getElementById('homeImg').clientHeight;
//        document.getElementById('homeImgTxt').style.height = homeImgHt + "px";
//        
//    }

    // Slideshow frame auto heigh
    if (document.getElementById('coverPic') != null) {
        var coverPicHeight = document.getElementById('coverPic').clientHeight;

        if (document.getElementById('coverPanel') != null) {
            document.getElementById('coverPanel').style.height = coverPicHeight + "px";
        }

        var slideImages = document.getElementsByClassName('slideImg');
        var i;
        var slideHeight;
        //alert(slideImages.length);
        for (i = 0; i < slideImages.length; i++) {
            slideHeight = slideImages[i].clientHeight;
            //alert(slideHeight);

            if (slideHeight > 0) {
                document.getElementById('slideshow').style.height = slideHeight + "px";
                return false;
            }
        }
        //alert(slideHeight);
    }


}


function getElementArray(elementName, className) {

    var list = document.getElementsByTagName(elementName);
    var value = "";
    var myList = [];
    for (i = 0; i < list.length; i++) {
        n = list[i].className.search(className);

        if (n >= 0) {
            myList.push(list[i]);
        }

    }
    return myList;
}
	
	
function toggleSpam(togDivId)
{
    var state = document.getElementById(togDivId).style.display;
    if (state == 'block') 
    {
        document.getElementById(togDivId).style.display = 'none';
    }
    else 
    {
       document.getElementById(togDivId).style.display = 'block';
    }
}

