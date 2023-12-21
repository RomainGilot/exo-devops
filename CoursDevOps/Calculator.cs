using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursDevOps
{
	public class Calculator
	{
        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }

        public int Substract(int numberOne, int numberTwo)
        {
            return numberOne - numberTwo;
        }

        public int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }

        public float Divide(int numberOne, int numberTwo)
        {
            if (numberTwo == 0)
                throw new ArgumentException("numberTwo cannot be equal to zero");

            return (float)numberOne / numberTwo;
        }

    }
}

