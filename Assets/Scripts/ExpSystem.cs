using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    public XpBar xpBar;
    public Player player;

    public int level;
    public int maxXp;
    public int currentXp;

    private void Start()
    {
        level = 1;
        currentXp = 0;
        maxXp = 10 * level;

        xpBar.SetMaxValueXpBar(maxXp);
        xpBar.SetValueXpBar(currentXp);
    }

    public void GrantXp(int xp)
    {
        currentXp += xp;
        xpBar.SetValueXpBar(currentXp);

        if(currentXp >= maxXp)
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

        player.FullHeal();
    }

    // TODO: With leveling up, add new enemy types, by killing count accelerate the meteor speeds in game
    // From market system, player can upgrade the ship with coins such as increasing shooting range, damage, bullet speed.
    // From skill system, player can open up new skills with coin.
}
