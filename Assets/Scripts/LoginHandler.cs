using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("UserCollection")]
public class LoginHandler : MonoBehaviour {

    [XmlArray("Users")]
    [XmlArrayItem("User")]
    public List<User> users = new List<User>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Register(string name, string pass)
    {
        User user = new User();
        byte[] salt = CreateSalt(32);
        user.userName = name;
        user.salt = Convert.ToBase64String(salt);
        user.iterations = 100;
        user.hash = Convert.ToBase64String(GenerateSaltedHash(Encoding.ASCII.GetBytes(pass), salt));
        users.Add(user);
    }

    private static byte[] CreateSalt(int size)
    {
        //Generate a cryptographic random number.
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);

        // Return a Base64 string representation of the random number.
        return buff;
    }

    static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
    {
        HashAlgorithm algorithm = new SHA256Managed();

        byte[] plainTextWithSaltBytes =
          new byte[plainText.Length + salt.Length];

        for (int i = 0; i < plainText.Length; i++)
        {
            plainTextWithSaltBytes[i] = plainText[i];
        }
        for (int i = 0; i < salt.Length; i++)
        {
            plainTextWithSaltBytes[plainText.Length + i] = salt[i];
        }

        return algorithm.ComputeHash(plainTextWithSaltBytes);
    }

    public bool IsCorrectPassword(string name, string pass)
    {
        User user = users.Find(
            delegate (User us)
            {
                return us.userName == name;
            }
        );
        if (CompareByteArrays(GenerateSaltedHash(Encoding.ASCII.GetBytes(pass), Encoding.ASCII.GetBytes(user.salt)), Encoding.ASCII.GetBytes(user.hash)))
        {
            return true;
        }
        return false;
    }

    public static bool CompareByteArrays(byte[] array1, byte[] array2)
    {
        if (array1.Length != array2.Length)
        {
            return false;
        }

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                return false;
            }
        }

        return true;
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
