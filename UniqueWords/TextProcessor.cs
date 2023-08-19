using System.Text;

namespace UniqueWords
{
    public static class TextProcessor
    {
        /// <summary>
        /// Returns the list of unique words in the <see cref="words"/> array.
        /// </summary>
        public static List<string> GetUniqueWordsFromArray(string[] words)
        {
            // TODO #1. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains and List<T>.Add methods.
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words), "Input array cannot be null.");
            }

            var list = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!list.Contains(words[i]))
                {
                    list.Add(words[i]);
                }
            }

            return list;
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static int CountUniqueWordsInText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text), "Input text cannot be null.");
            }

            int count = 0;
            var list = new List<string>();

            int i = 0;
            while (i < text.Length)
            {
                while (i < text.Length && text[i] == ' ')
                {
                    i++; // Skip spaces
                }

                int wordStart = i;
                while (i < text.Length && text[i] != ' ')
                {
                    i++; // Move to the end of the word
                }

                string word = text[wordStart..i];

                if (!string.IsNullOrWhiteSpace(word) && !list.Contains(word))
                {
                    list.Add(word);
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="lines"/>. Words are separated with a space (' ') character.
        /// </summary>
        public static IEnumerable<string> GetUniqueWordsFromEnumerable(IEnumerable<string> lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines), "Input lines cannot be null.");
            }

            var uniqueWords = new List<string>();

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] words = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        if (!uniqueWords.Contains(word))
                        {
                            uniqueWords.Add(word);
                            yield return word;
                        }
                    }
                }
            }
        }

        public static bool Check(List<string[]> a, string b)
        {
            bool ind = false;
            foreach (string[] line in a)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == b)
                    {
                        return true;
                    }
                }
            }

            return ind;
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> character.
        /// </summary>
        public static string[][] GetUniqueWordsArray(IEnumerable<string> lines, char separator)
        {
            List<string[]> uniqueWordsArray = new List<string[]>();

            foreach (string line in lines)
            {
                List<string> uniqueWords = new List<string>();

                int startIndex = 0;
                int separatorIndex = line.IndexOf(separator);

                while (separatorIndex != -1)
                {
                    string word = line.Substring(startIndex, separatorIndex - startIndex);
                    word = word.Trim();
                    if (!Check(uniqueWordsArray, word) && !uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }

                    startIndex = separatorIndex + 1;
                    separatorIndex = line.IndexOf(separator, startIndex);
                }

                string lastWord = line.Substring(startIndex);
                lastWord = lastWord.Trim();
                if (!Check(uniqueWordsArray, lastWord) && !uniqueWords.Contains(lastWord))
                {
                    uniqueWords.Add(lastWord);
                }

                uniqueWordsArray.Add(uniqueWords.ToArray());
            }

            return uniqueWordsArray.ToArray();
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> characters.
        /// </summary>
        public static ICollection<string> GetUniqueWordsCollection(string text, char separator)
        {
            // TODO #5. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains, List<T>.Add, String.IndexOf method and ranges.
            List<string> uniqueWords = new List<string>();

            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] words = line.Split(separator);

                foreach (string word in words)
                {
                    string trimmedWord = word.Trim();

                    if (!uniqueWords.Contains(trimmedWord))
                    {
                        uniqueWords.Add(trimmedWord);
                    }
                }
            }

            return uniqueWords;
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static ICollection<string> GetUniqueWordsInCharCollection(ICollection<char> collection, char separator)
        {
            // TODO #6. Analyze the unit tests for this method, and add a method implementation.
            List<string> uniqueWords = new List<string>();

            StringBuilder wordBuilder = new StringBuilder();

            foreach (char c in collection)
            {
                if (c == separator)
                {
                    string word = wordBuilder.ToString().Trim();

                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }

                    wordBuilder.Clear();
                }
                else
                {
                    wordBuilder.Append(c);
                }
            }

            string lastWord = wordBuilder.ToString().Trim();
            if (!string.IsNullOrEmpty(lastWord) && !uniqueWords.Contains(lastWord))
            {
                uniqueWords.Add(lastWord);
            }

            return uniqueWords;
        }
    }
}
