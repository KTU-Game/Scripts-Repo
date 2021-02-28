using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timeTextField;
    public float startingTime;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < 0)
            return;

        _timer -= Time.deltaTime;
        SetTimeText(_timer);
    }

    private void SetTimeText(float timer)
    {
        if (timer <= 0)//GAME OVER
        {
            timeTextField.text = ("00:00");
            //TO DO: GAME OVER code here
        }
        else if (timer <= 10)// ONE MINUTE LEFT
        {
            timeTextField.alignment = TextAlignmentOptions.Left;
            timeTextField.text = ($"  {timer:F2}");
        }
        else
        {
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);

            timeTextField.text = ($"{minutes:00}:{seconds:00}");
        }
    }
}
