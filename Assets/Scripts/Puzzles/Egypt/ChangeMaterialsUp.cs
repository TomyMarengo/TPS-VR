using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialsUp : MonoBehaviour
{
    private Vector3 initialPosition;
    public Material[] materials;
    public GameObject[] objects;
    public AudioClip audioClick;
    public AudioClip resolvedAll;
    public AudioClip resolvedOne;
    private bool canPressButton = true;
    public float cooldownTime = 0.3f;
    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        EgyptianPuzzleManager.Initialize(door, resolvedAll, resolvedOne);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canPressButton)
        {
            // Mover el botón hacia abajo
            AudioSource.PlayClipAtPoint(audioClick, transform.position);
            transform.Translate(new Vector3(-0.009f, 0f, -0.006f));

            EgyptianPuzzleManager.actualMaterial[0] = (EgyptianPuzzleManager.actualMaterial[0] + 3) % 5;
            EgyptianPuzzleManager.actualMaterial[1] = (EgyptianPuzzleManager.actualMaterial[1] + 1) % 5;
            EgyptianPuzzleManager.actualMaterial[2] = (EgyptianPuzzleManager.actualMaterial[2] + 3) % 5;
            EgyptianPuzzleManager.actualMaterial[3] = (EgyptianPuzzleManager.actualMaterial[3] + 0) % 5;

            Debug.Log(EgyptianPuzzleManager.actualMaterial);

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<MeshRenderer>().material = materials[EgyptianPuzzleManager.actualMaterial[i]];
            }

            EgyptianPuzzleManager.CheckStatus();
            
            canPressButton = false;
            Invoke(nameof(ResetButton), cooldownTime);
        }
    }

    private void ResetButton()
    {
        canPressButton = true;
        transform.position = initialPosition;
    }
}
