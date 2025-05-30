using System.Collections;
using Interface;
using UnityEngine;

namespace Rooms
{
    public class RoomWallActivate : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _offWall;
        [SerializeField] private GameObject _onWall;
        [SerializeField] private float delayBeforeActivate = 1f; // Wait x seconds

        public void Interact()
        {
            if (_offWall != null)
            {
                _offWall.SetActive(false);
                StartCoroutine(ActivateWallAfterDelay());
            }
        }

        private IEnumerator ActivateWallAfterDelay()
        {
            yield return new WaitForSeconds(delayBeforeActivate);
            
            if (_onWall != null)
            {
                _onWall.SetActive(true);
            }
        }
    }
}