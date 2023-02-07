using UnityEngine;

[System.Serializable]
public enum Dice
{
    D4 = 4,
    D6 = 6,
    D8 = 8,
    D10 = 10,
    D12 = 12,
    D20 = 20
}

public static class DiceRoller
{
    public static int Roll(Dice dice, int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, (int)dice + 1);

        return result;
    }

    public static int D4(int quantity = 1)
    {
        int result = 0;

        for(int i = 0; i < quantity; i++)
            result += Random.Range(1, 5);

        return result;
    }

    public static int D6(int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, 7);

        return result;
    }

    public static int D8(int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, 9);

        return result;
    }
    public static int D10(int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, 11);

        return result;
    }
    public static int D12(int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, 13);

        return result;
    }
    public static int D20(int quantity = 1)
    {
        int result = 0;

        for (int i = 0; i < quantity; i++)
            result += Random.Range(1, 21);

        return result;
    }
}
