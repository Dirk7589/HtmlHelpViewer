var cookie, selectedTab;

initalizeUI();
createGlobalCookie();
attachEventHandlers();

$(document).ready(function () {
    readCookie();
    var lastTab = cookie.selectedTab;
    selectLastTab(lastTab);
});

function createGlobalCookie() {
    if ($.cookie("helpViewerCookie") === undefined) {
        $.cookie("helpViewerCookie", "{\"selectedTab\" : 0, \"link\":\"\"}", { expires: 365, path: '/' });
    }
}

function initalizeUI() {
    $('#tipue_search_input').tipuesearch({ 'mode': 'static', 'showURL': false });
    $("#tabs").tabs({
        activate: function (event, ui) {
            selectedTab = ui.newTab.context.id.split("-")[2] - 1;
            cookie.selectedTab = selectedTab;
            writeCookie(cookie)
        }
    });
    $('#jstree_div').jstree({
        'core': tocData
    });


    $('div.split-pane').splitPane();
}

function selectLastTab(selectedTab) {
    $("#tabs").tabs("option", "active", selectedTab);
    
}

function navigateToContent(treeID) {
    var treeIDSplit = treeID[0].split("link:"),
        iframe = $("#content_pane");
    
    if (treeIDSplit[0] === "") {
        iframe.attr("src", treeIDSplit[1]);
        writeLink(treeIDSplit[1]);
    }

}

function attachEventHandlers() {
    $("#tipue_search_content").on('DOMSubtreeModified', function () {
        var alinks = $(this).find("div.tipue_search_content_title").find("a"),
            i;
        for (i = 0; i < alinks.length; i++) {
            $(alinks[i]).unbind('click');
            $(alinks[i]).on('click', clickHandler);
        }
        function clickHandler() {
            var iframe = $("#content_pane");
            iframe.attr("src", this.href);
            writeLink(this.href);
            return false;
        };
    })

    $('#jstree_div').on("changed.jstree", function (e, data) {
        navigateToContent(data.selected);
    });

    $("#content_pane").on('load', function () {
        readCookie(cookie);
        var urlOfPane = 'link:content/' + cookie.link.split('content/')[1], 
            currentSelection = $("#jstree_div").jstree('get_selected', true)[0];
        $("#jstree_div").jstree('deselect_node', currentSelection, true);
        $("#jstree_div").jstree('select_node', urlOfPane, true);

    });
}