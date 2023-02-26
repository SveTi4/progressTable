using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace UITestsProgressTable;

public class UnitTest1
{
    [Fact]
    public async void add_student_true()
    {
        var app = AvaloniaApp.GetApp();
        var mainWindow = AvaloniaApp.GetMainWindow();

        await Task.Delay(100);

        var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

        var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");

        var textBox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "newStudent");

        textBox.Text = "Dima";
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);

        Assert.True(listBoxItems.Count() == 2);
    }
    [Fact]
    public async void add_student_false()
    {
        var app = AvaloniaApp.GetApp();
        var mainWindow = AvaloniaApp.GetMainWindow();

        await Task.Delay(100);

        var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

        var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");

        var textBox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "newStudent");

        textBox.Text = "";
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);

        Assert.False(listBoxItems.Count() == 2);
    }
    [Fact]
    public async void save_and_load_true()
    {
        var app = AvaloniaApp.GetApp();
        var mainWindow = AvaloniaApp.GetMainWindow();

        await Task.Delay(100);

        var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

        var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
        var saveBtn = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
        var loadBtn = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

        var textBox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "newStudent");
        
        textBox.Text = "test";
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);
        saveBtn.Command.Execute(buttonAdd.CommandParameter);
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);
        loadBtn.Command.Execute(buttonAdd.CommandParameter);

        Assert.True(listBoxItems.Count() == 2);
    }
    [Fact]
    public async void save_and_load_false()
    {
        var app = AvaloniaApp.GetApp();
        var mainWindow = AvaloniaApp.GetMainWindow();

        await Task.Delay(100);

        var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

        var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
        var saveBtn = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
        var loadBtn = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

        var textBox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "newStudent");
        
        textBox.Text = "test";
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);
        saveBtn.Command.Execute(buttonAdd.CommandParameter);
        textBox.Text = "test2";
        buttonAdd.Command.Execute(buttonAdd.CommandParameter);
        loadBtn.Command.Execute(buttonAdd.CommandParameter);

        Assert.False(listBoxItems.Count() == 3);
    }
}