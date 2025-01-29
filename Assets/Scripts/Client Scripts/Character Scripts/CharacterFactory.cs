using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2D.Client
{
    public class CharacterFactory
    {

        public Character CurrentCharacterType {  get; private set; }

        public Character GetCharacter(string type)
        {
            Character character = null;
            switch (type) {
                case "Player":
                    character = new Player();
                    break;
                case "Enemy":
                    character = new Enemy();
                    break;
            }
            CurrentCharacterType = character;
            return character;
        }
    }
}

