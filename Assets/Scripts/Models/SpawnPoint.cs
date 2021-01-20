using UnityEngine;

namespace Models
{
    public class SpawnPoint
    {
        public int frequency;
        public int delay;
        public Vector2 position;

        public SpawnPoint(int frequency, int delay, Vector2 position)
        {
            this.frequency = frequency;
            this.delay = delay;
            this.position = position;
        }
    }
}