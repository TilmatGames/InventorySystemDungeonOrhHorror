using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Threading;

using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using UnityEngine.Android;

[AddComponentMenu("System/Scanner")]
public class QRScanner : MonoBehaviour
{
    WebCamTexture webCamTexture;
    Rect rect;
    BarcodeReader barCodeReader;
    public GameObject QRSkaner, Cam2, SkriptObject, scene, test;
  

    void Start()
    {

        
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
        barCodeReader = new BarcodeReader();
        rect = new Rect(Screen.width / 3, Screen.height / 3, Screen.width / 3, Screen.height / 3);
    }

    void OnGUI()
    {
        GUI.DrawTexture(rect, webCamTexture, ScaleMode.ScaleAndCrop);
    }

    void Update()
    {

        var result = barCodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);

        if (result != null)
        {

        
            if (result.Text.Substring(0, 1) == "i")
            {
                var mn = result.Text.Remove(0, 1);              
                SkriptObject.GetComponent<ControlItem>().addItem(Convert.ToInt32(mn));
            
                

            }
            else if (result.Text.Substring(0, 1) == "m")
            {
                var mn = result.Text.Remove(0, 1);
                SkriptObject.GetComponent<MonstrManager>().Apply(mn);
                
            }
           
            QRSkaner.SetActive(false);
            Cam2.SetActive(true);
            scene.SetActive(true);
        }
    }
}