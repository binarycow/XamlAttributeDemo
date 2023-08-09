using System.Collections.ObjectModel;

namespace XamlAttributeDemo;

public class AppViewModel
{
    public ObservableCollection<Item> Items { get; } = new();
}

public class Item
{
    public int Value { get; } = Random.Shared.Next(0, 100);
}