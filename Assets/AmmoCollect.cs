using UnityEngine;

public class AmmoCollector : MonoBehaviour
{
    public int currentAmmo = 0;          // how much ammo the player has
    public float shootingRange = 100f;   // how far the bullet can reach

    void Update()
    {
        // Shoot when the left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Pick up ammo box
        if (other.CompareTag("AmmoBox"))
        {
            currentAmmo += 20;
            other.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        // Only shoot if there is ammo left
        if (currentAmmo > 0)
        {
            currentAmmo--;

            // Create a ray from the middle of the screen
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit, shootingRange))
            {
                // Check if it hit the target
                if (hit.collider.CompareTag("Target"))
                {
                    // Find the drawbridge (the parent of the target)
                    GameObject g = hit.collider.gameObject;
                    Animation a = g.transform.parent.GetComponent<Animation>();
                    a.Play("LowerBridge");
                }
            }
        }
    }
}