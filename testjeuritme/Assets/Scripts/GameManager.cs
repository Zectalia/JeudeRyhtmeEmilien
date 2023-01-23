using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;


    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public KeyCode keyToPress;

    public GameObject resultsScreen;
    public GameObject start;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score : 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                start.SetActive(false);


                theMusic.Play();
            }





        }
        else if ( Input.GetKeyDown(KeyCode.P))
        {
            if (!resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                Debug.Log("stpppppp");
                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                finalScoreText.text = currentScore.ToString();

                string rankVal = "F";

                if (currentScore > 50000)
                {
                    rankVal = "E";
                    if (currentScore > 60000)
                    {
                        rankVal = "D";
                        if (currentScore > 70000)
                        {
                            rankVal = "C";
                            if (currentScore > 80000)
                            {
                                rankVal = "B";
                                if (currentScore > 90000)
                                {
                                    rankVal = "A";
                                    if (currentScore > 100000)
                                    {
                                        rankVal = "S";
                                    }
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;
            }
            else
            {
                resultsScreen.SetActive(false);
            }


        }
    }

    public void NoteHit()
    {

        multiplierTracker++;

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier : x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score : " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier : x" + currentMultiplier;
        missedHits++;
    }
    /*public void Stopmusic()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theMusic.Stop();
        }
    }*/
}

