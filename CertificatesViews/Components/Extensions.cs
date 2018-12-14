using CertificatesModel;
using CertificatesViews.Properties;
using System.Windows.Forms;

namespace CertificatesViews
{
    public static class Extensions
    {
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

                foreach (var contract in year)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Name = contract.ContractNumber;
                    subNode.Tag = contract;
                    subNode.Text = contract.ContractNumber;
                    subNode.ImageKey = "Certificate";
                    subNode.SelectedImageKey = "Certificate";

                    foreach (var certificate in contract)
                    {
                        TreeNode subSubNode = new TreeNode();
                        subSubNode.Name = certificate.CertificatePath;
                        subSubNode.Tag = certificate;
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
