﻿using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "+ 4 6";
           
            String[] stringArr = input.Split(' ');
            int[] parametersArray = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                int result = 0;
                if (int.TryParse(stringArr[i], out result))
                { parametersArray[i] = result; }
            }
          
            String pattern = @"[\*\+\-\/]";
            String temp;
            Program p = new Program();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                temp = match.Value;
                int d = p.test(temp, parametersArray);
                Console.WriteLine(d);
            }
            //x = new int[] { Convert.ToInt32(input) };
            Console.ReadKey();
        }
        int test(string temp, int[] g)
        {
            string t = g[1] + temp + g[2];
            Expression e = new Expression(t);
            object d = e.Evaluate();      
            return Convert.ToInt32(d);
        }
    }   
}
