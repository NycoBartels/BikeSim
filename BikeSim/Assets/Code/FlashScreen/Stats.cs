using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    private int firstCrossingCarHits;
    private int incomingCarHits;
    private int secondCrossingCarHits;
    private int thirdCrossingCarHits;
    private int forthCrossingCarHits;

    private int parkingCarHits;
    private int humanHits;
    private int lostBalance;
        

    public void firstCrossingHit() {
        firstCrossingCarHits++;
        Debug.Log("Increased by 1");
    }
    public void IncomingCarHit() {
        incomingCarHits++;
    }
    public void SecondCrossingCarHits() {
        secondCrossingCarHits++;
    }
    public void ThirdCrossingCarHits() {
        thirdCrossingCarHits++;
    }
    public void ForthCrossingCarHit() {
        forthCrossingCarHits++;
    }
    public void ParkingCarHit() {
        parkingCarHits++;
    }
    public void HumanHit() {
        humanHits++;
    }
    public void LostBalance() {
        lostBalance++;
    }

    public void ResetStats() {
        PlayerPrefs.SetInt("firstCrossingHits", 0);
        PlayerPrefs.SetInt("IncomingCarHits", 0);
        PlayerPrefs.SetInt("SecondCrossingCarHits", 0);
        PlayerPrefs.SetInt("ThirdCrossingCarHits", 0);
        PlayerPrefs.SetInt("ForthCrossingCarHits", 0);
        PlayerPrefs.SetInt("ParkingCarHits", 0);
        PlayerPrefs.SetInt("HumanHits", 0);
        PlayerPrefs.SetInt("LostBalance", 0);
    }
    public void SetPlayerPrefs() {
        PlayerPrefs.SetInt("firstCrossingHits", firstCrossingCarHits);
        PlayerPrefs.SetInt("IncomingCarHits", incomingCarHits);
        PlayerPrefs.SetInt("SecondCrossingCarHits", secondCrossingCarHits);
        PlayerPrefs.SetInt("ThirdCrossingCarHits", thirdCrossingCarHits);
        PlayerPrefs.SetInt("ForthCrossingCarHits", forthCrossingCarHits);
        PlayerPrefs.SetInt("ParkingCarHits", parkingCarHits);
        PlayerPrefs.SetInt("HumanHits", humanHits);
        PlayerPrefs.SetInt("LostBalance", lostBalance);
    }

}
