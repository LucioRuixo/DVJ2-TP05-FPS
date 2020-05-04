using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class UIManager : MonoBehaviour
    {
        int life;
        int score;

        public Player character;

        void Update()
        {
            foreach (Text text in GetComponentsInChildren<Text>())
            {
                switch (text.gameObject.name)
                {
                    case "Life":
                        life = character.life;
                        text.text = "Life: " + life;
                        break;
                    case "Score":
                        score = character.score;
                        text.text = "Score: " + score;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}