/************************************************************************************

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.2 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculusvr.com/licenses/LICENSE-3.2

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VR = UnityEngine.VR;
using System;

//-------------------------------------------------------------------------------------
/// <summary>
/// Shows debug information on a heads-up display.
/// </summary>
public class OVRDebugInfo : MonoBehaviour
{

    GameObject debugUIManager;
    GameObject debugUIObject;
    GameObject riftPresent;    
    GameObject fps;    
    GameObject ipd;
    GameObject fov;
    GameObject height;
	GameObject depth;
	GameObject resolutionEyeTexture;
    GameObject latencies;
    GameObject texts;    
	

	string strRiftPresent            = null; // "VR DISABLED"
    string strFPS                    = null; // "FPS: 0";
    string strIPD                    = null; // "IPD: 0.000";
    string strFOV                    = null; // "FOV: 0.0f";
    string strHeight                 = null; // "Height: 0.0f";
	string strDepth                  = null; // "Depth: 0.0f";
	string strResolutionEyeTexture   = null; // "Resolution : {0} x {1}"
    string strLatencies              = null; // "R: {0:F3} TW: {1:F3} PP: {2:F3} RE: {3:F3} TWE: {4:F3}"
	
	
	// added by Sophie
    
	// UI for display player's line
	public static GameObject player_line;
	public static GameObject player_line_text_GO;
	//public static string player_line_text = "Press Space to Start";
	public static string player_line_text = "Your line will be shown here. Press Space to Start";
	
	// UI for display clock
	public static GameObject clock;
	public static GameObject clock_text_GO;
	public static string clock_text = ""; 
    


    float updateInterval = 0.5f;
    float accum          = 0.0f;
    int   frames         = 0;
    float timeLeft       = 0.0f;

    bool  initUIComponent =  false;
    bool  isInited        =  false;


    float offsetY = 220.0f;
    float riftPresentTimeout = 0.0f;

    public static bool showVRVars = false;
	
	public static bool showClock = false;
	public static bool showPlayerLine = true;




    void Awake()
    {
        // Create canvas for using new GUI
        debugUIManager = new GameObject();
        debugUIManager.name = "DebugUIManager";
        debugUIManager.transform.parent = GameObject.Find("LeftEyeAnchor").transform;

        RectTransform rectTransform = debugUIManager.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100f, 100f);
        rectTransform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        rectTransform.localPosition = new Vector3(0.01f, 0.17f, 0.53f);
        rectTransform.localEulerAngles = Vector3.zero;

        Canvas canvas = debugUIManager.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.pixelPerfect = false;
		
		//InitUIComponents();
    }


    void Update()
    {
        if (initUIComponent && !isInited)
        {
            InitUIComponents();
        }

        if (Input.GetKeyDown(KeyCode.A) && riftPresentTimeout < 0.0f)
        {
            initUIComponent = true;
            showVRVars = true;
        }

        UpdateDeviceDetection();

        // Presenting VR variables
        if (showVRVars)
        {
            debugUIManager.SetActive(true);
            
            UpdateStrings();           
        }
        else
        {
            debugUIManager.SetActive(false);
        }
    }


    void OnDestroy()
    {
        isInited = false;
    }


    void InitUIComponents()
    {


        debugUIObject = new GameObject();
        debugUIObject.name = "DebugInfo";
        debugUIObject.transform.parent = GameObject.Find("DebugUIManager").transform;
        debugUIObject.transform.localPosition = new Vector3(0.0f, 100.0f, 0.0f);
        debugUIObject.transform.localEulerAngles = Vector3.zero;
        debugUIObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		// init clock 
		clock = new GameObject();
		clock.AddComponent<RectTransform>();
		clock.AddComponent<CanvasRenderer>();
		clock.AddComponent<Image>();
		clock.GetComponent<RectTransform>().sizeDelta = new Vector2(300f, 50f);
		clock.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0.5f);
		
		clock_text_GO = new GameObject();
		clock_text_GO.AddComponent<RectTransform>();
		clock_text_GO.AddComponent<CanvasRenderer>();
		clock_text_GO.AddComponent<Text>();
		clock_text_GO.GetComponent<RectTransform>().sizeDelta = new Vector2(300f, 50f);
		clock_text_GO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		clock_text_GO.GetComponent<Text>().fontSize = 24;
		clock_text_GO.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		clock_text_GO.GetComponent<Text>().color = Color.white;
		
		clock.transform.SetParent(debugUIObject.transform);
		clock_text_GO.transform.SetParent(clock.transform);
		RectTransform rt_clock = clock.GetComponent<RectTransform>();
		rt_clock.localPosition = new Vector3(0.0f, -150f, 0.0f);
		rt_clock.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		clock.transform.localEulerAngles = Vector3.zero;
			

		// init player_lilne
		player_line = new GameObject();
		player_line.AddComponent<RectTransform>();
		player_line.AddComponent<CanvasRenderer>();
		player_line.AddComponent<Image>();
		player_line.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 100f);
		player_line.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0.5f);
		
		player_line_text_GO = new GameObject();
		player_line_text_GO.AddComponent<RectTransform>();
		player_line_text_GO.AddComponent<CanvasRenderer>();
		player_line_text_GO.AddComponent<Text>();
		player_line_text_GO.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 100f);
		player_line_text_GO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		player_line_text_GO.GetComponent<Text>().fontSize = 24;
		player_line_text_GO.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		player_line_text_GO.GetComponent<Text>().color = Color.white;
		
		player_line.transform.SetParent(debugUIObject.transform);
		player_line_text_GO.transform.SetParent(player_line.transform);
		RectTransform rt_player_line = player_line.GetComponent<RectTransform>();
		rt_player_line.localPosition = new Vector3(0.0f, -300f, 0.0f);
		rt_player_line.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		player_line.transform.localEulerAngles = Vector3.zero;
			

        initUIComponent = false;
        isInited = true;

    }





    void UpdateStrings()
    {

        if (debugUIObject == null)
            return;

        if (showClock)
        {
            clock.GetComponentInChildren<Text>().text = clock_text;    
			clock.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0.5f);
        }
		else 
		{
			clock.GetComponentInChildren<Text>().text = "";
			clock.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0f);
		}
		
        if (showPlayerLine)
        {
            player_line.GetComponentInChildren<Text>().text = player_line_text;
			player_line.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0.5f);
        }
		else 
		{
			player_line.GetComponentInChildren<Text>().text = "";
			player_line.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0f);
		}


	}
	

    void RiftPresentGUI(GameObject guiMainOBj)
    {
        riftPresent = ComponentComposition(riftPresent);
        riftPresent.transform.SetParent(guiMainOBj.transform);
        riftPresent.name = "RiftPresent";
        RectTransform rectTransform = riftPresent.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        rectTransform.localEulerAngles = Vector3.zero;

        Text text = riftPresent.GetComponentInChildren<Text>();
        text.text = strRiftPresent;
        text.fontSize = 20;
    }


    void UpdateDeviceDetection()
    {
        if (riftPresentTimeout >= 0.0f)
        {
            riftPresentTimeout -= Time.deltaTime;
        }
    }


    GameObject VariableObjectManager(GameObject gameObject, string name, float posY, string str, int fontSize)
    {
     
        gameObject = ComponentComposition(gameObject);
        gameObject.name = name;
        gameObject.transform.SetParent(debugUIObject.transform);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0.0f, posY , 0.0f);

        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = str;
        text.fontSize = fontSize;
        gameObject.transform.localEulerAngles = Vector3.zero;

        rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        return gameObject;
    }


    GameObject ComponentComposition(GameObject GO)
    {
        GO = new GameObject();
        GO.AddComponent<RectTransform>();
        GO.AddComponent<CanvasRenderer>();
        GO.AddComponent<Image>();
        GO.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 100f);
        GO.GetComponent<Image>().color = new Color(255f / 255f, 5f / 255f, 5f / 255f,0.5f);

        texts = new GameObject();
        texts.AddComponent<RectTransform>();
        texts.AddComponent<CanvasRenderer>();
        texts.AddComponent<Text>();
        texts.GetComponent<RectTransform>().sizeDelta = new Vector2(300f, 100f);
		texts.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        texts.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        texts.GetComponent<Text>().color = Color.black;

        texts.transform.SetParent(GO.transform);
        texts.name = "TextBox";

        return GO;
    }


}
