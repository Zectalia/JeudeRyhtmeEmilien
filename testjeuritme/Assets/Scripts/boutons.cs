using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boutons : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultimage;
    public Sprite pressedimage;
    public KeyCode keyToPress;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedimage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultimage;
        }
    }
}
