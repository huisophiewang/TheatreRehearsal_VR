using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class InitBradGestureMap : SmartbodyGestureMapDefinition
{
    void Awake()
    {
        gestureMapName = "BradGesture";

        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_YouLf01",           "DEICTIC", "YOU",   "LEFT_HAND",  "", "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_YouLf01",           "DEICTIC", "YOU",   "LEFT_HAND",  "", "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_YouLf01",           "DEICTIC", "YOU",   "LEFT_HAND",  "", "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_MeLf01",            "DEICTIC", "ME",    "LEFT_HAND",  "", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_MeRt01",            "DEICTIC", "ME",    "RIGHT_HAND", "", "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_MeLf01",            "DEICTIC", "ME",    "LEFT_HAND",  "", "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_IndicateLeftLf01",  "DEICTIC", "LEFT",  "LEFT_HAND",  "", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_IndicateLeftBt01",  "DEICTIC", "LEFT",  "BOTH_HANDS", "", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_IndicateRightRt01", "DEICTIC", "RIGHT", "RIGHT_HAND", "", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_IndicateRightBt01", "DEICTIC", "RIGHT", "BOTH_HANDS", "", "ChrBrad@Idle01"));

        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_NegativeBt01", "METAPHORIC", "NEGATION",    "BOTH_HANDS", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_NegativeRt01", "METAPHORIC", "NEGATION",    "RIGHT_HAND", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_NegativeBt01", "METAPHORIC", "NEGATION",    "BOTH_HANDS", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_NegativeRt01", "METAPHORIC", "NEGATION",    "RIGHT_HAND", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_NegativeBt01", "METAPHORIC", "NEGATION",    "BOTH_HANDS", "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_NegativeRt01", "METAPHORIC", "NEGATION",    "RIGHT_HAND", "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_HoweverLf01",  "METAPHORIC", "CONTRAST",    "LEFT_HAND",  "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_Shrug01",      "METAPHORIC", "CONTRAST",    "BOTH_HANDS", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_Shrug01",      "METAPHORIC", "CONTRAST",    "BOTH_HANDS", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_Shrug01",      "METAPHORIC", "CONTRAST",    "BOTH_HANDS", "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_PleaBt02",     "METAPHORIC", "ASSUMPTION",  "BOTH_HANDS", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_PleaBt01",     "METAPHORIC", "ASSUMPTION",  "BOTH_HANDS", "open",       "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_PleaBt02",     "METAPHORIC", "ASSUMPTION",  "BOTH_HANDS", "tight",      "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_PleaBt01",     "METAPHORIC", "ASSUMPTION",  "BOTH_HANDS", "open",       "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_PleaBt02",     "METAPHORIC", "ASSUMPTION",  "BOTH_HANDS", "tight",      "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf01",  "METAPHORIC", "RHETORICAL",  "LEFT_HAND",  "noheadtilt", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf02",  "METAPHORIC", "RHETORICAL",  "LEFT_HAND",  "headtilt",   "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowRt01",  "METAPHORIC", "RHETORICAL",  "RIGHT_HAND", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatLowLf01",  "METAPHORIC", "RHETORICAL",  "LEFT_HAND",  "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatLowRt01",  "METAPHORIC", "RHETORICAL",  "RIGHT_HAND", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatLowLf01",  "METAPHORIC", "RHETORICAL",  "LEFT_HAND",  "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatLowRt01",  "METAPHORIC", "RHETORICAL",  "RIGHT_HAND", "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatMidBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "mid",        "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "low",        "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatMidBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "mid",        "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatLowBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "low",        "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatMidBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "mid",        "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatLowBt01",  "METAPHORIC", "INCLUSIVITY", "BOTH_HANDS", "low",        "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf01",  "METAPHORIC", "QUESTION",    "LEFT_HAND",  "noheadtilt", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf02",  "METAPHORIC", "QUESTION",    "LEFT_HAND",  "headtilt",   "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowRt01",  "METAPHORIC", "QUESTION",    "RIGHT_HAND", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatLowLf01",  "METAPHORIC", "QUESTION",    "LEFT_HAND",  "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_BeatLowRt01",  "METAPHORIC", "QUESTION",    "RIGHT_HAND", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatLowLf01",  "METAPHORIC", "QUESTION",    "LEFT_HAND",  "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_BeatLowRt01",  "METAPHORIC", "QUESTION",    "RIGHT_HAND", "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_ChopLf01",     "METAPHORIC", "OBLIGATION",  "LEFT_HAND",  "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_ChopBt01",     "METAPHORIC", "OBLIGATION",  "BOTH_HANDS", "",           "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_ChopLf01",     "METAPHORIC", "OBLIGATION",  "LEFT_HAND",  "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle02_ChopBt01",     "METAPHORIC", "OBLIGATION",  "BOTH_HANDS", "",           "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_ChopLf01",     "METAPHORIC", "OBLIGATION",  "LEFT_HAND",  "",           "ChrBrad@Idle03"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle03_ChopBt01",     "METAPHORIC", "OBLIGATION",  "BOTH_HANDS", "",           "ChrBrad@Idle03"));

        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf01", "EMBLEM", "GREETING", "LEFT_HAND", "", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf02", "EMBLEM", "GREETING", "LEFT_HAND", "", "ChrBrad@Idle02"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_BeatLowLf03", "EMBLEM", "GREETING", "LEFT_HAND", "", "ChrBrad@Idle03"));

        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_Contemplate01", "ADAPTOR", "CONTEMPLATE", "BOTH_HANDS", "mid", "ChrBrad@Idle01"));
        gestureMaps.Add(new SmartbodyGestureMap("ChrBrad@Idle01_Think01",       "ADAPTOR", "CONTEMPLATE", "BOTH_HANDS", "low", "ChrBrad@Idle01"));
    }


    void Start()
    {
    }
}
