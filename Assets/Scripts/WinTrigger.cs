using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject WinLevelPanel;

    private void Awake()
    {
        WinLevelPanel.transform.position = new Vector3(WinLevelPanel.transform.position.x, Screen.height*2, WinLevelPanel.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinLevelPanel.transform.DOMoveY(Screen.height/2, 1.0f);
        }
    }
}
