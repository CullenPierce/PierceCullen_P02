using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    [SerializeField] GameObject _enemyRockIcon = null;
    [SerializeField] GameObject _enemyPaperIcon = null;
    [SerializeField] GameObject _enemyScissorsIcon = null;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        EnemyChoice();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));

    }
    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }
    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        EnemyTurnEnded?.Invoke();

        StateMachine.ChangeState<ContestGameState>();
    }
    void EnemyChoice()
    {
        float number = UnityEngine.Random.Range(1f, 3.99f);
        int choice = (int) number;
        Debug.Log(number);
        Debug.Log(choice);

        if(choice == 1)
        {
            _enemyRockIcon.SetActive(true);
        }
        if(choice == 2)
        {
            _enemyPaperIcon.SetActive(true);
        }
        if(choice == 3)
        {
            _enemyScissorsIcon.SetActive(true);
        }
    }
}
