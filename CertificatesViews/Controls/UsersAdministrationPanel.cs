using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Factories;
using CertificatesModel.Interfaces;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class UsersAdministrationPanel : UserControl, IView<Users>
    {
        Users _usersList;

        public UsersAdministrationPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(Users obj)
        {
            ParentForm.Icon = Properties.Resources.Delicious;
            ParentForm.Text = "Администрирование пользователей";
            ParentForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            _usersList = obj;

            dgvUsers.DataSource = _usersList;
            
            dgvUsers.ReadOnly = true;
            dgvUsers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        // Удаление пользователя 
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count != 0)
            {
                var arrayId = new List<int>();
                foreach (DataGridViewRow row in dgvUsers.SelectedRows)
                {
                    arrayId.Add((int)row.Cells[0].Value);
                }
                var model = AppLocator.ModelFactory.Create<IUsersLoader>();
                model.DeleteUsers(arrayId.ToArray());
            }
        }

        // Добавление нового пользователя
        private void btAdd_Click(object sender, EventArgs e)
        {
            var form = new UserEditForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            User newUser = new User()
            {
                Login = form.UserLogin,
                UserRights = form.UserAccessRights
            };

            var model = AppLocator.ModelFactory.Create<IUsersLoader>();
            model.AddNewUser(newUser);
        }

        // Изменение учетных данных пользователя
        private void btEditUser_Click(object sender, EventArgs e)
        {
            var form = new UserEditForm();
            form.Text = "Редактирование пользователя";
            form.UserLogin = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
            form.UserAccessRights = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
            form.OkButton.Text = "Изменить";

            var result = form.ShowDialog();            
            if (result == DialogResult.Cancel)
                return;

            var model = AppLocator.ModelFactory.Create<IUsersLoader>();
            int id = (int)dgvUsers.SelectedRows[0].Cells[0].Value;

            var user = new User()
            {
                Id = (int)dgvUsers.SelectedRows[0].Cells[0].Value,
                Login = form.UserLogin,
                UserRights = form.UserAccessRights
            };

            model.EditUserData(user);
            dgvUsers.Refresh();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 1)
                btEditUser.Enabled = true;
            else
                btEditUser.Enabled = false;
        }
    }
}
