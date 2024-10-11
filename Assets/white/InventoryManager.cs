using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 選択できるブロックのプレハブ
    public GameObject selectedBlock; // 現在選択されているブロック
    public Button[] blockButtons; // ブロック選択用のボタン

    void Start()
    {   
        // 各ボタンにイベントを登録
        for (int i = 0; i < blockButtons.Length; i++)
        {
            int index = i; // スコープを保持するためにローカル変数を作成
            blockButtons[i].onClick.AddListener(() => SelectBlock(index));
        }

        // 最初のブロックを選択
        if (blockPrefabs.Length > 0) // プレハブが存在するか確認
        {
            SelectBlock(0);
        }
    }

    // ブロックを選択するメソッド
    private void SelectBlock(int index)
    {
        if (index >= 0 && index < blockPrefabs.Length)
        {
            selectedBlock = blockPrefabs[index]; // 選択されたブロックを設定
        }
    }
}
