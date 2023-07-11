using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingSword : MonoBehaviour
{
    public GameObject katana;
    public GameObject door1;
    public GameObject door2;

    public AudioClip audioClip;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Espada") {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(door1);
            Destroy(door2);
            katana.SetActive(true);
            
        }
    }
}