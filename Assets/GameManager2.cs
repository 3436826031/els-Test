using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPause=true;

    private shape currentShape=null;
    public shape[] shapes;
    public Color[] colors;

    public Control control;

    public Transform blockHode;

    private void Awake()
    {

        blockHode = transform.Find("BlockHode");
        control = GetComponent<Control>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)  return;

        if (currentShape == null) {
            SpawnShape();
        }


    }


    public void SpawnShape() {


        //生成随机数组
        int index = Random.Range(0, shapes.Length);

        int indexColor = Random.Range(0, colors.Length);

        shape shape = GameObject.Instantiate(shapes[index]);
        shape.transform.parent = blockHode;

        shape.init(colors[indexColor],control,this);

        currentShape = shape;


    }


    public void StartGame() {

        isPause = false;
        if (currentShape != null) {
            currentShape.resume();
        }

    }

    public void PauseGame() {
        isPause = true;
        if (currentShape != null)
            currentShape.Pause();
    }


    public void FallDown() {
        currentShape = null;
        Debug.Log("重新生成");

        if (control.model.isDataUpData) {
            control.view.UpdataGameUI(control.model.Score,control.model.HighScore);
        }


        if (control.model.isGameOver()) {

            PauseGame();
            control.view.ShowGameOverUI(control.model.Score);
        
        }
    
    }


}
