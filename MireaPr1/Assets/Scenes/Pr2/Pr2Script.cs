using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int state = 0;
    public GameObject NewGameObject;
    private float RandomNumber = 7;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Randomizer();
    }

    private void Randomizer()
    {
        RandomNumber = Random.Range(1, 1000);
        if (RandomNumber == 5)
            movement(state);
    }

    private void movement(int state)
    {
        if (state == 0)
        {
            transform.position = Vector3.zero;
            this.state = 1;
            Debug.Log("1");
        }
        else if (state == 1)
        {
            transform.position = new Vector3(2f, 2f, 0f);
            this.state = 2;
            Debug.Log("2");
        }
        else if (state == 2)
        {
            transform.position = new Vector3(4f, 4f, 0f);
            this.state = 3;
            Debug.Log("3");
        }

        else if (state == 3)
        {
            transform.position = new Vector3(6f, 6f, 0f);
            this.state = 0;
            Debug.Log("4");
        }
    }
}
