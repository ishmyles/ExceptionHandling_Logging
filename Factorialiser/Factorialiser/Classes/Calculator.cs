using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorialiser.Classes
{
    public static class Calculator
    {
        /// <summary>
        /// Calculates and returns the factorial of the input integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static int Factorial(int input)
        {
            #region Required Task
            // this method should:

            // return the factorial of the integer enetered (or a recursive step toward it)
            // in this normal operation, every step / recursion should be logged (Trace) in the following format
            // (if for example an input of 5 was received)
            // "Calcuator.Factorial: calculating: 5"

            // if the number entered is < 1 this should throw a NumberTooLowException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too low: -5"

            // if the number entered is >30 this should throw a NumberTooHighException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too high: 45"
            #endregion

            if (input < 1)
                throw new NumberTooLowException(input);
            else if (input > 30)
                throw new NumberTooHighException(input);

            int sum = input;

            for (int i = input; i != 1; i--)
            {
                sum *= (i - 1);
            }
            
            return sum;

            #region RecursiveMethod Solution
            //if (input <= 1)
            //    return 1;
            //return input * Factorial(input - 1);
            #endregion
        }
    }
}
