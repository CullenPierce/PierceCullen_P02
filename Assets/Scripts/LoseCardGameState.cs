using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCardGameState : CardGameState
{
    public override void Enter()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
