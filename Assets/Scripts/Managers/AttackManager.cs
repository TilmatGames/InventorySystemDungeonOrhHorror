using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private Text _HpPlayer, _DMGPlayer, _HpMonstr, _DMGMonstr, _dexterityMonstr;
    private System.Random rnd = new System.Random();
    private ControlItem controlItem;
    private int HPPlayer, HPMonstr, DexterityMonstr;

    void Start()
    {
        controlItem = gameObject.GetComponent<ControlItem>();
        HPPlayer = Convert.ToInt32(_HpPlayer.text);
        HPMonstr = Convert.ToInt32(_HpMonstr.text);
    }

    public void attackTrue()
    {
        if (Ability.HPMonstrOverChange != 0) { HPMonstr += Ability.HPMonstrOverChange; }
        if (Ability.DMGPlayerReflect != 0)
        {
            if (Convert.ToInt32(_DMGPlayer.text) >= 1)
            {
                HPPlayer = Convert.ToInt32(_HpPlayer.text) - Convert.ToInt32(_DMGPlayer.text) / Ability.DMGPlayerReflect;
                _HpPlayer.text = Convert.ToString(HPPlayer);
            }
        }
        if (Ability.DMGPlayerchange != 0)
        {
            if (Convert.ToInt32(_DMGPlayer.text) <= 1) { HPMonstr = Convert.ToInt32(_HpMonstr.text) - Convert.ToInt32(_DMGPlayer.text); }
            else
                HPMonstr = Convert.ToInt32(_HpMonstr.text) - (Convert.ToInt32(_DMGPlayer.text) - 1);// DMGPlayerchange;
        }
        else
            HPMonstr = Convert.ToInt32(_HpMonstr.text) - Convert.ToInt32(_DMGPlayer.text);

        if (Ability.AlwysAttackMonstr) { attackFalse(); }
        _HpMonstr.text = Convert.ToString(HPMonstr);
        gameObject.GetComponent<ControlItem>().hit();
        if (HPMonstr <= 0)

        {
            Ability.LivesMonstr--;
            _HpMonstr.text = Convert.ToString(Ability.HPMonstrTotal);
            if (Ability.LivesMonstr < 1)
            {
                attackFalse(Ability.MonstrDeadDMG);
                gameObject.GetComponent<MonstrManager>().MonstrDead();

            }
        }
        if (Ability.PlayerBoolTimerDead)
        {
            Ability.PlayerTimerDead--; if (Ability.PlayerTimerDead < 1)
            {
                controlItem.removeAllItem();
                gameObject.GetComponent<MonstrManager>().MonstrDead();
                _HpPlayer.text = "20";


            }
        }

    }


    public void attackFalse()
    {
        if (Ability.HPMonstrOverChange != 0) { HPMonstr += Ability.HPMonstrOverChange; }
        if (Ability.DexterityMonstchange) {  DexterityMonstr= Convert.ToInt32(_dexterityMonstr.text); DexterityMonstr++; _dexterityMonstr.text = Convert.ToString(DexterityMonstr); }
        HPPlayer = Convert.ToInt32(_HpPlayer.text) - Convert.ToInt32(_DMGMonstr.text);
        if (Ability.RNDDMG)
        {
            _DMGMonstr.text = Convert.ToString(rnd.Next(1, 7));
        }

        var hpmnstr = Convert.ToInt32(_HpMonstr.text);

        if (hpmnstr < Ability.HPMonstrTotal)
        {
            _HpMonstr.text = Convert.ToString(hpmnstr + Ability.HPMonstrchange);
        }

        if (Ability.MonstrDeadDMGOneRound != 0) { HPPlayer = Convert.ToInt32(_HpPlayer.text) - Ability.MonstrDeadDMGOneRound; }
        _HpPlayer.text = Convert.ToString(HPPlayer);

        controlItem.lose();
        if (HPPlayer <= 0)
        {

            controlItem.removeAllItem();
            _HpPlayer.text = "20";
        }
        if (Ability.MonstrTimerDead != 0) { gameObject.GetComponent<MonstrManager>().MonstrDead(); }
        if (Ability.PlusDMGMonstr != 0) { _DMGMonstr.text = Convert.ToString(Convert.ToInt32(_DMGMonstr.text) + Ability.PlusDMGMonstr); }
        if (Ability.PlayerBoolTimerDead)
        {
            Ability.PlayerTimerDead--; if (Ability.PlayerTimerDead < 1)
            {
                controlItem.removeAllItem();
                gameObject.GetComponent<MonstrManager>().MonstrDead();
                _HpPlayer.text = "20";


            }
        }
    }
    public void attackFalse(int dmg)
    {

        HPMonstr = Convert.ToInt32(_HpPlayer.text) - dmg;


        _HpPlayer.text = Convert.ToString(HPMonstr);
        var controlItem = gameObject.GetComponent<ControlItem>();
        controlItem.lose();
        if (HPMonstr <= 0)
        {

            controlItem.removeAllItem();
            _HpPlayer.text = "20";
        }
    }
}
