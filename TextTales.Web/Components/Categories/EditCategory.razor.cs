using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Categories;

public partial class EditCategory : ComponentBase
{
    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    [Parameter]
    public long Id { get; set; }

    private Category Model { get; set; } = new();

    private bool _isVisible = false;

    private string _alertText = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var category = await CategoryService.GetCategory(Id);

        if (category is not null)
        {
            Model = category;
        }
        else
        {
            NavigationManager.NavigateTo(Endpoints.Category.BaseUrl);
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Category can't be found!");
        }
    }

    private async Task SubmitHandler()
    {
        var isUpdated = await CategoryService.UpdateCategory(Id, Model!);

        if (!isUpdated)
        {
            await DisplayError("Something went wrong! Failed to update category.");

            return;
        }

        NavigationManager.NavigateTo(Endpoints.Category.BaseUrl);
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Category updated successfully!");
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
