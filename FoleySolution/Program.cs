using FoleySolution;

Console.WriteLine("Hi, user! Nice to see you");
Console.WriteLine("");
Console.WriteLine("Please, enter a text you want me to process");

var text = Console.ReadLine();
var result = Concordance.GenerateConcordance(text);

Console.WriteLine("===== Accepted! ====");
Console.WriteLine("===== Result: ====");

foreach (var word in result.Keys)
{
    var wordInfo = result[word];
    Console.WriteLine("{0} was found {1} in sentences under numbers [{2}]", word, wordInfo.Total, string.Join(", ", wordInfo.SentenceNumbers));
}

Console.ReadLine();