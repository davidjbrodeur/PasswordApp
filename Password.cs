using System;

namespace PasswordApp
{
    public class Password
    {
        char[] passwordArray;
        public char[] PasswordArray { get => passwordArray; }
        bool withSymbols; 
        public Password(bool withOrWithout)
        {
            this.passwordArray = generatePassword();
            this.withSymbols = withOrWithout; 
        }
        private char[] generatePassword()
        {
            int length = Utilities.randomIntegerGeneration(10, 15);
            char[] charArray = new char[length];
            for(int i = 0; i < length; i++)
            {
                if (withSymbols)
                {
                    charArray[i] = generateCharWithSymbols();
                } else
                {
                    charArray[i] = generateCharWithoutSymbols();
                }
                    
            }
            return charArray;
        }
        private char generateCharWithSymbols()
        {
            char c = (char)Utilities.randomIntegerGeneration(Utilities.ASCII_MINIMUM_WITH_SYMBOLS, Utilities.ASCII_MAXIMUM_WITH_SYMBOLS);
            return c;
        }
        private char generateCharWithoutSymbols()
        {
            char c = (char)Utilities.randomIntegerGeneration(Utilities.ASCII_MINIMUM_WITHOUT_SYMBOLS, Utilities.ASCII_MAXIMUM_WITHOUT_SYMBOLS);
            return c;
        }

    }
}
