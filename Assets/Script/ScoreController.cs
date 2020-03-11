using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    int score;
    TextMeshProUGUI tmPro;
    private void Awake()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore()
    {
        score += 10;
        RefreshUI();
    }

    private void RefreshUI()
    {
        tmPro.text = "Score :" + score;
    }
}
