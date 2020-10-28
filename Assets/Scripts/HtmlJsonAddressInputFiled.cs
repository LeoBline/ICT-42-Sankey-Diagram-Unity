using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Text;
using System;

public class HtmlJsonAddressInputFiled : MonoBehaviour
{
    
    public string htmlAddress = "";
    private void Awake()
    {
        var input = this.GetComponent<InputField>();
        if (input)
        {
            input.onEndEdit.AddListener(OnEndEdit);
        }
    }

    private void OnEndEdit(string arg0)
    {
        if (arg0 != "" && arg0.EndsWith(".json"))
        {
            Debug.Log(arg0);
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            Byte[] pageData = MyWebClient.DownloadData(arg0);
            MemoryStream ms = new MemoryStream(pageData);
            using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("GB2312")))
            {
                this.transform.parent.Find("JsonReader").GetComponent<JsonReaderTest>().loadHtmlData(sr);
                this.transform.parent.GetComponent<NodeShow>().continulFlag = true;
            }

        }
        else
        {
            Debug.Log("This Online file is not a Json file or the url is empty");
        }
    }
}
