using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadData : MonoBehaviour
{
    // GameOver Scene Texts
    [SerializeField] private Text goldsText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hiScoreText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text hiLevelText;

    // Upgrades Panel Texts
    [Header("Upgrades Panel Texts")]
    [SerializeField] private Text upgradeGoldsText;
    [SerializeField] private Text upgradeBulletSpeedText;
    [SerializeField] private Text upgradeBulletDamageText;
    [SerializeField] private Text upgradeMovementSpeedText;
    [SerializeField] private Text upgradeHealthPointText;
    [SerializeField] private Text upgradeBulletRateText;

    [Header("Costs Texts")]
    [SerializeField] private Text upgradeBulletSpeedCostText;
    [SerializeField] private Text upgradeBulletDamageCostText;
    [SerializeField] private Text upgradeMovementSpeedCostText;
    [SerializeField] private Text upgradeHealthPointCostText;
    [SerializeField] private Text upgradeBulletRateCostText;

    private int level;
    private int hiLevel;
    private int score;
    private int hiScore;
    private int golds;

    // Upgrades
    private int bulletSpeed;
    private int bulletDamage;
    private int movementSpeed;
    private int healthPoints;
    private int bulletRate;

    // Upgrades Costs
    private int bulletSpeedCost;
    private int bulletDamageCost;
    private int movementSpeedCost;
    private int healthPointsCost;
    private int bulletRateCost;

    [Header("Market Script")]
    public Market market;

    void OnEnable()
    {
        updateUi();
    }

    public async void updateUi()
    {
        await loadData();
        scoreText.text = "Score: " + score;
        hiScoreText.text = "Highest Score: " + hiScore;
        levelText.text = "Level: " + level;
        hiLevelText.text = "Highest Level: " + hiLevel;

        await calculateAndSaveGold();
        goldsText.text = "Golds: " + golds;

        await loadUpgrades();
        upgradeGoldsText.text = "Golds: " + golds;
        upgradeBulletSpeedText.text = "Bullet Speed: " + bulletSpeed;
        upgradeBulletDamageText.text = "Bullet Damage: " + bulletDamage;
        upgradeMovementSpeedText.text = "Movement Speed: " + movementSpeed;
        upgradeHealthPointText.text = "Health Points: " + healthPoints;
        upgradeBulletRateText.text = "Bullet Rate: " + bulletRate;

        await loadCosts();
        upgradeBulletSpeedCostText.text = "Cost: " + bulletSpeedCost;
        upgradeBulletDamageCostText.text = "Cost: " + bulletDamageCost;
        upgradeMovementSpeedCostText.text = "Cost: " + movementSpeedCost;
        upgradeHealthPointCostText.text = "Cost: " + healthPointsCost;
        upgradeBulletRateCostText.text = "Cost: " + bulletRateCost;
    }

    public async void updateUiWithoutGold()
    {
        await loadData();
        scoreText.text = "Score: " + score;
        hiScoreText.text = "Highest Score: " + hiScore;
        levelText.text = "Level: " + level;
        hiLevelText.text = "Highest Level: " + hiLevel;

        goldsText.text = "Golds: " + PlayerPrefs.GetInt("golds", 0);

        await loadUpgrades();
        upgradeGoldsText.text = "Golds: " + PlayerPrefs.GetInt("golds", 0);
        upgradeBulletSpeedText.text = "Bullet Speed: " + bulletSpeed;
        upgradeBulletDamageText.text = "Bullet Damage: " + bulletDamage;
        upgradeMovementSpeedText.text = "Movement Speed: " + movementSpeed;
        upgradeHealthPointText.text = "Health Points: " + healthPoints;
        upgradeBulletRateText.text = "Bullet Rate: " + bulletRate;

        await loadCosts();
        upgradeBulletSpeedCostText.text = "Cost: " + bulletSpeedCost;
        upgradeBulletDamageCostText.text = "Cost: " + bulletDamageCost;
        upgradeMovementSpeedCostText.text = "Cost: " + movementSpeedCost;
        upgradeHealthPointCostText.text = "Cost: " + healthPointsCost;
        upgradeBulletRateCostText.text = "Cost: " + bulletRateCost;
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
        golds += (level > 1 ? level : 0);
        PlayerPrefs.SetInt("golds", golds);
        await Task.Yield();
    }

    private async Task loadUpgrades()
    {
        bulletSpeed = PlayerPrefs.GetInt("bulletSpeed", 0);
        bulletDamage = PlayerPrefs.GetInt("bulletDamage", 0);
        movementSpeed = PlayerPrefs.GetInt("movementSpeed", 0);
        healthPoints = PlayerPrefs.GetInt("healthPoints", 0);
        bulletRate = PlayerPrefs.GetInt("bulletRate", 0);
        await Task.Yield();
    }

    private async Task loadCosts()
    {
        await market.calculateCost();

        bulletSpeedCost = PlayerPrefs.GetInt("bsCost");
        bulletDamageCost = PlayerPrefs.GetInt("bdCost");
        movementSpeedCost = PlayerPrefs.GetInt("msCost");
        healthPointsCost = PlayerPrefs.GetInt("hpCost");
        bulletRateCost = PlayerPrefs.GetInt("brCost");
        await Task.Yield();
    }
}
