using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TestResourceLoad : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;

    private void Start()
    {
        LoadResource().Forget();
    }

    private async UniTask LoadResource()
    {
        var doveObj = await Resources.LoadAsync<GameObject>("Dove") as GameObject;
        var hawkObj = await Resources.LoadAsync<GameObject>("Hawk") as GameObject;
        
        if (doveObj is null && hawkObj is null)
        {
            Debug.LogError("Load process is failed");
            return;
        }
        
        Debug.Log(doveObj!.name + " and " + hawkObj!.name);
        
        Instantiate(doveObj, new Vector3(0f, 1f, 0f), Quaternion.identity);
        Instantiate(hawkObj, new Vector3(1f, 1f, 3f), Quaternion.identity);
    }

    private IEnumerator TestCoroutine()
    {
        yield return null;
        yield return new WaitForSeconds(1f);
        yield return new WaitWhile(() => false);
        yield return new WaitUntil(() => true);
    }

    private async UniTask TestUniTask()
    {
        await UniTask.NextFrame();
        await UniTask.WaitForSeconds(1f);
        await UniTask.WaitWhile(() => false);
        await UniTask.WaitUntil(() => true);
        
        await UniTask.WhenAll(LoadResource(), TestUniTask());
    }
}
