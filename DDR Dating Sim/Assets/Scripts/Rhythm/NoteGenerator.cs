using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Allow for a way to specify where these show up on the y-axis.

public class NoteGenerator : MonoBehaviour
{
    public TextAsset csv;
    public GameObject arrow;

    public void Start()
    {
        // Read from file and generate here.
        GenerateLeft();
        GenerateUp();
        GenerateDown();
        GenerateRight();

        Debug.Log(csv.ToString());
    }

    void ReadFile()
    {
        // Read CSV file here.
    }

    void GenerateLeft()
    {
        Vector3 pos = new Vector3(-1.5f, 0.0f, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 180.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.S;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateUp()
    {
        Vector3 pos = new Vector3(-0.5f, 0.0f, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.D;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    void GenerateDown()
    {
        Vector3 pos = new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, -90.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.J;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;

    }

    void GenerateRight()
    {
        Vector3 pos = new Vector3(1.5f, 0.0f, 0.0f);
        Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject newArrow = Instantiate(arrow, pos, Quaternion.Euler(rotation));
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<NoteBehavior>().key_to_press = KeyCode.K;
        newArrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
