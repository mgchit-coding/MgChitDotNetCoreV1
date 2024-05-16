using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared.Services;

namespace MgChitDotNetCore.WindowForm
{
    public partial class FrmBlog : Form
    {
        private readonly AppDbContext _db;
        public FrmBlog()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new BlogDataModel
            {
                BlogAuthor = txtAuthor.Text,
                BlogContent = txtContent.Text,
                BlogTitle = txtTitle.Text,
            };
            _db.Blog.Add(model);
            var result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            if (result > 0)
                ClearControls();
        }
    }
}
