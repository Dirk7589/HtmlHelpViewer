function readCookie(cookieToRead) {
    cookie = $.parseJSON($.cookie("helpViewerCookie"));
}

function writeCookie(cookie) {
    var jsonString = JSON.stringify(cookie);
    $.cookie("helpViewerCookie", jsonString, { expires: 365, path: '/' });
}

function writeLink(link) {
    readCookie();
    cookie.link = link;
    writeCookie(cookie);
}