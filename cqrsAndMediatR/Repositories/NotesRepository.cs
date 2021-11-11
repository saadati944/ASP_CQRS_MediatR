﻿using cqrsAndMediatR.Dtos;

namespace cqrsAndMediatR.Repositories;

public class NotesRepository
{
    private List<Note> _notes;

    public NotesRepository()
    {
        _notes = new List<Note>();
        Random random = new Random();
        for (int i = 0; i < 10; i++)
            _notes.Add(new Note
            {
                Id = i,
                Name = $"Name_{i + 1}",
                CreatedDate = DateTime.Now.AddDays(-i),
                Description = $"Description_{i + 1}",
                Status = (Dtos.TaskStatus)(random.Next() % 2 + 1)
            });
    }

    public IEnumerable<Note> GetNotes()
    {
        return _notes;
    }

    public Note GetNote(int id)
    {
        return _notes.FirstOrDefault(x => x.Id == id);
    }

    public void AddNote(Note task)
    {
        _notes.Add(task);
    }

    public bool RemoveNote(Note task)
    {
        return _notes.Remove(task);
    }
}