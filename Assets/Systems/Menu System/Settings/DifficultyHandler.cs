using UnityEngine;

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

    private void Start()
    {
        difficulty = Difficulties.Easy;
        Debug.Log("Difficulty set to: Easy");
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
