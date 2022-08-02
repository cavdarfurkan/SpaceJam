using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public XpBar xpBar;
    public Player player;

    public int level;
    public int maxXp;
    public int currentXp;
    public int score;

    private float score2 = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    public SpawnMeteors spawnMeteors;

    private void Start()
    {
        score = 0;
        level = 1;
        currentXp = 0;
        maxXp = 10 * level;

        xpBar.SetMaxValueXpBar(maxXp);
        xpBar.SetValueXpBar(currentXp);

        levelText.text = "Lv." + level;
        scoreText.text = score.ToString();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("score", score);

        compareHighestValues();
    }

    private void compareHighestValues()
    {
        if (PlayerPrefs.GetInt("level") > PlayerPrefs.GetInt("levelHi", 1))
        {
            PlayerPrefs.SetInt("levelHi", PlayerPrefs.GetInt("level"));
        }

        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("scoreHi", 0))
        {
            PlayerPrefs.SetInt("scoreHi", PlayerPrefs.GetInt("score"));
        }
    }

    public void GrantXp(int xp)
    {
        currentXp += xp;
        xpBar.SetValueXpBar(currentXp);

        if (currentXp >= maxXp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXp = 0;
        maxXp = 10 * level;

        xpBar.SetValueXpBar(currentXp);
        xpBar.SetMaxValueXpBar(maxXp);

        levelText.text = "Lv." + level;

        player.FullHeal();
    }

    public void setScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();

        score2 += scorePoints;
        spawnMeteors.smallMeteorSpawnSpeed = 2.0f - (score2 >= 175 ? (175.0f/100.0f) : (score2/100.0f));
        spawnMeteors.largeMeteorSpawnSpeed = 6.0f - (score2 >= 575 ? (575.0f/100.0f) : (score2/100.0f));
    }
}
