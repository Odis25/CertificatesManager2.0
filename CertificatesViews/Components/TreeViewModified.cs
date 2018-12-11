using CertificatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews
{
    public class TreeViewModified: TreeView
    {
        public TreeViewModified()
        {
            
        }       
    }

    public static class Extensions
    {
        public static void AddCertificates(this TreeViewModified treeView, Certificates certificates)
        {
            //certificates.Sort();
            foreach (var year in certificates)
            {
                TreeNode node = new TreeNode();
                node.Name = year.YearOfCreationCertificate.ToString();
                node.Text = year.YearOfCreationCertificate.ToString();

                foreach (var contract in year)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Name = contract.ContractNumber;
                    subNode.Text = contract.ContractNumber;
                    foreach (var certificate in contract)
                    {
                        TreeNode subSubNode = new TreeNode();
                        subSubNode.Name = certificate.CertificatePath;
                        subSubNode.Text = certificate.CertificatePath;

                        subNode.Nodes.Add(subSubNode);
                    }

                    node.Nodes.Add(subNode);
                }

                treeView.Nodes.Add(node);
                
            }
        }
    }
}
