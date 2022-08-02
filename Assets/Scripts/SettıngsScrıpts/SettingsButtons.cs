using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    /**
    All PlayerPrefs

    level
    levelHi
    score
    scoreHi

    bulletSpeed
    bulletDamage
    movementSpeed
    healthPoints

    golds
    bsCost
    bdCost
    msCost
    hpCost
    **/

    public GameObject ValidationPopup;
    private bool isActive;

    void Start()
    {
        this.isActive = this.ValidationPopup.activeInHierarchy;
    }

    public void resetOnClick()
    {
        panelToggle();
    }

    public void backOnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void yesButtonOnClick()
    {
        PlayerPrefs.DeleteAll();
        panelToggle();
    }

    public void noButtonOnClick()
    {
        panelToggle();
    }

    private void panelToggle()
    {
        isActive = !isActive;
        ValidationPopup.SetActive(isActive);
    }
}
