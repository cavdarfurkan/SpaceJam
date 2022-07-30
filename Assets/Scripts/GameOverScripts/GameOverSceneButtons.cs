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
        if (market.buy(PlayerPrefs.GetInt("bsCost")))
        {
            bulletSpeed = PlayerPrefs.GetInt("bulletSpeed", 0);
            bulletSpeed += 1;
            PlayerPrefs.SetInt("bulletSpeed", bulletSpeed);
            market.InitAndUpdate();
        }
    }

    public void BulletDamageOnClick()
    {
        if (market.buy(PlayerPrefs.GetInt("bdCost")))
        {
            bulletDamage = PlayerPrefs.GetInt("bulletDamage", 0);
            bulletDamage += 1;
            PlayerPrefs.SetInt("bulletDamage", bulletDamage);
            market.InitAndUpdate();
        }
    }

    public void MovementSpeedOnClick()
    {
        if (market.buy(PlayerPrefs.GetInt("msCost")))
        {
            movementSpeed = PlayerPrefs.GetInt("movementSpeed", 0);
            movementSpeed += 1;
            PlayerPrefs.SetInt("movementSpeed", movementSpeed);
            market.InitAndUpdate();
        }
    }

    public void HealthPointsOnClick()
    {
        if (market.buy(PlayerPrefs.GetInt("hpCost")))
        {
            healthPoints = PlayerPrefs.GetInt("healthPoints", 0);
            healthPoints += 1;
            PlayerPrefs.SetInt("healthPoints", healthPoints);
            market.InitAndUpdate();
        }
    }
}
