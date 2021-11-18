using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CellProperties;

public class ControlItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cells, _cellsGun, _cellsGunClone, _head, _armor, _boots;
    [SerializeField] private Sprite _standartSprite;
    public int ItemID, IDUseItem;
    [SerializeField] private Text DMGUseItem;
    [SerializeField] private Material[] Mat;
    [SerializeField] private Text ItemName;
    [SerializeField] private List<Text> _stats;
    public List<int> IDHistoryItem;
  public List<int> IDHistoryGun;
  
    private bool _useItem;
    void Start()
    {

    }


    public void lose()
    {
        foreach (var elem in _cells)
        {

            foreach (var item in _cells)
            {
                if (_head[1].GetComponent<CellProperties>().ID != 0)
                {
                    var ITEM = item.GetComponent<CellProperties>();
                    if (ITEM.ID == _head[1].GetComponent<CellProperties>().ID)
                    {
                        ITEM.HP--;
                        if (ITEM.HP <= 0)
                        {
                            ItemID = ITEM.ID;
                            RemoveItem();

                        }
                    }
                }
            }

        }

        foreach (var item in _cells)
        {
            if (_armor[1].GetComponent<CellProperties>().ID != 0)
            {
                var ITEM = item.GetComponent<CellProperties>();
                if (ITEM.ID == _armor[1].GetComponent<CellProperties>().ID)
                {
                    ITEM.HP--;
                    if (ITEM.HP <= 0)
                    {
                        ItemID = ITEM.ID;
                        RemoveItem();
                    }
                }
            }
        }


        foreach (var item in _cells)
        {
            if (_boots[1].GetComponent<CellProperties>().ID != 0)
            {
                var ITEM = item.GetComponent<CellProperties>();
                if (ITEM.ID == _boots[1].GetComponent<CellProperties>().ID)
                {
                    ITEM.HP--;
                    if (ITEM.HP <= 0)
                    {
                        ItemID = ITEM.ID;
                        RemoveItem();
                    
                    }
                }
            }
        }
    }


    public void addItem(int ID)
    {

        foreach (var elem in _cells)
        {

            if (ID == elem.GetComponent<CellProperties>().ID)
            {
                return;
            }
            if (elem.GetComponent<CellProperties>().activeCell == ActiveCell.Active)
            {

                foreach (var item in gameObject.GetComponent<ItemManager>().Item)
                    if (item.ID == ID)
                    {
                        if (item.typeItem == SerialisedGuns.TypeItem.Gun)
                        {
                         
                            IDHistoryGun.Add(ID);
                       
                        }
                        IDHistoryItem.Add(ID);                                                                    
                           var cellProperties = elem.GetComponent<CellProperties>();
                        cellProperties.HP = item.HP;
                        cellProperties.DMG = item.DMG;
                        cellProperties.ID = ID;
                        cellProperties.name = item.Name;
                        cellProperties.activeCell = ActiveCell.InActive;
                        cellProperties.ability = item.ability;
                        elem.GetComponent<Image>().sprite = item.SpriteItem;
                        elem.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                        elem.GetComponent<Button>().enabled = true;
                        
                        return;
                    }
                return;
            }
        }
    }


    public void Clean(List<GameObject> list)
    {

        foreach (var elem in list)
        {
            var cell = elem.GetComponent<CellProperties>();
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                elem.GetComponent<Image>().sprite = _standartSprite;
                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cell.activeCell = ActiveCell.Active;
                cell.ID = 0;
                elem.GetComponent<Button>().enabled = false;
                if (elem.GetComponent<Image>().material == Mat[1])
                    elem.GetComponent<Image>().material = Mat[0];
                if (elem.GetComponent<CellProperties>().UseItem == true)
                {
                    DMGUseItem.text = "1";
                    elem.GetComponent<CellProperties>().UseItem = false;
                };
            }
        }
    }
    public void CleanInvenotory()
    {
        Clean(_cellsGun);
        Clean(_cellsGunClone);
        Clean(_head);
        Clean(_armor);
        Clean(_head);
    }

    public void hit()
    {
        if (IDUseItem != 0)
        {
            foreach (var elem in _cells)
            {
                var cell = elem.GetComponent<CellProperties>();
                if (cell.ID == IDUseItem)
                {
                    cell.HP--;
                    if (cell.HP <= 0)
                    {
                        ItemID = IDUseItem;
                        RemoveItem();
                        IDUseItem = 0;
                        DMGUseItem.text = "1";

                    }
                }
            }
        }
    }

    public void RemoveCell(GameObject cell)
    {
        cell.GetComponent<Image>().sprite = _standartSprite;
        cell.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
        cell.name = "";
        cell.GetComponent<CellProperties>().activeCell = ActiveCell.Active;
        cell.GetComponent<CellProperties>().ID = 0;
        cell.GetComponent<Button>().enabled = false;
        if (cell.GetComponent<Image>().material == Mat[1])
            cell.GetComponent<Image>().material = Mat[0];
        if (cell.GetComponent<CellProperties>().UseItem == true)
        {

            cell.GetComponent<CellProperties>().UseItem = false;
        };
    }
    public void removeAllItem()
    {
        foreach (var elem in _cells)
            RemoveCell(elem);
        foreach (var elem in _cellsGun)
            RemoveCell(elem);
        foreach (var elem in _cellsGunClone)
            RemoveCell(elem);
        foreach (var elem in _head)
            RemoveCell(elem);
        foreach (var elem in _armor)
            RemoveCell(elem);
        foreach (var elem in _boots)
            RemoveCell(elem);
        DMGUseItem.text = "1";
    }
    public void UseItemOnFight(GameObject Cell)
    {

        var cell = Cell.GetComponent<CellProperties>();
        if (cell.activeCell == ActiveCell.Active)
        {
            foreach (var elem in _cellsGunClone)
            {

                elem.GetComponent<Image>().material = Mat[0];
                elem.GetComponent<CellProperties>().activeCell = ActiveCell.Active;
                cell.activeCell = ActiveCell.Active;
                cell.GetComponent<CellProperties>().UseItem = false;
                IDUseItem = 0;
                DMGUseItem.text = "1";
            }
            cell.activeCell = ActiveCell.InActive;
            IDUseItem = cell.ID;
            cell.GetComponent<Image>().material = Mat[1];
            cell.GetComponent<CellProperties>().UseItem = true;
            DMGUseItem.text = Convert.ToString(1 + cell.DMG);

        }
        else
        {
            cell.GetComponent<Image>().material = Mat[0];
            cell.activeCell = ActiveCell.Active;
            IDUseItem = 0;
            DMGUseItem.text = "1";
            cell.GetComponent<CellProperties>().UseItem = false;

        }
    }



    public void RemoveItem()
    {

        foreach (var elem in _cells)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;
                cellProperties.name = "";
                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;
            }
        }
        foreach (var elem in _cellsGun)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;

                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;

            }
        }
        foreach (var elem in _cellsGunClone)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;

                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                elem.GetComponent<Image>().material = Mat[0];
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;
                if (elem.GetComponent<CellProperties>().UseItem == true)
                {
                    DMGUseItem.text = "1";
                    elem.GetComponent<Image>().material = Mat[0];
                    elem.GetComponent<CellProperties>().UseItem = false;
                };

            }
        }
        foreach (var elem in _armor)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;

                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;
            }
        }
        foreach (var elem in _boots)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;

                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;
            }
        }
        foreach (var elem in _head)
        {
            if (elem.GetComponent<CellProperties>().ID == ItemID)
            {
                var cellProperties = elem.GetComponent<CellProperties>();
                elem.GetComponent<Image>().sprite = _standartSprite;

                elem.GetComponent<Image>().color = new Color(100, 100, 100, 0.392f);
                cellProperties.activeCell = ActiveCell.Active;
                cellProperties.ID = 0;
                elem.GetComponent<Button>().enabled = false;
            }
        }

    }

    public void AddItemID(GameObject Cell)
    {
        ItemID = Cell.GetComponent<CellProperties>().ID;
        ItemName.text = Cell.GetComponent<CellProperties>().name;
        _stats[0].text = Convert.ToString(Cell.GetComponent<CellProperties>().DMG);
        _stats[1].text = Convert.ToString(Cell.GetComponent<CellProperties>().HP);
        _stats[2].text = Cell.GetComponent<CellProperties>().ability;
    }



    public void UseItem()
    {

        var items = gameObject.GetComponent<ItemManager>().Item;

        foreach (var item in items)
        {
            if (item.ID == ItemID)
            {
                if (item.typeItem == SerialisedGuns.TypeItem.Gun)
                {
                    foreach (var elem in _cellsGun)
                    {
                        if (ItemID == elem.GetComponent<CellProperties>().ID)
                        { return; }
                    }
                    for (int i = 0; i < _cellsGun.Count; i++)
                    {
                        if (_cellsGun[i].GetComponent<CellProperties>().activeCell == ActiveCell.Active)
                        {
                            _cellsGun[i].GetComponent<CellProperties>().ID = ItemID;
                            _cellsGun[i].GetComponent<Image>().sprite = item.SpriteItem;
                            _cellsGun[i].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _cellsGun[i].GetComponent<CellProperties>().activeCell = ActiveCell.InActive;
                            _cellsGun[i].GetComponent<Button>().enabled = true;

                            _cellsGunClone[i].GetComponent<CellProperties>().ID = ItemID;
                            _cellsGunClone[i].GetComponent<Image>().sprite = item.SpriteItem;
                            _cellsGunClone[i].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _cellsGunClone[i].GetComponent<CellProperties>().DMG = item.DMG;
                            _cellsGunClone[i].GetComponent<Button>().enabled = true;

                            return;

                        }
                    }
                }
                else
                     if (item.typeItem == SerialisedGuns.TypeItem.Head)
                {
                    foreach (var elem in _head)
                    {
                        if (ItemID == elem.GetComponent<CellProperties>().ID)
                        { return; }
                    }
                    for (int i = 0; i < _head.Count; i++)
                    {
                        if (_head[i].GetComponent<CellProperties>().activeCell == ActiveCell.Active)
                        {
                            _head[0].GetComponent<CellProperties>().ID = ItemID;
                            _head[0].GetComponent<Image>().sprite = item.SpriteItem;
                            _head[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _head[0].GetComponent<CellProperties>().activeCell = ActiveCell.InActive;
                            _head[0].GetComponent<Button>().enabled = true;

                            _head[1].GetComponent<CellProperties>().ID = ItemID;
                            _head[1].GetComponent<Image>().sprite = item.SpriteItem;
                            _head[1].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _head[1].GetComponent<Button>().enabled = true;
                            return;

                        }
                    }
                }
                else
                     if (item.typeItem == SerialisedGuns.TypeItem.Armor)
                {
                    foreach (var elem in _armor)
                    {
                        if (ItemID == elem.GetComponent<CellProperties>().ID)
                        { return; }
                    }
                    for (int i = 0; i < _armor.Count; i++)
                    {
                        if (_head[i].GetComponent<CellProperties>().activeCell == ActiveCell.Active)
                        {
                            _armor[0].GetComponent<CellProperties>().ID = ItemID;
                            _armor[0].GetComponent<Image>().sprite = item.SpriteItem;
                            _armor[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _armor[0].GetComponent<CellProperties>().activeCell = ActiveCell.InActive;
                            _armor[0].GetComponent<Button>().enabled = true;

                            _armor[1].GetComponent<CellProperties>().ID = ItemID;
                            _armor[1].GetComponent<Image>().sprite = item.SpriteItem;
                            _armor[1].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _armor[1].GetComponent<Button>().enabled = true;
                            return;
                        }
                    }
                }
                else
                     if (item.typeItem == SerialisedGuns.TypeItem.Boots)
                {
                    foreach (var elem in _boots)
                    {
                        if (ItemID == elem.GetComponent<CellProperties>().ID)
                        { return; }
                    }
                    for (int i = 0; i < _boots.Count; i++)
                    {
                        if (_boots[i].GetComponent<CellProperties>().activeCell == ActiveCell.Active)
                        {
                            _boots[0].GetComponent<CellProperties>().ID = ItemID;
                            _boots[0].GetComponent<Image>().sprite = item.SpriteItem;
                            _boots[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _boots[0].GetComponent<CellProperties>().activeCell = ActiveCell.InActive;
                            _boots[0].GetComponent<Button>().enabled = true;

                            _boots[1].GetComponent<CellProperties>().ID = ItemID;
                            _boots[1].GetComponent<Image>().sprite = item.SpriteItem;
                            _boots[1].GetComponent<Image>().color = new Color(255, 255, 255, 100);
                            _boots[1].GetComponent<Button>().enabled = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}
