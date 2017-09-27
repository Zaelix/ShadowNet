using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("NewsCollection")]
public class NewsContainer {

    [XmlArray("NewsPosts")]
    [XmlArrayItem("NewsPost")]
    public List<NewsItem> newsItems = new List<NewsItem>();

    public static NewsContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(NewsContainer));

        StringReader reader = new StringReader(_xml.text);

        NewsContainer news = serializer.Deserialize(reader) as NewsContainer;

        reader.Close();

        return news;
    }
}
