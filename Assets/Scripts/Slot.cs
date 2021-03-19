using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;

    public GameObject slotIconGO;
    public Sprite icon;

    private void Start()
    {
        slotIconGO = transform.GetChild(0).gameObject;
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
