using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

static void PrintRecursive(Tree.Node node)
{
    if (node.Parent is null)
        Console.WriteLine($"{node.Reference.name};");
    else
        Console.WriteLine($"{node.Reference.parent} -- {node.Reference.name};");

    Console.WriteLine($"subgraph cluster_{node.Reference.name}");
    Console.WriteLine("{");
    foreach (var child in node.Children)
        PrintRecursive(child);
    Console.WriteLine("}");
}

using (var streamReader = new FileStream("../../../../TppClassGeneration/TppClassDefinitions.json", FileMode.Open))
{
    // Deserialize
    JsonDocumentOptions options = new JsonDocumentOptions {  CommentHandling = JsonCommentHandling.Skip };
    JsonDocument document = JsonDocument.Parse(streamReader, options)!;
    List<Class> classes = (from serializedClass in document.RootElement.EnumerateArray() select serializedClass.Deserialize<Class>()!).ToList();

    // Build tree
    Tree tree = new Tree { Root = new Tree.Node { Parent = null, Children = new List<Tree.Node>(), Reference = null }, FullRegistry = new Dictionary<string, Tree.Node>() };
    foreach (var @class in classes)
    {
        if (@class.parent == null)
        {
            var node = new Tree.Node { Parent = null, Children = new List<Tree.Node>(), Reference = @class };
            tree.Root.Children.Add(node);
            tree.FullRegistry.Add(@class.name, node);
        }
    }
    do
    {
        foreach (var @class in classes)
        {
            Tree.Node parent;
            if (@class.parent != null && tree.FullRegistry.TryGetValue(@class.parent, out parent))
            {
                var node = new Tree.Node { Parent = parent, Children = new List<Tree.Node>(), Reference = @class };
                parent.Children.Add(node);
                tree.FullRegistry.Add(@class.name, node);
            }
        }

        continue;
    } while (tree.FullRegistry.Count < classes.Count);

    foreach (var topLevelNode in tree.Root.Children)
        PrintRecursive(topLevelNode);

    Console.ReadKey();
}

public class Tree
{
    public class Node
    {
        public Class Reference;
        public Node Parent;
        public List<Node> Children;
    }

    public Node Root;

    public Dictionary<string, Node> FullRegistry;
};