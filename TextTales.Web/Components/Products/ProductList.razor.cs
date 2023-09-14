using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Products;

public partial class ProductList : ComponentBase
{
    [Inject]
    public required IProductService ProductService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required DialogService DialogService { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    private IEnumerable<Product>? Products { get; set; }

    private IList<Product> SelectedProducts { get; set; } = new List<Product>();

    private bool _isLoading = false;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        Products = await ProductService.GetProducts();
        _isLoading = false;
    }

    private void NewProductHandler()
    {
        NavigationManager.NavigateTo(Endpoints.Product.AddUrl);
    }

    private void EditProductHandler(long productId)
    {
        NavigationManager.NavigateTo(Endpoints.Product.SetEditUrl(productId));
    }

    private async Task DeleteProductHandler(long productId, string productTitle)
    {
        var dialogResult = await DialogService.Confirm(
            $"Do you really want to delete {productTitle}?",
            "Delete Product",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

        if (dialogResult.HasValue && dialogResult.Value == false)
        {
            return;
        }

        var isDeleted = await ProductService.DeleteProduct(productId);

        if (isDeleted)
        {
            Products = await ProductService.GetProducts();

            NotificationService.Notify(NotificationSeverity.Success, "Success", "Product deleted successfully!");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Product can't be deleted!");
        }
    }
}
