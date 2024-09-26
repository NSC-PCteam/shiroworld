using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    public Button Camerabutton;

    public GameObject Canvas1;

    public GameObject Canvas2;
    

    void Start () {

        //初めはカメラ2をオフにしておく
        Camera2.enabled = false;

        bool isActive = true;

        Camerabutton.onClick.AddListener(() =>
        {
            isActive = !isActive;
            Canvas2.SetActive(isActive);
        });
    }

    void Update () {

    }

    public void PushButton()
    {
        //もしカメラ2がオフだったら
        if (!Camera2.enabled)
        {
            //カメラ2をオンにして
            Camera2.enabled = true;

            //カメラをオフにする
            Camera1.enabled = false;

            //キャンバスを映すカメラをカメラ2オブジェクトにする
            Canvas1.GetComponent<Canvas>().worldCamera = Camera2;
        }
        //もしカメラ2がオンだったら
        else
        {
            //カメラ2をオフにして
            Camera2.enabled = false;

            //カメラ1をオンにする
            Camera1.enabled = true;

            //キャンバスを映すカメラをカメラ1オブジェクトにする
            Canvas1.GetComponent<Canvas>().worldCamera = Camera1;
        }
    }
}