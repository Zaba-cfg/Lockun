using Interface;
using Text.Scripts;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Character.Scripts
{
    public class PlayerCandle : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject enableCandle;
        [SerializeField] private GameObject enableKey;
        [SerializeField] private FloatingText floatingText;

        public void Interact()
        {
            enableCandle.SetActive(true);
            enableKey.SetActive(true);
            floatingText.Show("I should take a look in the basement.");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
            //PlayerText.Instance.ShowMessage("I should take a look in the basement.");
        }
    }
}
