using CertificatesModel;
using CertificatesViews.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static CertificatesViews.TreeNodeCollectionExtensions;

namespace CertificatesViews
{
    public static class TreeNodeCollectionExtensions
    { 
        [Serializable]      
        public struct TreeNodeList
        {
            private List<string> uncheckedNodes;
            private List<string> expandedNodes;

            public TreeNode SelectedNode { get; set; }

            public List<string> UncheckedNodes
            {
                get { return uncheckedNodes ?? new List<string>(); }
                set { uncheckedNodes = value; }
            }
            public List<string> ExpandedNodes
            {
                get { return expandedNodes ?? new List<string>(); }
                set { expandedNodes = value; }
            }
        }

        /// <summary>
        /// Получение состояния узлов коллекции
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static TreeNodeList getNodeCollectionState(this TreeNodeCollection nodes)
        {
            TreeNodeList nodeState = new TreeNodeList();

            var uncheckedNodes = nodes.Descendants().Where(n => !n.Checked).Select(n => n.FullPath);
            nodeState.UncheckedNodes = uncheckedNodes.ToList();
            var expandedNodes = nodes.Descendants().Where(n => n.IsExpanded).Select(n => n.FullPath);
            nodeState.ExpandedNodes = expandedNodes.ToList();
            return nodeState;
        }

        /// <summary>
        /// Сохранения состояния узлов коллекции
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="savedState"></param>
        public static void setNodeCollectionState(this TreeNodeCollection nodes, TreeNodeList savedState)
        {
            if (nodes.Count == 0)
                return;

            foreach (var node in nodes.Descendants().Where(n => savedState.ExpandedNodes.Contains(n.FullPath)))
            {
                node.Expand();
            }
            foreach (var node in nodes.Descendants().Where(n => savedState.UncheckedNodes.Contains(n.FullPath)))
            {
                node.Checked = false;
            }
        }

        /// <summary>
        /// Перечисление всех узлов коллекции
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection nodes)
        {
            foreach (var node in nodes.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);
        
        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(this TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

    }

    public static class TreeViewExtensions
    {
        /// <summary>
        /// Добавление списка свидетельств в TreeView
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="certificates"></param>
        public static void AddCertificates(this TreeViewModified treeView, Certificates certificates)
        {
            // Составляем коллекцию  иконок для текущего дерева узлов
            ImageList imageCollection = new ImageList();
            imageCollection.Images.Add("UnselectedFolder", Resources.folder_closed);
            imageCollection.Images.Add("SelectedFolder", Resources.folder_opened);
            imageCollection.Images.Add("Certificate", Resources.certificate);

            // Добавляем коллекцию к текущему дереву
            treeView.ImageList = imageCollection;            

            foreach (var year in certificates)
            {
                TreeNode node = new TreeNode();
                node.Name = year.YearOfCreationCertificate.ToString();
                node.Tag = year;
                node.Text = year.YearOfCreationCertificate.ToString();
                node.ImageKey = "UnselectedFolder";
                node.SelectedImageKey = "SelectedFolder";
                node.Checked = true;                
                
                foreach (var contract in year)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Name = contract.ContractNumber;
                    subNode.Tag = contract;
                    subNode.Text = contract.ContractNumber;
                    subNode.ImageKey = "Certificate";
                    subNode.SelectedImageKey = "Certificate";
                    subNode.Checked = true;

                    foreach (var certificate in contract)
                    {
                        TreeNode subSubNode = new TreeNode();
                        subSubNode.Name = certificate.CertificatePath;
                        subSubNode.Tag = certificate;
                        subSubNode.Text = certificate.CertificatePath;
                        subSubNode.Checked = true;                       

                        subNode.Nodes.Add(subSubNode);
                    }

                    node.Nodes.Add(subNode);
                }

                treeView.Nodes.Add(node);
            }
        }

        public static void SerializeNodeState(this TreeViewModified treeView) // Сериализация TreeView
        {
            TreeNodeList state = treeView.Nodes.getNodeCollectionState();
            state.SelectedNode = treeView.SelectedNode;

            using (Stream file = File.Open("TreeState.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, state);
            }
        }

        public static void DeserializeNodeState(this TreeViewModified treeView) // Десериализация TreeView
        {
            if (!File.Exists("TreeState.dat"))
                return;
            using (Stream file = File.Open("TreeState.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                TreeNodeList state = (TreeNodeList)bf.Deserialize(file);
                treeView.Nodes.setNodeCollectionState(state);
                if (state.SelectedNode != null)
                    treeView.SelectedNode = state.SelectedNode;
            }
        }
    }
}
