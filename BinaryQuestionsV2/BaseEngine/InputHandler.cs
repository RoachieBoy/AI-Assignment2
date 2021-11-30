namespace BinaryQuestionsV2.BaseEngine
{
    public static class InputHandler
    {
        private static bool CheckInput(ConsoleKey keyToCheck)
        {
            var input = Console.ReadKey();

            return input.Key == keyToCheck;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckYes()
        {
            return CheckInput(ConsoleKey.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckNo()
        {
            return CheckInput(ConsoleKey.N);
        }

        public static bool CheckX()
        {
            return CheckInput(ConsoleKey.X);
        }
    }
}