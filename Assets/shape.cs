using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shape : MonoBehaviour
{


    private Transform pivot;

    private Control control;


    public bool isPause;
    public float timer = 0;
    private float stepTime = 0.8f;

    private int multiple = 15;//加速的倍速

    private bool isSpeedup;

    private GameManager2 gameManager2;

    // Start is called before the first frame update

    private void Awake()
    {

        pivot = transform.Find("pivot");


    }


    void Start()
    {
        
    }

    // Update is called once perframe
    void Update()
    {
        if (isPause)return;//isPause暂停

        timer += Time.deltaTime;//时间戳，每0.8s执行一次
        if (timer > stepTime) {
            timer = 0;
            Fall();//下落方法

          
        }

        InputControl();

    }


   


    public void init(Color color,Control control,GameManager2 gameMan) {


        foreach (Transform t in transform) {

            if (t.tag == "Block") {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.control = control;
        this.gameManager2 = gameMan;


    }



    /**
     * 下落
     */
    void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 1f;
        transform.position = pos;


        //判断有没有物体，通过Model类来判断
        if (control.model.IsValidMapPosition(this.transform) == false)
        {
            //如果有物体了
            pos.y += 1;
            transform.position = pos;
            isPause = true;
            Debug.Log("这里呢");
           // bool isLineclear = control.model.PlaceShape(this.transform);
            

            control.model.PlaceShape(this.transform);//停止之后，让他变成map二维数组的一部分
            gameManager2.FallDown();//curr重置为null，让他重新生成方块
        }



    }



    private void InputControl() {



     //   if (isSpeedup) return;


        // float h = Input.GetAxisRaw("Horizontal");
        float h = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {

            h = 1;
        }




        if (h != 0) {

            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;
            if (control.model.IsValidMapPosition(this.transform) == false) {
                pos.x -= h;
                transform.position = pos;
            
            }
        

        
        
        }


        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            transform.RotateAround(pivot.position,Vector3.forward,90);

            if (control.model.IsValidMapPosition(this.transform) == false) {

                transform.RotateAround(pivot.position, Vector3.forward, -90);
            }

        
        }



        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            isSpeedup = true;
            stepTime = stepTime / multiple;

        }



    
    }




   

    public void Pause() {

        isPause = true;
    }

    public void resume() {

        isPause = false;
    
    }

}
