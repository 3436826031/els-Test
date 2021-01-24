using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausestate : FSMState
{
    private void Awake()
    {
        stateID = StateID.Pause;


    }


    public override void DoBeforeEntering()
    {
        Debug.Log("为啥没执行最高类");
        control.view.ShowMenu();
        control.camera2.ZoomOut();

    }




}
