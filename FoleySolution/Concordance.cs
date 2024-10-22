using System.Text.RegularExpressions;

namespace FoleySolution
{
    public class Concordance
    {
        public static Dictionary<string, WordInfo> GenerateConcordance(string? text)
        {
            if (text == null)
            {
                return new Dictionary<string, WordInfo>();
            }


            // Remove punctuation except for sentence delimiters (.!?) and split sentences
            var sentences = Regex.Split(text, @"(?<=[.!?])\s+");

            // Dictionary to store the concordance
            var concordance = new Dictionary<string, WordInfo>(StringComparer.OrdinalIgnoreCase);

            // Iterate through each sentence
            for (int i = 0; i < sentences.Length; i++)
            {
                // Split by one or more whitespace
                var words = Regex.Split(sentences[i], @"\s+").Where(w => w.Length > 0);

                // Remove special symbols from the beginning and the end of each word
                var cleanWords = words.Select(w => Regex.Replace(w, @"^[^\w]+|[^\w]+$", "")).Where(w => w.Length > 0);

                foreach (var word in cleanWords)
                {
                    // Normalize the word to lowercase
                    string normalizedWord = word.ToLower();

                    // Check if the word is already in the concordance
                    if (!concordance.ContainsKey(normalizedWord))
                    {
                        concordance[normalizedWord] = new WordInfo();
                    }

                    // Increment frequency and add sentence number
                    concordance[normalizedWord].Total++;
                    concordance[normalizedWord].SentenceNumbers.Add(i + 1);
                }
            }

            return concordance;
        }
    }
}
