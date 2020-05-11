using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuUIManager : MonoBehaviour
    {
        public GameObject play;
        public GameObject credits;
        public GameObject assetsUsed;
        public GameObject _return;

        void SetCreditsActive(bool value)
        {
            play.SetActive(!value);
            credits.SetActive(!value);

            assetsUsed.SetActive(value);
            _return.SetActive(value);
        }

        public void Play()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void Credits()
        {
            SetCreditsActive(true);
        }

        public void Return()
        {
            SetCreditsActive(false);
        }
    }
}
