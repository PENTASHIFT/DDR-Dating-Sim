using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public TextAsset csv;
    public GameObject arrow;

    float beat_tempo;

    void Start()
    {
        beat_tempo = GetComponent<BeatScroller>().beat_tempo;
        Debug.Log(beat_tempo);

        ParseFile();
    }

    void ParseFile()
    {
        // Parse CSV file here.

        string[] lines = csv.ToString().Split('\n');
        float currentYPos = 0.0f;

        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] val = lines[i].Split(',');
            string note = val[0];
            float deltaTime = (float)Convert.ToDouble(val[1]);

            // TODO(josh): Don't check for specific note numbers.
            switch(note)
            {
                case "59":
                case "80":
                {
                    Debug.Log("Right");
                    if (0.0f == deltaTime)
                    {
                        GenerateRight(currentYPos);
                    }
                    else
                    {
                        //currentYPos -= beat_tempo / deltaTime;
                        //currentYPos -= beat_tempo * deltaTime;
                        currentYPos -= (deltaTime * 4f);
                        GenerateRight(currentYPos);
                    }
                } break;
                
                case "57":
                case "78":
                {
                    Debug.Log("Down");
                    if (0.0f == deltaTime)
                    {
                        GenerateDown(currentYPos);
                    }
                    else
                    {
                        //currentYPos -= beat_tempo / deltaTime;
                        //currentYPos -= beat_tempo * deltaTime;
                        currentYPos -= (deltaTime * 4f);
                        GenerateDown(currentYPos);
                    }
                } break;
                
                case "55":
                case "76":
                {
                    Debug.Log("Up");
                    if (0.0f == deltaTime)
                    {
                        GenerateUp(currentYPos);
                    }
                    else
                    {
                        //currentYPos -= beat_tempo / deltaTime;
                        //currentYPos -= beat_tempo * deltaTime;
                        currentYPos -= (deltaTime * 4f);
                        GenerateUp(currentYPos);
                    }
                } break;

                case "53":
                case "74":
                {
                    Debug.Log("Left");
                    if (0.0f == deltaTime)
                    {
                        GenerateLeft(currentYPos);
                    }
                    else
                    {
                        //currentYPos -= beat_tempo / deltaTime;
                        //currentYPos -= beat_tempo * deltaTime;
                        currentYPos -= (deltaTime * 4f);
                        GenerateLeft(currentYPos);
                    }
                } break;
                
                default: break;
            }
        }
    }

    void GenerateLeft(float y)
    {
        Vector3 pos = new Vector3(-1.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 180.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation), gameObject.transform);
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.S;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateUp(float y)
    {
        Vector3 pos = new Vector3(-0.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation), gameObject.transform);
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.D;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateDown(float y)
    {
        Vector3 pos = new Vector3(0.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, -90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation), gameObject.transform);
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.J;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;

    }

    void GenerateRight(float y)
    {
        Vector3 pos = new Vector3(1.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation), gameObject.transform);
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.K;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
