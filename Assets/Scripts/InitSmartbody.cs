using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections;

public class InitSmartbody : SmartbodyInit
{
    void Awake()
    {
        PostLoadEvent += delegate {
            SmartbodyManager.Get().PythonCommand(string.Format(@"scene.getCollisionManager().setStringAttribute('collisionResolutionType', 'default')"));
            SmartbodyManager.Get().PythonCommand(string.Format(@"scene.getCollisionManager().setBoolAttribute('singleChrCapsuleMode', True)"));
        };
    }

    void Start()
    {
    }
}
