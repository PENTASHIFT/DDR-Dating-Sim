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

        // Read from file and generate here.
        GenerateLeft(0.0f);
        GenerateUp(-1.0f);
        GenerateDown(-2.0f);
        GenerateRight(-3.0f);
    }

    string[,] ParseFile()
    {
        // Parse CSV file here.

        string[] lines = csv.ToString().Split('\n');
        string[,] beatMap = new string[lines.Length - 1, 4];

        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] vals = lines[i].Split(',');

            for (int ii = 0; ii < vals.Length - 1; ii++)
            {
                beatMap[i, ii] = vals[ii];
            }
        }

        return beatMap;
    }

    void GenerateLeft(float y)
    {
        Vector3 pos = new Vector3(-1.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 180.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.S;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateUp(float y)
    {
        Vector3 pos = new Vector3(-0.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.D;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateDown(float y)
    {
        Vector3 pos = new Vector3(0.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, -90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.J;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;

    }

    void GenerateRight(float y)
    {
        Vector3 pos = new Vector3(1.5f, y, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.K;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
