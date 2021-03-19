using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SerialisedTile
{
    // Start is called before the first frame update
    [Serializable]
    public class SerialisedTiles
    {
        public Sprite Sprites;
        public enum direction
        {
            TopLeft,
            BotLeft,
            TopRight,
            BotRight,
            LeftTop,
            LeftBot,
            RightTop,
            RightBot
        }
        public direction[] Directions;
    }
}

