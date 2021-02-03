using UnityEngine;

namespace Models
{
    public class Base
    {
        public int hp;
        public Vector2 position;

        public Base(int hp, Vector2 position)
        {
            this.hp = hp;
            this.position = position;
        }
        
        public void ResolveAttack(int attack)
        {
            hp -= attack;
            if (hp <= 0)
            {
                App.levelManager.RemoveBase(this);
            }
            Debug.Log("Current hp: " + this.hp);
        }
    }
}