using System;
using System.Collections.Generic;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(IsPalindromeNumber(111121111) ? "This is a Palindrome!" : "Not a Palindrome!");            
        }
        static bool IsPalindromeNumber(int numInput)
        {
            bool isPalindrome = false;
            
            int quotient = -1;
            int remainder = -1;
            int counterDiv = -1;
            kList aList = new kList();
            // The following code counts the number of digits
            int num1 = numInput;
            while (quotient != 0)
            {
                quotient = num1 / 10;
                num1 = quotient;
                counterDiv++;
            }
            // The following code adds the digits on a linked list in reversed order
            int counterProd = counterDiv;
            int num2 = numInput;
            while (num2 != 0)
            {
                quotient = num2 / tenExponent(counterDiv);
                aList.Add(quotient);
                num2 = num2 % tenExponent(counterDiv);
                counterDiv--;
                #region commented code
                //remainder = num1 % 10;
                //quotient = num1 / 10;                
                //aList.Add(remainder);
                //counter++;
                //num1 = quotient;
                #endregion
            }
            // The following code computes the value of the reveresed number on the list
            int newNum = 0;
            int product;
            Node tempNode = aList.headNode;
            while (tempNode.next != null)
            {
                product = computeProduct(tempNode.data, counterProd);
                newNum += product;
                counterProd--;
                tempNode = tempNode.next;
            }
            // the following code compares the values of the original and the reversed numbers
            if (numInput == newNum)
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }
        public static int computeProduct(int x, int y)
        {
            int result;
            if (y == 0)
            {
                result = x;                
            }
            else
            {
                result = x * 10;
                for (int i = 1; i < y; i++)
                {
                    result *= 10;
                }
            }            
            return result;
        }
        public static int tenExponent(int x)
        {
            int result = 1;
            for (int i = x; i > -1; i--)
            {
                result *= 10;
            }
            return result;
        }


    }
    public class kList
    {
        public Node headNode;
        public kList()
        {
            headNode = null;         
        }
        public void Add(int data)
        {
            if(headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }            
        }
        public void Print()
        {
            Node temp = headNode;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }
    }
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }       
    }
}
