using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject WinLevelPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinLevelPanel.transform.DOMoveY(540f, 1.0f);
        }
    }
}
