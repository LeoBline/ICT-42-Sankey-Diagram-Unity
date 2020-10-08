using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lineMouseOver : MonoBehaviour
{
    public string text="";
    public Vector2 position;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseExit()
    {
        if (a != null)
        {
            a.SetActive(false);
        }
        }
    private void OnMouseOver()
    {
        if (a != null)
        {
            a.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
