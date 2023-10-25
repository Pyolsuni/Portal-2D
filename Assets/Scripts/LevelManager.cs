using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI LevelText;

    private void Awake()
    {
        DOTween.Init();
        
    }

    private void Start()
    {   

        Sequence LevelTextSequence = DOTween.Sequence();
        LevelTextSequence.Append(LevelText.DOFade(1, 2f))
            .AppendInterval(2)
            .Append(LevelText.transform.DOMoveY(1120, 2))
            .Join(LevelText.DOFade(0, 2f));

    }
}
