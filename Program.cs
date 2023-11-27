using System;
using System.Collections.Generic;

// MenuItem class representing an item in the menu
public class MenuItem
{
    public string Name { get; }
    public string Description { get; }
    public bool Vegetarian { get; }
    public double Price { get; }

    public MenuItem(string name, string description, bool vegetarian, double price)
    {
        Name = name;
        Description = description;
        Vegetarian = vegetarian;
        Price = price;
    }
}

// Interface for the MenuIterator
public interface IIterator
{
    bool HasNext();
    MenuItem Next();
}

// Concrete Iterator for the merged menu
public class MergedMenuIterator : IIterator
{
    private List<MenuItem> menuItems;
    private int position = 0;

    public MergedMenuIterator(List<MenuItem> items)
    {
        menuItems = items;
    }

    public bool HasNext()
    {
        return position < menuItems.Count && menuItems[position] != null;
    }

    public MenuItem Next()
    {
        MenuItem menuItem = menuItems[position];
        position++;
        return menuItem;
    }
}

// Interface for the Menu
public interface IMenu
{
    IIterator CreateIterator();
}

// Concrete implementations of the merged menu
public class PancakeHouseMenu : IMenu
{
    private List<MenuItem> menuItems;

    public PancakeHouseMenu()
    {
        menuItems = new List<MenuItem>();
        // Add pancake house menu items
        // (Assume the same items as in the provided Java example)
        // Add your menu items here using menuItems.Add(...)
    }

    public IIterator CreateIterator()
    {
        return new MergedMenuIterator(menuItems);
    }
}

public class DinerMenu : IMenu
{
    private List<MenuItem> menuItems;

    public DinerMenu()
    {
        menuItems = new List<MenuItem>();
        // Add diner menu items
        // (Assume the same items as in the provided Java example)
        // Add your menu items here using menuItems.Add(...)
    }

    public IIterator CreateIterator()
    {
        return new MergedMenuIterator(menuItems);
    }
}

// Waitress class to handle printing the menus
public class Waitress
{
    private IMenu breakfastMenu;
    private IMenu lunchMenu;

    public Waitress(IMenu breakfastMenu, IMenu lunchMenu)
    {
        this.breakfastMenu = breakfastMenu;
        this.lunchMenu = lunchMenu;
    }

    public void PrintMenu()
    {
        IIterator breakfastIterator = breakfastMenu.CreateIterator();
        IIterator lunchIterator = lunchMenu.CreateIterator();

        Console.WriteLine("MENU");
        Console.WriteLine("----");
        Console.WriteLine("BREAKFAST");
        PrintMenuItems(breakfastIterator);

        Console.WriteLine("LUNCH");
        PrintMenuItems(lunchIterator);
    }

    private void PrintMenuItems(IIterator iterator)
    {
        while (iterator.HasNext())
        {
            MenuItem menuItem = iterator.Next();
            Console.WriteLine($"{menuItem.Name}, {menuItem.Price} -- {menuItem.Description}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of the menus
        IMenu pancakeHouseMenu = new PancakeHouseMenu();
        IMenu dinerMenu = new DinerMenu();

        // Creating a waitress
        Waitress waitress = new Waitress(pancakeHouseMenu, dinerMenu);

        // Printing out the menus
        waitress.PrintMenu();
    }
}