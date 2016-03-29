namespace SE2_Game.Game
{
    /// <summary>
    /// When generating many random numbers in a short time on different
    /// places, we will get identical numbers as the random number
    /// generator is based on the current time. By providing a single
    /// point where numbers are generated, this is circumvented.
    /// </summary>
    public static class Random
    {
        private static System.Random random = new System.Random();

        public static int Next()
        {
            return Random.random.Next();
        }
        public static int Next(int maxValue)
        {
            return Random.random.Next(maxValue);
        }
        public static int Next(int minValue, int maxValue)
        {
            return Random.random.Next(minValue, maxValue);
        }
    }
}
