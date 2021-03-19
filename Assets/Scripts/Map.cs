using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;
using Random = System.Random;

public class Map : MonoBehaviour
{
    [SerializeField] private SerialisedMap[] _height;
    public GameObject firstTitle;
    private float posx, posy;

    private int loops = 0;
    private static System.Random random = new System.Random(DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

    [ContextMenu("MainGenerate")]
    public void Generate()
    {

        {
            for (int j = 0; j < _height.Length; j++)
            {
                var elem = _height[j];
                for (int i = 0; i < elem._weight.Length; i++)
                {
                    var cell = elem._weight[i].GetComponent<Title>();
                    if (cell.TypeTitle == Title.typeTitle.OnLine)
                    {
                        if (!((i >= 3 && i <= 6 && j >= 3 && j <= 6))) //вырез серединки
                        {
                            if (!cell.Flag)
                            {
                                if (i > 0 && elem._weight[i - 1].GetComponent<Title>().Flag &&
                                    elem._weight[i - 1].GetComponent<Title>().TypeTitle ==
                                    Title.typeTitle.OnLine) //слева флаг
                                {
                                    cell._directionMaps = Title._directionMap.left;
                                    cell.GetComponent<SpriteRenderer>().sprite = TitleSpriteGenerate(cell);

                                    cell.Flag = true;
                                }

                                if (i < elem._weight.Length && elem._weight[i + 1].GetComponent<Title>().Flag &&
                                    elem._weight[i + 1].GetComponent<Title>().TypeTitle ==
                                    Title.typeTitle.OnLine) //справа флаг
                                {
                                    cell._directionMaps = Title._directionMap.right;
                                    cell.GetComponent<SpriteRenderer>().sprite = TitleSpriteGenerate(cell);

                                    cell.Flag = true;
                                }

                                if (j > 0 && _height[j - 1]._weight[i].GetComponent<Title>().Flag &&
                                    _height[j - 1]._weight[i].GetComponent<Title>().TypeTitle ==
                                    Title.typeTitle.OnLine) // снизу флаг 
                                {
                                    cell._directionMaps = Title._directionMap.bot;
                                    cell.GetComponent<SpriteRenderer>().sprite = TitleSpriteGenerate(cell);

                                    cell.Flag = true;
                                }

                                if (j + 1 < _height.Length &&
                                    _height[j + 1]._weight[i].GetComponent<Title>().Flag &&
                                    _height[j + 1]._weight[i].GetComponent<Title>().TypeTitle ==
                                    Title.typeTitle.OnLine) // сверху флаг
                                {
                                    cell._directionMaps = Title._directionMap.top;
                                    cell.GetComponent<SpriteRenderer>().sprite = TitleSpriteGenerate(cell);

                                    cell.Flag = true;
                                }
                            }
                        }
                    }
                }
            }
        }


        for (int j = 0; j < _height.Length; j++)
        {
            var elem = _height[j];
            for (int i = 0; i < elem._weight.Length; i++)
            {
                var cell = elem._weight[i].GetComponent<Title>();
                if ((!cell.Flag && cell.TypeTitle == Title.typeTitle.OnLine) || loops > 20)
                {
                    loops++;
                    Generate();
                }
            }
        }

        for (int j = 0; j < _height.Length; j++)
        {
            var elem = _height[j];
            for (int i = 0; i < elem._weight.Length; i++)
            {

                var cell = elem._weight[i].GetComponent<Title>();
                if (!cell.Flag)
                {

                    int rnd = random.Next(0, cell.AllTitles.Count);


                    cell.GetComponent<SpriteRenderer>().sprite = cell.AllTitles[rnd].Sprites;
                    cell.Flag = true;
                }
            }
        }
    }
    [ContextMenu("reset")]
    public void reset()
    {
        for (int j = 0; j < _height.Length; j++)
        {
            var elem = _height[j];
            for (int i = 0; i < elem._weight.Length; i++)
            {

                var cell = elem._weight[i].GetComponent<Title>();
                if (cell.Flag)
                {
                    cell.Flag = false;
                }
            }
        }
    }

    public Sprite TitleSpriteGenerate(Title title)
    {

        int DopRandom;
        var sprite = title.GetComponent<SpriteRenderer>().sprite;
        if (title._directionMaps == Title._directionMap.left)
        {
            int rnd = random.Next(0, title.TilesLeft.Count);


            sprite = title.TilesLeft[rnd].Sprites;
        }

        if (title._directionMaps == Title._directionMap.right)
        {
            int rnd = random.Next(0, title.TilesRight.Count);


            sprite = title.TilesRight[rnd].Sprites;
        }

        if (title._directionMaps == Title._directionMap.top)
        {
            int rnd = random.Next(0, title.TilesTop.Count);


            sprite = title.TilesTop[rnd].Sprites;
        }

        if (title._directionMaps == Title._directionMap.bot)
        {
            int rnd = random.Next(0, title.TilesBot.Count);


            sprite = title.TilesBot[rnd].Sprites;
        }

        return (sprite);
    }

    [ContextMenu("Generate")]
    public void InstallTitle()
    {
        var _posZero = firstTitle.transform.position;
        for (int j = 0;
            j < _height.Length;
            j++)
        {
            var elem = _height[j];
            for (int i = 0; i < elem._weight.Length; i++)
            {
                if (!((i >= 3 && i <= 6 && j >= 3 && j <= 6)))
                {
                    elem._weight[i].transform.position =
                        new Vector3(_posZero.x + (i) * posx, _posZero.y + (j) * posy, 0);
                }
            }
        }
    }


    void Start()
    {
        Generate();
    }

    [Serializable]
    public class SerialisedMap
    {
        public GameObject[] _weight;
    }
}