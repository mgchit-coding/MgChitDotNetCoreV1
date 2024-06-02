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
        public FrmBlog(int id)
        {
            InitializeComponent();
            _db = new AppDbContext();
            var blog = _db.Blog.FirstOrDefault(x => x.BlogId == id);
            txtAuthor.Text = blog.BlogAuthor;
            txtContent.Text = blog.BlogContent;
            txtTitle.Text = blog.BlogTitle;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var model = new BlogDataModel
            {
                BlogAuthor = txtAuthor.Text,
                BlogContent = txtContent.Text,
                BlogTitle = txtTitle.Text,
            };
            _db.Blog.Update(model);
            var result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            if (result > 0)
                ClearControls();
            this.Close();
        }
    }
}
