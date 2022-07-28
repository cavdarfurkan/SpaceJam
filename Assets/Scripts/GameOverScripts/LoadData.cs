using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadData : MonoBehaviour
{
    [SerializeField] private Text goldsText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hiScoreText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text hiLevelText;

    private int level;
    private int hiLevel;
    private int score;
    private int hiScore;
    private int golds;

    void OnEnable()
    {
        editUi();
    }

    void Start()
    {

    }

    private async void editUi()
    {
        await loadData();
        scoreText.text = "Score: " + score;
        hiScoreText.text = "Highest Score: " + hiScore;
        levelText.text = "Level: " + level;
        hiLevelText.text = "Highest Level: " + hiLevel;

        await calculateAndSaveGold();
        goldsText.text = "Golds: " + golds;
    }

    private async Task loadData()
    {
        level = PlayerPrefs.GetInt("level", 1);
        hiLevel = PlayerPrefs.GetInt("levelHi", 1);
        score = PlayerPrefs.GetInt("score", 0);
        hiScore = PlayerPrefs.GetInt("scoreHi", 0);
        await Task.Yield();
    }

    private async Task calculateAndSaveGold()
    {
        golds = PlayerPrefs.GetInt("golds", 0);
        golds += (score / 10);
        PlayerPrefs.SetInt("golds", golds);
        await Task.Yield();
    }
}
