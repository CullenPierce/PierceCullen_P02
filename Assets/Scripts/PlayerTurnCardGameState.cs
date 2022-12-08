using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTurnCardGameState : CardGameState
{
    

    [SerializeField] GameObject _rockIcon = null;
    [SerializeField] GameObject _paperIcon = null;
    [SerializeField] GameObject _scissorsIcon = null;

    

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        

        

        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
    }

    public override void Exit()
    {
        

        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        
        if(_rockIcon.activeSelf == true || _paperIcon.activeSelf == true || _scissorsIcon.activeSelf == true)
        {
            StateMachine.ChangeState<EnemyTurnCardGameState>();

        }
    }

    void OnPressedCancel()
    {
        SceneManager.LoadScene("CardGameMainMenu");
    }
}
