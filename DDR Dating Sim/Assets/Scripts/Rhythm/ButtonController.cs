using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer the_SR;
    public Sprite default_image;
    public Sprite   pressed_image;

    public KeyCode key_to_press;


    // Start is called before the first frame update
    void Start()
    {
        the_SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key_to_press)) {the_SR.sprite = pressed_image;}
        if(Input.GetKeyUp(key_to_press)) {the_SR.sprite = default_image;}
    }
}
