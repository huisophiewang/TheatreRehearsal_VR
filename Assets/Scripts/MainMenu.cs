using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    AsyncOperation m_loadingLevelStatus = null;


    void Awake()
    {
        Application.runInBackground = true;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log("Unity Version: " + Application.unityVersion);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VHUtils.ApplicationQuit();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject.FindObjectOfType<DebugInfo>().NextMode();
        }
    }

    void OnGUI()
    {
        float buttonH;

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.Android)
            buttonH = 70;
        else
            buttonH = 20;

        Rect r = new Rect(0.25f, 0.2f, 0.5f, 0.6f);
        GUILayout.BeginArea(VHGUI.ScaleToRes(ref r));
        GUILayout.BeginVertical();

        if (m_loadingLevelStatus != null)
        {
            GUI.enabled = false;
        }

        if (GUILayout.Button("Start Level", GUILayout.Height(buttonH)))
        {
            StartCoroutine(LoadLevel("vhAssetsTestScene"));
        }

        if (GUILayout.Button("Mecanim Test", GUILayout.Height(buttonH)))
        {
            StartCoroutine(LoadLevel("mecanim"));
        }

        if (GUILayout.Button("Mecanim Web Test", GUILayout.Height(buttonH)))
        {
            StartCoroutine(LoadLevel("mecanimWeb"));
        }

        GUILayout.Space(40);

        if (GUILayout.Button("Exit", GUILayout.Height(buttonH)))
        {
            VHUtils.ApplicationQuit();
        }

        if (m_loadingLevelStatus != null)
        {
            GUI.enabled = true;
        }


        if (m_loadingLevelStatus != null)
        {
            GUILayout.Space(40);

            GUILayout.Label("Loading Level");

            GUILayout.Box("", GUILayout.Height(buttonH), GUILayout.Width(m_loadingLevelStatus.progress * r.width));
        }


        GUILayout.EndVertical();
        GUILayout.EndArea();
    }


    IEnumerator LoadLevel(string levelName)
    {
        m_loadingLevelStatus = Application.LoadLevelAsync(levelName);

        yield return m_loadingLevelStatus;
    }
}
