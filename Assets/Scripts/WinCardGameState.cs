using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCardGameState : CardGameState
{

    [SerializeField] Text _YouWin = null;
    private void Start()
    {
        _YouWin.gameObject.SetActive(false);
    }
    public override void Enter()
    {
        _YouWin.gameObject.SetActive(true);
    }


}
