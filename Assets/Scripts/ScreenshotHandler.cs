using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;
    private Camera myCamera;
    private bool takeScreenshotOnNectFrame;
    // Start is called before the first frame update
  public ScreenshotHandler(Camera camera  )
    {
        myCamera = camera;
      
    }
    // Update is called once per frame
    private void Awake()
    {
    
        myCamera = gameObject.GetComponent<Camera>();
        instance = this;
      

    }
    private void OnPostRender()
    {
        if (takeScreenshotOnNectFrame)
        {
            takeScreenshotOnNectFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
            Debug.Log("Save");
            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
       
    }
    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNectFrame = true; 
    }
    public void TakeScreenshot_Static(int width,int height)
    {
        instance.TakeScreenshot(width, height);
    }

   
}
