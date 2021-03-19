using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour, IPointerUpHandler
{
    
	public GameObject[] Scene;
    public GameObject[] OtherScene;
    public UnityEvent Event;

    public void OnPointerUp(PointerEventData eventData)
    {
       
        foreach (var elem in OtherScene)    { elem.SetActive(false); }
        foreach (var elem in Scene) { elem.SetActive(true); }
       
        Event.Invoke();
    }
}
