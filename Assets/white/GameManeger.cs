using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera camera1; // カメラ1
    public Camera camera2; // カメラ2
    public Camera camera3; // カメラ3
    public Camera camera4; // カメラ4
    public Camera camera5; // カメラ5
    public GameObject canvas1; // キャンバス1
    
    public GameObject canvas3; // キャンバス3
    public GameObject canvas4; // キャンバス4
    public GameObject canvas5; // キャンバス5

    public Button switchToCamera2Button; // Camera2に切り替えるボタン
    public Button switchToCamera3Button; // Camera3に切り替えるボタン
    public Button reswitchToCamera2Button; // Camera2に戻るボタン
    public Button switchToCamera4Button; // Camera4に切り替えるボタン
    public Button reswitchToCamera1Button1; // Camera4からCamera1に戻るボタン
    public Button reswitchToCamera1Button2; // Camera2からCamera1に戻るボタン
    public Button finishbutton; // Camera2からCamera5に切り替えるボタン



    void Start()
    {
        // 初期設定
        SwitchToCamera1(); // Camera1をデフォルトで有効に

        // ボタンにリスナーを追加
        switchToCamera2Button.onClick.AddListener(SwitchToCamera2);
        switchToCamera3Button.onClick.AddListener(SwitchToCamera3);
        reswitchToCamera2Button.onClick.AddListener(ReswitchToCamera2);
        switchToCamera4Button.onClick.AddListener(SwitchToCamera4);
        reswitchToCamera1Button1.onClick.AddListener(ReswitchToCamera1No1);
        reswitchToCamera1Button2.onClick.AddListener(ReswitchToCamera1No2);
        finishbutton.onClick.AddListener(FinishButton);
    }

    public void SwitchToCamera1()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(false); // Canvas4を非表示
        canvas1.SetActive(true); // Canvas1を表示
        canvas5.SetActive(false); // Canvas5を非表示
    }

    public void SwitchToCamera2()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(true); // Canvas4を表示
        canvas1.SetActive(false); // Canvas1を非表示
        
        canvas5.SetActive(false); // Canvas5を非表示
    }

    public void SwitchToCamera3()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(true);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(true); // Canvas3を表示
        canvas4.SetActive(false); // Canvas4を非表示
        canvas1.SetActive(false); // Canvas1を非表示
        
        canvas5.SetActive(false); // Canvas5を非表示
    }

    public void ReswitchToCamera2()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(true); // Canvas4を表示
        canvas1.SetActive(false); // Canvas1を非表示
        
        canvas5.SetActive(false); // Canvas5を非表示
    }
    public void SwitchToCamera4()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(true);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(false); // Canvas4を表示
        canvas1.SetActive(false); // Canvas1を非表示
        
        canvas5.SetActive(true); // Canvas5を表示
    }
    public void ReswitchToCamera1No1()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(false); // Canvas4を表示
        canvas1.SetActive(true); // Canvas1を表示
        
        canvas5.SetActive(false); // Canvas5を非表示
    }
    public void ReswitchToCamera1No2()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(false); // Canvas4を非表示
        canvas1.SetActive(true); // Canvas1を表示
        
        canvas5.SetActive(false); // Canvas5を非表示
    }
    public void FinishButton()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera5.gameObject.SetActive(true);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(false); // Canvas4を非表示
        canvas1.SetActive(false); // Canvas1を非表示
        canvas5.SetActive(false); // Canvas5を非表示
    }
}