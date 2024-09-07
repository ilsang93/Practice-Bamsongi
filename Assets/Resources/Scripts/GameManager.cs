using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Text scoreText;
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score += value;
            scoreText.text = "Score : " + score;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Score = 0;
    }
}
