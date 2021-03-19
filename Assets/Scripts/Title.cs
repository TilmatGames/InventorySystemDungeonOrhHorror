using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public enum typeTitle
    {
        OnLine,
        NotLine
    }
    
    public bool Flag;
    public typeTitle TypeTitle;
    
   // private SpriteRenderer _tiles, _tilesJevel;
    public List<SerialisedTile.SerialisedTiles> TilesLeft;
    public List<SerialisedTile.SerialisedTiles> TilesRight;
    public List<SerialisedTile.SerialisedTiles> TilesBot;
    public List<SerialisedTile.SerialisedTiles> TilesTop;
    public List<SerialisedTile.SerialisedTiles> AllTitles;


    public enum _directionMap
    {
        top,
        right,
        bot,
        left
    }

    public _directionMap _directionMaps;


    // Update is called once per frame
}