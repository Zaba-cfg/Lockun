using Character.Scripts;
using Rooms;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles.Living
{
    public class PuzzleManagerLiving : MonoBehaviour
    {
        [SerializeField] private float timer = 40f;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject puzzleLiving;
        private RoomDoorUnlocker _roomDoorUnlocker;
        public TextMeshProUGUI timerText;
        public TextMeshProUGUI livingText;
        public TextMeshProUGUI livingText2;
        public bool startTimer;
        public bool hasWon;
        public bool[] currentPattern = new bool[5];
        public bool[] correctPattern = new bool[5];

        private void Start()
        {
            _roomDoorUnlocker = GetComponent<RoomDoorUnlocker>();

            int trueCount = 0;

            // Random values
            for (int i = 0; i < correctPattern.Length; i++)
            {
                correctPattern[i] = Random.value > 0.5f;

                if (correctPattern[i])
                    trueCount++;
            }

            // If less than 2, force it
            while (trueCount < 2)
            {
                int randomIndex = Random.Range(0, correctPattern.Length);
                if (!correctPattern[randomIndex])
                {
                    correctPattern[randomIndex] = true;
                    trueCount++;
                }
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
            var playerSpeed = player.GetComponent<PlayerMovement>();
            playerSpeed.moveSpeed = 60f;
            
            for (int i = 0; i < correctPattern.Length; i++)
            {
                if (currentPattern[i] != correctPattern[i])
                    return;
            }

            if (!hasWon)
            {
                hasWon = true;
                Debug.Log("PUZZLE RESOLVED");
                _roomDoorUnlocker.UnlockDoor();
                Destroy(timerText);
                Destroy(livingText);
                Destroy(livingText2);
                playerSpeed.moveSpeed = 40f;
                Destroy(puzzleLiving);
            }
        }
        public void TimerStarted() // Start timer
        {
            if (!startTimer)
            {
                startTimer = true;
                timerText.gameObject.SetActive(true);
                livingText.gameObject.SetActive(true);
                livingText2.gameObject.SetActive(true);
            }
        }
    }
}
