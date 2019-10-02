using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class InitOliviaFace : SmartbodyFaceDefinition
{
    void Awake()
    {
        definitionName = "ChrOliviaFace";
        neutral = "ChrOlivia@face_neutral";

        //actionUnits.Add(new SmartbodyFacialExpressionDefinition(1, "both", "ChrBrad@001_inner_brow_raiser"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(1, "left", "ChrOlivia@001_InnerBrowRaiserL"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(1, "right", "ChrOlivia@001_InnerBrowRaiserR"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(2,  "both",    "ChrBrad@002_outer_brow_raiser"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(2, "left", "ChrOlivia@002_OuterBrowRaiserL"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(2, "right", "ChrOlivia@002_OuterBrowRaiserR"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(4, "both", "ChrOlivia@004_BrowLowerer"));
        //actionUnits.Add(new SmartbodyFacialExpressionDefinition(4,  "left",    "ChrBrad@004_brow_lowerer_lf"));
        //actionUnits.Add(new SmartbodyFacialExpressionDefinition(4,  "right",   "ChrBrad@004_brow_lowerer_rt"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(5, "both", "ChrOlivia@005_UpperLidRaiser"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(6, "both", "ChrOlivia@006_CheekRaiser"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(7, "both", "ChrOlivia@007_LidTightener"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(9,  "both",    "ChrBrad@009_nose_wrinkle"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(10, "both", "ChrOlivia@010_UpperLipRaiser"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(12, "both",    "ChrBrad@012_lip_corner_puller"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(12, "left", "ChrOlivia@012_LipCornerPullerL"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(12, "right", "ChrOlivia@012_LipCornerPullerR"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(15, "both",    "ChrBrad@015_lip_corner_depressor"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(23, "both",    "ChrBrad@023_lip_tightener"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(25, "both", "ChrOlivia@025_LipsPart"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(26, "both", "ChrOlivia@026_JawDrop"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(27, "both",    "ChrBrad@027_mouth_stretch"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(38, "both",    "ChrBrad@038_nostril_dilator"));
        //#actionUnits.Add(new SmartbodyFacialExpressionDefinition(45, "both",    "ChrBrad@blink"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(45, "left", "ChrOlivia@045_BlinkL"));
        actionUnits.Add(new SmartbodyFacialExpressionDefinition(45, "right", "ChrOlivia@045_BlinkR"));

        visemes.Add(new KeyValuePair<string, string>("open", "ChrOlivia@open"));
        visemes.Add(new KeyValuePair<string, string>("W", "ChrOlivia@W"));
        visemes.Add(new KeyValuePair<string, string>("ShCh", "ChrOlivia@ShCh"));
        visemes.Add(new KeyValuePair<string, string>("PBM", "ChrOlivia@PBM"));
        visemes.Add(new KeyValuePair<string, string>("FV", "ChrOlivia@FV"));
        visemes.Add(new KeyValuePair<string, string>("wide", "ChrOlivia@wide"));
        visemes.Add(new KeyValuePair<string, string>("tBack", "ChrOlivia@tBack"));
        visemes.Add(new KeyValuePair<string, string>("tRoof", "ChrOlivia@tRoof"));
        visemes.Add(new KeyValuePair<string, string>("tTeeth", "ChrOlivia@tTeeth"));
    }


    void Start()
    {
    }
}
