using Interface;
using UnityEngine;

namespace Puzzles.Bedroom
{
    public class BedroomSwitchController : MonoBehaviour, IInteractable
    {
        public bool isOn;
        private float _timer;
        public float timeToReset = 4f;

        private BedroomMinigameManager _manager;

        private void Start()
        {
            _manager = Object.FindFirstObjectByType<BedroomMinigameManager>();
        }

        private void Update() // Timer to set OFF the switches if the player takes too long
        {
            if (isOn && !_manager.hasWon)
            {
                _timer += Time.deltaTime;
                if (_timer >= timeToReset)
                    TurnOff();
            }
        }

        public void Interact()
        {
            if (!isOn)
            {
                TurnOn();
            }
        }

        private void TurnOn()
        {
            isOn = true;
            _timer = 0f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            _manager.CheckWinCondition();
        }

        private void TurnOff()
        {
            isOn = false;
            _timer = 0f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
