using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("NewsPosts")]
public class NewsItem {

    [XmlAttribute("Date")]
    public int date;

    [XmlAttribute("Title")]
    public string title;

    [XmlAttribute("Content")]
    public string content;
    
}
