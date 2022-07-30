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

    public void resetOnClick()
    {
        PlayerPrefs.DeleteAll();
        //Todo: Ask for validations
    }

    public void backOnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
