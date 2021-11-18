using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private Sprite[] Characters;
    private int i=0;
    public GameObject Character;
    public void NextCharacter() {

        i++;
        if (i == Characters.Length)
            i = 0;
       
        Character.GetComponent<Image>().sprite = Characters[i];
    }
    public void PreviosCharacter()
    {

        i--;
        if (i <= 0)
            i = Characters.Length-1;
        Debug.Log(i);
        Character.GetComponent<Image>().sprite = Characters[i];
       
    }
    public void Aply()
    {
        Debug.Log(i);
        SaveCharacter.NumberSkin = i;

       
       

    }
}
