using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            if (controller.PlayerHealth.CurrentHeal < controller.PlayerHealth.MaxHeal)
            {
                controller.ChangeHealth(200);
                Destroy(gameObject);
            }
        }
    }
}
