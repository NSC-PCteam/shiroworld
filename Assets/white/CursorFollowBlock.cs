using UnityEngine;

public class CursorFollowBlock : MonoBehaviour
{
    public GameObject blockPrefab;  // プレビュー用のブロック
    public LayerMask placementLayer; // ブロックを配置するレイヤー
    public float gridSize = 1.0f;    // グリッドのサイズ
    public Camera Camera2;
    private GameObject previewBlock; // プレビュー用のブロック

    void Start()
    {
        // プレビュー用のブロックを生成
        previewBlock = Instantiate(blockPrefab);
        previewBlock.SetActive(false); // 初期状態では非表示
    }

    void Update()
    {
        // マウスの位置を取得
        Ray ray = Camera2.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, placementLayer))
        {
            // ヒットした位置を取得
            Vector3 hitPosition = hit.point;
            Vector3 gridPosition = new Vector3(
                Mathf.Round(hitPosition.x / gridSize) * gridSize,
                hitPosition.y, // 高さはそのまま
                Mathf.Round(hitPosition.z / gridSize) * gridSize
            );

            // プレビュー用のブロックを更新
            previewBlock.transform.position = gridPosition;
            previewBlock.SetActive(true);
        }
        else
        {
            // 何もヒットしない場合はプレビューを非表示
            previewBlock.SetActive(false);
        }
    }
}
