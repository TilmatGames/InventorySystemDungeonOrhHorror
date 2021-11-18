using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellProperties : MonoBehaviour
{
 
    public int ID;
    public int HP;
    public int DMG;
    public string name;
    public string ability;
    public enum ActiveCell
    {
      Active,
      InActive

    }
    public ActiveCell activeCell;
    public bool UseItem;
}
