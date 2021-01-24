using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{


    /**
     * 
     * 基本逻辑：将地图组件，具象为一个Transform类型的二维数组
     * 通过存放具体的Transfrom来判断这个位置到底有没有东西。
     * 
     * 
     */
    // Start is called before the first frame update

    public const int MAX_ROWS = 23;
    public const int MAX_COLUMS = 10;

    public const int NORMAL_ROWS = 20;
    
    private Transform[,] map = new Transform[MAX_COLUMS, MAX_ROWS];

    

    private int score = 0;
    private int highScore=0;
    private int numberGame = 0;

    public int Score { get { return score; } }
    public int HighScore { get { return highScore; } }
    public int NumberGame { get { return numberGame; } }



    public bool isDataUpData;



    private void Awake()
    {

        loadGame();//加载数据

    }


    //判断有没有占用位置
    //循环输入Transfor
    public bool IsValidMapPosition(Transform t) {

        //通过方块的脚本Shape将本身的Transfrom坐标信息传入

        foreach (Transform child in t) {
            //如果不是Block标签就跳过，遍历所有的脚本信息
            if (child.tag != "Block") continue;

            Vector2 pos = child.position.Round();//转换为二维坐标

            if (IsInsideMap(pos) == false) return false;
            if (map[(int)pos.x, (int)pos.y] != null) return false;  //用二维数组判断是否用物体

        }

        return true;

   

    }



    public bool isGameOver() {

        for (int i = NORMAL_ROWS; i < MAX_ROWS; i++) {

            for (int j = 0; j < MAX_COLUMS; j++) {


                if (map[j, i] != null)
                {
                    numberGame++;
                    SaveData();
                    return true;

                }
                 



            }
        }


        return false;
    }

    private bool IsInsideMap(Vector2 pos) {
        return pos.x >= 0 && pos.x < MAX_COLUMS && pos.y >= 0;
    }



    public void PlaceShape(Transform t) {

        foreach (Transform child in t) {

            if (child.tag != "Block") continue;


            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
        CheckMap();
    
    }

    //检查地图是否要消除行
    public bool CheckMap() {

        int count = 0;

        for (int i = 0; i < MAX_ROWS; i++) {
            //满了一行
            if (CheckIsRowFull(i)){
                //消除行
                count++;
                DeleteRow(i);
                 MoveDownRowsAbove(i+1);
                i--;
            }

        
        }



        if (count > 0)
        {
            score += (count * 100);
            if (score > highScore)
            {
                highScore = score;
                isDataUpData = true;
            }
            return true;
        }
        else return false;

    
    
    }


    public bool CheckIsRowFull(int row) {

        for (int i = 0; i < MAX_COLUMS; i++) {

            if (map[i, row] == null) return false;
        }
        return true;

    }


    public void DeleteRow(int row) {

        for (int i = 0; i < MAX_COLUMS; i++) {
            Destroy(map[i, row].gameObject);//销毁物体·
            map[i, row] = null;
          
        }


    }


    //吧上面的移动到下面

    public void MoveDownRowsAbove(int row) {

        for (int i = row; i < MAX_ROWS; i++) {
            MoveDownRow(i);
           
          
        }
    
    
    }


    private void MoveDownRow(int row) {
        for (int i = 0; i < MAX_COLUMS; i++) {
            if (map[i, row] != null) {
                map[i, row - 1] = map[i, row];
                map[i, row] = null;
                map[i, row - 1].position += new Vector3(0, -1, 0);
                Debug.Log("这儿能不能运行类");
            }


        }
    
    
    }



    private void loadGame() {

      highScore=  PlayerPrefs.GetInt("HighScore", highScore);
      numberGame=  PlayerPrefs.GetInt("NumberGame", numberGame);


    }

    private void SaveData() {

        PlayerPrefs.SetInt("HighScore",highScore);
        PlayerPrefs.SetInt("NumberGame", numberGame);


    
    }




    public void Restart() {

        for (int i = 0; i < MAX_COLUMS; i++) {

            for (int j = 0; j < MAX_ROWS; j++) {

                if (map[i, j] != null) {

                    Destroy(map[i, j].gameObject);
                    map[i, j] = null;

                }
            }
        }
        score = 0;


    }



}
