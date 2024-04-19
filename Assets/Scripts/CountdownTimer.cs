using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Net.NetworkInformation;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public string timer;
    private DateTime targetTime;
    private TimeSpan remainingTime;
    private const string LastCheckTimeKey = "LastCheckTime";
    private const double CountdownDuration = 24 * 60 * 60;

    public bool bonusReady = true;

    void Start()
    {
        if(PlayerPrefs.GetInt("bonusReady") == 2)
        {
            bonusReady = true;
        }
        else if(PlayerPrefs.GetInt("bonusReady") == 1)
        {
            bonusReady = false;
        }

        if(bonusReady == false)
        {
            LoadTimer();
        }
    }

    void Update()
    {
        
        remainingTime = targetTime - DateTime.UtcNow;

        if (remainingTime.TotalSeconds <= 0 || bonusReady == true)
        {
            bonusReady = true;
            timerText.text = "gift";
        }
        else
        {
            
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            timer = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
        }
    }

    private void LoadTimer()
    {
        if (PlayerPrefs.HasKey(LastCheckTimeKey))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString(LastCheckTimeKey));
            DateTime lastCheckTime = DateTime.FromBinary(temp);
            TimeSpan passedTime = DateTime.UtcNow - lastCheckTime;

            if (passedTime.TotalSeconds > CountdownDuration)
            {
                targetTime = DateTime.UtcNow;
            }
            else
            {
                targetTime = lastCheckTime.AddSeconds(CountdownDuration);
            }
        }
        else
        {
            ResetTimer();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(LastCheckTimeKey, DateTime.UtcNow.ToBinary().ToString());
        PlayerPrefs.Save();
    }

    public void ResetTimer()
    {
        targetTime = DateTime.UtcNow.AddSeconds(CountdownDuration);
        PlayerPrefs.SetString(LastCheckTimeKey, DateTime.UtcNow.ToBinary().ToString());
        PlayerPrefs.Save();
    }
}
