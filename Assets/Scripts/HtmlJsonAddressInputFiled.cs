using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Text;
using LitJson;
using System;
/**
 * Class Name :  
 *     HtmlJsonAddressInputFiled

 * Class Description : 
 *     
 */
public class HtmlJsonAddressInputFiled : MonoBehaviour
{

    public GameObject JsonReader;
    public GameObject graph;
    public string htmlAddress = "";
    public System.IO.StreamReader myReader;
    
    private void Awake()
    {
        var input = this.GetComponent<InputField>();
        if (input)
        {
            input.onEndEdit.AddListener(OnEndEdit);
        }
    }


    //get the content of file
    private System.IO.StreamReader Get(string url)
    {
        HttpWebRequest request;
        request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
        return myreader;
    }
    private void OnEndEdit(string arg0)
    {
        this.htmlAddress = this.GetComponent<InputField>().text;
        if (this.htmlAddress != "" && this.htmlAddress.EndsWith(".json"))
        {
            Debug.Log(htmlAddress);
            this.myReader = this.Get(htmlAddress);
            string content = myReader.ReadToEnd();
            this.JsonReader.GetComponent<JsonReaderTest>().loadHtmlData(content);
            this.graph.GetComponent<NodeShow>().continulFlag = true;
        }
        else
        {
            Debug.Log("This Online file is not a Json file or the url is empty");
        }
    }
}
