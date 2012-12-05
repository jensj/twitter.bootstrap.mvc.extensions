using System;
using System.Collections;

public class PagedViewModel
{
    public const int DefaultPagesize = 30;

    public PagedViewModel(IEnumerable items, int totalNumberOfItems, int currentPage = 1, string title = "data")
    {
        PageSize = DefaultPagesize;
        Items = items;
        TotalNumberOfItems = totalNumberOfItems;
        CurrentPage = currentPage;
        Title = title;
    }

    public int CurrentPage { get; set; }
    public IEnumerable Items { get; set; }
    public int PageSize { get; set; }
    public int TotalNumberOfItems { get; set; }
    public string Title { get; set; }
    public bool Filtered { get; set; }

    public int FirstItemOrdinal()
    {
        if (TotalNumberOfItems == 0) return 0;
        return 1 + PageSize*(CurrentPage - 1);
    }

    public int LastItemOrdinal()
    {
        return Math.Min(PageSize*CurrentPage, TotalNumberOfItems);
    }

    public int TotalNumberOfPages()
    {
        return (int) Math.Ceiling((decimal) TotalNumberOfItems/PageSize);
    }

    public object Default()
    {
        return Activator.CreateInstance(Items.GetType().GenericTypeArguments[0]);
    }
}