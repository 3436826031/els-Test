using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menustate : FSMState
{
    // Start is called before the first frame update


    private void Awake()
    {
        stateID = StateID.Menu;

        AddTransition(Transition.StartButtonClick, StateID.Play);

    }

    //当进入这个状态的时候机会条用这个方法
    public override void DoBeforeEntering()
    {
        control.view.ShowMenu();
        control.camera2.ZoomOut();

    }

    //当离开这个状态是要做到事
    public override void DoBeforeLeaving()
    {
       
        control.view.HideMenu();

    }

    public void OnstartButtonClick() {

        fsm.PerformTransition(Transition.StartButtonClick);
    

    }





}
