using Interface;
using Rooms;
using Text.Scripts;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Character.Scripts
{
    public class PlayerCandle : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject enableCandle;
        [SerializeField] private GameObject enableKey;
        [SerializeField] private GameObject enableArrow;
        [SerializeField] private FloatingText floatingText;//Floating text
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle;

        public void Interact()
        {
            roomCameraCompletedPuzzle.MoveCamera();
            enableCandle.SetActive(true);
            enableKey.SetActive(true);
            enableArrow.SetActive(false);
            floatingText.Show("I should take a look in the basement.");//Floating text
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
        }
    }
}
