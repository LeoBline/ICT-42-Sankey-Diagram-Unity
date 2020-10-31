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

        
        /*Debug.Log(a.name+" "+eventData);*/
        //set the drag border.

            
            drag.GetComponent<RectTransform>().localPosition = eventData.position;
            float x=result.x, y = result.y;
            if (result.x < 0) x = 0;
            if (result.x > 1039) x = 1039;
            if (result.y < nodeheight) y = nodeheight;
            if (result.y > 630) y = 630;

            a.x0 = x - nodewidth;
            a.y0 = y - nodeheight;
            a.y1 = y;
            a.x1 = x;

            Debug.Log(a.x0 + " " + a.x1 + " " + a.y0 + " " + a.y1);
            nodeshow.GetComponent<NodeShow>().dragFlag = true;
            nodeshow.GetComponent<NodeShow>().dragNode = this.name.Substring(5);
        
    }
    
   
        
    
}
