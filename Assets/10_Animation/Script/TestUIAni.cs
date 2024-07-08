using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIAni : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ani.SetBool("active", true);
        }
    }

    public void CloseWindow()
    {
        ani.SetBool("active", false);
    }
}
