using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Text speedText;
    private float gameSpeed = 1f; // �ʱ� ����� 1���

    private bool isPaused = false;

    void Start()
    {
        UpdateSpeedText(); // ��� �ؽ�Ʈ �ʱ�ȭ
    }

    void Update()
    {
        if (!isPaused)
        {
            // ���� ������ ����� ����
            Time.timeScale = gameSpeed;
        }
    }

    // 1��� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void SetSpeed1()
    {
        gameSpeed = 1f;
        UpdateSpeedText(); // ��� �ؽ�Ʈ ������Ʈ
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

    // ���� ����� UI �ؽ�Ʈ�� ������Ʈ�ϴ� �޼���
    private void UpdateSpeedText()
    {
        if (isPaused)
        {
            speedText.text = "�Ͻ�����";
        }
        else
        {
            speedText.text = "���� ���: " + gameSpeed.ToString("F0");
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
        Time.timeScale = 0f; // ���� �ð��� ����
        isPaused = true;
        UpdateSpeedText();
    }

    void ResumeGame()
    {
        Time.timeScale = gameSpeed; // ���� �ð��� ���� ������� ����
        isPaused = false;
        UpdateSpeedText();
    }
}