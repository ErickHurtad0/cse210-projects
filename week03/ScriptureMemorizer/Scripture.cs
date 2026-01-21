using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();

        _words = new List<Word>();

        string[] pieces = text.Split(' ');

        foreach (string piece in pieces)
        {
            Word newWord = new Word(piece);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int amount)
    {
        int hiddenCount = 0;

        while (hiddenCount < amount && !AllWordsHidden())
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string text = "";

        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        return _reference.GetDisplayText() + "\n" + text.Trim();
    }
}
