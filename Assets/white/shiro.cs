using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonSelector : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform gridParent;
    public int gridSize = 10;
    private HashSet<string> selectedButtons = new HashSet<string>();

    private void Start()
    {
        CreateButtons();
    }

    private void CreateButtons()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject button = Instantiate(buttonPrefab, gridParent);
                string buttonID = $"btn_{x}_{y}";
                button.GetComponentInChildren<Text>().text = buttonID;
                button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(buttonID));
            }
        }
    }

    private void OnButtonClick(string buttonID)
    {
        Button button = FindButtonById(buttonID);
        if (button != null)
        {
            if (selectedButtons.Contains(buttonID))
            {
                button.GetComponent<Image>().color = Color.grey;
                selectedButtons.Remove(buttonID);
            }
            else
            {
                button.GetComponent<Image>().color = Color.red;
                selectedButtons.Add(buttonID);
            }

            Debug.Log($"Selected Buttons: {string.Join(", ", selectedButtons)}");
        }
    }

    private Button FindButtonById(string buttonID)
    {
        foreach (Button button in gridParent.GetComponentsInChildren<Button>())
        {
            if (button.GetComponentInChildren<Text>().text == buttonID)
                return button;
        }
        return null;
    }
}
