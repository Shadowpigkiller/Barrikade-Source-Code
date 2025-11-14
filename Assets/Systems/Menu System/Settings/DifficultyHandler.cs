using UnityEngine;
using UnityEngine.UI;

public class DifficultyHandler : MonoBehaviour
{
    //Handles the changes that are applied when difficulty is changed

    public enum Difficulties
    {
        Easy,
        Medium,
        Hard
    }

    [SerializeField] public static Difficulties difficulty;
    [SerializeField] public Difficulties diffInstance;

    private void Start()
    {
        difficulty = Difficulties.Easy;
        Debug.Log("Difficulty set to: Easy");
    }

    private void Update()
    {
        if (diffInstance != difficulty)
        {
            gameObject.GetComponent<Image>().color = Color.gray;

        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public static void ChangeDifficulty(int diff)
    {
        switch (diff)
        {
            case 0: //easy
                difficulty = Difficulties.Easy;
                Debug.Log("Difficulty set to: Easy");
                break;
            case 1: //medium
                difficulty = Difficulties.Medium;
                Debug.Log("Difficulty set to: Medium");
                break;
            case 2: //hard
                difficulty = Difficulties.Hard;
                Debug.Log("Difficulty set to: Hard");
                break;
        }
    }

}
