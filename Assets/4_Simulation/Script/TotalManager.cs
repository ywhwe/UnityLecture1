using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalManager : MonoBehaviour
{
    public static TotalManager instance;

    public Image fadeScreen;
    
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void MoveScene(int id)
    {
        
    }

    public void MoveScene(string sceneName)
    {
        
    }

    private IEnumerator FadeScreen(bool fadeOut)
    {
        var fadeTimer = 0f;
        const float FadeDuration = 1f;

        var initialValue = fadeOut ? 0f : 1f;
        var fadeDir = fadeOut ? 1f : -1f;

        while (fadeTimer < FadeDuration)
        {
            yield return null;
            fadeTimer += Time.deltaTime;

            var color = fadeScreen.color;

            initialValue += fadeDir * Time.deltaTime;
            color.a += initialValue;

            fadeScreen.color = color;
        }
    }
}
