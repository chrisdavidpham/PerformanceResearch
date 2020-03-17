using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomExtensions;

namespace MathExpression
{
    class MathExpression
    {
        private Random Random;

        public MathExpression()
        {
            Random = new Random();
        }

        public string GenerateRandom(int n, long max)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<char> parathesisQueue = new Stack<char>();
            bool operation = true;
            for (int i = 1; i <= n; i++)
            {
                if (operation)
                {
                    int r = Random.Next(2);
                    switch (r)
                    {
                        case 0:
                            // Open Paranthesis
                            if (i != n)
                            {
                                stringBuilder.Append('(');
                                parathesisQueue.Push(')');
                            }
                            else
                            {
                                operation = false;
                                stringBuilder.Append(Random.NextLong(max));
                            }
                            break;
                        case 1:
                            // Number
                            operation = false;
                            stringBuilder.Append(Random.NextLong(max));
                            break;
                    }
                }
                else if (i != n && parathesisQueue.Any())
                {
                    int r = Random.Next(5);
                    switch (r)
                    {
                        case 0:
                            // Close Paranthesis
                            stringBuilder.Append(parathesisQueue.Pop());
                            break;
                        case 1:
                            // Multiply
                            operation = true;
                            stringBuilder.Append('*');
                            break;
                        case 2:
                            // Divide
                            operation = true;
                            stringBuilder.Append('/');
                            break;
                        case 3:
                            // Add
                            operation = true;
                            stringBuilder.Append('+');
                            break;
                        case 4:
                            operation = true;
                            stringBuilder.Append('-');
                            // Subtract
                            break;
                    }
                }
                else if (i != n)
                {
                    int r = Random.Next(4);
                    switch (r)
                    {
                        case 0:
                            // Multiply
                            operation = true;
                            stringBuilder.Append('*');
                            break;
                        case 1:
                            // Divide
                            operation = true;
                            stringBuilder.Append('/');
                            break;
                        case 2:
                            // Add
                            operation = true;
                            stringBuilder.Append('+');
                            break;
                        case 3:
                            operation = true;
                            stringBuilder.Append('-');
                            // Subtract
                            break;
                    }
                }
            }
            while (parathesisQueue.Any())
            {
                stringBuilder.Append(parathesisQueue.Pop());
            }
            return stringBuilder.ToString();
        }
    }
}