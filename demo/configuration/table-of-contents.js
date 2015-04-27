// JavaScript source code
var tocData = {
    'multiple': false,
    "themes": {
        "theme": "default",
        "dots": true,
        "icons": true,
        "url": "../css/style.min.css"
    },
    'data': [
       { "id": "userguide", "parent": "#", "text": "User Guide" },
       { "id": "chapter1", "parent": "userguide", "text": "Chapter 1" },
       { "id": "link:content/section1.html", "parent": "chapter1", "text": "Section 1" },
       { "id": "link:content/section1.html#subSection", "parent": "link:content/section1.html", "text": "Sub Section"},
       { "id": "reference", "parent": "#", "text": "Reference" },
       { "id": "link:content/page1.html", "parent": "reference", "text": "Page 1" },
       { "id": "link:content/page2.html", "parent": "reference", "text": "Page 2" },
    ]
};