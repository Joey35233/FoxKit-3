using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

void RecurseTree(Tree.Node node)
{
    Console.WriteLine($"{node.Reference.parent} -- {node.Reference.name};");
    if (node.Children.Count > 0)
    {
        Console.WriteLine($"subgraph cluster_{node.Reference.name}");
        Console.WriteLine("{");
        foreach (var child in node.Children)
            RecurseTree(child);
        Console.WriteLine("}");
    }
}

using (var streamReader = new FileStream("../../../../TppClassGeneration/TppClassDefinitions.json", FileMode.Open))
{
    // Deserialize
    JsonDocumentOptions options = new JsonDocumentOptions {  CommentHandling = JsonCommentHandling.Skip };
    JsonDocument document = JsonDocument.Parse(streamReader, options)!;
    List<Class> classes = (from serializedClass in document.RootElement.EnumerateArray() select serializedClass.Deserialize<Class>()!).ToList();

    // Build tree
    Tree tree = new Tree { Children = new List<Tree.Node>(), FullRegistry = new Dictionary<string, Tree.Node>() };
    foreach (var @class in classes)
    {
        if (@class.parent == null)
        {
            var node = new Tree.Node { Parent = null, Children = new List<Tree.Node>(), Reference = @class };
            tree.Children.Add(node);
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

    foreach (var topChild in tree.Children)
        foreach (var child in topChild.Children)
            RecurseTree(child);

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

    public List<Node> Children;

    public Dictionary<string, Node> FullRegistry;
};