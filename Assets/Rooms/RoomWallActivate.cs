using System.Collections;
using Interface;
using UnityEngine;

namespace Rooms
{
    public class RoomWallActivate : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject offWall;
        [SerializeField] private GameObject onWall;
        [SerializeField] private float delayBeforeActivate = 1f; // Wait x seconds

        public void Interact()
        {
            if (offWall != null) // Set Active the desire walls to let player cross to the next room
            {
                offWall.SetActive(false);
                StartCoroutine(ActivateWallAfterDelay());
            }
        }

        private IEnumerator ActivateWallAfterDelay()
        {
            yield return new WaitForSeconds(delayBeforeActivate);
            
            if (onWall != null)
            {
                onWall.SetActive(true);
            }
        }
    }
}