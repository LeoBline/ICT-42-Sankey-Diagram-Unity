using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/**
 * Class name:
 *      CreateJsReader
 *      
 * Class description:
 *      This class extends Editor class to get the ablity to recive JSon File as input
 */
public class CreateJsReader : Editor
{
    /*
     * Method name: 
     *      Start
     * Method description: 
     *      This method is called before the first frame update
     */
    void Start()
    {

        GameObject jsreader = new GameObject();
        jsreader.name = "JsonReader";
        jsreader.AddComponent<JsonReaderTest>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}

/**
 * Class name:
 *      Test
 *      
 * Class description:
 *      Using for case testing of CreateJsReader class.
 * 
 */
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


