using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Blob : MonoBehaviour
{
    public GameObject blobPreFab;
    
    protected FSMstate idleState;
    protected FSMstate wanderingState;
    protected FSMstate TracingFoodState;
    protected FSMstate eatingState;
    
    protected FSMstate curState;
    protected FSMstate nextState;
    
    private bool isTransition;

    protected NavMeshAgent agent;

    protected Food targetFood;

    protected int hp = 20;
    protected const int MaxHp = 40;

    private WaitForSeconds energyUseRate = new WaitForSeconds(2f);
    private void Awake()
    {
        StateInit();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UsingEnergy());
    }

    private void Update()
    {
        if(isTransition)
        {
            curState = nextState;
            curState.OnEnter?.Invoke();
            isTransition = false;
        }
        
        
        curState.OnUpdate?.Invoke();
        isTransition = TransitionCheck();

        if (isTransition) curState.OnExit?.Invoke();
        
    }

    protected abstract void StateInit();
    protected abstract bool TransitionCheck();

    public void ResetFood()
    {
        targetFood = null;
    }

    private IEnumerator UsingEnergy()
    {
        while (hp > 0)
        {
            yield return energyUseRate; // waits 2sec
            hp--;

            if (hp < 0)
            {
                targetFood.RemoveOwner(this);
                Destroy(gameObject);
            }

            if (hp >= MaxHp)
            {
                Instantiate(blobPreFab, transform.position, Quaternion.identity);
                hp -= 20;
            }
        }
    }
}
