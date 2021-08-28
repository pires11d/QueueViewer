namespace System.Windows.Forms
{
    public static class WindowsFormsExtensions
    {
        public static TreeNode GetNode(this TreeNode rootNode, string name)
        {
            if (rootNode != null)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Name == name)
                        return node;
                }
            }
            return null;
        }
    }
}
