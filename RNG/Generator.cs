using System;

namespace RNG
{
    public class Generator
    {
        private const int DEFAULT_MAX = 10;
        private const int DEFAULT_MIN = 0;
        Random rand;
        public int max { get; set; }
        public int min { get; set; }
        public Generator()
        {
            max = DEFAULT_MAX;
            min = DEFAULT_MIN;
            rand = new Random();
        }

        public Generator(int max)
        {
            this.max = max;
            this.min = DEFAULT_MIN;
            rand = new Random();
        }

        public Generator(int min, int max)
        {
            this.max = max;
            this.min = min;
            rand = new Random();
        }

        public int Generate()
        {
            return rand.Next(max);
        }
    }
}
