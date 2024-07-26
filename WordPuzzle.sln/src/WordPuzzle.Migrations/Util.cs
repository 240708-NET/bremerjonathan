using WordPuzzle.Model;
using WordPuzzle.Repository;

public class Util
{
    internal static void AddUser(IUserRepository userRepository, string firstName, string lastName, string userName) {
        if(userRepository.UserExists(userName))
            return;
        var firstUser = new User(firstName,lastName, userName);
        userRepository.AddUser(firstUser);
    }

    internal static void AddWords(IUserRepository urepo, IWordRepository wrepo, string username, string filepath) {
        var user = urepo.GetUserByUserName(username);
        if(user == null) 
            return;
       
        HashSet<Word> words = [];
        using var reader = new StreamReader(filepath);
        string? word;
        for (int i = 0; (word = reader.ReadLine()) != null; i++)
        {
            words.Add(new Word(word.ToLower(), user.Id));
        }
        wrepo.AddWords(words);
    }

}