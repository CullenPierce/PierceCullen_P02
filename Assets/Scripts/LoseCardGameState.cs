using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCardGameState : CardGameState
{
    private void Start()
    {

    }
    public override void Enter()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
