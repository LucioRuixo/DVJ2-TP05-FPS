using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class UIManager : MonoBehaviour
    {
        void SetCreditsActive(bool value)
        {
            foreach (Transform child in GetComponentsInChildren(typeof(Transform), true))
            {
                switch (child.name)
                {
                    case "Play":
                    case "Credits":
                    case "Logo":
                        child.gameObject.SetActive(!value);
                        break;
                    case "Assets Used":
                    case "Return":
                        child.gameObject.SetActive(value);
                        break;
                    default:
                        break;
                }
            }
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
            foreach (Transform child in GetComponentsInChildren(typeof(Transform), true))
            {
                switch (child.name)
                {
                    case "Play":
                    case "Credits":
                    case "Logo":
                        child.gameObject.SetActive(true);
                        break;
                    case "Assets Used":
                    case "Return":
                        child.gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
