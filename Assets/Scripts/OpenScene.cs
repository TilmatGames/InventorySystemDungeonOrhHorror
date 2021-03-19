using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenScene : MonoBehaviour, IPointerUpHandler
{
    public string name;
    public void OnPointerUp(PointerEventData eventData)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
