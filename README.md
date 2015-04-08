# HtmlHelpViewer
A HTML Help viewer that provides a table of contents and search for HTML pages.

Overview

This is an HTML based help viewer designed to provide a table of contents and search for html pages.
These features are provided using Jqeury UI, JSTree, and Tipue-search. This viewer will work
inside all browsers and all operating systems. The viewer can be placed on a server,
or installed on a local machine. 

Setup and Installation

Two modes of installation are available, online and offline

Offline:
1: Create a directory on a customers machine where the help viewer will be installed.  
2: Inside the installation directory install the following files and folders:  
	$/content  
	$/configuration  
	$/css  
	$/external  
	$/mainPage.help  
3: Place your content files inside the content folder. Note, these files can contain sub folders.  
3.1: In order to have the table of contents update when clicking a link to another page inside the  
help file, add the following elements to the bottom of your html pages.  
'''html  
\<script src="../external/jquery/jquery.js"\></script\>  
\<script src="../external/jquery.cookie.js"\></script\>  
\<script src="../external/help-viewer-utilities.js"\>\</script\>  
\<script\>  
	$("a").on('click', function () {  
		writeLink(this.href);  
		return true;  
	});  
\</script\>  
'''  
4: Build your table of contents by editing table-of-contents.js  
4.1: Each entry in the table of contents contains the following key/value pairs, id, parent, and text.  
4.2: id, represents a node in the tree. If a node in the tree represents  
a page to link to the id must be structured as followed "link:content/myContent.html" Linking to anchors inside a page  
is also supported such as "link:content/myContent.html#myAnchor"  
4.3: parent, represents the id of a nodes parent node.   
4.4: text, represents the text to display in the tree  
5: Build the offline search content file either using the searchUpdater CSharp project, or another application  
6: Launch mainPage.html  

For more information about building the table of contents, see the Using the alternative JSON Format section of http://www.jstree.com/docs/json/  
For more information about building an offline tipue search content, see JSON MODE section of http://www.tipue.com/search/docs/  

Copyright and Acknowledgements  

The following libraries and scripts were used to create the HTML Help Viewer.  
* Jquery UI: http://jqueryui.com/  
* JSTree: http://www.jstree.com/  
* Split-pane: https://github.com/shagstrom/split-pane  
* Tipue-search: http://www.tipue.com/search/  
* Jquery Cookie: https://github.com/carhartl/jquery-cookie  