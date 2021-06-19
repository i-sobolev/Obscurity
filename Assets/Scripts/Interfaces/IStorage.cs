using System.Collections;
using System.Collections.Generic;

public interface IStorage : IIteractable
{
    List<Item> Items { get; set; }
    int MaxItems { get; set; }
    bool IsLocked { get; set; }
}
