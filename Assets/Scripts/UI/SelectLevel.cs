using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    public void OnLevelSelectClicked() {
        SceneManager.LoadScene("Scenes/Level" + levelText.text + "Scene");
    }

}
