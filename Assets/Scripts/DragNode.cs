using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNode : MonoBehaviour, IDragHandler
{
    [SerializeField] RectTransform drag;
    public NodesStructure a;
    public float nodewidth;
     public float nodeheight;
    private GameObject nodeshow;
    public void setRectTransform(RectTransform rectTransform,GameObject nodeshow)
    {
        drag = rectTransform;
        this.nodeshow = nodeshow;
    }
    public void setNodeStructure(NodesStructure node, float width, float hight)
    {
        a = node;
        nodewidth = width;
        nodeheight = hight;
    }
    public void OnDrag(PointerEventData eventData)
    {

        Vector2 result;
        Vector2 clickPosition = eventData.position;
        RectTransform thisRect = GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect.parent.GetComponent<RectTransform>(), clickPosition, GameObject.Find("Camera").GetComponent<Camera>(), out result);
        result += thisRect.sizeDelta / 2;

        drag.GetComponent<RectTransform>().localPosition = eventData.position;
        /*Debug.Log(a.name+" "+eventData);*/
        a.x0 = result.x-nodewidth;
         a.y0 = result.y-nodeheight;
        a.y1 = result.y;
        a.x1 = result.x;
        nodeshow.GetComponent<NodeShow>().dragFlag = true;
        nodeshow.GetComponent<NodeShow>().dragNode = this.name.Substring(5);
        Debug.Log(nodeshow.GetComponent<NodeShow>().dragNode);

    }
    
   
        
    
}
