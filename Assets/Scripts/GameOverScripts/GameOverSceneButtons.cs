using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverSceneButtons : MonoBehaviour
{
    public GameObject upgradesPanel;
    private Animator animator;

    private bool isActive;

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
        animator.SetBool("isEnabled", isActive);
    }
}
