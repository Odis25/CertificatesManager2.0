using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class UserEditForm : Form
    {
        public event EventHandler Changed = delegate { };

        public Button OkButton
        {
            get { return btAdd; }
            set { btAdd = value; }
        }

        // Логин пользователя
        public string UserLogin
        {
            get { return tbUserLogin.Text; }
            set { tbUserLogin.Text = value; }
        }

        // Уровень доступа пользователя
        public string UserAccessRights
        {
            get
            {
                switch (cbUserAccessRights.SelectedIndex)
                {
                    case 0:
                        return "User";
                    case 1:
                        return "Metrolog";
                    case 2:
                        return "Administrator";
                    default:
                        return "User";
                }
            }
            set
            {
                switch (value.ToLower())
                {
                    case "user":
                        cbUserAccessRights.SelectedIndex = 0;
                        break;
                    case "metrolog":
                        cbUserAccessRights.SelectedIndex = 1;
                        break;
                    case "administrator":
                        cbUserAccessRights.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
            }
        }

        public UserEditForm()
        {
            InitializeComponent();
        }
    }
}
