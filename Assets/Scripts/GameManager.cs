using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public TMP_InputField CurrentPlayerNameInput;
    public string bestScorerName;
    public string currentPlayerName;
    public int bestScore;
    public Text bestScoreText;
    private void Awake()
    {
        if (gameManager==null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadScore();
        bestScoreText.text = "Best Score: "+bestScorerName+" Score: "+bestScore;
    }

    public void SaveScore()
    {
        
        SaveScoreAndName data = new SaveScoreAndName();
        data.bestScore = bestScore;
        data.bestScorerName = bestScorerName;
        string text = JsonUtility.ToJson(data);
        File.WriteAllText("C:/Users/Zakir/Desktop/" + "save.json",text);
        
    }

    public void LoadScore()
    {
        if (File.Exists("C:/Users/Zakir/Desktop/" + "save.json"))
        {
            SaveScoreAndName data = new SaveScoreAndName();
            string text = File.ReadAllText("C:/Users/Zakir/Desktop/" + "save.json");
            data = JsonUtility.FromJson<SaveScoreAndName>(text);
            bestScore = data.bestScore;
            bestScorerName = data.bestScorerName;
        }
    }





    [System.Serializable]
    public class SaveScoreAndName
    {
        public string bestScorerName;
        public int bestScore;
    }


    public void StartGame()
    {
        currentPlayerName = CurrentPlayerNameInput.text;
        SceneManager.LoadScene("main");
    }
}
