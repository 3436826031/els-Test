using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager2 : MonoBehaviour
{

    private Camera mainCamera;



    // Start is called before the first frame update
    void Start()
    {

       
        
    }


    private void Awake()
    {

        mainCamera = Camera.main;


    }


    public void ZoomIn() {

        mainCamera.DOOrthoSize(13.62f,0.5f);

    }


    public void ZoomOut() {

        mainCamera.DOOrthoSize(17f,0.5f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
