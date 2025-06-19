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
        [SerializeField] private FloatingText floatingText; //Floating text
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle; // Camera completed puzzle

        public void Interact()
        {
            roomCameraCompletedPuzzle.MoveCamera(); // Move camera to show completed puzzle
            
            enableCandle.SetActive(true);
            enableKey.SetActive(true);
            enableArrow.SetActive(false);
            
            floatingText.Show("I should take a look in the basement."); //Floating text
            
            // Hide everything because if I destroy it the floating text breaks
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
        }
    }
}
