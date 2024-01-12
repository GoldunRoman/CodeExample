using UnityEngine;

public static class WalletStorage
{
    private const string CoinsKey = "coins";

    public static void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt(CoinsKey, coins);
        PlayerPrefs.Save();
    }

    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(CoinsKey, 0);
    }
}
