using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    private ObjPool objPool;

    private WaitForSeconds duration = new WaitForSeconds(3f);
    
    void Update()
    {
        transform.Translate(0f, 0f, 5 * Time.deltaTime);
        
    }
    
    public void Init(float angle, ObjPool pool)
    {
        transform.position = Vector3.zero;
        transform.RotateAround(Vector3.zero, Vector3.up, angle);

        objPool = pool;
        
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        while (true)
        {
            yield return duration;
            
            objPool.SetObj(this);
        }
    }
}
