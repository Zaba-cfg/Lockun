using Interface;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerCandle : MonoBehaviour, IInteractable

    {
        public GameObject candle;

        public void Interact()
        {
            candle.SetActive(true);
            Destroy(gameObject);
        }
    }
}
