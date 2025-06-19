using Interface;
using UnityEngine;

namespace Puzzles.Living
{
    public class Switch : MonoBehaviour, IInteractable
    {
        [Header("Quantity of levers (from 0)")]
        public int index;
        public PuzzleManagerLiving manager;

        private bool _isOn;
        
        [SerializeField] private Color colorOn = Color.green;
        [SerializeField] private Color colorOff = Color.red;

        public void Interact() // Set lever ON or OFF
        {
            if (!manager.hasWon)
            {
                _isOn = !_isOn;
                manager.currentPattern[index] = _isOn;
                manager.CheckPattern();

                if (_isOn)
                {
                    GetComponent<Renderer>().material.color = colorOn;
                }

                if (!_isOn)
                {
                    GetComponent<Renderer>().material.color = colorOff;
                }

                manager.TimerStarted();
            }
        }

    }
}
