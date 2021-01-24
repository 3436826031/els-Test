using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{



    [HideInInspector]
    public View view;
    [HideInInspector]
    public Model model;

    public CameraManager2 camera2;
    public GameManager2 gameManager2;


    private FSMSystem fsm;

    // Start is called before the first frame update

    private void Awake()
    {
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();

        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();

        camera2 = GetComponent<CameraManager2>();
        gameManager2 = GetComponent<GameManager2>();
    }


    private void Start()
    {
        MakeFSM();
    }

    void MakeFSM() {
        fsm = new FSMSystem();

      FSMState[] states=  GetComponentsInChildren<FSMState>();

        //遍历讲状态添加到FSMSystem中

        foreach (FSMState state in states) {
            fsm.AddState(state,this);
        }



        //设置默认状态
        Menustate s = GetComponentInChildren<Menustate>();
        fsm.setCurrentState(s);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
