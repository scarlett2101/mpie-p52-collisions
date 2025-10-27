using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // check if the player walked into the trigger
        if (other.CompareTag("Player"))
        {
            // get the parent object (the hut)
            GameObject parent = transform.parent.gameObject;

            // get the Animation component from the hut
            Animation animation = parent.GetComponent<Animation>();

            // play the "OpenDoor" animation
            animation.Play("OpenDoor");
        }
    }
}