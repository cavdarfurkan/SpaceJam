using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Threading.Tasks;

public class GameOverSceneButtons : MonoBehaviour
{
    public GameObject upgradesPanel;
    private Animator animator;

    private bool isActive;

    public Market market;

    // Upgrades
    private int bulletSpeed;
    private int bulletDamage;
    private int movementSpeed;
    private int healthPoints;

    private int maximumUpgradeLimit = 10;

    void Start()
    {
        this.isActive = this.upgradesPanel.activeInHierarchy;

        this.animator = upgradesPanel.GetComponent<Animator>();
    }

    public void PlayAgainButtonOnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // As well as close button onclick inside upgrades panel
    public void UpgradesButtonOnClick()
    {
        isActive = !isActive;
        upgradesPanel.SetActive(isActive);
    }

    public void BulletSpeedOnClick()
    {
        bulletSpeed = PlayerPrefs.GetInt("bulletSpeed", 0);
        if (bulletSpeed < maximumUpgradeLimit)
        {
            if (market.buy(PlayerPrefs.GetInt("bsCost")))
            {
                bulletSpeed += 1;
                PlayerPrefs.SetInt("bulletSpeed", bulletSpeed);
                market.InitAndUpdate();
            }
        }
    }

    public void BulletDamageOnClick()
    {
        bulletDamage = PlayerPrefs.GetInt("bulletDamage", 0);
        if (bulletDamage < maximumUpgradeLimit)
        {
            if (market.buy(PlayerPrefs.GetInt("bdCost")))
            {
                bulletDamage += 1;
                PlayerPrefs.SetInt("bulletDamage", bulletDamage);
                market.InitAndUpdate();
            }
        }
    }

    public void MovementSpeedOnClick()
    {
        movementSpeed = PlayerPrefs.GetInt("movementSpeed", 0);
        if (movementSpeed < maximumUpgradeLimit)
        {
            if (market.buy(PlayerPrefs.GetInt("msCost")))
            {
                movementSpeed += 1;
                PlayerPrefs.SetInt("movementSpeed", movementSpeed);
                market.InitAndUpdate();
            }
        }
    }

    public void HealthPointsOnClick()
    {
        healthPoints = PlayerPrefs.GetInt("healthPoints", 0);
        if (healthPoints < maximumUpgradeLimit)
        {
            if (market.buy(PlayerPrefs.GetInt("hpCost")))
            {
                healthPoints += 1;
                PlayerPrefs.SetInt("healthPoints", healthPoints);
                market.InitAndUpdate();
            }
        }
    }
}
