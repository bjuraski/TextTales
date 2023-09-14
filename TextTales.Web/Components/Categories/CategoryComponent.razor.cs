using Microsoft.AspNetCore.Components;
using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Components.Categories;

public partial class CategoryComponent : ComponentBase
{
    [Inject]
    public required ICategoryService CategoryService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Parameter]
    public long? Id { get; set; }

    [Parameter]
    public Category Model { get; set; } = new();

    [Parameter]
    public bool IsEdit { get; set; } = false;

    [Parameter]
    public required Func<Task> SubmitHandler { get; set; }

    [Parameter]
    public RenderFragment? AlertFragmentContent { get; set; }

    private string _title = string.Empty;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _title = $"{(IsEdit ? "Edit" : "New")} Category";
    }

    private void OnCancelClickHandler()
    {
        NavigationManager.NavigateTo(Endpoints.Category.BaseUrl);
    }
}
