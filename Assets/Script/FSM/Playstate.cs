using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playstate : FSMState
{

    private void Awake()
    {
        stateID = StateID.Play;

        AddTransition(Transition.PauseButtonClick, StateID.Pause);


    }


    


    public override void DoBeforeEntering()
    {
        control.view.ShowGameUI(control.model.Score,control.model.HighScore);
        control.camera2.ZoomIn();
        control.gameManager2.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        control.view.HideGameUI();
        control.view.ShowRestartButton();
        control.gameManager2.PauseGame();
    }

    public void OnPauseButtonClick() {
        fsm.PerformTransition(Transition.PauseButtonClick);
        control.view.HideGameUI();

    }



    public void OnReStartButtonOnclick() {

        control.view.HideGamoverUI();
        control.model.Restart();
        control.gameManager2.StartGame();

        control.view.UpdataGameUI(0, control.model.HighScore);
    
    }




}
