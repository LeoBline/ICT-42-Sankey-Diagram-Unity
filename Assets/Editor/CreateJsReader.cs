using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CreateJsReader : Editor
{
    // Start is called before the first frame update
    
    void Start()
    {

        GameObject jsreader = new GameObject();
        jsreader.name = "JsonReader";
        jsreader.AddComponent<JsonReaderTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public static class Test
{
[MenuItem("GameObject/JSonReader", priority = 11)]
    static void Init()
    {
        GameObject jsreader = new GameObject();
        jsreader.name = "JsonReader";
        jsreader.AddComponent<JsonReaderTest>();
    }
}


