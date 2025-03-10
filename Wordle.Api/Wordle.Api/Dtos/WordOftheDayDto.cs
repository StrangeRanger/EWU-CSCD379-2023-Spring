﻿using Wordle.Api.Data;

namespace Wordle.Api.Dtos;

public class WordOfTheDayDto
{
    public string Word { get; set; }
    public DateTime Date { get; set; }

    public WordOfTheDayDto(DateWord dateWord)
    {
        Word = dateWord.Word.Text;
        Date = dateWord.Date;
    }
}
