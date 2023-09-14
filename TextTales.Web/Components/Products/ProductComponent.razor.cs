using Microsoft.AspNetCore.Components;
using System.Globalization;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Products;

public partial class ProductComponent : ComponentBase
{
    [Inject]
    public required IProductService ProductService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Parameter]
    public long? Id { get; set; }

    [Parameter]
    public Product Model { get; set; } = new();

    [Parameter]
    public IEnumerable<Category>? Categories { get; set; }

    [Parameter]
    public bool IsEdit { get; set; } = false;

    [Parameter]
    public required Func<Task> SubmitHandler { get; set; }

    [Parameter]
    public RenderFragment? AlertFragmentContent { get; set; }

    private string _title = string.Empty;

    private CultureInfo CultureInfo { get; set; } = new CultureInfo("fr-FR");

    private string? _fileName;

    private long? _fileSize;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _title = $"{(IsEdit ? "Edit" : "New")} Product";
    }

    private void OnCancelClickHandler()
    {
        NavigationManager.NavigateTo(Endpoints.Product.BaseUrl);
    }
}
