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
    
    public float idleTime = 1f;
    protected float idleTimer;
    
    protected float eatingTimer;
    protected float eatingRate = 0.2f;

    protected Vector3 WanderingPos;

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

    private IEnumerator UsingEnergy()
    {
        while (hp > 0)
        {
            yield return energyUseRate; // waits 2sec
            hp--;

            if (hp <= 0)
            {
                if(targetFood != null && targetFood.IsDestroyed())
                    targetFood.RemoveOwner(this);
                if (gameObject.CompareTag("Dove")) SimulationManager.instance.doveCount--;
                if (gameObject.CompareTag("Hawk")) SimulationManager.instance.hawkCount--;
                Destroy(gameObject);
            }

            if (hp >= MaxHp)
            {
                Instantiate(blobPreFab, transform.position, Quaternion.identity);
                if (blobPreFab.CompareTag("Dove")) SimulationManager.instance.doveCount++;
                if (blobPreFab.CompareTag("Hawk")) SimulationManager.instance.hawkCount++;
                hp -= 20;
            }
        }
    }
}
