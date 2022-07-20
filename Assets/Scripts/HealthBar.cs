using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private Queue animQue;

    void Awake()
    {
        animQue = new Queue();
    }

    public void SetMaxHealthBarValue(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealthBarValue(int prevHealth, int health)
    {
        animQue.Enqueue(new int[2] { prevHealth, health });

        if (animQue.Count == 1)
            StartCoroutine(AnimatedSetHealtBarValue(prevHealth, health));
    }

    IEnumerator AnimatedSetHealtBarValue(int prevHealth, int health)
    {
        // Decreasing health
        if(prevHealth > health)
        {
            for (int i = prevHealth; i >= health; i--)
            {
                slider.value = i;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                yield return new WaitForSeconds(0.005f);
            }
        }
        // Increasing health
        if(prevHealth < health)
        {
            for (int i = prevHealth; i <= health; i++)
            {
                slider.value = i;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                yield return new WaitForSeconds(0.005f);
            }
        }

        if (animQue.Count > 1)
        {
            animQue.Dequeue();
            int[] quePeek = (int[]) animQue.Peek();
            StartCoroutine(AnimatedSetHealtBarValue(quePeek[0], quePeek[1]));
        }

        if(animQue.Count == 1)
            animQue.Dequeue();
    }
}
