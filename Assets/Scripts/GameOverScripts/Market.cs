using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;


public class Market : MonoBehaviour
{
    private int golds;

    // Upgrades
    private int bulletSpeed;
    private int bulletDamage;
    private int movementSpeed;
    private int healthPoints;
    private int bulletRate;

    [Header("LoadData Script")]
    public LoadData loadDataScript;

    void OnEnable()
    {
        Init();
    }

    private async void Init()
    {
        await loadData();
        await calculateCost();
    }

    public async void InitAndUpdate()
    {
        Init();
        loadDataScript.updateUi();

        await Task.Yield();
    }

    public bool buy(int cost)
    {
        if (this.golds >= cost)
        {
            this.golds -= cost;
            print("Upgrade bought");
            saveGold();
            return true;
        }
        else
        {
            print("Insufficent golds");
            return false;
        }
    }
    /**
    ---Upgrade Costs---
    = lv^2 + 10
        0lv -> 10$
        1lv -> 11$
        2lv -> 14$
        3lv -> 19$
        4lv -> 26$
        5lv -> 35$
        ...
        10lv -> 110$
        ...
        20lv -> 410$
    **/
    public async Task calculateCost()
    {
        PlayerPrefs.SetInt("bsCost", ((int)Mathf.Pow(bulletSpeed, 2)) + 10);
        PlayerPrefs.SetInt("bdCost", ((int)Mathf.Pow(bulletDamage, 2)) + 10);
        PlayerPrefs.SetInt("msCost", ((int)Mathf.Pow(movementSpeed, 2)) + 10);
        PlayerPrefs.SetInt("hpCost", ((int)Mathf.Pow(healthPoints, 2)) + 10);
        PlayerPrefs.SetInt("brCost", ((int)Mathf.Pow(bulletRate, 2)) + 10);
        await Task.Yield();
    }

    private async void saveGold()
    {
        PlayerPrefs.SetInt("golds", this.golds);
        await Task.Yield();
    }

    private async Task loadData()
    {
        this.golds = PlayerPrefs.GetInt("golds", 0);
        this.bulletSpeed = PlayerPrefs.GetInt("bulletSpeed", 0);
        this.bulletDamage = PlayerPrefs.GetInt("bulletDamage", 0);
        this.movementSpeed = PlayerPrefs.GetInt("movementSpeed", 0);
        this.healthPoints = PlayerPrefs.GetInt("healthPoints", 0);
        this.bulletRate = PlayerPrefs.GetInt("bulletRate", 0);
        await Task.Yield();
    }
}
