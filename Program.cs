using Xunit;

namespace JobNimbusAssessment
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class BracketChecker
    {
        // checks if there is a closing bracket for every opening bracket, regardless of order
        public static bool HasMatchingBrackets(string input)
        {
            int matchingPairs = 0;

            foreach (char c in input)
            {
                if (c == '<')
                {
                    matchingPairs++;
                }
                else if (c == '>')
                {
                    matchingPairs--;
                }
                // prevents closing before opening
                if (matchingPairs < 0)
                {
                    return false;
                }
            }

            return matchingPairs == 0;
        }

        // checks if every opening bracket has a matching closing bracket before the next opening bracket
        public static bool HasMatchingSubsequentBrackets(string input)
        {
            Stack<char> charStack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '<')
                {
                    if (charStack.Count != 0)
                    {
                        if (charStack.Peek() != '<')
                        {
                            charStack.Push(c);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        charStack.Push(c);
                    }
                }
                else if (c == '>')
                {
                    if (charStack.Count == 0)
                    {
                        return false;
                    }

                    if (charStack.Peek() == '<')
                    {
                        charStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return charStack.Count == 0;
        }
    }

    // Unit Tests
    public class BracketCheckerTests
    {
        [Fact]
        public static void RunTests()
        {
            Console.Write("TEST SUBSEQUENT BRACKETS\n");
            // required tests
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<>") == true);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("><") == false);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<<>") == false);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("") == true);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<abc...xyz>") == true);

            // additional tests
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<<>>") == false);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<<><>>") == false);

            // real world examples
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<div>content here</div>") == true);
            Assert.True(BracketChecker.HasMatchingSubsequentBrackets("<div>>syntax error</div>") == false);

            Console.Write("\nTEST MATCHING BRACKETS\n");
            // required tests
            Assert.True(BracketChecker.HasMatchingBrackets("<>") == true);
            Assert.True(BracketChecker.HasMatchingBrackets("><") == false);
            Assert.True(BracketChecker.HasMatchingBrackets("<<>") == false);
            Assert.True(BracketChecker.HasMatchingBrackets("") == true);
            Assert.True(BracketChecker.HasMatchingBrackets("<abc...xyz>") == true);

            // additional tests
            Assert.True(BracketChecker.HasMatchingBrackets("<<>>") == true);
            Assert.True(BracketChecker.HasMatchingBrackets("<<><>>") == true);

            // real world examples
            Assert.True(BracketChecker.HasMatchingBrackets("<div>content here</div>") == true);
            Assert.True(BracketChecker.HasMatchingBrackets("<div>>syntax error</div>") == false);
        }
    }
}

// TODO: 
// - Clarify business requirements to know if they want subsequent bracket searching or accumulative. 
// - Separate out Unit Tests
// - Add more real world examples
// - Add two params to the method: `openChar` and `closingChar` to make it configurable. 