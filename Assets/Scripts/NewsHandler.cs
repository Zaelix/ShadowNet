using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsHandler : MonoBehaviour {

    public const string path = "NewsPosts";
    public MonoBehaviour contentsObject;
    NewsContainer newsCont;

    int currentDate = 20730214;
    Color lastColor = Color.gray;
    Color darkGray = new Color(0f, 0f, 0.6f, 1);

    // Use this for initialization
    void Start () {
        newsCont = NewsContainer.Load(path);
        foreach(NewsItem item in newsCont.newsItems)
        {
            print(item.title);
        }
        LoadNewsList();
	}

    public void LoadNewsList() {
        lastColor = Color.gray;
        foreach (NewsItem item in newsCont.newsItems)
        {
            if(item.date <= currentDate)
            {
                CreateUINewsItem(item.title, item.content, item.date);
            }
        }
    }

    void CreateUINewsItem(string title, string content, int date)
    {
        GameObject newsPostObj = (GameObject)Instantiate(Resources.Load("NewsPostTextObject"));
        newsPostObj.name = "NPO" + date;
        newsPostObj.transform.SetParent(contentsObject.transform, false);
        newsPostObj.GetComponent<Text>().text = FormatDate(date) + " ::: " + title + "\r\n" + content;
        newsPostObj.transform.localScale = new Vector3(1, 1, 1);
        lastColor = lastColor == Color.black ? darkGray : Color.black;
        newsPostObj.GetComponent<Text>().color = lastColor;
    }

    string FormatDate(int date) {
        string fDate = "";
        fDate = date.ToString().Substring(0, 4);
        fDate += "-" + date.ToString().Substring(4, 2);
        fDate += "-" + date.ToString().Substring(6, 2);
        return fDate;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
