using System.ComponentModel.DataAnnotations;
using System;


    namespace cd_c_passcodeGenerator
    {
        public class PasscodeGenerator
        {
            public string lowers = "abcdefghijklmnopqrstuvwxyz";
            public string  uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public string numbers = "123456789";
            public string specials = "!@#$%^&*(()";

            public int count = 1;

            public string GeneratePasscode(bool uselowers, bool useuppers, bool usenumbers, bool usespecials, int passcodeSize)
            {
                char[] _passcode = new char[passcodeSize];
                string charSet = " "; 
                Random rando = new Random();
                int counter;

                if (uselowers) charSet += lowers;
                if (useuppers) charSet += uppers;
                if (usenumbers) charSet += numbers;
                if (usespecials) charSet += specials;

                for (counter = 0; counter < passcodeSize; counter++)
                {
                    _passcode[counter] = charSet[rando.Next(charSet.Length -1)];
                }
                return String.Join(null, _passcode);
            }
        }
    }
