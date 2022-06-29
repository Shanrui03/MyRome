using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    public bool isPunished;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Screen.height / 3;
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isPunished)
                GameLogicMaster.milkScroe++;
            else
                GameLogicMaster.milkScroe--;
            
            Destroy(this.gameObject);
        }
    }
}