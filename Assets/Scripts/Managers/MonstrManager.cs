using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstrManager : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    [SerializeField] public Text _dexterity,_name, _hp, _DMG, _nameability;
    [SerializeField] private Image _monstrSprite;
    private Ability _ability;
    private ItemManager _item;
    public List<SerialisedMonstr> Monstrs;
    void Start() { 
        _ability = gameObject.GetComponent<Ability>();
        _item = gameObject.GetComponent<ItemManager>();
    }
    public void Apply(string ID)
    {
        foreach (var elem in Monstrs)
        {
            if (elem.ID == ID)
            {
               
                  Ability.LivesMonstr = elem.lives;
                _ability.  NumberAbility(elem.NumbeAbilityr);
                Ability.HPMonstrTotal = elem.HP;
                _dexterity.text= Convert.ToString(elem.Dexterity);
                _name.text = elem.Name;
                _hp.text = Convert.ToString(elem.HP);
                _DMG.text = Convert.ToString(elem.DMG);
                _nameability.text = elem.ability;
                _monstrSprite.sprite = elem.sprite;
                _monstrSprite.color = new Color(255, 255, 255, 100);
                if (Ability.RNDDMG)
                {
                    _DMG.text = Convert.ToString(rnd.Next(1, 7));
                }
               
                if (Ability.DMGLastGunID > 0) { _DMG.text = Convert.ToString(_item.Item[Ability.DMGLastGunID-1].DMG); }
                if (Ability.MonstrAddHP != 0 || Ability.MonstrAddDMG != 0)
                {
                    if (Ability.NextScan)
                    {

                        _hp.text = Convert.ToString(elem.HP + Ability.MonstrAddHP);
                        _DMG.text = Convert.ToString(elem.DMG + Ability.MonstrAddDMG);
                        Ability.MonstrAddHP = 0;
                        Ability.MonstrAddDMG = 0;   
                        Ability.NextScan = false;
                    }
                    else Ability.NextScan = true;
                }           
            }

        }
    }
    [ContextMenu("AplyID")]
    public void AplyID()
    {
        for (int i = 0; i < Monstrs.Count; i++)
            Monstrs[i].ID = Convert.ToString(i + 1);

    }
    public void MonstrDead()
    {
        _name.text = "";
        _nameability.text = "";
        _DMG.text = "0";
        _hp.text = "0";
        Ability.PlayerBoolTimerDead = false;
        Ability.LivesMonstr = 0;
        Ability.HPMonstrchange = 0;
        Ability.MonstrDeadDMG = 0;
        Ability.RNDDMG = false;
        Ability.DMGPlayerReflect = 0;
        Ability.AlwysAttackMonstr = true;
        Ability.DexterityMonstchange = false;
        Ability.HPMonstrOverChange = 0;
        gameObject.GetComponent<Ability>().BlockGunActive(false);
        _monstrSprite.color = new Color(255, 255, 255, 0);
    }


}

[Serializable]
public class SerialisedMonstr
{
    public string Name;
    public int DMG;
    public int HP;
    public int Dexterity;
    public int lives;
    public string ability;
    public int NumbeAbilityr;
    public Sprite QR;
    public Sprite sprite;
    public enum TypeMonstr
    {
        Monstr,
        EliteMonstr,
        Trap

    }
    public TypeMonstr typeItem;
    public string ID;
}
