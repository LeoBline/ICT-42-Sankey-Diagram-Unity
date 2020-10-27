using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HtmlJsonButton : MonoBehaviour
{
    public GameObject Diague;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Diague.SetActive(false);
        button.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Call when click
    void onClick()
    {
        Debug.Log("Click");
        Diague.SetActive(true);
    }
    
}
