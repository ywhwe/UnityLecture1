using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate
{
    public Action OnEnter;
    public Action OnUpdate;
    public Action OnExit;
    
    public FSMstate(Action onEnter, Action onUpdate, Action onExit)
    {
        OnEnter = onEnter;
        OnUpdate = onUpdate;
        OnExit = onExit;
    }
}

/*public class FSMState
{
    /*private delegate void name(int a, float c);

    private name b;

    private Action<int, float> a;
    private Func<int, string> c;
    private Predicate<int> d;* /

    private delegate void varname(int a);

    private varname a;

    private void Test1(int c)
    {
        
    }

    public void Test2(int f)
    {
        
    }

    private void Main()
    {
        a = Test1;
        a += Test2;
        
        a.Invoke(2); // then Test1 and Test2 will operated with
                       // parameter: 2
    }
}*/
