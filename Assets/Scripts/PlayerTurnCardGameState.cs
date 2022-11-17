using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] Text _playerTurnTextUI = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();

        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);

        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        if(_playerTurnCount >= 3)
        {
            StateMachine.ChangeState<WinCardGameState>();
            Debug.Log("WInSTate");
        }
        if(_playerTurnCount< 3)
        {
            StateMachine.ChangeState<EnemyTurnCardGameState>();

        }
    }

    void OnPressedCancel()
    {
        SceneManager.LoadScene("CardGameMainMenu");
    }
}
