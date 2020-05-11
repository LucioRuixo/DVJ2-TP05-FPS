using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameplayUIManager : MonoBehaviour
    {
        int life;
        int score;

        public Player player;

        public Text lifeText;
        public Text scoreText;

        void Update()
        {
            
            life = player.life;
            lifeText.text = "Life: " + life;

            score = player.score;
            scoreText.text = "Score: " + score;
        }
    }
}