using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public Camera camera2; // Camera2の参照
    public Camera camera3; // Camera3の参照

    public GameObject canvas1;
    
    public GameObject canvas3; // Canvas3の参照
    public GameObject canvas4; // Canvas4の参照


    void Start()
    {
        // 初期設定
        SwitchToCamera2(); // Camera2をデフォルトで有効に
    }

    public void SwitchToCamera2()
    {
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(false);
        canvas3.SetActive(false); // Canvas3を非表示
        canvas4.SetActive(true); // Canvas4を表示
    }

    public void SwitchToCamera3()
    {
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(true);
        canvas3.SetActive(true); // Canvas3を表示
        canvas4.SetActive(false); // Canvas4を非表示
    }
}
