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
    private int score;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

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
    }

    // TODO: With leveling up, add new enemy types, by killing count accelerate the meteor speeds in game
    // From market system, player can upgrade the ship with coins such as increasing shooting range, damage, bullet speed.
    // From skill system, player can open up new skills with coin.
}
