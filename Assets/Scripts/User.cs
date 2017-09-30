using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("Users")]
public class User {
    [XmlAttribute("Username")]
    public int userName;

    [XmlAttribute("Iterations")]
    public string iterations;

    [XmlAttribute("Salt")]
    public string salt;

    [XmlAttribute("Hash")]
    public string hash;
}
