using OzonProductsApi.Application.OzonApiClient.Models.Response;

namespace OzonProductsApi.Application.CategoryTreeService;

public class CategoryTreeManager
{
    private readonly Dictionary<long, List<CategoryNode>> _typeIdPaths = new();
    private readonly Dictionary<string, List<CategoryNode>> _typeNamePaths = new();

    public CategoryTreeManager(List<CategoryNode> categories)
    {
        foreach (var root in categories)
        {
            BuildPaths(root, new List<CategoryNode>());
        }
    }

    private void BuildPaths(CategoryNode node, List<CategoryNode> path)
    {
        var newPath = new List<CategoryNode>(path) { node };

        if (node.TypeId.HasValue)
        {
            _typeIdPaths[node.TypeId.Value] = newPath;
        }

        if (!string.IsNullOrEmpty(node.TypeName))
        {
            _typeNamePaths[node.TypeName] = newPath;
        }

        foreach (var child in node.Children)
        {
            BuildPaths(child, newPath);
        }
    }

    public CategoryNode? FindByTypeId(long typeId)
    {
        return _typeIdPaths.TryGetValue(typeId, out var path) ? BuildTree(path) : null;
    }

    public CategoryNode? FindByTypeName(string typeName)
    {
        return _typeNamePaths.TryGetValue(typeName, out var path) ? BuildTree(path) : null;
    }

    private CategoryNode BuildTree(List<CategoryNode> path)
    {
        CategoryNode? root = null;
        CategoryNode? current = null;

        foreach (var node in path)
        {
            var newNode = new CategoryNode
            {
                Id = node.Id,
                Name = node.Name,
                Disabled = node.Disabled,
                TypeId = node.TypeId,
                TypeName = node.TypeName,
                Children = new List<CategoryNode>()
            };

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                current!.Children.Add(newNode);
            }

            current = newNode;
        }

        return root!;
    }
}