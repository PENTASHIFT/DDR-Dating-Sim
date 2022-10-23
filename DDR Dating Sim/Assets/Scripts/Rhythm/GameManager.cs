using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TEST

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool start_playing;
    public BeatScroller beatscroller;
    public float current_score;

    public int score_per_note;
    public int score_per_good_note;
    public int score_per_perfect_note;

    public Text score_text;
    public Text multi_text;
    public Text combo_text;

    public float total_notes;
    public float normal_hits;
    public float good_hits;
    public float perfect_hits;
    public float missed_hits;

    public int combo;
    public float points_per_note;
    public Slider slider;
    public GameObject lane_interface;

    // FROM TUTORIAL //     //game doesnt use multiplier so getting rid of all multiplier
    // public int current_multiplier;
    // public int multiplier_tracker;
    // public int[] multiplier_threshold;

    public static GameManager instance;

    public GameObject result_screen;
    public Text percent_hit_text, normals_text, goods_text, perfects_text, missed_text, rank_text, final_score_text;
    public GameObject rankS, rankA, rankB, rankC, rankD;

    // Start is called before the first frame update
    void Start()
    {
        start_playing = false;
        instance = this;

        current_score = 0;
        combo = 0;
        // score_per_note = 100;
        // score_per_good_note = 125;
        // score_per_perfect_note = 150;
        // current_multiplier = 1;

        score_text.text = "Score: " + current_score; //.ToString("000");
        combo_text.text = "Max Combo: " + combo;

        total_notes = FindObjectsOfType<NoteBehavior>().Length;

        points_per_note = 10000 / total_notes;

        Debug.Log(points_per_note);
    }

    // Update is called once per frame
    void Update()
    {
        if(!start_playing)
        {
            if(Input.anyKeyDown)    //starts the music and scroller
            {
                start_playing = true;
                beatscroller.has_started = true;

                music.Play();
            }
        }
        else
        {
            if(!music.isPlaying && !result_screen.activeSelf)
            {
                slider.gameObject.SetActive(false);
                score_text.enabled = false;
                combo_text.enabled = false;
                lane_interface.SetActive(false);

                result_screen.SetActive(true);

                normals_text.text = "" + normal_hits;
                goods_text.text = good_hits.ToString();
                perfects_text.text = perfect_hits.ToString();
                missed_text.text = "" + missed_hits;

                float total_hit = normal_hits+good_hits+perfect_hits;
                float percent_hit = (total_hit / total_notes) * 100f;
                percent_hit_text.text = percent_hit.ToString("F1") + "%";
                
                // string rank_val = "D";
                if(percent_hit > 55)
                {
                    rankD.SetActive(false);
                    rankC.SetActive(true);
                    // rank_val = "C";
                    if(percent_hit > 70)
                    {
                        rankC.SetActive(false);
                        rankB.SetActive(true);
                        // rank_val = "B";
                        if(percent_hit > 85)
                        {
                            rankB.SetActive(false);
                            rankA.SetActive(true);
                            // rank_val = "A";
                            if(percent_hit > 95)
                            {
                                rankA.SetActive(false);
                                rankS.SetActive(true);
                                // rank_val = "S";
                            }
                        }
                    }
                }
                // rank_text.text = rank_val;
                final_score_text.text = ((int)current_score).ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("hit on time");

        // if(current_multiplier-1 < multiplier_threshold.Length)
        // {
        //     multiplier_tracker++;
        //     if(multiplier_threshold[current_multiplier-1] <= multiplier_tracker)
        //     {
        //         multiplier_tracker = 0;
        //         current_multiplier++;
        //     }
        // }

        // multi_text.text = "Multiplier: x" + current_multiplier;

        // // current_score += score_per_hit + current_multiplier;
        current_score += points_per_note;
        slider.value += points_per_note;
        combo++;

        score_text.text = "Score: " + Mathf.Ceil(current_score);
        combo_text.text = "Max Combo: " + combo;
    }

    public void NormalHit()
    {
        // current_score += score_per_note;    // + current_multiplier
        NoteHit();

        normal_hits++;
    }

    public void GoodHit()
    {
        // current_score += score_per_good_note; // + current_multiplier
        NoteHit();

        good_hits++;
    }

    public void PerfectHit()
    {
        // current_score += score_per_perfect_note; //+ current_multiplier
        NoteHit();

        perfect_hits++;
    }

    public void NoteMissed()
    {
        Debug.Log("missed note");

        // current_multiplier = 1;
        // multiplier_tracker = 0;

        // multi_text.text = "Multiplier: x" + current_multiplier;
    
        missed_hits++;

        combo = 0;
        combo_text.text = "Max Combo: " + combo;
    }
}
