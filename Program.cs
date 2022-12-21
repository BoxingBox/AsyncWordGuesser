using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

Greeting();
var word = Console.ReadLine();
word = word.ToLower();




if (Regex.IsMatch(word, @"^[a-zA-Z]+$")) 
{ 
  try
  {
     DateTime Begin =   DateTime.Now;
     await RandomlyRecreateAsync(word);
     DateTime End = DateTime.Now;
     DurationAnnouncement(Begin, End);



    }
  catch (IndexOutOfRangeException e) {Console.WriteLine("Something went wrong"); }
  finally
  {
        Console.WriteLine("Thanks for playing");
  }
}

else Console.WriteLine("The application only supports string characters. Please try again");







Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
    
}
int RandomlyRecreate(string word)
{

    Random random = new Random();



    int ExitCondition = 0;                              //exit loop once the word is guessed correctly
    char[] chars = new char[word.Length];        //initializes array the size of the input word
    int counter = 0;                             //counts attempts


    while(ExitCondition == 0) 
    {
        Console.WriteLine(counter + "st loop");
    
      for (int i = 0; i < word.Length; i++) 
      { 
            chars[i] = (char)('a' + random.Next(26)); counter++;
             
      } 

      string Tester = new string(chars);          //assembles the array into a string so as it can be tested for validity

      if (Tester == word)
      {
            ExitCondition = 1;
            string s = new string(chars);
            Console.WriteLine("*****************************************");
            Console.WriteLine("The word is : " + s);
            Console.WriteLine("The computer found the word in " + counter + " tries");
       }
      
    }





    return counter;
}
void Greeting()
{
    Console.WriteLine("Enter a word you want your PC to guess");
    
}
void DurationAnnouncement(DateTime begin, DateTime end)
{

    int duration =  end.Second - begin.Second;
    Console.WriteLine("It took " + duration + " seconds to guess your word");
}