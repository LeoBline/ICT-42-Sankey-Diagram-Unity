using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;

public class JsonLoadButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            //open file panel
            string filePath = EditorUtility.OpenFilePanel("Load Json File", Application.streamingAssetsPath, "json");
            if (filePath.Length != 0)
            {
                //the file path is a html address
                if (filePath.Substring(0, 4) == "http")
                {
                    string pageHtml = "";
                    WebClient MyWebClient = new WebClient();
                    MyWebClient.Credentials = CredentialCache.DefaultCredentials;
                    byte[] pageData = MyWebClient.DownloadData(filePath);
                    MemoryStream ms = new MemoryStream(pageData);
                    using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("GB2312")))
                    {
                        gameObject.transform.parent.Find("JsonReader").GetComponent<JsonReaderTest>().loadHtmlData(sr);
                        gameObject.transform.parent.GetComponent<NodeShow>().continulFlag = true;
                    }
                }
                else
                {
                    //local Json File
                    gameObject.transform.parent.Find("JsonReader").GetComponent<JsonReaderTest>().loadDate(filePath);
                    if (filePath.EndsWith(".json"))
                    {
                        gameObject.transform.parent.GetComponent<NodeShow>().continulFlag = true;
                    }
                }
            }
        };
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
