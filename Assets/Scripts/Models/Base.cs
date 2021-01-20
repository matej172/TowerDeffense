using UnityEngine;

namespace Models
{
    public class Base
    {
        private int hp;
        public Vector2 position = new Vector2(4f, 3f);

        public Base(int hp)
        {
            this.hp = hp;
        }
        
        public void ResolveAttack(int attack)
        {
            hp -= attack;
            Debug.Log("Current hp: " + this.hp);
        }
    }
}