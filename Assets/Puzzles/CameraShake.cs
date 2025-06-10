using System.Collections;
using UnityEngine;

namespace Puzzles
{
    public class CameraShake : MonoBehaviour
    {
        public float duration = 0.5f;
        public float magnitude = 0.5f;

        private Vector3 _originalPos;

        public void Shake()
        {
            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            _originalPos = transform.localPosition;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = _originalPos + new Vector3(x, y, 0f);

                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = _originalPos;
        }
    }
}