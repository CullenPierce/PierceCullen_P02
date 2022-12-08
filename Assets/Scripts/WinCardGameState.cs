using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCardGameState : CardGameState
{

    private void Start()
    {

    }
    public override void Enter()
    {
        SceneManager.LoadScene("WinScreen");
    }


}
