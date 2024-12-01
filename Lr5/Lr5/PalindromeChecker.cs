namespace Lr5
{
    internal class PalindromeChecker
    {
        public static bool IsPalindrome(string input)
        {
            var stack = new Stack<char>(input.Length);

            foreach (char c in input)
            {
                stack.Push(c);
            }

            foreach (char c in input)
            {
                if (c != stack.Pop())
                {
                    return false;
                }
            }

            return true;
        }
    }
}