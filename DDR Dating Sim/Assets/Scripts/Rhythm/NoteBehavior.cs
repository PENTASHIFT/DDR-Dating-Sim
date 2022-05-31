using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public bool can_be_pressed;

    public KeyCode key_to_press;

    public GameObject hit_effect, good_effect, perfect_effect, miss_effect;

    // Start is called before the first frame update
    void Start()
    {
        can_be_pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key_to_press))
        {
            if(can_be_pressed)
            {
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();

                float note_pos = Mathf.Abs(transform.position.y);

                if(note_pos > 7.7 && note_pos < 7.8)   // <.25 //(note_pos > 7.95 && note_pos < 8.05) 
                {
                    Debug.Log("perfect");
                    GameManager.instance.PerfectHit();
                    
                    Instantiate(perfect_effect,transform.position,perfect_effect.transform.rotation);
                }
                else if(note_pos > 7.65 && note_pos < 7.85) // < 0.05f (note_pos > 7.9 && note_pos < 8.1)
                {
                    Debug.Log("good");
                    GameManager.instance.GoodHit();

                    Instantiate(good_effect,transform.position,good_effect.transform.rotation);
                }
                else
                {
                    Debug.Log("normal");
                    GameManager.instance.NormalHit();
                    Instantiate(hit_effect,transform.position,hit_effect.transform.rotation);
                }
                // if(Mathf.Abs(transform.position.y) < 7.7)   // <.25
                // {
                //     Debug.Log("normal");
                //     GameManager.instance.NormalHit();
                // }
                // else if(Mathf.Abs(transform.position.y) < 7.95) // < 0.05f
                // {
                //     Debug.Log("good");
                //     GameManager.instance.GoodHit();
                // }
                // else
                // {
                //     Debug.Log("perfect");
                //     GameManager.instance.PerfectHit();
                // }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Activator")
        {
            can_be_pressed = true;
        }
        if(other.tag == "DestroyHere")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            can_be_pressed = false;
            GameManager.instance.NoteMissed();

            Instantiate(miss_effect,transform.position, miss_effect.transform.rotation);
        }
    }
}
