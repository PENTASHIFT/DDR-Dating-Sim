using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttontest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChoiceScreen.Show("option1", "option2, which is longer");
        }
    }
}
