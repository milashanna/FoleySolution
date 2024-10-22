namespace FoleySolution
{
    // Class to store information about a word
    public class WordInfo
    {
        // Set of sentence numbers where the word appears.
        // A Set is used to avoid duplicates when the word occurs multiple times in the same sentence.
        public ISet<int> SentenceNumbers { get; set; }

        // Total count of the word in the text
        public int Total { get; set; }

        public WordInfo()
        {
            Total = 0;
            SentenceNumbers = new HashSet<int>();
        }
    }
}
