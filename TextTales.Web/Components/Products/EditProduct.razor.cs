using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Products;

public partial class EditProduct : ComponentBase
{
    [Inject]
    public required IProductService ProductService { get; set; }

    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    [Parameter]
    public long Id { get; set; }

    private Product Model { get; set; } = new();

    private IEnumerable<Category>? Categories { get; set; }

    private bool _isVisible = false;

    private string _alertText = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var product = await ProductService.GetProduct(Id);

        if (product is not null)
        {
            Model = product;
            Categories = await CategoryService.GetCategories();
        }
        else
        {
            NavigationManager.NavigateTo(Endpoints.Product.BaseUrl);
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Product can't be found!");
        }
    }

    private async Task SubmitHandler()
    {
        var isUpdated = await ProductService.UpdateProduct(Id, Model!);

        if (!isUpdated)
        {
            await DisplayError("Something went wrong! Failed to update product.");

            return;
        }

        NavigationManager.NavigateTo(Endpoints.Product.BaseUrl);
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Product updated successfully!");
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
