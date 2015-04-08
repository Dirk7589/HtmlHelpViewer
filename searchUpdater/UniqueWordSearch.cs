using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace searchUpdater
{
    static class UniqueWordReader
    {
        public static LinkedList<string> findUniqueWords(string textToSearch)
        {
            //remove numbers and punctuation
            textToSearch = Regex.Replace(textToSearch, "\\.|;|:|,|[0-9]|'", "");
            //create collection of words
            MatchCollection wordCollection = Regex.Matches(textToSearch, @"[\w]+", RegexOptions.Multiline);
            //create linked list for words
            LinkedList<string> wordList = new LinkedList<string>();
            //create linked list for unique words
            LinkedList<string> uniqueWord = new LinkedList<string>();
            //populate wordList with content of collection
            for (int i = 0; i < wordCollection.Count; i++)
            {
                wordList.AddLast(wordCollection[i].ToString().ToLower().Trim());
            }
            //populate hashtable of word frequency
            //for everyword in full word list
            foreach (var word in wordList)
            {
                //if unique linked list does not contain a word, add it as a key, and set the value:1
                //if unique linked list contains the word, increment the value
                if (uniqueWord.Contains(word))
                {

                }
                else
                {
                    uniqueWord.AddLast(word);
                    
                }
            }
            return uniqueWord;
        }
    }
}