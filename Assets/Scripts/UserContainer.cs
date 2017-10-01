using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("UserCollection")]
public class UserContainer {

    [XmlArray("Users")]
    [XmlArrayItem("User")]
    public List<User> users = new List<User>();

    public static UserContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(UserContainer));

        StringReader reader = new StringReader(_xml.text);

        UserContainer userCont = serializer.Deserialize(reader) as UserContainer;

        reader.Close();

        return userCont;
    }

    public void AddUser(User user)
    {
        users.Add(user);
        SaveUserDataToXML();
    }

    public User FindUserByName(string name)
    {
        User user = users.Find(
            delegate (User us)
            {
                return us.userName == name;
            }
        );
        return user;
    }
    
    private void SaveUserDataToXML()
    {
        XmlWriter writer = XmlWriter.Create("Users.xml");
        writer.WriteStartDocument();
        writer.WriteStartElement("Users");
        foreach (User user in users)
        {
            writer.WriteStartElement("User");

            writer.WriteElementString("UserName", user.userName);
            writer.WriteElementString("Iterations", user.iterations.ToString());
            writer.WriteElementString("Salt", user.salt);
            writer.WriteElementString("Hash", user.hash);

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
}
