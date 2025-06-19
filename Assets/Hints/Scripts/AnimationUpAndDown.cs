using UnityEngine;

namespace Hints.Scripts
{
    public class AnimationUpAndDown : MonoBehaviour
    {
        private Vector3 _startPosition;
        public float amplitude = 0.2f;
        public float speed = 2f; 
        
        private void Start()
        {
            _startPosition = transform.position;
        }
        void Update() // Up and Down animation, simple animation made with ChatGPT
        {
            if (gameObject != null)
            {
                float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
                transform.position = _startPosition + new Vector3(0, yOffset, 0);
            }
        }
    }
}
