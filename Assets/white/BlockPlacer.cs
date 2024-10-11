using UnityEngine;
using UnityEngine.UI; // UIを使用するために追加

public class BlockPlacer : MonoBehaviour
{
    public InventoryManager inventoryManager; // InventoryManagerの参照
    public Camera camera2; // Camera2
    public float placementDistance = 100f; // 設置距離
    public float gridSize = 1.0f; // グリッドのサイズ
    private bool eraserMode = false; // 消しゴムモードのフラグ
    private Quaternion blockRotation; // ブロックの回転
    public GameObject Eraser; // 消しゴムの表示
    public Text messageText; // メッセージ表示用のTextオブジェクト

    void Start()
    {
        blockRotation = Quaternion.identity; // 初期回転を設定
        Eraser.gameObject.SetActive(false);
        messageText.gameObject.SetActive(false); // 初期は非表示
    }

    void Update()
    {
        if (camera2.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (eraserMode)
                {
                    RemoveBlock();
                }
                else
                {
                    PlaceBlock();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                eraserMode = !eraserMode;
                Eraser.gameObject.SetActive(eraserMode);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateBlock();
            }
        }
    }

    void PlaceBlock()
    {
        Ray ray = camera2.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, placementDistance))
        {
            // ヒットしたオブジェクトのタグをチェック
            if (hit.collider.CompareTag("Block") || hit.collider.CompareTag("Basic"))
            {
                // 選択されたブロックがない場合
                if (inventoryManager.selectedBlock == null)
                {
                    ShowMessage("インベントリからブロックを選択してください！"); // メッセージを表示
                    return; // 処理を終了
                }

                Vector3 normal = hit.normal;
                Vector3 position = hit.point + normal * (gridSize / 2);

                position.x = Mathf.Round(position.x / gridSize) * gridSize;
                position.y = Mathf.Round(position.y / gridSize) * gridSize;
                position.z = Mathf.Round(position.z / gridSize) * gridSize;

                // インベントリから選択されたブロックをインスタンス化
                Instantiate(inventoryManager.selectedBlock, position, blockRotation);
            }
        }
    }

    void RemoveBlock()
    {
        Ray ray = camera2.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, placementDistance))
        {
            if (hit.collider.CompareTag("Block"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    void RotateBlock()
    {
        blockRotation *= Quaternion.Euler(0, 90, 0); // Y軸を中心に90度回転
    }

    void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        Invoke("HideMessage", 2f); // 2秒後にメッセージを非表示に
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}
