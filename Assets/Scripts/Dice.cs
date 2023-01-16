using UnityEngine;

public class Dice
{
    public static int D20(int count)
    {
        int rollValue = Random.Range(1, 21);

        return rollValue;
    }
}
