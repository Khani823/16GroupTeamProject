using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 spawnPointPosition;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("���ε� �Ϸ�");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Setting GameManager spawnPoint to: " + spawnPointPosition);
            GameManager.instance.spawnPoint = spawnPointPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToLoad)
        {
            // BattleMap_01 Ȱ��ȭ
            GameObject battleMap01 = GameObject.Find("BattleMap_01");
            if (battleMap01 != null)
            {
                battleMap01.SetActive(true);

                // SpawnPoint ã��
                Transform spawnPointTransform = battleMap01.transform.Find("SpawnPoint");
                if (spawnPointTransform != null)
                {
                    // �÷��̾� ��ġ ����
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player != null)
                    {
                        player.transform.position = spawnPointTransform.position;
                        Debug.Log("ĳ������ġ " + player.transform.position);
                    }
                }
            }
        }
    }
}
