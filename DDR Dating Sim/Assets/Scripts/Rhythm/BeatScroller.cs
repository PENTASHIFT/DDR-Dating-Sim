using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beat_tempo;
    public bool has_started;


    // Start is called before the first frame update
    void Start()
    {
        beat_tempo = beat_tempo / 60f;  // gives how fast it will move per sec
        has_started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!has_started)
        {
            // if(Input.anyKeyDown) {has_started = true;}
        }
        else
        {
            // moves scroller up
            transform.position += new Vector3(0f, beat_tempo * Time.deltaTime, 0f);
        }
    }
}
