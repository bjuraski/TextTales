using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Categories;

public partial class AddCategory : ComponentBase
{
    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    private Category Model { get; set; } = new();

    private bool _isVisible = false;

    private string _alertText = string.Empty;

    private async Task SubmitHandler()
    {
        var isCreated = await CategoryService.CreateCategory(Model);

        if (!isCreated)
        {
            await DisplayError("Something went wrong! Failed to create new category.");

            return;
        }

        NavigationManager.NavigateTo(Endpoints.Category.BaseUrl);
        NotificationService.Notify(NotificationSeverity.Success, "Success", "New category added successfully!");
    }

    private async Task DisplayError(string message)
    {
        _isVisible = true;
        _alertText = message;

        await InvokeAsync(StateHasChanged);

        await Task.Delay(5000);

        _isVisible = false;

        await InvokeAsync(StateHasChanged);
    }
}
