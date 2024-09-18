using Agava.YandexGames;
using UnityEngine;

public class VerificationAuthorization : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        { 
            PlayerAccount.RequestPersonalProfileDataPermission();
        }

        if (PlayerAccount.IsAuthorized)
        {
            return;
        }
    }
}
