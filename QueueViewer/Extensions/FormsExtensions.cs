namespace System.Windows.Forms
{
    public static class WindowsFormsExtensions
    {
        public static TreeNode GetNode(this TreeNode rootNode, string name)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Text == name)
                    return node;
            }
            return null;
        }
    }
}
