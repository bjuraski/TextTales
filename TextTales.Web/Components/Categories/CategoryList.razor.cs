using Microsoft.AspNetCore.Components;
using Radzen;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Categories;

public partial class CategoryList : ComponentBase
{
    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required IProductService ProductService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required DialogService DialogService { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    private IEnumerable<Category>? Categories { get; set; }

    private IList<Category> SelectedCategories { get; set; } = new List<Category>();

    private bool _isLoading = false;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        Categories = await CategoryService.GetCategories();
        _isLoading = false;
    }

    private void NewCategoryHandler()
    {
        NavigationManager.NavigateTo(Endpoints.Category.AddUrl);
    }

    private void EditCategoryHandler(long categoryId)
    {
        NavigationManager.NavigateTo(Endpoints.Category.SetEditUrl(categoryId));
    }

    private async Task DeleteCategoryHandler(long categoryId, string categoryName)
    {
        var dialogResult = await DialogService.Confirm(
            $"Do you really want to delete {categoryName}?",
            "Delete Category",
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false, CloseDialogOnEsc = true });

        if (dialogResult.HasValue && dialogResult.Value == false)
        {
            return;
        }

        var productOfCategoryExists = await ProductService.ProductOfCategoryExists(categoryId);

        if (productOfCategoryExists)
        {
            await DialogService.Alert(
                $"Category {categoryName} can't be deleted, since it's already assigned to some products!",
                "Warning!",
                new AlertOptions { OkButtonText = "Ok", CloseDialogOnEsc = true, ShowClose = false });

            return;
        }

        var isDeleted = await CategoryService.DeleteCategory(categoryId);

        if (isDeleted)
        {
            Categories = await CategoryService.GetCategories();

            NotificationService.Notify(NotificationSeverity.Success, "Success", "Category deleted successfully!");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Category can't be deleted!");
        }
    }
}
