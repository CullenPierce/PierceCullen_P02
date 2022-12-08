using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContestGameState : CardGameState
{


    [SerializeField] Text _enemyHealthTextUI = null;
    [SerializeField] Text _playerHealthTextUI = null;

    [SerializeField] GameObject _rockIcon = null;
    [SerializeField] GameObject _paperIcon = null;
    [SerializeField] GameObject _scissorsIcon = null;

    [SerializeField] GameObject _enemyRockIcon = null;
    [SerializeField] GameObject _enemyPaperIcon = null;
    [SerializeField] GameObject _enemyScissorsIcon = null;

    int _enemyHealth = 3;
    int _playerHealth = 3;


    public override void Enter()
    {
        Debug.Log("Contest: ...Entering");

        _enemyHealthTextUI.text = "Enemy Health: " + _enemyHealth;
        _playerHealthTextUI.text = "Player Health: " + _playerHealth;

        //Rock
        if(_rockIcon.activeSelf == true)
        {
            if(_enemyRockIcon.activeSelf == true)
            {
                Debug.Log("Tie");
            }
            if (_enemyPaperIcon.activeSelf == true)
            {
                Debug.Log("Enemy Win");
                _playerHealth--;
            }
            if (_enemyScissorsIcon.activeSelf == true)
            {
                Debug.Log("Player Win");
                _enemyHealth--;
            }
            _rockIcon.SetActive(false);
            //StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
        //Paper
        if (_paperIcon.activeSelf == true)
        {
            if (_enemyRockIcon.activeSelf == true)
            {
                Debug.Log("Player Win");
                _enemyHealth--;
            }
            if (_enemyPaperIcon.activeSelf == true)
            {
                Debug.Log("Tie");
            }
            if (_enemyScissorsIcon.activeSelf == true)
            {
                Debug.Log("Enemy Win");
                _playerHealth--;
            }
            _paperIcon.SetActive(false);
            //StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
        //Scissors
        if (_scissorsIcon.activeSelf == true)
        {
            if (_enemyRockIcon.activeSelf == true)
            {
                Debug.Log("Enemy Win");
                _playerHealth--;
            }
            if (_enemyPaperIcon.activeSelf == true)
            {
                Debug.Log("Player Win");
                _enemyHealth--;
            }
            if (_enemyScissorsIcon.activeSelf == true)
            {
                Debug.Log("Tie");
            }
            _scissorsIcon.SetActive(false);
            //StateMachine.ChangeState<PlayerTurnCardGameState>();
            
        }
        _enemyRockIcon.SetActive(false);
        _enemyPaperIcon.SetActive(false);
        _enemyScissorsIcon.SetActive(false);

        _enemyHealthTextUI.text = "Enemy Health: " + _enemyHealth;
        _playerHealthTextUI.text = "Player Health: " + _playerHealth;

        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        

        
    }
    public override void Exit()
    {
        Debug.Log("Exiting Contest");
    }

    void OnPressedConfirm()
    {
        if(_enemyHealth > 0 && _playerHealth > 0)
        {
            StateMachine.ChangeState<PlayerTurnCardGameState>();

        }
        if(_enemyHealth == 0)
        {
            StateMachine.ChangeState<WinCardGameState>();
        }
        if(_playerHealth == 0)
        {
            StateMachine.ChangeState<LoseCardGameState>();
        }
    }
}
