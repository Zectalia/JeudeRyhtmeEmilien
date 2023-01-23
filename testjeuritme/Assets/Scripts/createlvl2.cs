using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createlvl2 : MonoBehaviour
{

    public GameObject square;

    public KeyCode keyToPress;

    public GameObject parent;

    public float beatTempo;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            GameObject segment = Instantiate(square);
            Transform tr = segment.GetComponent<Transform>();
            tr.position = new Vector3(3.5f, Time.deltaTime, 0f);
        }

    }
}


