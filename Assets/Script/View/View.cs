using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour
{

    private RectTransform logoName;
    private RectTransform MenuUI;

    private RectTransform GameUI;

    private GameObject restart;

    private GameObject gameOverUI;
    private GameObject rankUI;

    public Text Score2;
    public Text highScore;

    public Text OverScore;

    public Text RankCore;
    public Text RankHighcore;
    public Text RankNumber;




    //确实做到了将试图和那个分离了啊
    //用control来控制试图的调用

    // Start is called before the first frame update
    void Awake()
    {
        logoName = transform.Find("Canvas/logoName") as RectTransform;
        MenuUI = transform.Find("Canvas/MenuUI") as RectTransform;

        GameUI = transform.Find("Canvas/GameUI") as RectTransform;

        restart = transform.Find("Canvas/MenuUI/restartButton").gameObject;


      // Score2= transform.Find("Canvas/GameUI/ScoreLabel/Text3").GetComponent<Text>();


        gameOverUI = transform.Find("Canvas/GameOverUI").gameObject;
        rankUI= transform.Find("Canvas/rankUI").gameObject;
        //   highScore = transform.Find("Canvas/GameUI/highScoreLabel/Text").GetComponent<Text>();

        Debug.Log(Score2 + "1212121" + highScore);

    }



    public void ShowMenu() {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(205f, 0.5f);

        MenuUI.gameObject.SetActive(true);
        MenuUI.DOAnchorPosY(50f, 0.5f);

    }

    public void HideMenu() {
        logoName.DOAnchorPosY(373f, 0.5f)
            .OnComplete(delegate { logoName.gameObject.SetActive(false); });
        MenuUI.DOAnchorPosY(-62f, 0.5f)
              .OnComplete(delegate { MenuUI.gameObject.SetActive(false); });

    }



    public void UpdataGameUI(int score, int highScore ) {

        this.Score2.text = score.ToString();
        this.highScore.text = highScore.ToString();


    }

    public void ShowGameUI(int score=0,int highScore=0) {

       this.Score2.text = score.ToString();
       this.highScore.text = highScore.ToString();


        GameUI.gameObject.SetActive(true);
        GameUI.DOAnchorPosY(-50.9f, 0.5f);
        
    }


    public void HideGameUI() {

        GameUI.DOAnchorPosY(65f, 0.5f)
                .OnComplete(delegate { GameUI.gameObject.SetActive(false); });

    }

    public void ShowRestartButton(){
        restart.SetActive(true);
        }



    public void ShowGameOverUI(int score) {

        gameOverUI.SetActive(true);

        OverScore.text = score.ToString();
    }


    public void HideGamoverUI() {

        gameOverUI.SetActive(false);
    }


    public void OnHomeButtonClick() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    
    }



    public void ShowRankUI(int highScore,int score,int numbersGame) {


        rankUI.SetActive(true);

        RankCore.text = score.ToString();
       RankHighcore.text = highScore.ToString();
        RankNumber.text = numbersGame.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
