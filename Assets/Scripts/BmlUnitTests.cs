using UnityEngine;
using System.Collections;

public class BmlUnitTests : MonoBehaviour
{
    struct BMLData
    {
        public bool hasStart;
        public float start;
        public bool hasStroke;
        public float stroke;
        public bool hasEnd;
        public float end;
    }


    float m_debugMenuButtonH;
    string m_testStatusLabel = "";
    float m_testStatusStartTime;
    string m_bmlId;

    float [] m_faceSliders = new float [300];
    int [] faceUnits = new int [] { 1, 2, 4, 5, 6, 7, 10, 12, 25, 26, 45 };
    string [] m_faceBothLeftRightText = new string [] { "B", "L", "R" };
    int [] m_faceBothLeftRight = new int [300];


    void Start()
    {
        if (VHUtils.IsAndroid() || VHUtils.IsIOS())
            m_debugMenuButtonH = 70;
        else
            m_debugMenuButtonH = 20;
    }


    void Update()
    {
    }


    void OnGUI()
    {
        float buttonX = 0;
        float buttonY = 0;
        float buttonW = 200;
        float spaceHeight = 30;

        GUILayout.BeginArea(new Rect(buttonX, buttonY, buttonW, Screen.height));
        GUILayout.BeginVertical();

        GUILayout.Space(spaceHeight);

        if (GUILayout.Button("Play Anim", GUILayout.Height(m_debugMenuButtonH)))
        {
            BMLData data = new BMLData();
            StartCoroutine(TestPlayAnimation("ChrBrad@Idle01_ChopBoth01", data));
        }

        if (GUILayout.Button("Play Anim w/Start", GUILayout.Height(m_debugMenuButtonH)))
        {
            BMLData data = new BMLData();
            data.hasStart = true;
            data.start = 1;
            StartCoroutine(TestPlayAnimation("ChrBrad@Idle01_ChopBoth01", data));
        }

        if (GUILayout.Button("Play Anim w/Stroke", GUILayout.Height(m_debugMenuButtonH)))
        {
            BMLData data = new BMLData();
            data.hasStroke = true;
            data.stroke = 3;
            StartCoroutine(TestPlayAnimation("ChrBrad@Idle01_ChopBoth01", data));
        }

        if (GUILayout.Button("Play Anim w/End", GUILayout.Height(m_debugMenuButtonH)))
        {
            BMLData data = new BMLData();
            data.hasEnd = true;
            data.end = 5;
            StartCoroutine(TestPlayAnimation("ChrBrad@Idle01_ChopBoth01", data));
        }

        if (GUILayout.Button("Gaze Camera", GUILayout.Height(m_debugMenuButtonH)))
        {
            StartCoroutine(TestGazeCamera());
        }


        foreach (int i in faceUnits)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(string.Format(@"au_{0}:", i), GUILayout.Width(40));

            float newSlider = GUILayout.HorizontalSlider(m_faceSliders[i], 0, 1);
            if (newSlider != m_faceSliders[i])
            {
                m_faceSliders[i] = newSlider;

                string side;
                switch (m_faceBothLeftRight[i])
                {
                    case 0: side = "both"; break;
                    case 1: side = "left"; break;
                    case 2: side = "right"; break;
                    default: side = ""; break;
                }

                StartCoroutine(TestSetFaceAnimationImmediate(i, side, m_faceSliders[i]));
            }

            m_faceBothLeftRight[i] = GUILayout.SelectionGrid(m_faceBothLeftRight[i], m_faceBothLeftRightText, 3);

            GUILayout.EndHorizontal();
        }


        GUILayout.Space(spaceHeight);

        if (GUILayout.Button("Reset", GUILayout.Height(m_debugMenuButtonH)))
        {
            StartCoroutine(TestReset());
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();

        string testStatusLabel = m_testStatusLabel.Replace("@time", string.Format("{0:f2}", Time.time - m_testStatusStartTime));
        TextAnchor origAnchor = GUI.skin.label.alignment;
        GUI.skin.label.alignment = TextAnchor.UpperCenter;
        Rect rectLabel = new Rect(0.0f, 0.1f, 1.0f, 1.0f);
        GUI.Label(VHGUI.ScaleToRes(ref rectLabel), testStatusLabel);
        GUI.skin.label.alignment = origAnchor;
    }


    IEnumerator TestReset()
    {
        m_testStatusLabel = "Resetting...";

        SmartbodyManager.Get().PythonCommand(string.Format(@"scene.command('char {0} gazefade out 1')", "Brad"));

        GameObject.Find("BradM").GetComponent<ICharacterController>().SBGaze("BradM", "");

        yield return new WaitForSeconds(2.0f);

        m_testStatusLabel = "";
    }


