using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public InventoryManager inventoryManager; // InventoryManagerの参照
    public Camera camera2; // Camera2
    public float placementDistance = 100f; // 設置距離
    public float gridSize = 1f; // グリッドのサイズ
    private bool eraserMode = false; // 消しゴムモードのフラグ
    private Quaternion blockRotation; // ブロックの回転

    void Start()
    {
        blockRotation = Quaternion.identity; // 初期回転を設定
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

            // 「E」キーで消しゴムモードの切り替え
            if (Input.GetKeyDown(KeyCode.E))
            {
                eraserMode = !eraserMode;
            }

            // 「R」キーで回転を変更
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
            Vector3 normal = hit.normal;
            Vector3 position = hit.point + normal * (gridSize / 2);

            position.x = Mathf.Round(position.x / gridSize) * gridSize;
            position.y = Mathf.Round(position.y / gridSize) * gridSize;
            position.z = Mathf.Round(position.z / gridSize) * gridSize;

            // インベントリから選択されたブロックをインスタンス化
            Instantiate(inventoryManager.selectedBlock, position, blockRotation);
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
}
