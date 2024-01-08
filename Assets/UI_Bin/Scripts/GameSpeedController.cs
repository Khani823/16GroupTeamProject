using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Text speedText;
    private float gameSpeed = 1f; // 초기 배속은 1배속

    private bool isPaused = false;

    void Start()
    {
        UpdateSpeedText(); // 배속 텍스트 초기화
    }

    void Update()
    {
        if (!isPaused)
        {
            // 게임 로직에 배속을 적용
            Time.timeScale = gameSpeed;
        }
    }

    // 1배속 버튼 클릭 시 호출되는 메서드
    public void SetSpeed1()
    {
        gameSpeed = 1f;
        UpdateSpeedText(); // 배속 텍스트 업데이트
    }

    public void SetSpeed2()
    {
        gameSpeed = 2f;
        UpdateSpeedText();
    }

    public void SetSpeed3()
    {
        gameSpeed = 3f;
        UpdateSpeedText();
    }

    public void SetSpeed4()
    {
        gameSpeed = 4f;
        UpdateSpeedText();
    }

    // 현재 배속을 UI 텍스트로 업데이트하는 메서드
    private void UpdateSpeedText()
    {
        if (isPaused)
        {
            speedText.text = "일시정지";
        }
        else
        {
            speedText.text = "현재 배속: " + gameSpeed.ToString("F0");
        }
    }

    public void TogglePauseResume()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // 게임 시간을 정지
        isPaused = true;
        UpdateSpeedText();
    }

    void ResumeGame()
    {
        Time.timeScale = gameSpeed; // 게임 시간을 현재 배속으로 복원
        isPaused = false;
        UpdateSpeedText();
    }
}