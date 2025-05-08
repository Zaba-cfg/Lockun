using System;
using UnityEngine;

public class RoomLightController : MonoBehaviour
{
    public GameObject darkOverlay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            darkOverlay.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            darkOverlay.SetActive(true);
        }
    }
}
