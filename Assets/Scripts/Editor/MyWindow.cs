using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : EditorWindow
{
    private List<string> sceneNames = new List<string>();

    [MenuItem("Window/Scene Loader")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SceneLoader));
    }

    private void OnEnable()
    {
        UpdateSceneList();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Refresh Scenes"))
        {
            UpdateSceneList();
        }

        GUILayout.Space(10);

        if (sceneNames.Count == 0)
        {
            EditorGUILayout.HelpBox("No scenes found in build settings.", MessageType.Warning);
            return;
        }

        GUILayout.Label("Select a Scene to Load:", EditorStyles.label);

        foreach (string sceneName in sceneNames)
        {
            if (GUILayout.Button(sceneName))
            {
                LoadSceneByName(sceneName);
            }
        }
    }

    private void UpdateSceneList()
    {
        sceneNames.Clear();

        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            string scenePath = EditorBuildSettings.scenes[i].path;
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            sceneNames.Add(sceneName);
        }
    }

    private void LoadSceneByName(string sceneName)
    {
        string scenePath = "";
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName))
            {
                scenePath = scene.path;
                break;
            }
        }
        if (Application.isPlaying)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (!string.IsNullOrEmpty(scenePath))
        {
            EditorSceneManager.OpenScene(scenePath);
        }
        else
        {
            Debug.LogError("Scene not found in build settings: " + sceneName);
        }
    }
}