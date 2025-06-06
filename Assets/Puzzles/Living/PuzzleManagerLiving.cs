using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles.Living
{
    public class PuzzleManagerLiving : MonoBehaviour
    {
        [SerializeField] private GameObject doorToUnlock;
        [SerializeField] private float timer = 60f;

        public TextMeshProUGUI timerText;
        public bool startTimer;
        public bool hasWon;
        public bool[] currentPattern = new bool[5];
        public bool[] correctPattern = new bool[5];

        private void Start()
        {
            for (int i = 0; i < correctPattern.Length; i++)
            {
                // Fix and try other form
                correctPattern[i] = Random.value > 0.5f; // 50% chance true or false
            }
        }

        private void Update() // Timer countdown
        { 
            if (!startTimer || hasWon) return;

            timer -= Time.deltaTime;
            UpdateTimerUI();

            if (timer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        private void UpdateTimerUI() // Update timer in UI
        {
            if (timerText != null)
            {
                int seconds = Mathf.CeilToInt(timer);
                timerText.text = "Time Remaining: " + seconds;
            }
        }
        
        public void CheckPattern() // Check if puzzle completed
        {
            for (int i = 0; i < correctPattern.Length; i++)
            {
                if (currentPattern[i] != correctPattern[i])
                    return;
            }

            if (!hasWon)
            {
                hasWon = true;
                Debug.Log("PUZZLE RESOLVED");
                var door2DCollider = doorToUnlock.GetComponent<Collider2D>();
                door2DCollider.enabled = true;
                Destroy(timerText);
            }
        }
        public void TimerStarted() // Start timer
        {
            if (!startTimer)
            {
                startTimer = true;
                timerText.gameObject.SetActive(true);
            }
        }
    }
}
