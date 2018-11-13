using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _8
    {
        [TestMethod]
        public void MyAtoiTest()
        {
            Assert.AreEqual(42, MyAtoi("42"));
            Assert.AreEqual(-42, MyAtoi("     -42"));
            Assert.AreEqual(4193, MyAtoi("   4193 with words"));
            Assert.AreEqual(0, MyAtoi("words and 987"));
            Assert.AreEqual(-2147483648, MyAtoi("-91283472332"));
        }

        public int MyAtoi(string str)
        {
            int stage = 0;
            bool minus = false;
            long value = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (stage==0)
                {
                    if(str[i]!=' ')
                    {
                        if (CharToI(str[i]) >= 0)
                        {
                            stage = 1;
                            value = value * 10 + CharToI(str[i]);
                        }else if (str[i] == '-')
                        {
                            minus = true;
                            stage = 1;
                        }else if (str[i] == '+')
                        {
                            stage = 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    if(CharToI(str[i]) >= 0)
                    {
                        value = value * 10 + CharToI(str[i]);
                        if (value > int.MaxValue)
                        {
                            return minus ? int.MinValue : int.MaxValue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return minus ? -(int)value : (int)value;
        }

        int CharToI(char c)
        {
            var v = c - '0';
            return v >= 0 && v <= 9 ? v : -1;
        }
    }
}
