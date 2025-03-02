using UnityEngine;
using TMPro;
using System.Collections;

public class Timer_Countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] int timeLeft;

    private void Start()
    {
        StartCoroutine(countDown());

    }

    private void FixedUpdate()
    {
       
    }

    IEnumerator countDown()
    {
        while(timeLeft > 0)
        {
            timerText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        timerText.text = "GO!";
        Game_Controller.instance.startGame();
        yield return new WaitForSeconds(1f);
        timerText.gameObject.SetActive(false);
    }
}
