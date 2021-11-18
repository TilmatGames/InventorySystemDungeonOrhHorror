using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    public static int move = 0;
  [SerializeField]  private Text _numberMove;
    public static void IncrementMove() { move++; }
    public void NumberMoveAply()
    { IncrementMove();
        _numberMove.text = Convert.ToString(move); }
}