    IEnumerator TestPlayAnimation(string motionName, BMLData bmlData)
    {
        // TODO need to find a way to do this via Mecanim motions

        GameObject motionObject = GameObject.Find(motionName);
        SmartbodyMotion motion = motionObject.GetComponent<SmartbodyMotion>();

        float start = motion.GetSyncPointTime("start");
        float ready = motion.GetSyncPointTime("readyTime");
        float strokeStart = motion.GetSyncPointTime("strokeStartTime");
        float emphasis = motion.GetSyncPointTime("emphasisTime");
        float stroke = motion.GetSyncPointTime("strokeTime");
        float relax = motion.GetSyncPointTime("relaxTime");
        float end = motion.GetSyncPointTime("stop");

        string bmlLine = string.Format(@"<animation name=""{0}"" />", motionName);

        if (bmlData.hasStart)
        {
            bmlLine = bmlLine.Replace(" />", string.Format(@" start=""{0}"" />", bmlData.start));

            start += bmlData.start;
            ready += bmlData.start;
            strokeStart += bmlData.start;
            emphasis += bmlData.start;
            stroke += bmlData.start;
            relax += bmlData.start;
            end += bmlData.start;
        }

        if (bmlData.hasStroke)
        {
            bmlLine = bmlLine.Replace(" />", string.Format(@" stroke=""{0}"" />", bmlData.stroke));

            float amountToAdjust = bmlData.stroke - stroke;   // eg, if stroke in the motion is 1.2, and bmlData.stroke is 3, we want to adjust the start by 1.8
            start += amountToAdjust;
            ready += amountToAdjust;
            strokeStart += amountToAdjust;
            emphasis += amountToAdjust;
            stroke += amountToAdjust;
            relax += amountToAdjust;
            end += amountToAdjust;
        }

        if (bmlData.hasEnd)
        {
            bmlLine = bmlLine.Replace(" />", string.Format(@" end=""{0}"" />", bmlData.end));

            float amountToAdjust = bmlData.end - end;   // eg, if end in the motion is 3.2, and bmlData.end is 5, we want to adjust the start by 1.8
            start += amountToAdjust;
            ready += amountToAdjust;
            strokeStart += amountToAdjust;
            emphasis += amountToAdjust;
            stroke += amountToAdjust;
            relax += amountToAdjust;
            end += amountToAdjust;
        }

        m_testStatusStartTime = Time.time;

        m_testStatusLabel =  string.Format("Play Animation - {0}\n", motionName) + 
                             bmlLine + "\n" +
                             string.Format("start = {0:f2} (@time)\n", start) +
                             string.Format("ready = {0:f2} (@time)\n", ready) +
                             string.Format("strokeStart = {0:f2} (@time)\n", strokeStart) +
                             string.Format("emphasis = {0:f2} (@time)\n", emphasis) +
                             string.Format("stroke = {0:f2} (@time)\n", stroke) +
                             string.Format("relax = {0:f2} (@time)\n", relax) +
                             string.Format("end = {0:f2} (@time)\n", end);

        string bmlString = "renderer_bml_" + GenerateBmlId();
        string xml =    string.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>") + 
                        string.Format(@"<act>") + 
                           string.Format(@"<bml>") + 
                              bmlLine + 
                           string.Format(@"</bml>") + 
                        string.Format(@"</act>");

        VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "Brad", bmlString, xml));
        VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "BradM", bmlString, xml));

        yield return new WaitForSeconds(end);

        /*
        yield return new WaitForSeconds(1.44f);
        // to-do, make current line red, only show time on this line

        yield return new WaitForSeconds(0);
        yield return new WaitForSeconds(0.21f);
        yield return new WaitForSeconds(0.15f);
        yield return new WaitForSeconds(0.18f);
        yield return new WaitForSeconds(1.68f);
        */

        yield return new WaitForSeconds(1.0f);

        m_testStatusLabel = "";
    }


    IEnumerator TestGazeCamera()
    {
        m_testStatusLabel =  "Gaze camera - all defaults\n";
        m_testStatusLabel += "<gaze target=\"Camera\" />\n";
        m_testStatusLabel += "current defaults:\n";
        m_testStatusLabel += "sbm:joint-speed 5000 5000 <head> <eyes>\n";
        m_testStatusLabel += "sbm:speed-smoothing 0.6 0.5 0.0 <lumbar> <cervical> <eyes>\n";

        string bmlString = "renderer_bml_" + GenerateBmlId();
        string xml =    @"<?xml version=""1.0"" encoding=""UTF-8""?>" + 
                        @"<act>" + 
                           @"<bml>" + 
                              @"<gaze target=""Camera"" />" + 
                           @"</bml>" + 
                        @"</act>";

        VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "Brad", bmlString, xml));
        VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "BradM", bmlString, xml));

        yield return new WaitForSeconds(2.0f);

        m_testStatusLabel = "";
    }


    IEnumerator TestSetFaceAnimationImmediate(int au, string side, float amount)
    {
        //SmartbodyManager.Get().PythonCommand(string.Format(@"scene.command('char {0} viseme au_{1} {2}')", "Brad", i, newSlider));

        // deactivate current value
        {
            string bmlString = "renderer_bml_" + GenerateBmlId();
            string xml =    @"<?xml version=""1.0"" encoding=""UTF-8""?>" + 
                            @"<act>" + 
                                @"<bml>" + 
                                    string.Format(@"<face type=""facs"" au=""{0}"" side=""{1}"" amount=""{2}"" start=""0"" ready=""0.0001"" end=""999"" />", au, "both", 0) +    // current bug in smartbody where ready has to be > 0
                                @"</bml>" + 
                            @"</act>";

            VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "Brad", bmlString, xml));
            VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "BradM", bmlString, xml));
        }

        // set value based on given amount
        {
            string bmlString = "renderer_bml_" + GenerateBmlId();
            string xml =    @"<?xml version=""1.0"" encoding=""UTF-8""?>" + 
                            @"<act>" + 
                                @"<bml>" + 
                                    string.Format(@"<face type=""facs"" au=""{0}"" side=""{1}"" amount=""{2}"" start=""0"" ready=""0.0001"" end=""999"" />", au, side, amount ) +   // current bug in smartbody where ready has to be > 0
                                @"</bml>" + 
                            @"</act>";

            VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "Brad", bmlString, xml));
            VHMsgBase.Get().SendVHMsg(string.Format("vrSpeak {0} ALL {1} {2}", "BradM", bmlString, xml));
        }

        yield break;
    }


    static string GenerateBmlId()
    {
        // needs to be unique for smartbody
        return string.Format(@"{0:yyyyMMddhhmmss_f}{1}", System.DateTime.Now, UnityEngine.Random.Range(1000, 10000));
    }
}
