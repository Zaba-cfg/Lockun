using System.Collections;
using TMPro;
using UnityEngine;

namespace Text.Scripts
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float offsetY = 4f;
        [SerializeField] private float duration = 5f;
        [SerializeField] private float offsetX = 6.5f;

        private TextMeshPro _textMesh;

        private void Start()
        {
            _textMesh = GetComponent<TextMeshPro>();
            _textMesh.enabled = false;
        }

        private void Update()
        {
            if (_textMesh.enabled && player != null)
            {
                transform.position = player.transform.position + new Vector3(offsetX, offsetY, 0);
            }
        }

        public void Show(string message)
        {
            StopAllCoroutines();
            StartCoroutine(ShowAndHide(message));
        }

        private IEnumerator ShowAndHide(string message)
        {
            _textMesh.text = message;
            _textMesh.enabled = true;
            yield return new WaitForSeconds(duration);
            _textMesh.enabled = false;
        }
    }
}