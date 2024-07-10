interface IWordScrambler
{
    string Scramble(string word);
    bool IsAnagram(params string[] words);
}