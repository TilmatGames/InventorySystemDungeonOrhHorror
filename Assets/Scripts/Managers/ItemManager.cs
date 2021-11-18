using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    public List<SerialisedGuns> Item;
    [ContextMenu("AplyID")]
    public void AplyID() {
        for (int i = 0; i < Item.Count; i++)
            Item[i].ID = i + 1;
    
    }
}

[Serializable]
public class SerialisedGuns
{     
    public string Name;

    
    public int DMG;
    public int HP;
    public int Dexterity;
    public string ability;
    public Sprite QR;
    public Sprite SpriteItem;
    public enum TypeItem
    {
        Gun,
        Head,
        Armor,
        Boots,
        any
    }
    public TypeItem typeItem;
    public int ID;
}