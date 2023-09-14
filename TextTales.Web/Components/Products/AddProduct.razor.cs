using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Products;

public partial class AddProduct : ComponentBase
{
    [Inject]
    public required IProductService ProductService { get; set; }

    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    private Product Model { get; set; } = new();

    private IEnumerable<Category>? Categories { get; set; }

    private bool _isVisible = false;

    private string _alertText = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Categories = await CategoryService.GetCategories();
    }

    private async Task SubmitHandler()
    {
        var isCreated = await ProductService.CreateProduct(Model);

        if (!isCreated)
        {
            await DisplayError("Something went wrong! Failed to create new product.");

            return;
        }

        NavigationManager.NavigateTo(Endpoints.Product.BaseUrl);
        NotificationService.Notify(NotificationSeverity.Success, "Success", "New product added successfully!");
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
