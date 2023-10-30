using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI LevelText;

    private void Awake()
    {
        DOTween.Init();
        LevelText.color = new Color(LevelText.color.r, LevelText.color.g, LevelText.color.b, 0.0f);
    }

    private void Start()
    {
        Sequence LevelTextSequence = DOTween.Sequence();
        LevelTextSequence.Append(LevelText.DOFade(1, 2f))
            .AppendInterval(2)
            .Append(LevelText.transform.DOMoveY(Screen.height, 2))
            .Join(LevelText.DOFade(0, 2f));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
