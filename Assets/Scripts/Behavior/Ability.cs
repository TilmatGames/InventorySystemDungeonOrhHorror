using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public static int LivesMonstr;
    public static int HPMonstrTotal;
    public static int HPMonstrchange = 0, DMGPlayerchange = 0, DMGPlayerReflect = 0, MonstrDeadDMG = 0, MonstrAddHP = 0, MonstrAddDMG = 0, MonstrDeadDMGOneRound = 0, MonstrTimerDead = 0, PlusDMGMonstr = 0, PlayerTimerDead = 0, DMGLastGunID=0, HPMonstrOverChange = 0;
    public static bool NextScan = false, RNDDMG = false, PlayerBoolTimerDead = false, AlwysAttackMonstr = false, DexterityMonstchange = false;
    public GameObject BlockGunStacK, FightMenu;
    private ControlItem _controlItem;

    void Start()
    {

        _controlItem = gameObject.GetComponent<ControlItem>();

    }
    public void NumberAbility(int numberUbility)
    {

        switch (numberUbility)
        {
            case 1: //Восстанавливает 1 ед здоровья после атаки
                HPMonstrchange = 1;
                break;
            case 2: //Урон от оружия снижен в двое
                DMGPlayerchange = 2;
                break;

            case 3:  //после смерти наносит 2 ед
                MonstrDeadDMG = 2;
                break;
            case 4:                //  Следующий монстр(или один из них) получит + 1ед.к здоровью и урону
                MonstrAddHP = 1;
                MonstrAddDMG = 1;

                break;
            case 5:  //нельзя использовать оружее
                BlockGunActive(true);
                break;
            case 6: //Восстанавливает 2 ед здоровья после атаки
                HPMonstrchange = 2;
                break;
            case 7: //Перед боем уничтожает 2 последних подобранных вещей

                removeItem(2);
                break;
            case 8:                //  Следующий монстр(или один из них) получит + 1ед.к здоровью и урону
                MonstrAddHP = 2;
                MonstrAddDMG = 2;

                break;
            case 9:                //  наносит случайный урон от 1 до 6
                RNDDMG = true;
                break;
            case 10:                //  уйти от монсира
                FightMenuActive(true);

                break;
            case 11:                //  Перед боем уничтожает 1 последних подобранных Оружий
                removeGun(1);

                break;
            case 12:                // Вызывает заражение крови после первого укуса укуса 2 ед
                MonstrDeadDMGOneRound = 2;

                break;
            case 13:                // Вызывает заражение крови после первого укуса укуса 6 ед
                MonstrDeadDMGOneRound = 6;

                break;
            case 14:                // После каждой атаки манстра, он получает +2 ед.урона
                PlusDMGMonstr = 2;
                break;

            case 15:                // если не умирает за 5 хода , высасывает противника  
                PlayerTimerDead = 5;
                PlayerBoolTimerDead = true;
                break;
            case 16:                // После каждой атаки манстра, он получает +2 ед.урона
                DMGLastGunID = DMGLastGun();

                break;
            case 17:               //Урон от оружия 2 отражен
                DMGPlayerchange = 2;
                DMGPlayerReflect = 2;
                break;
            case 18:               //умирает через 1 ход
                PlayerTimerDead = 1;


                break;
            case 19:               //Уувеличивает урон в 2 раза и прибавляет 2 хп
               
                break;
            case 20:                // если не умирает за 6 хода , высасывает противника  
                PlayerTimerDead = 6;
                PlayerBoolTimerDead = true;
                break;
            case 21:                // После каждого удара уклонение вырастает на 1 ед.
                DexterityMonstchange = true;
                break;

            case 22:                // Каждый ход восстанавливает себе 2 ед. здоровья
                HPMonstrOverChange = 2;
                break;
            case 23:                //  
               
                break;




              


        }

    }

    public void BlockGunActive(bool Active)
    {
        BlockGunStacK.SetActive(Active);
    }
    public void FightMenuActive(bool Active)
    {
        FightMenu.SetActive(Active);
    }
    public void removeItem(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (_controlItem.IDHistoryItem.Count > 0)
            {
                _controlItem.ItemID = _controlItem.IDHistoryItem[_controlItem.IDHistoryItem.Count - 1];
                _controlItem.RemoveItem();
                _controlItem.IDHistoryItem.RemoveAt(_controlItem.IDHistoryItem.Count - 1);
            }
            else Debug.Log("нет предметов");
        }
    }
    public void removeGun(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (_controlItem.IDHistoryGun.Count > 0)
            {
                _controlItem.ItemID = _controlItem.IDHistoryGun[_controlItem.IDHistoryGun.Count - 1];
                _controlItem.RemoveItem();
                _controlItem.IDHistoryGun.RemoveAt(_controlItem.IDHistoryGun.Count - 1);
            }
            else Debug.Log("нет предметов");
        }
    }
    public int DMGLastGun()
    {

        if (_controlItem.IDHistoryGun.Count > 0)
        {

            return (_controlItem.IDHistoryGun[_controlItem.IDHistoryGun.Count - 1]);

        }
        else return -1;

    }

}
