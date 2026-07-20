using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int coins = 0;

    public void CollectCoin()
    {
        coins++;

        PlayerObserverManager.NotifyCoinCollected(coins);
    }
}