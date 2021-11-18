using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class pngCreater : MonoBehaviour
{
    [SerializeField] private Text[] __names;
    [SerializeField] private ItemManager __itemManager;
    [SerializeField] private  GeneratorQR __generatorQR;
    [ContextMenu("Create Cards")]
    private void createCard()
    {
        StartCoroutine(AddCard());
   
    }
    public IEnumerator AddCard()
    {
        for (int i = 0; i < __itemManager.Item.Count; i++)
        {

            __generatorQR.CreateQR(i+1);
            __names[0].text = __itemManager.Item[i].Name;
            __names[1].text = __itemManager.Item[i].DMG.ToString();
            __names[2].text = __itemManager.Item[i].HP.ToString();
            __names[3].text = "1";
            __names[4].text = __itemManager.Item[i].ability;
            yield return new WaitForChangedResult();
            yield return UploadPNG(__names[0].text);


        }


    }
    IEnumerator UploadPNG(string name)
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Object.Destroy(tex);

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes( name+".png", bytes);


        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("fileUpload", bytes);

        // Upload to a cgi script
        var w = UnityWebRequest.Post("http://localhost/cgi-bin/env.cgi?post", form);
        yield return w.SendWebRequest();

    }
}