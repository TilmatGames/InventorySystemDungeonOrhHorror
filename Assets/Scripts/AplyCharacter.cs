using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AplyCharacter : MonoBehaviour
{
   [SerializeField] private Sprite[] Characters;
    [SerializeField] private GameObject _character;
    void Start()
    {

        _character.GetComponent<Image>().sprite = Characters[SaveCharacter.NumberSkin];
    }

}
