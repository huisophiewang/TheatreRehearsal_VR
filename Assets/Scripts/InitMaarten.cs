using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class InitMaarten: SmartbodyCharacterInit
{
    protected override void Awake()
    {
        base.Awake();

        unityBoneParent = "ChrMaarten/CharacterRoot/JtRoot";
        //assetPaths.Add(new KeyValuePair<string, string>("ChrBrad.sk", "Art/Characters/SB/ChrBrad/sk"));
        //assetPaths.Add(new KeyValuePair<string, string>("ChrBrad.sk", "Art/Characters/SB/ChrBrad/face"));
        //assetPaths.Add(new KeyValuePair<string, string>("ChrBrad.sk", "Art/Characters/SB/ChrBrad/locomotion"));
        //assetPaths.Add(new KeyValuePair<string, string>("ChrBrad.sk", "Art/Characters/SB/ChrBrad/motion"));
        //assetPaths.Add(new KeyValuePair<string, string>("ChrBrad.sk", "Art/Characters/SB/ChrBrad/motion-converted"));
        skeletonName = "ChrMaarten.sk";
        loadSkeletonFromSk = false;
        voiceType = "remote_audiofile";
        voiceCode = VHUtils.GetExternalAssetsPath() + "Sounds";
        voiceTypeBackup = "remote";
        voiceCodeBackup = "Festival_voice_rab_diphone";
        usePhoneBigram = false;
        startingPosture = "ChrBrad@Idle01";

     


        PostLoadEvent += delegate(UnitySmartbodyCharacter character)
            {
                SmartbodyManager.Get().PythonCommand(string.Format(@"bml.execBML('{0}', '<gaze target=""ReachSphere8"" sbm:joint-range=""HEAD NECK EYES""/>')", character.SBMCharacterName));
                SmartbodyManager.Get().PythonCommand(string.Format(@"bml.execBML('{0}', '<saccade mode=""talk""/>')", character.SBMCharacterName));
                //SmartbodyManager.Get().PythonCommand(string.Format(@"scene.getCharacter('{0}').setStringAttribute('saccadePolicy', 'alwayson')", character.SBMCharacterName));
                //SmartbodyManager.Get().PythonCommand(string.Format(@"scene.getCharacter('{0}').setBoolAttribute('bmlRequestUsesPolling', False)", character.SBMCharacterName));

                
            };
    }


    protected override void Start()
    {
        base.Start();
    }
}
