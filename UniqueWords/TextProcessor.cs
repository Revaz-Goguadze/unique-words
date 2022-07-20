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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static int CountUniqueWordsInText(string text)
        {
            // TODO #2. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains, List<T>.Add, String.IndexOf method and ranges.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="lines"/>. Words are separated with a space (' ') character.
        /// </summary>
        public static IEnumerable<string> GetUniqueWordsFromEnumerable(IEnumerable<string> lines)
        {
            // TODO #3. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains, List<T>.Add, String.Split method.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> character.
        /// </summary>
        public static string[][] GetUniqueWordsArray(IEnumerable<string> lines, char separator)
        {
            // TODO #4. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains, List<T>.Add, String.IndexOf, String.Substring and List<T>.ToArray() methods.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> characters.
        /// </summary>
        public static ICollection<string> GetUniqueWordsCollection(string text, char separator)
        {
            // TODO #5. Analyze the unit tests for this method, and add a method implementation.
            // Use List<T>.Contains, List<T>.Add, String.IndexOf method and ranges.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static ICollection<string> GetUniqueWordsInCharCollection(ICollection<char> collection, char separator)
        {
            // TODO #6. Analyze the unit tests for this method, and add a method implementation.
            throw new NotImplementedException();
        }
    }
}
