// читаем весь файл с рабочего стола в строку текста
string text = File.ReadAllText("C:\\Users\\annab\\Downloads\\Text1.txt");

// убирем знаки пунктуации из текста
var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

// cохраняем символы-разделители в массив
char[] delimiters = new char[] { ' ', '\r', '\n' };

// разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
string[] words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> dict = new Dictionary<string, int>();

foreach (string str in words)
{
    if (dict.ContainsKey(str))
        dict[str] = dict[str] + 1;
    else
        dict.Add(str, 1);
}

List<KeyValuePair<string, int>> mapping = dict.ToList();
mapping.Sort((x, y) => x.Value.CompareTo(y.Value));

for (int i = 1; i <= 10; i++)
    Console.WriteLine(mapping[^i]);