
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;


public class RotateMap : MonoBehaviour
{
    public Transform transform;
    public float rotation = 10f;
    private bool hasInteracted = false;
    public float rotationSnapThreshold = 10f;
    private bool puzzleDone = false;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasInteracted && other.gameObject.tag == "Player")
        {
            transform.Rotate(rotation, 0f, 0f, Space.Self);
            Debug.Log("ROTATING to " + transform.localRotation.eulerAngles.x.ToString());
            if ((Mathf.Abs(transform.localRotation.eulerAngles.x) % 360f) < rotationSnapThreshold)
            {
                Debug.Log("Correct position reached");
                puzzleDone = true;
                audioSource.Play();
            }
            else
            {
                puzzleDone = false;
            }

            hasInteracted = true;
        }
    }

    public bool getPuzzleDone()
    {
        return puzzleDone;
    }


    private void OnTriggerExit(Collider other)
    {
        if (hasInteracted && other.CompareTag("Player"))
        {
            hasInteracted = false;
        }
    }
}
