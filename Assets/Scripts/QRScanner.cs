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
 


    void Start()
    {

     
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
        barCodeReader = new BarcodeReader();
        rect = new Rect(Screen.width / 3, Screen.height / 3, Screen.width/3, Screen.height/3);
    }

    void OnGUI()
    {
        GUI.DrawTexture(rect, webCamTexture, ScaleMode.ScaleAndCrop);
    }
    public GameObject QRSkaner, Cam2, SkriptObject,scene,test;
    void Update()
    {
      
           var result = barCodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
    
        if (result != null)
        {
         
            Debug.Log("Decoded text: " + result.Text);

             Application.OpenURL(result.Text);
            //  webCamTexture.Stop();
            test.GetComponent<Text>().text = result.Text;
            SkriptObject.GetComponent<dbController>().Skaner(int.Parse(result.Text));
            QRSkaner.SetActive(false);
            Cam2.SetActive(true);
            scene.SetActive(true);
        }
    }
}